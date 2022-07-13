#if NET35

using NUnit.Framework;
using System;
using NSubstitute;
using Twilio.Http.Net35;
using System.Net;
using Twilio.Http;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Twilio.Tests.Http
{
    [TestFixture]
    public class WebRequestClientTest : TwilioTest
    {
        public WebRequestClient TwilioClient;
        private HttpWebRequestFactory _mockFactory;
        private IHttpWebRequestWrapper _mockRequest;
        private IHttpWebResponseWrapper _mockResponse;
        private Uri _requestUrl;
        private string _requestBody;

        [SetUp]
        public void Init()
        {
            this._requestUrl = null;
            this._requestBody = null;

            this._mockFactory = Substitute.For<HttpWebRequestFactory>();
            this._mockRequest = Substitute.For<IHttpWebRequestWrapper>();
            this._mockRequest.Headers = new NameValueCollection();

            this._mockResponse = Substitute.For<IHttpWebResponseWrapper>();
            this._mockResponse.GetResponseStream().Returns(new MemoryStream());

            this._mockFactory.Create(Arg.Do<Uri>(arg => this._requestUrl = arg))
                             .Returns(this._mockRequest);

            this._mockRequest.GetResponse().Returns(this._mockResponse);
            this._mockRequest.WriteBody(Arg.Do<byte[]>(arg =>
                this._requestBody = Encoding.UTF8.GetString(arg, 0, arg.Length)
            ));

            this.TwilioClient = new WebRequestClient(this._mockFactory);
        }

        private Stream responseBody(string body)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(body));
        }

        [Test]
        public void TestMakeRequestSuccess()
        {
            // Setup
            this._mockResponse.StatusCode = HttpStatusCode.OK;
            this._mockResponse.GetResponseStream().Returns(this.responseBody("{'key': 'val'}"));

            // Run Test
            var request = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            var response = this.TwilioClient.MakeRequest(request);

            // Assert
            Assert.AreEqual(new Uri("https://api.twilio.com/v1/Resource.json"), this._requestUrl);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("{'key': 'val'}", response.Content);
            Assert.IsNull(this._requestBody);

            Assert.AreSame(request, this.TwilioClient.LastRequest);
            Assert.AreSame(response, this.TwilioClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestReturnsNon200()
        {
            // Setup
            this._mockResponse.StatusCode = HttpStatusCode.NotFound;
            this._mockResponse.GetResponseStream().Returns(this.responseBody("{'message': 'not found'}"));

            // Non-2XX Status codes throw a WebException
            var rawException = Substitute.For<WebException>();
            var wrappedException = Substitute.For<WebExceptionWrapper>(rawException);
            wrappedException.Response = this._mockResponse;
            this._mockRequest.GetResponse().Returns(x => { throw wrappedException; });

            // Run Test
            var request = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");
            var response = this.TwilioClient.MakeRequest(request);

            // Assert
            Assert.AreEqual(new Uri("https://api.twilio.com/v1/Resource.json"), this._requestUrl);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual("{'message': 'not found'}", response.Content);
            Assert.IsNull(this._requestBody);

            Assert.AreSame(request, this.TwilioClient.LastRequest);
            Assert.AreSame(response, this.TwilioClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestThrowsOnConnectionError()
        {
            // Setup
            this._mockResponse = null;

            // Connection errors throw a WebException without a Response property set
            var rawException = Substitute.For<WebException>();
            var wrappedException = Substitute.For<WebExceptionWrapper>(rawException);
            wrappedException.Response = null;
            this._mockRequest.GetResponse().Returns(x => { throw wrappedException; });

            // Run Test
            var request = new Request(HttpMethod.Get, "https://api.twilio.com/v1/Resource.json");

            try
            {
                this.TwilioClient.MakeRequest(request);
                Assert.Fail("Should have thrown");
            }
            catch (WebException ex)
            {
                // Assert throws the raw exception
                Assert.AreSame(rawException, ex);
            }

            // Assert
            Assert.AreEqual(new Uri("https://api.twilio.com/v1/Resource.json"), this._requestUrl);
            Assert.IsNull(this._requestBody);
            Assert.AreSame(request, this.TwilioClient.LastRequest);
            Assert.IsNull(this.TwilioClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestWithParams()
        {
            // Setup
            this._mockResponse.StatusCode = HttpStatusCode.Created;
            this._mockResponse.GetResponseStream().Returns(this.responseBody("{'key': 'val'}"));

            // Run Test
            var request = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            request.AddPostParam("post_param", "post_value");
            request.AddQueryParam("query_param", "query_value");

            var response = this.TwilioClient.MakeRequest(request);

            // Assert
            Assert.AreEqual(new Uri("https://api.twilio.com/v1/Resource.json?query_param=query_value"), this._requestUrl);
            Assert.AreEqual("post_param=post_value", this._requestBody);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.AreEqual("{'key': 'val'}", response.Content);

            Assert.AreSame(request, this.TwilioClient.LastRequest);
            Assert.AreSame(response, this.TwilioClient.LastResponse);
        }

        [Test]
        public void TestMakeRequestAddsHeadersAndUserAgent()
        {
            // Setup
            this._mockResponse.StatusCode = HttpStatusCode.OK;

            // Run Test
            var request = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            request.SetAuth("user", "pass");

            var response = this.TwilioClient.MakeRequest(request);

            // Assert
            Assert.AreEqual(new Uri("https://api.twilio.com/v1/Resource.json"), this._requestUrl);

            Assert.AreEqual("POST", this._mockRequest.Method);
            Assert.AreEqual("application/json", this._mockRequest.Accept);
            Assert.AreEqual("application/x-www-form-urlencoded", this._mockRequest.ContentType);

            Assert.Contains("Accept-Encoding", this._mockRequest.Headers.AllKeys);
            Assert.AreEqual("utf-8", this._mockRequest.Headers["Accept-Encoding"]);

            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes("user:pass"));
            Assert.Contains("Authorization", this._mockRequest.Headers.AllKeys);
            Assert.AreEqual("Basic " + authString, this._mockRequest.Headers["Authorization"]);

            Assert.IsNotNull(this._mockRequest.UserAgent);
            Regex rgx = new Regex(@"^twilio-csharp/[0-9.]+(-rc\.[0-9]+)?\s\(\w+\s\w+\)\s.NET/3.5$");
            Assert.IsTrue(rgx.IsMatch(this._mockRequest.UserAgent));
        }

        [Test]
        public void TestMakeRequestAddUserAgentExtensions()
        {
            // Setup
            this._mockResponse.StatusCode = HttpStatusCode.OK;
            string[] userAgentExtensions = new string[] { "twilio-run/2.0.0-test", "flex-plugin/3.4.0" };

            // Run Test
            var request = new Request(HttpMethod.Post, "https://api.twilio.com/v1/Resource.json");
            request.UserAgentExtensions = userAgentExtensions;
            request.SetAuth("user", "pass");

            var response = this.TwilioClient.MakeRequest(request);

            // Assert
            string[] actualUserAgent = this._mockRequest.UserAgent.Split(' ');
            var actualUserAgentExtensions = actualUserAgent.ToList().GetRange(actualUserAgent.Length - userAgentExtensions.Length, userAgentExtensions.Length);
            CollectionAssert.AreEqual(userAgentExtensions, actualUserAgentExtensions);
        }
    }
}
#endif