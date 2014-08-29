using System;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using Moq;
using Simple;

namespace Twilio.Api.Tests
{
    [TestFixture]
    public class CallTests
    {
        private const string CALL_SID = "CA123";

        private const string FROM = "+15005550006";

        private const string TO = "+13144586142";

        private const string URL = "http://www.example.com/phone/";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldInitiateOutboundCall()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.InitiateOutboundCall(FROM, TO, URL);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(FROM, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(TO, toParam.Value);
            var urlParam = savedRequest.Parameters.Find(x => x.Name == "Url");
            Assert.IsNotNull(urlParam);
            Assert.AreEqual(URL, urlParam.Value);
        }

        [Test]
        public void ShouldInitiateOutboundCallAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Call>(It.IsAny<RestRequest>(), It.IsAny<Action<Call>>()))
                .Callback<RestRequest, Action<Call>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.InitiateOutboundCall(FROM, TO, URL, call =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Call>(It.IsAny<RestRequest>(), It.IsAny<Action<Call>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(FROM, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(TO, toParam.Value);
            var urlParam = savedRequest.Parameters.Find(x => x.Name == "Url");
            Assert.IsNotNull(urlParam);
            Assert.AreEqual(URL, urlParam.Value);
        }

        [Test]
        public void ShouldGetCall()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.GetCall(CALL_SID);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }

        [Test]
        public void ShouldListCalls()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CallResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new CallResult());
            var client = mockClient.Object;

            client.ListCalls();

            mockClient.Verify(trc => trc.Execute<CallResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCallsAsynchronously()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<CallResult>(It.IsAny<RestRequest>(), It.IsAny<Action<CallResult>>()))
                .Callback<RestRequest, Action<CallResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListCalls(calls =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<CallResult>(It.IsAny<RestRequest>(), It.IsAny<Action<CallResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCallsWithFilters()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CallResult>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new CallResult());
            var client = mockClient.Object;
            CallListRequest options = new CallListRequest();
            options.From = FROM;
            options.StartTime = new DateTime();

            client.ListCalls(options);

            mockClient.Verify(trc => trc.Execute<CallResult>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual("GET", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(FROM, fromParam.Value);
            var startTimeParam = savedRequest.Parameters.Find(x => x.Name == "StartTime");
            Assert.IsNotNull(startTimeParam);
            Assert.AreEqual(options.StartTime.Value.ToString("yyyy-MM-dd"), startTimeParam.Value);
        }

        [Test]
        public void ShouldRedirectCall()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;
            var redirectedFriendlyName = Utilities.MakeRandomFriendlyName();
            var redirectUrl = "http://devin.webscript.io/twilioconf?conf=" + redirectedFriendlyName;

            client.RedirectCall(CALL_SID, redirectUrl, "GET");

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var urlParam = savedRequest.Parameters.Find(x => x.Name == "Url");
            Assert.IsNotNull(urlParam);
            Assert.AreEqual(redirectUrl, urlParam.Value);
            var methodParam = savedRequest.Parameters.Find(x => x.Name == "Method");
            Assert.IsNotNull(methodParam);
            Assert.AreEqual("GET", methodParam.Value);
        }

        [Test]
        public void ShouldHangupCall()
        {
            RestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<RestRequest>()))
                .Callback<RestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.HangupCall(CALL_SID, HangupStyle.Completed);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<RestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual("POST", savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
            var statusParam = savedRequest.Parameters.Find(x => x.Name == "Status");
            Assert.IsNotNull(statusParam);
            Assert.AreEqual(HangupStyle.Completed.ToString().ToLower(), statusParam.Value);
        }
    }
}