using System.Net;
using NUnit.Framework;
using Twilio.Base;

#if !NET35
using System.Net.Http;
#endif

namespace Twilio.Tests.Base
{
    [TestFixture]
    public class TwilioResponseTest
    {
        // Mock resource class for testing
        private class MockResource : Resource
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

#if !NET35
        [Test]
        public void TestTwilioResponseWithResource()
        {
            var resource = new MockResource { Id = "123", Name = "Test" };
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new TwilioResponse<MockResource>(resource, headers, statusCode);

            Assert.AreEqual(resource, response.Data);
            Assert.AreEqual(headers, response.Headers);
            Assert.AreEqual(statusCode, response.StatusCode);
        }

        [Test]
        public void TestTwilioResponseWithBool()
        {
            var data = true;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.NoContent;

            var response = new TwilioResponse<bool>(data, headers, statusCode);

            Assert.AreEqual(true, response.Data);
            Assert.AreEqual(headers, response.Headers);
            Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Test]
        public void TestTwilioResponseWithString()
        {
            var data = "test string";
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new TwilioResponse<string>(data, headers, statusCode);

            Assert.AreEqual("test string", response.Data);
            Assert.AreEqual(headers, response.Headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void TestTwilioResponseWithNullData()
        {
            MockResource data = null;
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.NotFound;

            var response = new TwilioResponse<MockResource>(data, headers, statusCode);

            Assert.IsNull(response.Data);
            Assert.AreEqual(headers, response.Headers);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Test]
        public void TestTwilioResponseWithDifferentStatusCodes()
        {
            var resource = new MockResource { Id = "456", Name = "Created" };
            var headers = new HttpResponseMessage().Headers;

            var createdResponse = new TwilioResponse<MockResource>(resource, headers, HttpStatusCode.Created);
            Assert.AreEqual(HttpStatusCode.Created, createdResponse.StatusCode);

            var acceptedResponse = new TwilioResponse<MockResource>(resource, headers, HttpStatusCode.Accepted);
            Assert.AreEqual(HttpStatusCode.Accepted, acceptedResponse.StatusCode);

            var badRequestResponse = new TwilioResponse<MockResource>(resource, headers, HttpStatusCode.BadRequest);
            Assert.AreEqual(HttpStatusCode.BadRequest, badRequestResponse.StatusCode);
        }

        [Test]
        public void TestTwilioResponseDataIsReadOnly()
        {
            var resource = new MockResource { Id = "789", Name = "ReadOnly" };
            var headers = new HttpResponseMessage().Headers;
            var statusCode = HttpStatusCode.OK;

            var response = new TwilioResponse<MockResource>(resource, headers, statusCode);

            // Verify that Data property returns the same instance
            Assert.AreSame(resource, response.Data);

            // Modify the original resource
            resource.Name = "Modified";

            // The response should reflect the change since it holds a reference
            Assert.AreEqual("Modified", response.Data.Name);
        }
#endif
    }
}
