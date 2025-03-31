using System.Net;
using System.Text;
using System.Text.RegularExpressions;

using Twilio.Constant;
using Twilio.Http;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.UnitTests.Http
{
    public class MockResponseHandler : DelegatingHandler
    {
        public class MockResponse
        {
            public Uri? requestUri;
            public HttpResponseMessage? message;
            public Exception? error;
        }

        private Dictionary<string, MockResponse> responseMap = new Dictionary<string, MockResponse>();

        public HttpRequestMessage? InternalRequest { get; private set; }

        private Random random = new Random();

        public void Respond(string url, HttpStatusCode code, string? content = null)
        {
            MockResponse response = new MockResponse();
            response.requestUri = new Uri(url);
            response.message = new HttpResponseMessage(code);
            response.message.Content = new StringContent(content ?? "");
            response.error = null;

            responseMap[url] = response;
        }

        public void Error(string url, Exception error)
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
            var route = request.RequestUri?.ToString().Split('?')[0] ?? "";
            MockResponse response = responseMap[route];

            Assert.Equal(response.requestUri?.ToString(), route);
            
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

    
    public class SystemNetHttpClientTest : TwilioTest
    {
        private MockResponseHandler _mockHttp;
        public SystemNetHttpClient TwilioHttpClient { get; set; }

        
        public SystemNetHttpClientTest()
        {
            this._mockHttp = new MockResponseHandler();
            var internalHttpClient = new System.Net.Http.HttpClient(this._mockHttp);
            this.TwilioHttpClient = new SystemNetHttpClient(internalHttpClient);
        }

        [Fact]
        public void TestMakeRequestSuccess()
        {
            this._mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            Assert.Equal("{'test': 'val'}", resp.Content);

            Assert.Same(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.Same(resp, this.TwilioHttpClient.LastResponse);
        }

        [Fact]
        public async void TestMakeRequestAsyncSuccess()
        {
            this._mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            var result = await this.TwilioHttpClient.MakeRequestAsync(testRequest);
            
            Response resp = result;

            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            Assert.Equal("{'test': 'val'}", resp.Content);

            Assert.Same(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.Same(resp, this.TwilioHttpClient.LastResponse);
        }

        [Fact]
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

            async void testRunner(object? index)
            {
                if(index == null)
                {
                    throw new ArgumentNullException(nameof(index));
                }
                int i = (int)index;
                Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/" + i + "/Resource.json");
                var result = await this.TwilioHttpClient.MakeRequestAsync(testRequest);
                // result.Wait();
                responses[i] = result;
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
                Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
                Assert.Equal("{'test': 'val" + i + "'}", resp.Content);
            }
        }

        [Fact]
        public void TestMakeRequestReturnsNon200()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.InternalServerError);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);

            Assert.Equal(HttpStatusCode.InternalServerError, resp.StatusCode);
            Assert.Same(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.Same(resp, this.TwilioHttpClient.LastResponse);
        }

        [Fact]
        public void TestMakeRequestThrowsOnConnectionErrors()
        {
            this._mockHttp.Error(
                "https://api.twilio.com/v1/Resource.json",
                new HttpRequestException("Unable to connect!")
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");

            Assert.Throws<HttpRequestException>(() => TwilioHttpClient.MakeRequest(testRequest));

            Assert.Same(testRequest, this.TwilioHttpClient.LastRequest);
            Assert.Null(this.TwilioHttpClient.LastResponse);
        }

        [Fact]
        public void TestMakeRequestWithParams()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            testRequest.AddPostParam("post_param", "post_value");
            testRequest.AddQueryParam("query_param", "query_value");

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;

            Assert.Equal("https://api.twilio.com/v1/Resource.json?query_param=query_value",
                            internalRequest.RequestUri?.ToString());

            Assert.NotNull(internalRequest.Content);
            Assert.IsAssignableFrom<FormUrlEncodedContent>(internalRequest.Content);
        }
        
        [Fact]
        public void TestMakeRequestWithJsonBody()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);
            
            Request testRequest = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            testRequest.ContentType = EnumConstants.ContentTypeEnum.JSON;
            testRequest.Body = "{\"status\":\"awe\"}";

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;

            Assert.NotNull(internalRequest.Content);
            Assert.IsAssignableFrom<StringContent>(internalRequest.Content);
            Assert.Equal("application/json", internalRequest.Content?.Headers?.ContentType?.MediaType);
            Assert.Equal("utf-8", internalRequest.Content?.Headers?.ContentType?.CharSet);
        }

        [Fact]
        public void TestMakeRequestAddsHeadersAndUserAgent()
        {
            this._mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            testRequest.SetAuth("username", "password");

            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this._mockHttp.InternalRequest;
            Assert.NotNull(internalRequest);

            Assert.Equal("Basic", internalRequest.Headers?.Authorization?.Scheme);
            Assert.Equal(Encoding.UTF8.GetBytes("username:password"), Convert.FromBase64String(internalRequest?.Headers?.Authorization?.Parameter ?? ""));

            Assert.Equal("application/json", internalRequest?.Headers?.Accept.ToString());
            Assert.Equal("utf-8", internalRequest?.Headers?.AcceptEncoding.ToString());

            Assert.NotNull(internalRequest?.Headers?.UserAgent);
            Regex rgx = new Regex(@"^twilio-csharp/[0-9.]+(-rc\.[0-9]+)?\s\(\w+\s\w+\)\s[.\s\w]+/[^\s]+$");
            Assert.Matches(rgx, internalRequest?.Headers?.UserAgent?.ToString());
        }

        [Fact]
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
            Assert.Equal(userAgentExtensions, actualUserAgentExtensions);
        }
    }
}