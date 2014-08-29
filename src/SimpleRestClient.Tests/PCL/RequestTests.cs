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
using System.Net.Http;

namespace SimpleRestClient.Tests
{

#if PCL

    [TestClass]
    public class RequestTests
    {
        RestClient client;
        string BASE_URL = "http://example.com";

        public RequestTests()
        {
            client = new RestClient();
            client.BaseUrl = BASE_URL;
        }

        [TestMethod]
        public void When_A_Default_Header_Is_Present_Then_RequestMessage_Includes_This_Header()
        {
            string token = AuthorizationToken;

            client.DefaultParameters.Add(new Parameter() { Name = "Authorization", Value = token, Type = ParameterType.HttpHeader });

            var request = new RestRequest();

            var requestmessage = client.ConfigureRequestMessage(request);

            Assert.IsTrue(requestmessage.Headers.Contains("Authorization"));
            Assert.AreEqual(token, requestmessage.Headers.Authorization.ToString());
        }

        [TestMethod]
        public async Task When_Request_Method_Is_POST_Then_Request_Body_Contains_Encoded_Parameters()
        {
            string body = "Foo=12345&Bar=abcde";
            var sourcebytes = Encoding.UTF8.GetBytes(body);

            var request = new RestRequest();
            request.Method = "POST";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var requestmessage = client.ConfigureRequestMessage(request);
            var actualbytes = await requestmessage.Content.ReadAsByteArrayAsync();

            Assert.IsInstanceOfType(requestmessage.Content, typeof(FormUrlEncodedContent));
            Assert.AreEqual(actualbytes.Length, actualbytes.Length);
            CollectionAssert.AreEquivalent(sourcebytes, actualbytes);            
        }


        [TestMethod]
        public void When_Request_Method_Is_POST_Then_ContentType_Is_FormEncoded()
        {
            var request = new RestRequest();
            request.Method = "POST";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var requestmessage = client.ConfigureRequestMessage(request);

            Assert.AreEqual("application/x-www-form-urlencoded", requestmessage.Content.Headers.ContentType.MediaType);
        }

        [TestMethod]
        public async Task When_Request_Method_Is_GET_Then_Request_Body_Does_Not_Contain_Encoded_Parameters()
        {
            var request = new RestRequest();
            request.Method = "GET";
            request.AddParameter("Foo", "12345");
            request.AddParameter("Bar", "abcde");

            var requestmessage = client.ConfigureRequestMessage(request);

            Assert.IsNull(requestmessage.Content);
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
