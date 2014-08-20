using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestClient.Tests.PCL
{

#if PCL

    [TestClass]
    public class ResponseTests
    {
        RestClient client;
        string BASE_URL = "http://example.com";

        public ResponseTests()
        {
            client = new RestClient();
            client.BaseUrl = BASE_URL;
        }

        [TestMethod]
        public async Task When_200OK_Response_Is_Returned_Then_Set_Proper_Response_Values()
        {
            var client = new RestClient();
            client.BaseUrl = BASE_URL;
            client.MessageHandler = new FakeHttpMessageHandler(HttpStatusCode.OK);

            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);
            
            Console.WriteLine(response.ResponseStatus);
            Console.WriteLine(response.StatusCode);

            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // Test protocol error handling
        [TestMethod]
        public async Task When_400BadRequest_Response_Is_Returned_Then_Set_Proper_Response_Values()
        {
            var sourcecontent = "{\"code\": 90011, \"message\": \"Param From must be specified.\", \"more_info\": \"https://www.twilio.com/docs/errors/90011\", \"status\": 400}";

            var client = new RestClient();
            client.BaseUrl = BASE_URL;

            client.MessageHandler = new FakeHttpMessageHandler(HttpStatusCode.BadRequest, sourcecontent);

            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);
                
            Console.WriteLine(response.ResponseStatus);
            Console.WriteLine(response.StatusCode);

            Assert.AreEqual(ResponseStatus.Completed, response.ResponseStatus);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            CollectionAssert.AreEquivalent(Encoding.ASCII.GetBytes(sourcecontent), response.RawBytes);
        }

        // Test transport error handling
        [TestMethod]
        public async Task When_Request_Timeout_Causes_Transport_Error_Then_Set_Exception_Properties()
        {
            var client = new RestClient();
            client.BaseUrl = BASE_URL;
            client.Timeout = 1;

            client.MessageHandler = new FakeHttpMessageHandler(HttpStatusCode.BadRequest);

            var request = new RestRequest();

            var response = await client.ExecuteAsync(request);
            Console.WriteLine(response.ErrorMessage);

            Assert.IsNotNull(response.ErrorException);
        }

        //Test aborting the request
        //[TestMethod]
        //public void When_Async_Http_Request_Is_Aborted_Then_Populate_Exception_Properties()
        //{
        //    var message = "The request was aborted: The request was canceled.";

        //    var webexception = new WebException(message, null, WebExceptionStatus.RequestCanceled, null);

        //    var wrapper = new HttpWebRequestWrapper();
        //    var restresponse = wrapper.ParseWebException(webexception, new TimeOutState() { TimedOut = false });

        //    Assert.IsNotNull(restresponse.ErrorException);
        //    Assert.AreEqual(message, restresponse.ErrorMessage);
        //    Assert.AreEqual(ResponseStatus.Aborted, restresponse.ResponseStatus);
        //}
    }

#endif
}
