using System;
using System.Net;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Clients
{
    [TestFixture]
    public class TwilioRestClientTest
    {
        HttpClient client;

        [SetUp]
        public void Init()
        {
            client = Substitute.For<HttpClient>();
        }

        [Test]
        public void TestValidSslCert()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            TwilioRestClient.ValidateSslCertificate(client);
        }

        [Test]
        public void TestCantConnect()
        {
            // Exception type doesn't matter, just needs to match in IsInstanceOf below.
            client.MakeRequest(Arg.Any<Request>()).Throws(new InvalidOperationException());

            try {
                TwilioRestClient.ValidateSslCertificate(client);
                Assert.Fail("Should have failed ssl verification");
            } catch (CertificateValidationException e) {
                Assert.IsInstanceOf(typeof(InvalidOperationException), e.GetBaseException());
                Assert.AreEqual("Connection to api.twilio.com:8443 failed", e.Message);
                Assert.IsNull(e.Response);
                Assert.IsNotNull(e.Request);
            } catch (Exception) {
                Assert.Fail("Threw an unknown exception");
            }
        }

        [Test]
        public void TestNotOkResponse()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.SwitchingProtocols, "NOTOK"));

            try {
                TwilioRestClient.ValidateSslCertificate(client);
                Assert.Fail("Should have failed ssl verification");
            } catch (CertificateValidationException e) {
                Assert.AreEqual("Unexpected response from certificate endpoint", e.Message);
                Assert.IsNotNull(e.Response);
                Assert.IsNotNull(e.Request);
            } catch (Exception) {
                Assert.Fail("Threw an unknown exception");
            }
        }
    }
}
