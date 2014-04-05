using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimpleRestClient.Tests
{
    [TestClass]
    public class AsynchronousRequestTests
    {
        ManualResetEvent manualResetEvent;
        private const string BASE_URL = "http://example.com/";

        [TestMethod]
        public void When_A_DefaultParameter_Header_Is_Present()
        {
            manualResetEvent = new ManualResetEvent(false);
            string token = AuthorizationToken;

            var client = new RestClient();
            client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = token, Type = ParameterType.HttpHeader });
            client.BaseUrl = BASE_URL;

            client.WebRequest = new HttpWebRequestWrapper() { HttpWebRequestType = typeof(FakeHttpWebRequest)};

            var request = new RestRequest();

            var response = client.ExecuteAsync(request, r =>
            {                
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne();
        }

        //[TestMethod]
        //public void When_Authorization_Fails()
        //{
        //    manualResetEvent = new ManualResetEvent(false);
        //    string token = AuthorizationToken;

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_AUTHORIZATION_FAILURE;

        //        var response = client.ExecuteAsync<Test>(request, c => { 
        //            manualResetEvent.Set();
        //            Assert.AreEqual(HttpStatusCode.Unauthorized, c.StatusCode);
        //            Assert.AreEqual("Unauthorized", c.StatusDescription);
        //            Assert.IsNull(c.Data);
        //        });

        //        manualResetEvent.WaitOne();
        //    }
        //}

        //[TestMethod]
        //public void When_Request_Fails()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    string token = AuthorizationToken;

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_BADREQUEST_FAILURE;

        //        var response = client.ExecuteAsync<Test>(request, c=> {

        //            manualResetEvent.Set();
        //            Assert.AreEqual(HttpStatusCode.BadRequest, c.StatusCode);
        //            Assert.AreEqual("Bad Request", c.StatusDescription);

        //            Assert.IsInstanceOfType(c.Data, typeof(Test));
        //            Assert.AreEqual("12345", c.Data.Foo);
        //            Assert.AreEqual("abcde", c.Data.Bar);

        //        });

        //        manualResetEvent.WaitOne();

        //    }
        //}


        //[TestMethod]
        //public void When_A_DefaultParameter_UrlSegment_Is_Present()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    string segment = "1234567890";
        //    string url = BASE_URL + segment + "/" + RequestBodyCapturer.VALIDATE_DEFAULTPARAMETER_URLSEGMENT;

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.DefaultParameters.Add(new Parameter() { Name = "AccountSid", Value = segment, Type = ParameterType.UrlSegment });
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = "{AccountSid}/" + RequestBodyCapturer.VALIDATE_DEFAULTPARAMETER_URLSEGMENT;

        //        var response = client.ExecuteAsync<Test>(request, c => {
        //            manualResetEvent.Set();
        //        });
        //        manualResetEvent.WaitOne();

        //        Assert.AreEqual(url, RequestBodyCapturer.CapturedResourceLocation);
        //    }
        //}

        //[TestMethod]
        //public void When_Method_Is_GET_Querystring_Contains_Parameters()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    string url = BASE_URL + RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS + "?Foo=12345&Bar=abcde";

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS;
        //        request.AddParameter("Foo", "12345");
        //        request.AddParameter("Bar", "abcde");

        //        var response = client.ExecuteAsync<Test>(request, c => {
        //            manualResetEvent.Set();
        //        });
        //        manualResetEvent.WaitOne();

        //        Assert.AreEqual(url, RequestBodyCapturer.CapturedResourceLocation);
        //    }
        //}

        //[TestMethod]
        //public void When_Method_Is_POST_Body_Contains_Parameters()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    string body = "Foo=12345&Bar=abcde";

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_POST_METHOD_PARAMETERS;
        //        request.Method = "POST";
        //        request.AddParameter("Foo", "12345");
        //        request.AddParameter("Bar", "abcde");

        //        var response = client.ExecuteAsync<Test>(request, c => {
        //            manualResetEvent.Set();
        //        });
        //        manualResetEvent.WaitOne();

        //        Assert.AreEqual(true, RequestBodyCapturer.CapturedHasEntityBody);
        //        Assert.AreEqual(body, RequestBodyCapturer.CapturedEntityBody);
        //    }
        //}

        //[TestMethod]
        //public void When_Method_Is_POST_ContentType_Is_FormEncoded()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_POST_METHOD_CONTENTYPE;
        //        request.Method = "POST";
        //        request.AddParameter("Foo", "12345");
        //        request.AddParameter("Bar", "abcde");

        //        var response = client.ExecuteAsync<Test>(request, c => {
        //            manualResetEvent.Set();
        //        });
        //        manualResetEvent.WaitOne();

        //        Assert.AreEqual("application/x-www-form-urlencoded", RequestBodyCapturer.CapturedContentType);
        //    }
        //}

        //[TestMethod]
        //public void When_Json_Is_Returned_Deserialize_Correctly()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    var test = new Test() { Foo = "12345", Bar = "abcde" };

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION;

        //        var response = client.ExecuteAsync<Test>(request, c =>
        //        {
        //            manualResetEvent.Set();

        //            Assert.IsInstanceOfType(c.Data, typeof(Test));
        //            Assert.AreEqual("12345", c.Data.Foo);
        //            Assert.AreEqual("abcde", c.Data.Bar);
        //        });

        //        manualResetEvent.WaitOne();
        //    }
        //}

        //[TestMethod]
        //public void When_Json_Is_Returned_With_Deserialization_Failure()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    string token = AuthorizationToken;

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION_FAILURE;

        //        var response = client.ExecuteAsync<Test>(request, c=> {
        //            manualResetEvent.Set();
        //            Assert.IsInstanceOfType(c.Data, typeof(Test));
        //            Assert.IsNull(c.Data.Foo);
        //            Assert.IsNull(c.Data.Bar);
        //        });

        //        manualResetEvent.WaitOne();
        //    }
        //}

        //[TestMethod]
        //public void When_Request_Times_Out()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.Timeout = 5000;
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_REQUEST_TIMEOUT;

        //        var response = client.ExecuteAsync<Test>(request, c =>
        //        {
        //            manualResetEvent.Set();

        //            Assert.AreEqual(ResponseStatus.TimedOut, c.ResponseStatus);
        //        });

        //        manualResetEvent.WaitOne();
        //    }
        //}

        //[TestMethod]
        //public void When_Request_Is_Canceled()
        //{
        //    manualResetEvent = new ManualResetEvent(false);

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_REQUEST_CANCELED;

        //        var response = client.ExecuteAsync<Test>(request, c =>
        //        {
        //            manualResetEvent.Set();

        //            Assert.AreEqual(ResponseStatus.Aborted, c.ResponseStatus);
        //        });

        //        manualResetEvent.WaitOne(1000);

        //        response.Abort();
        //    }
        //}


        //public static Action<HttpListenerContext> Generic<T>() where T : new()
        //{
        //    return ctx =>
        //    {
        //        var methodName = ctx.Request.Url.Segments.Last();
        //        var method = typeof(T).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        //        if (method.IsStatic)
        //        {
        //            method.Invoke(null, new object[] { ctx });
        //        }
        //        else
        //        {
        //            method.Invoke(new T(), new object[] { ctx });
        //        }
        //    };
        //}

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
