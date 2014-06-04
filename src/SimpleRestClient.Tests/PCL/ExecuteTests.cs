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
    public class ExecuteTests
    {
        RestClient client;
        string BASE_URL = "http://example.com";

        public ExecuteTests()
        {
            client = new RestClient();
            client.BaseUrl = BASE_URL;
        }

        //[TestMethod]
        //public async Task Foo()
        //{
        //    var restrequest = new RestRequest();
        //    restrequest.Method = "POST";

        //    var response = await client.ExecuteAsync(restrequest);

        //    Assert.Inconclusive();
        //}

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


        [TestMethod]
        public void When_A_Default_Header_Is_Present_Then_WebRequest_Includes_This_Header()
        {
            string token = AuthorizationToken;

            client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = token, Type = ParameterType.HttpHeader });

            var request = new RestRequest();
            
            var requestmessage = client.ConfigureRequestMessage(request);

            Assert.IsTrue(requestmessage.Headers.Any(kvp => kvp.Key=="Authorization"));
            Assert.AreEqual(token, requestmessage.Headers.Authorization.ToString());
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

#endif
}
