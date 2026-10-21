using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
#if NET35
using System.Reflection;
#else
using System.Net.Http;
#endif

namespace Twilio.Http
{
    /// <summary>
    /// Refuses TLS connections whose certificate chain contains one of eight intermediate certificates that are no
    /// longer trustworthy.
    /// </summary>
    /// <remarks>
    /// The private keys of these intermediates are weak, so anyone can use them to issue a certificate that a
    /// default trust store accepts. This is the same list Go distrusts as of Go 1.27.3 and 1.26.10
    /// (CVE-2026-111943, golang/go#82345). Each certificate is identified by the SHA-256 hash of its DER-encoded
    /// SubjectPublicKeyInfo.
    ///
    /// The SDK's default HTTP clients apply this check. A client built from your own System.Net.Http.HttpClient
    /// doesn't; to opt in, build it with <c>CreateHttpClientHandler()</c>, which every build except .NET Framework
    /// 3.5 has:
    /// <code>
    /// var httpClient = new System.Net.Http.HttpClient(DistrustedIntermediates.CreateHttpClientHandler());
    /// var twilioClient = new TwilioRestClient(accountSid, authToken, httpClient: new SystemNetHttpClient(httpClient));
    /// </code>
    ///
    /// On the .NET Framework 3.5 runtime, HttpWebRequest has no per-request certificate callback, so the SDK can't
    /// apply the check. To opt in there, use <c>ValidateServerCertificate</c> as the app-wide callback:
    /// <code>
    /// ServicePointManager.ServerCertificateValidationCallback = DistrustedIntermediates.ValidateServerCertificate;
    /// </code>
    /// </remarks>
    public static class DistrustedIntermediates
    {
        // Copied from Go commit 7f86f957633ee31a1c17a1eb8452ca7a3d9bc141 (src/crypto/x509/verify.go).
        internal static readonly ICollection<string> DistrustedSpkiSha256 = new HashSet<string>(StringComparer.Ordinal)
        {
            "ebed6475c2c2d80fcb199f3fe8dd6e6b3ce60b77eb15d4e42c3dec0c6f5b5105",
            "49dd353dc2b919a3770645117d0e60c16115e7d1bc259eefe734b00ea434fe5f",
            "e0254c7fcdc265e2f0f8a428dabb75ab4ae039b4872d62f5ee57f0877d5a8a41",
            "5c0660a2b164910d8ff589c18e14552e9e0ec237dcefe2cb736d41a4811f81a0",
            "43bffa19d6ef651451f6841e019931e96f6f2eaeff28ab4b6f1ce4576de2717b",
            "63ecefee431d49523bc1136c4e72d0206a477086caf606cd5cf025686c109cf8",
            "ec4ffa1ad0ac88081314b7aaffef6a91f97cd57291bb5ba686c5415f5eb4f6b6",
            "92c063d67e8f14db71d288e11266ffdaf69cbf115f7bab14f3bc2f68d25e0e30"
        };

        // Decides whether the platform's own validation passed, before the distrust check runs.
        internal delegate bool BaseValidation(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors);

#if !NET35
        /// <summary>
        /// Create an HttpClientHandler with the platform's default settings, plus the distrust check.
        /// </summary>
        /// <returns>a handler that refuses distrusted intermediates</returns>
        public static HttpClientHandler CreateHttpClientHandler()
        {
            return CreateHttpClientHandler(DistrustedSpkiSha256, DefaultValidation);
        }

        // The handler the SDK's default clients use.
        internal static HttpClientHandler CreateDefaultHandler()
        {
            var handler = CreateHttpClientHandler();
            handler.AllowAutoRedirect = false;
            return handler;
        }

        internal static HttpClientHandler CreateHttpClientHandler(ICollection<string> distrusted,
            BaseValidation baseValidation)
        {
#if NET462
            // HttpClientHandler has no certificate callback before .NET Framework 4.7.1. WebRequestHandler is the
            // HttpWebRequest-based handler that HttpClientHandler already uses on .NET Framework.
            var handler = new WebRequestHandler();
            handler.ServerCertificateValidationCallback = (sender, certificate, chain, errors) =>
                Validate(sender, certificate, chain, errors, distrusted, baseValidation);
            return handler;
#else
            var handler = new HttpClientHandler();
            try
            {
                handler.ServerCertificateCustomValidationCallback = (message, certificate, chain, errors) =>
                    Validate(message, certificate, chain, errors, distrusted, baseValidation);
            }
            catch (PlatformNotSupportedException)
            {
                // Platforms such as Blazor WebAssembly don't support the callback; keep their default validation.
            }
            catch (NotImplementedException)
            {
                // Some Mono-based platforms, such as older Unity versions, throw this instead.
            }
            return handler;
#endif
        }
#else
        // HttpWebRequest.ServerCertificateValidationCallback exists from .NET Framework 4.5 on, which is the runtime
        // most apps that load this net35 build run on. On a .NET Framework 3.5 runtime it's missing, and requests
        // keep their default validation.
        private static readonly PropertyInfo RequestCallbackProperty =
            typeof(HttpWebRequest).GetProperty("ServerCertificateValidationCallback");

        internal static void Apply(HttpWebRequest request)
        {
            Apply(request, DistrustedSpkiSha256, DefaultValidation);
        }

        internal static void Apply(HttpWebRequest request, ICollection<string> distrusted, BaseValidation baseValidation)
        {
            if (RequestCallbackProperty == null)
            {
                return;
            }
            RemoteCertificateValidationCallback callback = (sender, certificate, chain, errors) =>
                Validate(sender, certificate, chain, errors, distrusted, baseValidation);
            RequestCallbackProperty.SetValue(request, callback, null);
        }

        /// <summary>
        /// A ServicePointManager.ServerCertificateValidationCallback that accepts only certificates the system trusts,
        /// and refuses distrusted intermediates.
        /// </summary>
        /// <remarks>
        /// For apps on the .NET Framework 3.5 runtime, where the SDK can't apply the check per request. It applies to
        /// every HttpWebRequest in the app, not just the SDK's; to keep a callback of your own, call this from it.
        /// </remarks>
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors)
        {
            // Not DefaultValidation: it calls the ServicePointManager callback, which may be this method.
            return errors == SslPolicyErrors.None && !ContainsDistrusted(certificate, chain, DistrustedSpkiSha256);
        }
#endif

        // A handler or request callback replaces the platform's default validation, so reproduce it: the system's
        // verdict, or ServicePointManager.ServerCertificateValidationCallback on HttpWebRequest-based stacks,
        // where the app may have set one and a per-handler callback would otherwise bypass it.
        internal static bool DefaultValidation(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors)
        {
#if !NET8_0_OR_GREATER
            if (HonorsServicePointManager)
            {
                var callback = ServicePointManager.ServerCertificateValidationCallback;
                if (callback != null)
                {
                    return callback(sender, certificate, chain, errors);
                }
            }
#endif
            return errors == SslPolicyErrors.None;
        }

#if !NET8_0_OR_GREATER
#if NET35 || NET462
        private static readonly bool HonorsServicePointManager = true;
#else
        // HttpClientHandler is HttpWebRequest-based on Mono, but not on .NET Core.
        private static readonly bool HonorsServicePointManager = Type.GetType("Mono.Runtime") != null;
#endif
#endif

        private static bool Validate(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors, ICollection<string> distrusted, BaseValidation baseValidation)
        {
            return baseValidation(sender, certificate, chain, errors)
                && !ContainsDistrusted(certificate, chain, distrusted);
        }

        // Checks the chain the platform built, like Go, plus the server's certificate in case there's no chain.
        internal static bool ContainsDistrusted(X509Certificate certificate, X509Chain chain,
            ICollection<string> distrusted)
        {
            if (certificate != null && distrusted.Contains(SpkiSha256Hex(certificate.GetRawCertData())))
            {
                return true;
            }
            if (chain != null)
            {
                foreach (var element in chain.ChainElements)
                {
                    if (distrusted.Contains(SpkiSha256Hex(element.Certificate.RawData)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Go hashes the SubjectPublicKeyInfo bytes exactly as they appear in the certificate, so read them from the
        // DER rather than re-encoding the public key. Returns an empty string for a certificate it can't parse,
        // which the platform has already parsed, so that shouldn't happen.
        internal static string SpkiSha256Hex(byte[] certificateDer)
        {
            byte[] spki;
            try
            {
                spki = SubjectPublicKeyInfo(certificateDer);
            }
            catch (ArgumentException)
            {
                return "";
            }
            byte[] digest;
            using (var sha256 = SHA256.Create())
            {
                digest = sha256.ComputeHash(spki);
            }
            return BitConverter.ToString(digest).Replace("-", "").ToLowerInvariant();
        }

        // Certificate ::= SEQUENCE { tbsCertificate, signatureAlgorithm, signatureValue }
        // TBSCertificate ::= SEQUENCE { version [0] EXPLICIT OPTIONAL, serialNumber, signature, issuer, validity,
        //                               subject, subjectPublicKeyInfo, ... }
        internal static byte[] SubjectPublicKeyInfo(byte[] der)
        {
            int length;
            var offset = ReadHeader(der, 0, 0x30, out length);
            offset = ReadHeader(der, offset, 0x30, out length);
            if (offset < der.Length && der[offset] == 0xa0)
            {
                offset = Skip(der, offset);
            }
            for (var i = 0; i < 5; i++)
            {
                offset = Skip(der, offset);
            }
            var contentOffset = ReadHeader(der, offset, 0x30, out length);
            var spki = new byte[contentOffset + length - offset];
            Array.Copy(der, offset, spki, 0, spki.Length);
            return spki;
        }

        private static int Skip(byte[] der, int offset)
        {
            int length;
            var contentOffset = ReadHeader(der, offset, -1, out length);
            return contentOffset + length;
        }

        // Returns the content offset of the DER element at offset. expectedTag is -1 to accept any tag.
        private static int ReadHeader(byte[] der, int offset, int expectedTag, out int length)
        {
            if (offset + 2 > der.Length)
            {
                throw new ArgumentException("Truncated DER element");
            }
            var tag = der[offset];
            if ((tag & 0x1f) == 0x1f || (expectedTag != -1 && tag != expectedTag))
            {
                throw new ArgumentException("Unexpected DER tag " + tag);
            }
            length = der[offset + 1];
            var contentOffset = offset + 2;
            if (length >= 0x80)
            {
                var lengthBytes = length & 0x7f;
                if (lengthBytes == 0 || lengthBytes > 3 || contentOffset + lengthBytes > der.Length)
                {
                    throw new ArgumentException("Unsupported DER length");
                }
                length = 0;
                for (var i = 0; i < lengthBytes; i++)
                {
                    length = (length << 8) | der[contentOffset++];
                }
            }
            if (contentOffset + length > der.Length)
            {
                throw new ArgumentException("Truncated DER element");
            }
            return contentOffset;
        }
    }
}
