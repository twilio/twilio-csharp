using System;
using NUnit.Framework;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class UsageTests
    {
        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldListUsage()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<UsageResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new UsageResult());
            var client = mockClient.Object;

            client.ListUsage("calls", DateTime.Now, DateTime.Now.AddDays(-7));

            mockClient.Verify(trc => trc.Execute<UsageResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Usage/Records.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            //Assert.AreEqual(3, savedRequest.Parameters.Count);
            //var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            //Assert.IsNotNull(fromParam);
            //Assert.AreEqual(FROM, fromParam.Value);
            //var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            //Assert.IsNotNull(toParam);
            //Assert.AreEqual(TO, toParam.Value);
            //var urlParam = savedRequest.Parameters.Find(x => x.Name == "Url");
            //Assert.IsNotNull(urlParam);
            //Assert.AreEqual(URL, urlParam.Value);

        }
    }
}
