using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;

namespace SimpleRestClient.Tests
{
    [TestClass]
    public class SynchronousRequestTests
    {
        // deserialization error
        // http timeout
        // dns failure

        private const string BASE_URL = "http://localhost:18080/";

        [TestMethod]
        public void When_A_DefaultParameter_Header_Is_Present()
        {
            string token = AuthorizationToken;

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = token, Type = ParameterType.HttpHeader });
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_DEFAULTPARAMETER_HEADER;

                var response = client.Execute<Test>(request);

                Assert.IsTrue(RequestBodyCapturer.CapturedHasBasicAuthenticationHeader);
                Assert.AreEqual(token, RequestBodyCapturer.CapturedBasicAuthenticationHeaderValue);
            }
        }

        [TestMethod]
        public void When_Authorization_Fails()
        {
            string token = AuthorizationToken;

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_AUTHORIZATION_FAILURE;

                var response = client.Execute<Test>(request);

                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
                Assert.AreEqual("Unauthorized", response.StatusDescription);
                Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
                Assert.IsNull(response.Data);
            }
        }

        [TestMethod]
        public void When_Request_Fails()
        {
            string token = AuthorizationToken;

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_BADREQUEST_FAILURE;

                var response = client.Execute<Test>(request);

                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual("Bad Request", response.StatusDescription);

                Assert.IsInstanceOfType(response.Data, typeof(Test));
                Assert.AreEqual("12345", response.Data.Foo);
                Assert.AreEqual("abcde", response.Data.Bar);

            }
        }

        [TestMethod]
        public void When_A_DefaultParameter_UrlSegment_Is_Present()
        {
            string segment = "1234567890";
            string url = BASE_URL + segment + "/" + RequestBodyCapturer.VALIDATE_DEFAULTPARAMETER_URLSEGMENT;

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.DefaultParameters.Add(new Parameter() { Name = "AccountSid", Value = segment, Type = ParameterType.UrlSegment });
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = "{AccountSid}/" + RequestBodyCapturer.VALIDATE_DEFAULTPARAMETER_URLSEGMENT;

                var response = client.Execute<Test>(request);

                Assert.AreEqual(url, RequestBodyCapturer.CapturedResourceLocation);
            }
        }

        [TestMethod]
        public void When_Method_Is_GET_Querystring_Contains_Parameters()
        {
            string url = BASE_URL + RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS + "?Foo=12345&Bar=abcde";

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS;
                request.AddParameter("Foo", "12345");
                request.AddParameter("Bar", "abcde");

                var response = client.Execute<Test>(request);

                Assert.AreEqual(url, RequestBodyCapturer.CapturedResourceLocation);
            }
        }

        [TestMethod]
        public void When_Method_Is_POST_Body_Contains_Parameters()
        {
            string body = "Foo=12345&Bar=abcde";

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_POST_METHOD_PARAMETERS;
                request.Method = "POST";
                request.AddParameter("Foo", "12345");
                request.AddParameter("Bar", "abcde");

                var response = client.Execute<Test>(request);

                Assert.AreEqual(true, RequestBodyCapturer.CapturedHasEntityBody);
                Assert.AreEqual(body, RequestBodyCapturer.CapturedEntityBody);
            }
        }

        [TestMethod]
        public void When_Method_Is_POST_ContentType_Is_FormEncoded()
        {
            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_POST_METHOD_CONTENTYPE;
                request.Method = "POST";
                request.AddParameter("Foo", "12345");
                request.AddParameter("Bar", "abcde");

                var response = client.Execute<Test>(request);

                Assert.AreEqual("application/x-www-form-urlencoded", RequestBodyCapturer.CapturedContentType);
            }
        }

        [TestMethod]
        public void When_Json_Is_Returned_Deserialize_Correctly()
        {
            var test = new Test() { Foo = "12345", Bar = "abcde" };

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION;

                var response = client.Execute<Test>(request);

                Assert.IsInstanceOfType(response.Data, typeof(Test));
                Assert.AreEqual("12345", response.Data.Foo);
                Assert.AreEqual("abcde", response.Data.Bar);
            }
        }

        [TestMethod]
        public void When_Json_Is_Returned_With_Deserialization_Failure()
        {
            string token = AuthorizationToken;

            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION_FAILURE;

                var response = client.Execute<Test>(request);

                Assert.IsInstanceOfType(response.Data, typeof(Test));
                Assert.IsNull(response.Data.Foo);
                Assert.IsNull(response.Data.Bar);
            }
        }

        [TestMethod]
        public void When_Request_Times_Out()
        {
            using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
            {
                var client = new RestClient();
                client.Timeout = 5000;
                client.BaseUrl = BASE_URL;

                var request = new RestRequest();
                request.Resource = RequestBodyCapturer.VALIDATE_REQUEST_TIMEOUT;

                var response = client.Execute<Test>(request);

                Assert.AreEqual(ResponseStatus.Error, response.ResponseStatus);
            }
        }

        public static Action<HttpListenerContext> Generic<T>() where T : new()
        {
            return ctx =>
            {
                var methodName = ctx.Request.Url.Segments.Last();
                var method = typeof(T).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                if (method.IsStatic)
                {
                    method.Invoke(null, new object[] { ctx });
                }
                else
                {
                    method.Invoke(new T(), new object[] { ctx });
                }
            };
        }

        private string AuthorizationToken
        {
            get
            {
                var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", "test", "user")));
                return string.Format("Basic {0}", token);
            }
        }

    }
}
