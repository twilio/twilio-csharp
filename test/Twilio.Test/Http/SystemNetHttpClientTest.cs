using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Twilio.Http;
using HttpMethod = Twilio.Http.HttpMethod;

namespace Twilio.Tests.Http
{
    public class MockResponseHandler : DelegatingHandler
    {
        private Uri _nextRequestUri;
        private HttpResponseMessage _nextResponse;
        public HttpRequestMessage InternalRequest { get; private set; }
        public String FormData { get; private set; }

        public void Respond(String url, HttpStatusCode code, String content=null)
        {
            this._nextRequestUri = new Uri(url);
            this._nextResponse = new HttpResponseMessage(code);
            this._nextResponse.Content = new StringContent(content ?? "");
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
                                                                     CancellationToken cancellationToken)
        {
            // Uri will contain query params, only assert on the uri route
            var route = request.RequestUri.ToString().Split('?')[0];
            Assert.AreEqual(this._nextRequestUri.ToString(), route);
            this.InternalRequest = request;
            return Task.FromResult(this._nextResponse);
        }
    }
    
    [TestFixture]
    public class SystemNetHttpClientTest : TwilioTest
    {
        private MockResponseHandler mockHttp;
        public SystemNetHttpClient TwilioHttpClient { get; set; }
        
        [SetUp]
        public void Init()
        {
            this.mockHttp = new MockResponseHandler();
            var internalHttpClient = new System.Net.Http.HttpClient(this.mockHttp);
            this.TwilioHttpClient = new SystemNetHttpClient(internalHttpClient);
        }

        [Test]
        public void TestMakeRequestSuccess()
        {
            this.mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);
            
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            Assert.AreEqual("{'test': 'val'}", resp.Content);
            
            Assert.IsNotNull(this.TwilioHttpClient.LastRequest);
            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            
            Assert.IsNotNull(this.TwilioHttpClient.LastResponse);
            Assert.AreSame(resp, this.TwilioHttpClient.LastResponse);
        }
        
        [Test]
        public void TestMakeRequestAsyncSuccess()
        {
            this.mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.OK,
                "{'test': 'val'}"
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Task<Response> result = this.TwilioHttpClient.MakeRequestAysnc(testRequest);
            result.Wait();
            Response resp = result.Result;
            
            Assert.AreEqual(HttpStatusCode.OK, resp.StatusCode);
            Assert.AreEqual("{'test': 'val'}", resp.Content);
            
            Assert.IsNotNull(this.TwilioHttpClient.LastRequest);
            Assert.AreSame(testRequest, this.TwilioHttpClient.LastRequest);
            
            Assert.IsNotNull(this.TwilioHttpClient.LastResponse);
            Assert.AreSame(resp, this.TwilioHttpClient.LastResponse);
        }
        
        [Test]
        public void TestMakeRequestError()
        {
            // TODO: How does this work in the code?? Which method call throws?
            this.mockHttp.Respond(
                "https://api.twilio.com/v1/Resource.json",
                HttpStatusCode.InternalServerError
            );

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            Response resp = this.TwilioHttpClient.MakeRequest(testRequest);
            
            Assert.AreEqual(HttpStatusCode.InternalServerError, resp.StatusCode);
        }

        [Test]
        public void TestMakeRequestWithParams()
        {
            this.mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            testRequest.AddPostParam("post_param", "post_value");
            testRequest.AddQueryParam("query_param", "query_value");
            
            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this.mockHttp.InternalRequest;
            
            Assert.AreEqual("https://api.twilio.com/v1/Resource.json?query_param=query_value", 
                            internalRequest.RequestUri.ToString());
            
            Assert.IsNotNull(internalRequest.Content);
            Assert.IsInstanceOf<FormUrlEncodedContent>(internalRequest.Content);
        }

        [Test]
        public void TestMakeRequestAddsHeadersAndUserAgent()
        {
            this.mockHttp.Respond("https://api.twilio.com/v1/Resource.json", HttpStatusCode.OK);

            Request testRequest = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            testRequest.SetAuth("username", "password");
                                          
            this.TwilioHttpClient.MakeRequest(testRequest);

            HttpRequestMessage internalRequest = this.mockHttp.InternalRequest;
            Assert.IsNotNull(internalRequest);
            
            Assert.AreEqual("Basic", internalRequest.Headers.Authorization.Scheme);
            Assert.AreEqual("username:password", Convert.FromBase64String(internalRequest.Headers.Authorization.Parameter));

            Assert.AreEqual("application/json", internalRequest.Headers.Accept.ToString());
            Assert.AreEqual("utf-8", internalRequest.Headers.AcceptEncoding.ToString());
            
            Assert.IsNotNull(internalRequest.Headers.UserAgent);
            StringAssert.StartsWith("twilio-csharp/", internalRequest.Headers.UserAgent.ToString());
        }
    }
}