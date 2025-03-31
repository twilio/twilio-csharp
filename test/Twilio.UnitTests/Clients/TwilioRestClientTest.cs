using System;
using System.Net;
using System.Collections.Generic;

#if !NET35
using System.Threading.Tasks;
#endif

using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using System.IO;
using HttpClient = Twilio.Http.HttpClient;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.UnitTests.Clients
{

    public class TwilioRestClientTest
    {
        HttpClient client;


        public TwilioRestClientTest()
        {
            client = Substitute.For<HttpClient>();
        }

        [Fact]
        public void TestValidSslCert()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            TwilioRestClient.ValidateSslCertificate(client);
        }

        [Fact]
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
                Assert.IsAssignableFrom<InvalidOperationException>(e.GetBaseException());
                Assert.Equal("Connection to tls-test.twilio.com:443 failed", e.Message);
                Assert.Null(e.Response);
                Assert.NotNull(e.Request);
            }
            catch (Exception)
            {
                Assert.Fail("Threw an unknown exception");
            }
        }

        [Fact]
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
                Assert.Equal("Unexpected response from certificate endpoint", e.Message);
                Assert.NotNull(e.Response);
                Assert.NotNull(e.Request);
            }
            catch (Exception)
            {
                Assert.Fail("Threw an unknown exception");
            }
        }

        [Fact]
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
                Assert.Equal("Bad request", e.Message);
                Assert.Equal(20001, e.Code);
                Assert.Equal("https://www.twilio.com/docs/errors/20001", e.MoreInfo);
                Assert.Equal(400, e.Status);
                var expectedDetails = new Dictionary<string, object>();
                expectedDetails.Add("foo", "bar");
                Assert.Equal(expectedDetails, e.Details);
            }
        }

        [Fact]
        public void TestRedirectResponse()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.RedirectKeepVerb, "REDIRECT"));
            Request request = new Request(HttpMethod.Get, "https://www.contoso.com");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", null, null, client);
            twilioClient.Request(request);
        }

        [Fact]
        public void TestActivatingDebugLogging()
        {
            var output = new StringWriter();
            Console.SetOut(output);
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://www.contoso.com");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", null, null, client);
            twilioClient.LogLevel = "debug";
            twilioClient.Request(request);
            Assert.Contains("request.URI: https://www.contoso.com/", output.ToString());
        }

        [Fact]
        public void RequestPropagatesEdgeAndRegion()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://verify.twilio.com/");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", region: "us1", httpClient: client);
            twilioClient.Edge = "frankfurt";

            twilioClient.Request(request);

            Assert.Equal("frankfurt", request.Edge);
            Assert.Equal("us1", request.Region);
        }

        [Fact]
        public void RequestWithUserAgentExtensions()
        {
            client.MakeRequest(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://verify.twilio.com/");
            string[] userAgentExtensions = new string[] { "twilio-run/2.0.0-test", "flex-plugin/3.4.0" };
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", httpClient: client);
            twilioClient.UserAgentExtensions = userAgentExtensions;

            twilioClient.Request(request);

            Assert.Equal(request.UserAgentExtensions, userAgentExtensions);
        }

#if !NET35
        [Fact]
        public async Task RequestAsyncPropagatesEdgeAndRegion()
        {
            client.MakeRequestAsync(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://verify.twilio.com/");
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", region: "us1", httpClient: client);
            twilioClient.Edge = "frankfurt";

            await twilioClient.RequestAsync(request);

            Assert.Equal("frankfurt", request.Edge);
            Assert.Equal("us1", request.Region);
        }

        [Fact]
        public async Task RequestAsyncWithUserAgentExtensions()
        {
            client.MakeRequestAsync(Arg.Any<Request>()).Returns(new Response(HttpStatusCode.OK, "OK"));
            Request request = new Request(HttpMethod.Get, "https://verify.twilio.com/");
            string[] userAgentExtensions = new string[] { "twilio-run/2.0.0-test", "flex-plugin/3.4.0" };
            TwilioRestClient twilioClient = new TwilioRestClient("foo", "bar", httpClient: client);
            twilioClient.UserAgentExtensions = userAgentExtensions;

            await twilioClient.RequestAsync(request);

            Assert.Equal(request.UserAgentExtensions, userAgentExtensions);
        }
#endif
    }
}
