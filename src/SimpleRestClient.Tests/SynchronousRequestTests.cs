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
            wrapper.HttpWebRequestType = typeof(FakeHttpWebRequest);
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
            wrapper.HttpWebRequestType = typeof(FakeHttpWebRequest);
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

    public class FakeHttpWebResponse : HttpWebResponse
    {
        private static SerializationInfo SerializationInfo;
        private readonly MemoryStream _responseStream;

        public static void InitializeHttpWebResponse(HttpStatusCode status, string statusDescription)
        {
            InitializeHttpWebResponse(status, statusDescription, 0);
        }

        public static void InitializeHttpWebResponse(HttpStatusCode status, string statusDescription, int contentLength)
        {
            SerializationInfo = new SerializationInfo(typeof(HttpWebResponse), new FormatterConverter());
            StreamingContext sc = new StreamingContext();
            WebHeaderCollection headers = new WebHeaderCollection();
            SerializationInfo.AddValue("m_HttpResponseHeaders", headers);
            SerializationInfo.AddValue("m_Uri", new Uri("http://example.com"));
            SerializationInfo.AddValue("m_Certificate", null);
            SerializationInfo.AddValue("m_Version", HttpVersion.Version11);
            SerializationInfo.AddValue("m_StatusCode", status);
            SerializationInfo.AddValue("m_ContentLength", contentLength);
            SerializationInfo.AddValue("m_Verb", "GET");
            SerializationInfo.AddValue("m_StatusDescription", statusDescription);
            SerializationInfo.AddValue("m_MediaType", null);
            SerializationInfo.AddValue("m_ConnectStream", null, typeof(Stream));
        }

        public FakeHttpWebResponse()
            : base(SerializationInfo, new StreamingContext())
        { 
        
        }

        public FakeHttpWebResponse(Stream response) : this()
        {
            _responseStream = (MemoryStream)response;
        }

        public override Stream GetResponseStream()
        {
            return this._responseStream;
        }
    }

    public class FakeHttpWebRequest : HttpWebRequest
    {
        private FakeHttpWebResponse _httpwebresponse;
        private static readonly SerializationInfo SerializationInfo;
        private readonly MemoryStream _requestStream;

        static FakeHttpWebRequest()
        {
            SerializationInfo = new SerializationInfo(typeof(HttpWebRequest), new FormatterConverter());
            SerializationInfo.AddValue("_HttpRequestHeaders", new WebHeaderCollection(), typeof(WebHeaderCollection));
            SerializationInfo.AddValue("_Proxy", null, typeof(IWebProxy));
            SerializationInfo.AddValue("_KeepAlive", false);
            SerializationInfo.AddValue("_Pipelined", false);
            SerializationInfo.AddValue("_AllowAutoRedirect", false);
            SerializationInfo.AddValue("_AllowWriteStreamBuffering", false);
            SerializationInfo.AddValue("_HttpWriteMode", 0);
            SerializationInfo.AddValue("_MaximumAllowedRedirections", 0);
            SerializationInfo.AddValue("_AutoRedirects", 0);
            SerializationInfo.AddValue("_Timeout", 500);
            SerializationInfo.AddValue("_ReadWriteTimeout", 500);
            SerializationInfo.AddValue("_MaximumResponseHeadersLength", 128);
            SerializationInfo.AddValue("_ContentLength", 0);
            SerializationInfo.AddValue("_MediaType", 0);
            SerializationInfo.AddValue("_OriginVerb", 0);
            SerializationInfo.AddValue("_ConnectionGroupName", null);
            SerializationInfo.AddValue("_Version", HttpVersion.Version11, typeof(Version));
            SerializationInfo.AddValue("_OriginUri", new Uri("http://example.com"), typeof(Uri));
        }

        public FakeHttpWebRequest()
            : base(SerializationInfo, new StreamingContext())
        {
            _requestStream = new MemoryStream();

            FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.OK, "OK");
            _httpwebresponse = new FakeHttpWebResponse();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Net.HttpWebRequest"/> class from the specified instances of the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> and <see cref="T:System.Runtime.Serialization.StreamingContext"/> classes.
        /// </summary>
        /// <param name="serializationInfo">A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> object that contains the information required to serialize the new <see cref="T:System.Net.HttpWebRequest"/> object. </param><param name="streamingContext">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> object that contains the source and destination of the serialized stream associated with the new <see cref="T:System.Net.HttpWebRequest"/> object. </param>
        protected FakeHttpWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        #region Overrides of HttpWebRequest

        /// <summary>
        /// Gets a <see cref="T:System.IO.Stream"/> object to use to write request data.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.IO.Stream"/> to use to write request data.
        /// </returns>
        /// <exception cref="T:System.Net.ProtocolViolationException">The <see cref="P:System.Net.HttpWebRequest.Method"/> property is GET or HEAD.-or- <see cref="P:System.Net.HttpWebRequest.KeepAlive"/> is true, <see cref="P:System.Net.HttpWebRequest.AllowWriteStreamBuffering"/> is false, <see cref="P:System.Net.HttpWebRequest.ContentLength"/> is -1, <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false, and <see cref="P:System.Net.HttpWebRequest.Method"/> is POST or PUT. </exception><exception cref="T:System.InvalidOperationException">The <see cref="M:System.Net.HttpWebRequest.GetRequestStream"/> method is called more than once.-or- <see cref="P:System.Net.HttpWebRequest.TransferEncoding"/> is set to a value and <see cref="P:System.Net.HttpWebRequest.SendChunked"/> is false. </exception><exception cref="T:System.NotSupportedException">The request cache validator indicated that the response for this request can be served from the cache; however, requests that write data must not use the cache. This exception can occur if you are using a custom cache validator that is incorrectly implemented. </exception><exception cref="T:System.Net.WebException"><see cref="M:System.Net.HttpWebRequest.Abort"/> was previously called.-or- The time-out period for the request expired.-or- An error occurred while processing the request. </exception><exception cref="T:System.ObjectDisposedException">In a .NET Compact Framework application, a request stream with zero content length was not obtained and closed correctly. For more information about handling zero content length requests, see Network Programming in the .NET Compact Framework.</exception><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.DnsPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Net.WebPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override Stream GetRequestStream()
        {
            return _requestStream;
        }

        public override WebResponse GetResponse()
        {
            return _httpwebresponse;
        }

        public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state)
        {
            Task<WebResponse> f = Task<WebResponse>.Factory.StartNew(
                _ =>
                {
                    System.Diagnostics.Debug.WriteLine("Foo");

                    FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.OK, "OK");
                    return new FakeHttpWebResponse(new MemoryStream());
                },
                state
            );

            if (callback != null) f.ContinueWith((res) => callback(f));
            return f;
        }

        public override WebResponse EndGetResponse(IAsyncResult asyncResult)
        {
            return ((Task<WebResponse>)asyncResult).Result;
        }

        #endregion
    }

    //public class FakeAsyncResult : IAsyncResult
    //{
    //    public object AsyncState
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public System.Threading.WaitHandle AsyncWaitHandle
    //    {
    //        get { return new System.Threading.WaitHandle(); }
    //    }

    //    public bool CompletedSynchronously
    //    {
    //        get { throw new NotImplementedException(); }
    //    }

    //    public bool IsCompleted
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}

}
