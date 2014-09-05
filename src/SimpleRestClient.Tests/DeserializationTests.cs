using Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SimpleRestClient.Tests
{
	[TestFixture]
    public class DeserializationTests
    {
        [Test]
        public void When_Response_With_Valid_Json_Needs_Deserialization_Then_Derserialize_To_Type()
        {
            var sourcecontent = "{ \"firstName\":\"Jon\", \"lastName\":\"Doe\"}";
            var sourcebytes = Encoding.UTF8.GetBytes(sourcecontent);

            var sourceuser = new User() { FirstName = "Jon", LastName = "Doe" };

            var client = new RestClient();
            var restrequest = new RestRequest();
            var restresponse = new RestResponse();
            restresponse.ResponseStatus = ResponseStatus.Completed;
            restresponse.RawBytes = sourcebytes;

            var actualuser = client.Deserialize<User>(restrequest, restresponse);

            Assert.IsNull(actualuser.ErrorException);
            Assert.AreEqual(sourceuser, actualuser.Data);
        }

        [Test]
        public void When_Response_With_Invalid_Json_Needs_Deserialization_Then_Derserialize_To_Type()
        {
            var sourcecontent = "{ \"firstName\":'', \"lastName\":\"Doe\"}";
            var sourcebytes = Encoding.UTF8.GetBytes(sourcecontent);

            var client = new RestClient();
            var restrequest = new RestRequest();
            var restresponse = new RestResponse();
            restresponse.ResponseStatus = ResponseStatus.Completed;
            restresponse.RawBytes = sourcebytes;

            var actualuser = client.Deserialize<User>(restrequest, restresponse);

            Assert.IsNotNull(actualuser.ErrorException);
        }
    }
}
