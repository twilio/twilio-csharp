using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading;
using System.Linq;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
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
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.InitiateOutboundCall(FROM, TO, URL);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
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
        public void ShouldInitiateOutboundCallWithCallbackEvents()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            var options = new CallOptions();
            options.To = TO;
            options.From = FROM;
            options.Url = URL;
            options.StatusCallback = "http://example.com";
            string[] events = { "initiated", "ringing", "completed" };
            options.StatusCallbackEvents = events;
            client.InitiateOutboundCall(options);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var fromParam = savedRequest.Parameters.Find(x => x.Name == "From");
            Assert.IsNotNull(fromParam);
            Assert.AreEqual(FROM, fromParam.Value);
            var toParam = savedRequest.Parameters.Find(x => x.Name == "To");
            Assert.IsNotNull(toParam);
            Assert.AreEqual(TO, toParam.Value);
            var urlParam = savedRequest.Parameters.Find(x => x.Name == "Url");
            Assert.IsNotNull(urlParam);
            Assert.AreEqual(URL, urlParam.Value);
            var callbackParam = savedRequest.Parameters.Find(x => x.Name == "StatusCallback");
            Assert.IsNotNull(callbackParam);
            Assert.AreEqual("http://example.com", callbackParam.Value);
            var eventParams = savedRequest.Parameters.FindAll(x => x.Name == "StatusCallbackEvent");
            Assert.IsNotNull(eventParams);
            Assert.AreEqual(3, eventParams.Count);
            var values = new System.Collections.Generic.List<string>();
            eventParams.ForEach((p => values.Add(p.Value.ToString())));
            values.Sort();
            Assert.AreEqual(new List<string>() { "completed", "initiated", "ringing" }, values);
        }

        [Test]
        public void ShouldInitiateOutboundCallAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Call>(It.IsAny<IRestRequest>(), It.IsAny<Action<Call>>()))
                .Callback<IRestRequest, Action<Call>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.InitiateOutboundCall(FROM, TO, URL, call =>
            {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Call>(It.IsAny<IRestRequest>(), It.IsAny<Action<Call>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
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
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.GetCall(CALL_SID);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var callSidParam = savedRequest.Parameters.Find(x => x.Name == "CallSid");
            Assert.IsNotNull(callSidParam);
            Assert.AreEqual(CALL_SID, callSidParam.Value);
        }

        [Test]
        public void ShouldListCalls()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new CallResult());
            var client = mockClient.Object;

            client.ListCalls();

            mockClient.Verify(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCallsByNumber()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new CallResult());
            var client = mockClient.Object;

            client.ListCalls(FROM);

            mockClient.Verify(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCallsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<CallResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<CallResult>>()))
                .Callback<IRestRequest, Action<CallResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListCalls(calls => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<CallResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<CallResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListCallsWithFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new CallResult());
            var client = mockClient.Object;
            CallListRequest options = new CallListRequest();
            options.From = FROM;
            options.StartTime = new DateTime();

            client.ListCalls(options);

            mockClient.Verify(trc => trc.Execute<CallResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
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
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;
            var redirectedFriendlyName = Utilities.MakeRandomFriendlyName();
            var redirectUrl = "http://devin.webscript.io/twilioconf?conf=" + redirectedFriendlyName;

            client.RedirectCall(CALL_SID, redirectUrl, "GET");

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
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
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Call());
            var client = mockClient.Object;

            client.HangupCall(CALL_SID, HangupStyle.Completed);

            mockClient.Verify(trc => trc.Execute<Call>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Calls/{CallSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
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
