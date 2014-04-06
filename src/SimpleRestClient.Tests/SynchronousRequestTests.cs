using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests
{
    [TestClass]
    public class SynchronousRequestTests
    {
        RestClient client;
        string BASE_URL = "http://example.com";

        public SynchronousRequestTests()
        {
            client = new RestClient();
            client.BaseUrl = BASE_URL;
        }

        // Test properties like Proxy, Timeout, UserAgent

        [TestMethod]
        public void When_A_Default_Header_Is_Present_Then_WebRequest_Includes_This_Header()
        {
            string token = AuthorizationToken;

            client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = token, Type = ParameterType.HttpHeader });

            var request = new RestRequest();

            var wrapper = new HttpWebRequestWrapper();
            var webrequest = wrapper.ConfigureRequest(client, request);

            Assert.IsTrue(webrequest.Headers.AllKeys.Contains("Authorization"));
            Assert.AreEqual(token, webrequest.Headers["Authorization"]);
        }

        [TestMethod]
        public void When_Request_Method_Is_POST_Then_Request_Body_Contains_Encoded_Parameters()
        {
            string body = "Foo=12345&Bar=abcde";
            var sourcebytes = Encoding.UTF8.GetBytes(body);

            var request = new RestRequest();
            request.Method = "POST";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var wrapper = new HttpWebRequestWrapper();
            wrapper.Request = new FakeHttpWebRequest();
            var webrequest = (FakeHttpWebRequest)wrapper.ConfigureRequest(client, request);

            var stream = webrequest.GetRequestStream();
            stream.Position = 0;
            byte[] actualbytes = stream.ReadAsBytes();

            Assert.AreEqual(sourcebytes.Length, webrequest.ContentLength);
            Assert.AreEqual(sourcebytes.Length, actualbytes.Length);
            CollectionAssert.AreEquivalent(sourcebytes, actualbytes);            
        }

        [TestMethod]
        public void When_Request_Method_Is_POST_Then_ContentType_Is_FormEncoded()
        {
            var request = new RestRequest();
            request.Method = "POST";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var wrapper = new HttpWebRequestWrapper();
            var webrequest = wrapper.ConfigureRequest(client, request);

            Assert.AreEqual("application/x-www-form-urlencoded", webrequest.ContentType);
        }

        [TestMethod]
        public void When_Request_Method_Is_GET_Then_Request_Body_Does_Not_Contain_Encoded_Parameters()
        {
            byte[] sourcebytes = new byte[0];

            var request = new RestRequest();
            request.Method = "GET";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var wrapper = new HttpWebRequestWrapper();
            wrapper.Request = new FakeHttpWebRequest();
            var webrequest = (FakeHttpWebRequest)wrapper.ConfigureRequest(client, request);

            var stream = webrequest.GetRequestStream();
            byte[] actualbytes = stream.ReadAsBytes();

            Assert.AreEqual(0, webrequest.ContentLength);
            Assert.AreEqual(sourcebytes.Length,actualbytes.Length);
            CollectionAssert.AreEquivalent(sourcebytes, actualbytes);
        }

        [TestMethod]
        public void When_Request_Method_Is_GET_Then_ContentType_Is_Empty()
        {
            var request = new RestRequest();
            request.Method = "GET";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var wrapper = new HttpWebRequestWrapper();
            var webrequest = wrapper.ConfigureRequest(client, request);

            Assert.IsTrue(string.IsNullOrWhiteSpace(webrequest.ContentType));
        }

        [TestMethod]
        public void When_Http_Protocol_Error_Then_Response_Contains_Status_Code_And_Description()
        {
            FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.BadRequest, "BAD REQUEST");
            var webexception = new WebException(
                "The remote server returned an error: (400) Bad Request.",
                null,
                WebExceptionStatus.ProtocolError,
                new FakeHttpWebResponse(new MemoryStream())
            );

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception);

            Assert.AreEqual(HttpStatusCode.BadRequest, restresponse.StatusCode);
            Assert.AreEqual("BAD REQUEST", restresponse.StatusDescription);
            Assert.AreEqual(ResponseStatus.Completed, restresponse.ResponseStatus);
        }

        [TestMethod]
        public void When_Http_Protocol_Error_Then_Response_Contains_Content()
        {
            var sourcecontent = Encoding.ASCII.GetBytes("{\"code\": 90011, \"message\": \"Param From must be specified.\", \"more_info\": \"https://www.twilio.com/docs/errors/90011\", \"status\": 400}");
            var stream = new MemoryStream(sourcecontent);

            FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.BadRequest, "BAD REQUEST", (int)sourcecontent.Length);
            var webexception = new WebException(
                "The remote server returned an error: (400) Bad Request.",
                null,
                WebExceptionStatus.ProtocolError,
                new FakeHttpWebResponse(stream)
            );

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception);

            Assert.AreEqual(HttpStatusCode.BadRequest, restresponse.StatusCode);
            Assert.AreEqual( (int)sourcecontent.Length, restresponse.RawBytes.Length);
            CollectionAssert.AreEquivalent(sourcecontent, restresponse.RawBytes);
            Assert.AreEqual(ResponseStatus.Completed, restresponse.ResponseStatus);
        }

        [TestMethod]
        public void When_Http_Request_Times_Out_Then_Populate_Exception_Properties()
        {
            var message = "The operation has timed out";

            var webexception = new WebException(message,null,WebExceptionStatus.Timeout,null);
            
            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception);

            Assert.IsNotNull(restresponse.ErrorException);
            Assert.AreEqual(message, restresponse.ErrorMessage);
            Assert.AreEqual(ResponseStatus.Error, restresponse.ResponseStatus);
        }

        [TestMethod]
        public void When_Async_Http_Request_Times_Out_Then_Populate_Exception_Properties()
        {
            var message = "The request was aborted: The request was canceled.";

            var webexception = new WebException(message, null, WebExceptionStatus.RequestCanceled, null);

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception, new TimeOutState() { TimedOut=true });

            Assert.IsNotNull(restresponse.ErrorException);
            Assert.AreEqual(message, restresponse.ErrorMessage);
            Assert.AreEqual(ResponseStatus.TimedOut, restresponse.ResponseStatus);
        }

        [TestMethod]
        public void When_Async_Http_Request_Is_Aborted_Then_Populate_Exception_Properties()
        {
            var message = "The request was aborted: The request was canceled.";

            var webexception = new WebException(message, null, WebExceptionStatus.RequestCanceled, null);

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception, new TimeOutState() { TimedOut = false });

            Assert.IsNotNull(restresponse.ErrorException);
            Assert.AreEqual(message, restresponse.ErrorMessage);
            Assert.AreEqual(ResponseStatus.Aborted, restresponse.ResponseStatus);
        }

        [TestMethod]
        public void When_Http_Request_Completes_Successfully_Then_Extract_Response()
        {
            var sourcecontent = Encoding.ASCII.GetBytes("{\"sid\": \"SMb2628b9fb5992e2f117891601451084b\", \"date_created\": \"Thu, 03 Apr 2014 02:11:55 +0000\", \"date_updated\": \"Thu, 03 Apr 2014 02:11:58 +0000\", \"date_sent\": \"Thu, 03 Apr 2014 02:11:58 +0000\", \"account_sid\": \"AC3137d76457814a5eabf7de62f346d39a\", \"to\": \"+13144586142\", \"from\": \"+19108638087\", \"body\": \"Enter '1234' to confirm your identity and access your account.\", \"status\": \"delivered\", \"num_segments\": \"1\", \"num_media\": null, \"direction\": \"outbound-api\", \"api_version\": \"2010-04-01\", \"price\": \"-0.00750\", \"price_unit\": \"USD\", \"uri\": \"/2010-04-01/Accounts/AC3137d76457814a5eabf7de62f346d39a/Messages/SMb2628b9fb5992e2f117891601451084b.json\", \"subresource_uris\": {\"media\": \"/2010-04-01/Accounts/AC3137d76457814a5eabf7de62f346d39a/Messages/SMb2628b9fb5992e2f117891601451084b/Media.json\"}}");
            var stream = new MemoryStream(sourcecontent);

            FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.OK, "OK", (int)sourcecontent.Length);
            var webresponse = new FakeHttpWebResponse(stream);

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ExtractResponse(webresponse);

            Assert.AreEqual(HttpStatusCode.OK, restresponse.StatusCode);
            Assert.AreEqual((int)sourcecontent.Length, restresponse.RawBytes.Length);
            CollectionAssert.AreEquivalent(sourcecontent, restresponse.RawBytes);
        }

        //[TestMethod]
        //public void When_A_DefaultParameter_UrlSegment_Is_Present_Then_The_Segment_Will_Be_Replaced()
        //{
        //    string segment = "1234567890";
        //    string url = "http://example.com/" + segment;

        //    var client = new RestClient();
        //    client.BaseUrl = "http://example.com/";
        //    client.DefaultParameters.Add(new Parameter() { Name = "AccountSid", Value = segment, Type = ParameterType.UrlSegment });

        //    var request = new RestRequest();
        //    request.Resource = "{AccountSid}";

        //    var webrequest = (HttpWebRequest)WebRequest.Create("http://example.com");
        //    webrequest.ConfigureRequest(client, request);

        //    Assert.AreEqual(url, webrequest.RequestUri.ToString());
        //}

        //[TestMethod]
        //public void When_Method_Is_GET_Querystring_Contains_Parameters()
        //{
        //    string url = BASE_URL + RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS + "?Foo=12345&Bar=abcde";

        //    var client = new RestClient();
        //    client.BaseUrl = BASE_URL;

        //    var request = new RestRequest();
        //    request.Resource = RequestBodyCapturer.VALIDATE_GET_METHOD_PARAMETERS;
        //    request.AddParameter("Foo", "12345");
        //    request.AddParameter("Bar", "abcde");

        //    var webrequest = (HttpWebRequest)WebRequest.Create("http://example.com");
        //    webrequest.ConfigureRequest(client, request);

        //    Assert.AreEqual(url, webrequest.RequestUri.ToString());
        //}

        //[TestMethod]
        //public void When_Json_Is_Returned_Deserialize_Correctly()
        //{
        //    var test = new Test() { Foo = "12345", Bar = "abcde" };

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION;

        //        var response = client.Execute<Test>(request);

        //        Assert.IsInstanceOfType(response.Data, typeof(Test));
        //        Assert.AreEqual("12345", response.Data.Foo);
        //        Assert.AreEqual("abcde", response.Data.Bar);
        //    }
        //}

        //[TestMethod]
        //public void When_Json_Is_Returned_With_Deserialization_Failure()
        //{
        //    string token = AuthorizationToken;

        //    using (SimpleServer.Create(BASE_URL, Generic<RequestBodyCapturer>()))
        //    {
        //        var client = new RestClient();
        //        client.BaseUrl = BASE_URL;

        //        var request = new RestRequest();
        //        request.Resource = RequestBodyCapturer.VALIDATE_OBJECT_DESERIALIZATION_FAILURE;

        //        var response = client.Execute<Test>(request);

        //        Assert.IsInstanceOfType(response.Data, typeof(Test));
        //        Assert.IsNull(response.Data.Foo);
        //        Assert.IsNull(response.Data.Bar);
        //    }
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
