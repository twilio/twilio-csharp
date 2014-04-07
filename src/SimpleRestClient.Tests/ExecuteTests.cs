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
    public class ExecuteTests
    {
        ManualResetEvent manualResetEvent;
        private const string BASE_URL = "http://example.com/";

        [TestMethod]
        public void When_200OK_Response_Is_Returned_Then_Set_Proper_Response_Values()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new RestClient();
            client.BaseUrl = BASE_URL;

            client.WebRequest = new HttpWebRequestWrapper() { 
                Request = new FakeHttpWebRequest(r=>
                    {
                        FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.OK, "OK");
                        return new FakeHttpWebResponse(new MemoryStream());
                    }) 
            };

            var request = new RestRequest();

            var response = client.ExecuteAsync(request, r =>
            {                
                manualResetEvent.Set();

                Console.WriteLine(r.ResponseStatus);
                Console.WriteLine(r.StatusCode);

                Assert.AreEqual(ResponseStatus.Completed, r.ResponseStatus);
                Assert.AreEqual(HttpStatusCode.OK, r.StatusCode);
            });

            manualResetEvent.WaitOne();
        }

        [TestMethod]
        public void When_400BadRequest_Response_Is_Returned_Then_Set_Proper_Response_Values()
        {
            manualResetEvent = new ManualResetEvent(false);

            var sourcecontent = Encoding.ASCII.GetBytes("{\"code\": 90011, \"message\": \"Param From must be specified.\", \"more_info\": \"https://www.twilio.com/docs/errors/90011\", \"status\": 400}");
            var stream = new MemoryStream(sourcecontent);

            var client = new RestClient();
            client.BaseUrl = BASE_URL;

            client.WebRequest = new HttpWebRequestWrapper()
            {
                Request = new FakeHttpWebRequest(r =>
                {                    
                    FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.BadRequest, "BAD REQUEST", (int)sourcecontent.Length);
                    return new FakeHttpWebResponse(stream);
                })
            };

            var request = new RestRequest();

            var response = client.ExecuteAsync(request, r =>
            {
                manualResetEvent.Set();

                Console.WriteLine(r.ResponseStatus);
                Console.WriteLine(r.StatusCode);

                Assert.AreEqual(ResponseStatus.Completed, r.ResponseStatus);
                Assert.AreEqual(HttpStatusCode.BadRequest, r.StatusCode);
                CollectionAssert.AreEquivalent(sourcecontent, r.RawBytes);
            });

            manualResetEvent.WaitOne();
        }

        [TestMethod]
        public void When_Request_Timeout_Causes_Transport_Error_Then_Set_Exception_Properties()
        {
            manualResetEvent = new ManualResetEvent(false);

            var client = new RestClient();
            client.BaseUrl = BASE_URL;
            client.Timeout = 0;

            client.WebRequest = new HttpWebRequestWrapper()
            {
                Request = new FakeHttpWebRequest(r =>
                {
                    FakeHttpWebResponse.InitializeHttpWebResponse(HttpStatusCode.BadRequest, "BAD REQUEST");
                    return new FakeHttpWebResponse(new MemoryStream());
                })
            };

            var request = new RestRequest();

            var response = client.ExecuteAsync(request, r =>
            {
                manualResetEvent.Set();

                Console.WriteLine(r.ErrorMessage);

                Assert.IsNotNull(r.ErrorException);
            });

            manualResetEvent.WaitOne();
        }
       
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
    }
}
