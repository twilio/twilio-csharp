using Simple;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleRestClient.Tests
{

#if FX35

	[TestFixture]
    public class ResponseTests
    {
        [Test]
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

        [Test]
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
            Assert.AreEqual((int)sourcecontent.Length, restresponse.RawBytes.Length);
            CollectionAssert.AreEquivalent(sourcecontent, restresponse.RawBytes);
            Assert.AreEqual(ResponseStatus.Completed, restresponse.ResponseStatus);
        }

        [Test]
        public void When_Http_Request_Times_Out_Then_Populate_Exception_Properties()
        {
            var message = "The operation has timed out";

            var webexception = new WebException(message, null, WebExceptionStatus.Timeout, null);

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception);

            Assert.IsNotNull(restresponse.ErrorException);
            Assert.AreEqual(message, restresponse.ErrorMessage);
            Assert.AreEqual(ResponseStatus.Error, restresponse.ResponseStatus);
        }

        [Test]
        public void When_Async_Http_Request_Times_Out_Then_Populate_Exception_Properties()
        {
            var message = "The request was aborted: The request was canceled.";

            var webexception = new WebException(message, null, WebExceptionStatus.RequestCanceled, null);

            var wrapper = new HttpWebRequestWrapper();
            var restresponse = wrapper.ParseWebException(webexception, new TimeOutState() { TimedOut = true });

            Assert.IsNotNull(restresponse.ErrorException);
            Assert.AreEqual(message, restresponse.ErrorMessage);
            Assert.AreEqual(ResponseStatus.TimedOut, restresponse.ResponseStatus);
        }

        [Test]
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

        [Test]
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
    }
#endif
}
