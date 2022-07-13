#if !NET35
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Twilio.Http;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.Tests.Http
{
    public class MockResponseHandler : DelegatingHandler
    {
        public class MockResponse
        {
            public Uri requestUri;
            public HttpResponseMessage message;
            public Exception error;
        }

        private Dictionary<String, MockResponse> responseMap = new Dictionary<String, MockResponse>();

        public HttpRequestMessage InternalRequest { get; private set; }

        private Random random = new Random();

        public void Respond(String url, HttpStatusCode code, String content = null)
        {
            MockResponse response = new MockResponse();
            response.requestUri = new Uri(url);
            response.message = new HttpResponseMessage(code);
            response.message.Content = new StringContent(content ?? "");
            response.error = null;

            responseMap[url] = response;
        }

        public void Error(String url, Exception error)
        {
            MockResponse response = new MockResponse();
            response.requestUri = new Uri(url);
            response.error = error;

            responseMap[url] = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            // Uri will contain query params, only lookup on the uri route
            var route = request.RequestUri.ToString().Split('?')[0];
            MockResponse response = responseMap[route];

            Assert.AreEqual(response.requestUri.ToString(), route);
            if (response.error != null)
            {
                throw response.error;
            }
            this.InternalRequest = request;

            // Inject some randomness for multi-threading scenarios. And for fun!
            Thread.Sleep(random.Next(100));
            return Task.FromResult(response.message);
        }
    }

    [TestFixture]
    public class SystemNetHttpClientTest : TwilioTest
    {
        private MockResponseHandler _mockHttp;
        public SystemNetHttpClient TwilioHttpClient { get; set; }

        [SetUp]
        public void Init()
        {
            this._mockHttp = new MockResponseHandler();
            var internalHttpClient = new System.Net.Http.HttpClient(this._mockHttp);
            this.TwilioHttpClient = new SystemNetHttpClient(internalHttpClient);
        }

        [Test]
        public void TestMakeRequestSuccess()
        {
            this._mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            Assert.AreEqual("{'test': 'val'}", resp.Content);

            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.AreSame(resp, this.TwilioHttpClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestAsyncSuccess()
        {
            this._mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Task<Response> result = this.TwilioHttpClient.MakeRequestAsync(testRequest);
            result.Wait();
            Response resp = result.Result;

            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            Assert.AreEqual("{'test': 'val'}", resp.Content);

            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.AreSame(resp, this.TwilioHttpClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestAsyncSuccessThreadSafe()
        {
            // Create enough threads to rule out any suspicion.
            const int testIterations = 100;
            Response[] responses = new Response[testIterations];
            Thread[] threads = new Thread[testIterations];

            // Initiazlie the reponse mapping.
            for (int i = 0; i < testIterations; ++i)
            {
                this._mockHttp.Respond(
                    "https://api.twilio.com/v1/" + i + "/Resource.json",
                    HttpStatusCode.OK,
                    "{'test': 'val" + i + "'}"
                );
            }

            void testRunner(object index)
            {
                int i = (int)index;
                Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/" + i + "/Resource.json");
                Task<Response> result = this.TwilioHttpClient.MakeRequestAsync(testRequest);
                result.Wait();
                responses[i] = result.Result;
            }

            // Intialize and run all the threads. Then hold for completion.
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(testRunner);
                threads[i].Start(i);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            // Finally, make sure all the response matches our expectations.
            for (int i = 0; i < testIterations; ++i)
            {
                Response resp = responses[i];
                Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
                Assert.AreEqual("{'test': 'val" + i + "'}", resp.Content);
            }
        }

        [Test]
        public void TestMakeRequestReturnsNon200()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.InternalServerError);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);

            Assert.AreEqual(HttpStatusCode.InternalServerError, resp.StatusCode);
            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.AreSame(resp, this.TwilioHttpClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestThrowsOnConnectionErrors()
        {
            this._mockHttp.Error(
                "https://api.twilio.com/v1/Resource.json",
                new HttpRequestException("Unable to connect!")
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");

            Assert.Throws<HttpRequestException>(() => TwilioHttpClient.MakeRequest(testRequest));

            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.IsNull(this.TwilioHttpClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestWithParams()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            testRequest.AddPostParam("post_param", "post_value");
            testRequest.AddQueryParam("query_param", "query_value");

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;

            Assert.AreEqual("https://api.twilio.com/v1/Resource.json?query_param=query_value",
                            internalRequest.RequestUri.ToString());

            Assert.IsNotNull(internalRequest.Content);
            Assert.IsInstanceOf<FormUrlEncodedContent>(internalRequest.Content);
        }

        [Test]
        public void TestMakeRequestAddsHeadersAndUserAgent()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            testRequest.SetAuth("username", "password");

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;
            Assert.IsNotNull(internalRequest);

            Assert.AreEqual("Basic", internalRequest.Headers.Authorization.Scheme);
            Assert.AreEqual("username:password", Convert.FromBase64String(internalRequest.Headers.Authorization.Parameter));

            Assert.AreEqual("application/json", internalRequest.Headers.Accept.ToString());
            Assert.AreEqual("utf-8", internalRequest.Headers.AcceptEncoding.ToString());

            Assert.IsNotNull(internalRequest.Headers.UserAgent);
            Regex rgx = new Regex(@"^twilio-csharp/[0-9.]+(-rc\.[0-9]+)?\s\(\w+\s\w+\)\s[.\s\w]+/[^\s]+$");
            Assert.IsTrue(rgx.IsMatch(internalRequest.Headers.UserAgent.ToString()));
        }

        [Test]
        public void TestMakeRequestAddUserAgentExtensions()
        {
            string[] userAgentExtensions = new string[] { "twilio-run/2.0.0-test", "flex-plugin/3.4.0" };

            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            testRequest.UserAgentExtensions = userAgentExtensions;
            testRequest.SetAuth("username", "password");

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;
            string userAgent = internalRequest.Headers.UserAgent.ToString();
            string[] actualUserAgent = userAgent.Split(' ');
            var actualUserAgentExtensions = actualUserAgent.ToList().GetRange(actualUserAgent.Length - userAgentExtensions.Length, userAgentExtensions.Length);
            CollectionAssert.AreEqual(userAgentExtensions, actualUserAgentExtensions);
        }
    }
}
#endif