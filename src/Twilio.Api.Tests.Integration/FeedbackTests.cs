using NUnit.Framework;
using System;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class FeedbackTests
    {
        private const string CALL_SID = "CA123";

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void TestCreateFeedback()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Feedback());
            var client = mockClient.Object;

            client.CreateFeedback(CALL_SID, 3, "imperfect-audio");

            mockClient.Verify(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST , savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var qualityScoreParam = savedRequest.Parameters.Find(x => x.Name == "QualityScore");
            Assert.IsNotNull(qualityScoreParam);
            Assert.AreEqual(3, qualityScoreParam.Value);
            var issueParam = savedRequest.Parameters.Find(x => x.Name == "Issue");
            Assert.IsNotNull(issueParam);
            Assert.AreEqual("imperfect-audio", issueParam.Value);
        }

        [Test]
        public void TestDeleteFeedback()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteFeedback(CALL_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE , savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }

        [Test]
        public void TestGetFeedback()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Feedback());
            var client = mockClient.Object;

            client.GetFeedback(CALL_SID);

            mockClient.Verify(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }

        [Test]
        public void TestUpdateFeedback()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Feedback());
            var client = mockClient.Object;

            client.UpdateFeedback(CALL_SID, 3, "imperfect-audio");

            mockClient.Verify(trc => trc.Execute<Feedback>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}/Feedback.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST , savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var qualityScoreParam = savedRequest.Parameters.Find(x => x.Name == "QualityScore");
            Assert.IsNotNull(qualityScoreParam);
            Assert.AreEqual(3, qualityScoreParam.Value);
            var issueParam = savedRequest.Parameters.Find(x => x.Name == "Issue");
            Assert.IsNotNull(issueParam);
            Assert.AreEqual("imperfect-audio", issueParam.Value);
        }
    }
}

