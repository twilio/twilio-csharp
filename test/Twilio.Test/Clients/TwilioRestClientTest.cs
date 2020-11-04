using System;
using System.Net;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using System.IO;

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

            try
            {
                TwilioRestClient.ValidateSslCertificate(client);
                Assert.Fail("Should have failed ssl verification");
            }
            catch (CertificateValidationException e)
            {
                Assert.IsInstanceOf(typeof(InvalidOperationException), e.GetBaseException());
                Assert.AreEqual("Connection to api.twilio.com:8443 failed", e.Message);
                Assert.IsNull(e.Response);
                Assert.IsNotNull(e.Request);
            }
            catch (Exception)
            {
                Assert.Fail("Threw an unknown exception");
            }
        }

        [Test]
        public void TestNotOkResponse()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.SwitchingProtocols, "NOTOK"));

            try
            {
                TwilioRestClient.ValidateSslCertificate(client);
                Assert.Fail("Should have failed ssl verification");
            }
            catch (CertificateValidationException e)
            {
                Assert.AreEqual("Unexpected response from certificate endpoint", e.Message);
                Assert.IsNotNull(e.Response);
                Assert.IsNotNull(e.Request);
            }
            catch (Exception)
            {
                Assert.Fail("Threw an unknown exception");
            }
        }

        [Test]
        public void TestBadResponseWithDetails()
        {
            string jsonResponse = @"{
                                    ""code"": 20001,
                                    ""message"": ""Bad request"",
                                    ""more_info"": ""https://www.twilio.com/docs/errors/20001"",
                                    ""status"": 400,
                                    ""details"": {
                                        ""foo"": ""bar""
                                    }}";
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.BadRequest, jsonResponse));
            try
            {
                Request request = new Request(HttpMethod.Get, "https://www.contoso.com");
                TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", null, null, client);
                twilioClient.Request(request);
                Assert.Fail("Should have failed");
            }
            catch (ApiException e)
            {
                Assert.AreEqual("Bad request", e.Message);
                Assert.AreEqual(20001, e.Code);
                Assert.AreEqual("https://www.twilio.com/docs/errors/20001", e.MoreInfo);
                Assert.AreEqual(400, e.Status);
                var expectedDetails = new Dictionary<string, object>();
                expectedDetails.Add("foo", "bar");
                Assert.AreEqual(expectedDetails, e.Details);
            }
        }

        [Test]
        public void TestRedirectResponse()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.RedirectKeepVerb, "REDIRECT"));
            Request request = new Request(HttpMethod.Get, "https://www.contoso.com");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", null, null, client);
            twilioClient.Request(request);
        }

        [Test]
        public void TestActivatingDebugLogging()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://www.contoso.com");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", null, null, client);
            twilioClient.LogLevel = "debug";
            twilioClient.Request(request);
            Assert.That(output.ToString(), Contains.Substring("request.URI: https://www.contoso.com/"));
        }
    }
}
