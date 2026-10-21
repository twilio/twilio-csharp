using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Twilio.Http;

namespace Twilio.Tests.Http
{
    [TestFixture]
    public class DistrustedIntermediatesTest
    {
        private X509Certificate2 _root;
        private X509Certificate2 _intermediate;
        private X509Certificate2 _leaf;
        private X509Certificate2 _otherHostLeaf;
        private TlsServer _server;

        [OneTimeSetUp]
        public void CreateChain()
        {
            var now = DateTimeOffset.UtcNow;
            using (var rootKey = RSA.Create(2048))
            using (var intermediateKey = RSA.Create(2048))
            {
                var rootRequest = CaRequest("CN=Distrust Test Root", rootKey);
                _root = rootRequest.CreateSelfSigned(now.AddHours(-1), now.AddDays(1));

                var intermediateRequest = CaRequest("CN=Distrust Test Intermediate", intermediateKey);
                _intermediate = intermediateRequest.Create(_root, now.AddHours(-1), now.AddDays(1), new byte[] { 2 })
                    .CopyWithPrivateKey(intermediateKey);

                var leafNames = new SubjectAlternativeNameBuilder();
                leafNames.AddIpAddress(IPAddress.Loopback);
                _leaf = IssueLeaf("CN=127.0.0.1", leafNames, 3);

                var otherHostNames = new SubjectAlternativeNameBuilder();
                otherHostNames.AddDnsName("example.com");
                _otherHostLeaf = IssueLeaf("CN=example.com", otherHostNames, 4);
            }
        }

        private X509Certificate2 IssueLeaf(string subject, SubjectAlternativeNameBuilder names, byte serial)
        {
            var now = DateTimeOffset.UtcNow;
            using (var key = RSA.Create(2048))
            {
                var request = new CertificateRequest(subject, key, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                request.CertificateExtensions.Add(names.Build());
                request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(
                    new OidCollection { new Oid("1.3.6.1.5.5.7.3.1") }, false));
                var leaf = request.Create(_intermediate, now.AddHours(-1), now.AddDays(1), new[] { serial })
                    .CopyWithPrivateKey(key);
                // SslStream on macOS needs the key in a keychain-backed certificate, so round-trip through PKCS#12.
                return new X509Certificate2(leaf.Export(X509ContentType.Pkcs12), (string)null,
                    X509KeyStorageFlags.Exportable);
            }
        }

        [SetUp]
        public void StartServer()
        {
            _server = new TlsServer(_leaf, _intermediate);
        }

        [TearDown]
        public void StopServer()
        {
            _server.Dispose();
        }

        private static CertificateRequest CaRequest(string subject, RSA key)
        {
            var request = new CertificateRequest(subject, key, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
            request.CertificateExtensions.Add(new X509KeyUsageExtension(
                X509KeyUsageFlags.KeyCertSign | X509KeyUsageFlags.CrlSign, true));
            return request;
        }

        private static string Hash(X509Certificate2 certificate)
        {
            return DistrustedIntermediates.SpkiSha256Hex(certificate.RawData);
        }

        // The SDK's default validation, with the test root trusted: chain errors are cleared only when the chain
        // leads to the test root, and every other error (such as a hostname mismatch) still goes to DefaultValidation.
        private bool TrustTestRoot(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if ((errors & SslPolicyErrors.RemoteCertificateChainErrors) != 0 && ChainsToTestRoot(certificate))
            {
                errors &= ~SslPolicyErrors.RemoteCertificateChainErrors;
            }
            return DistrustedIntermediates.DefaultValidation(sender, certificate, chain, errors);
        }

        private bool ChainsToTestRoot(X509Certificate certificate)
        {
            using (var custom = new X509Chain())
            {
                custom.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
                custom.ChainPolicy.CustomTrustStore.Add(_root);
                custom.ChainPolicy.ExtraStore.Add(_intermediate);
                custom.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                return custom.Build(new X509Certificate2(certificate));
            }
        }

        private HttpStatusCode Get(HttpClientHandler handler)
        {
            return Get(handler, _server);
        }

        private static HttpStatusCode Get(HttpClientHandler handler, TlsServer server)
        {
            using (var client = new System.Net.Http.HttpClient(handler))
            {
                return client.GetAsync(server.Url).GetAwaiter().GetResult().StatusCode;
            }
        }

        [Test]
        public void TestCleanChainConnects()
        {
            var handler = DistrustedIntermediates.CreateHttpClientHandler(
                DistrustedIntermediates.DistrustedSpkiSha256, TrustTestRoot);

            Assert.AreEqual(HttpStatusCode.OK, Get(handler));
            Assert.AreEqual(1, _server.RequestCount);
        }

        [Test]
        public void TestDistrustedIntermediateIsRefused()
        {
            var distrusted = new HashSet<string>(DistrustedIntermediates.DistrustedSpkiSha256) { Hash(_intermediate) };
            var handler = DistrustedIntermediates.CreateHttpClientHandler(distrusted, TrustTestRoot);

            Assert.Throws<HttpRequestException>(() => Get(handler));
            Assert.AreEqual(0, _server.RequestCount, "the request must not reach the server");
        }

        [Test]
        public void TestDistrustedLeafIsRefused()
        {
            var distrusted = new HashSet<string> { Hash(_leaf) };
            var handler = DistrustedIntermediates.CreateHttpClientHandler(distrusted, TrustTestRoot);

            Assert.Throws<HttpRequestException>(() => Get(handler));
            Assert.AreEqual(0, _server.RequestCount);
        }

        // The handler's callback replaces the platform's validation, so check it kept hostname verification: a trusted,
        // non-distrusted chain issued for another host must still be refused.
        [Test]
        public void TestHostnameMismatchIsRejected()
        {
            var handler = DistrustedIntermediates.CreateHttpClientHandler(
                DistrustedIntermediates.DistrustedSpkiSha256, TrustTestRoot);

            using (var otherHost = new TlsServer(_otherHostLeaf, _intermediate))
            {
                Assert.Throws<HttpRequestException>(() => Get(handler, otherHost));
                Assert.AreEqual(0, otherHost.RequestCount, "the request must not reach the server");
            }
        }

        [Test]
        public void TestPublicHandlerKeepsPlatformValidation()
        {
            // The test root isn't in the system trust store, so the default validation must still refuse it.
            Assert.Throws<HttpRequestException>(() => Get(DistrustedIntermediates.CreateHttpClientHandler()));
            Assert.AreEqual(0, _server.RequestCount);
        }

        [Test]
        public void TestDefaultHandler()
        {
            var handler = DistrustedIntermediates.CreateDefaultHandler();

            Assert.IsFalse(handler.AllowAutoRedirect);
            Assert.IsNotNull(handler.ServerCertificateCustomValidationCallback);
        }

        [Test]
        public void TestContainsDistrustedChecksBuiltChain()
        {
            using (var chain = new X509Chain())
            {
                chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
                chain.ChainPolicy.CustomTrustStore.Add(_root);
                chain.ChainPolicy.ExtraStore.Add(_intermediate);
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                Assert.IsTrue(chain.Build(_leaf));

                Assert.IsFalse(DistrustedIntermediates.ContainsDistrusted(_leaf, chain,
                    DistrustedIntermediates.DistrustedSpkiSha256));
                Assert.IsTrue(DistrustedIntermediates.ContainsDistrusted(_leaf, chain,
                    new HashSet<string> { Hash(_intermediate) }));
                Assert.IsTrue(DistrustedIntermediates.ContainsDistrusted(_leaf, chain,
                    new HashSet<string> { Hash(_root) }));
            }
        }

        [Test]
        public void TestSpkiHashMatchesEncodedPublicKey()
        {
            using (var ecKey = ECDsa.Create(ECCurve.NamedCurves.nistP256))
            {
                var now = DateTimeOffset.UtcNow;
                var ecCertificate = new CertificateRequest("CN=ec", ecKey, HashAlgorithmName.SHA256)
                    .CreateSelfSigned(now.AddHours(-1), now.AddDays(1));
                foreach (var certificate in new[] { _root, _intermediate, _leaf, ecCertificate })
                {
                    var expected = Convert.ToHexString(
                        SHA256.HashData(certificate.PublicKey.ExportSubjectPublicKeyInfo())).ToLowerInvariant();
                    Assert.AreEqual(expected, Hash(certificate), certificate.Subject);
                }
            }
        }

        [Test]
        public void TestUnparseableCertificateIsNotDistrusted()
        {
            Assert.AreEqual("", DistrustedIntermediates.SpkiSha256Hex(new byte[] { 0x30, 0x05, 0x01 }));
        }

        [Test]
        public void TestDistrustedList()
        {
            Assert.AreEqual(8, DistrustedIntermediates.DistrustedSpkiSha256.Count);
            Assert.IsTrue(DistrustedIntermediates.DistrustedSpkiSha256.All(
                h => h.Length == 64 && h.All(c => "0123456789abcdef".IndexOf(c) >= 0)));
        }

        // A minimal HTTPS server on 127.0.0.1 that sends the leaf and intermediate, and counts requests it receives.
        private sealed class TlsServer : IDisposable
        {
            private readonly TcpListener _listener;
            private readonly SslStreamCertificateContext _context;
            private int _requestCount;

            public TlsServer(X509Certificate2 leaf, X509Certificate2 intermediate)
            {
                _context = SslStreamCertificateContext.Create(leaf, new X509Certificate2Collection(intermediate),
                    offline: true);
                _listener = new TcpListener(IPAddress.Loopback, 0);
                _listener.Start();
                Url = "https://127.0.0.1:" + ((IPEndPoint)_listener.LocalEndpoint).Port + "/";
                Task.Run(AcceptLoop);
            }

            public string Url { get; }

            public int RequestCount => Volatile.Read(ref _requestCount);

            private async Task AcceptLoop()
            {
                while (true)
                {
                    TcpClient client;
                    try
                    {
                        client = await _listener.AcceptTcpClientAsync();
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    _ = Task.Run(() => Serve(client));
                }
            }

            private async Task Serve(TcpClient client)
            {
                using (client)
                using (var tls = new SslStream(client.GetStream()))
                {
                    try
                    {
                        await tls.AuthenticateAsServerAsync(new SslServerAuthenticationOptions
                        {
                            ServerCertificateContext = _context
                        });
                        var buffer = new byte[4096];
                        var received = new StringBuilder();
                        while (!received.ToString().Contains("\r\n\r\n"))
                        {
                            var read = await tls.ReadAsync(buffer, 0, buffer.Length);
                            if (read == 0)
                            {
                                return;
                            }
                            received.Append(Encoding.ASCII.GetString(buffer, 0, read));
                        }
                        Interlocked.Increment(ref _requestCount);
                        var response = Encoding.ASCII.GetBytes(
                            "HTTP/1.1 200 OK\r\nContent-Length: 2\r\nConnection: close\r\n\r\nok");
                        await tls.WriteAsync(response, 0, response.Length);
                    }
                    catch (Exception)
                    {
                        // The client refused the handshake.
                    }
                }
            }

            public void Dispose()
            {
                _listener.Stop();
            }
        }
    }
}
