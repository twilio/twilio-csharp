using System;
using Simple;
using System.Net;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleRestClient.Tests
{

#if FX35

	[TestFixture]
    public class RequestTests
    {
        RestClient client;
        string BASE_URL = "http://example.com";

        public RequestTests()
        {
            client = new RestClient();
            client.BaseUrl = BASE_URL;
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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
