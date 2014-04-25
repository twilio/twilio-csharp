using System;
using NUnit.Framework;
using System.Threading;
using Moq;
using RestSharp;

namespace Twilio.Api.Tests.Integration
{
    [TestFixture]
    public class ConferenceTests
    {
        private const string CONFERENCE_SID = "CF123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TwilioRestClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TwilioRestClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetConference()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Conference>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Conference());
            var client = mockClient.Object;

            //create a new conference
            client.GetConference(CONFERENCE_SID);

            mockClient.Verify(trc => trc.Execute<Conference>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
        }

        [Test]
        public void ShouldGetConferenceAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Conference>(It.IsAny<IRestRequest>(), It.IsAny<Action<Conference>>()))
                .Callback<IRestRequest, Action<Conference>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            //create a new conference
            client.GetConference(CONFERENCE_SID, conference => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Conference>(It.IsAny<IRestRequest>(), It.IsAny<Action<Conference>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences/{ConferenceSid}.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var conferenceSidParam = savedRequest.Parameters.Find(x => x.Name == "ConferenceSid");
            Assert.IsNotNull(conferenceSidParam);
            Assert.AreEqual(CONFERENCE_SID, conferenceSidParam.Value);
        }

        [Test]
        public void ShouldListConferences()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ConferenceResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ConferenceResult());
            var client = mockClient.Object;

            client.ListConferences();

            mockClient.Verify(trc => trc.Execute<ConferenceResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }
        
        [Test]
        public void ShouldListConferencesAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ConferenceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConferenceResult>>()))
                .Callback<IRestRequest, Action<ConferenceResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListConferences(conferences => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ConferenceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConferenceResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListConferenceUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ConferenceResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ConferenceResult());
            var client = mockClient.Object;
            ConferenceListRequest options = new ConferenceListRequest();

            client.ListConferences(options);

            mockClient.Verify(trc => trc.Execute<ConferenceResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListConferenceAsynchronouslyUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ConferenceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConferenceResult>>()))
                .Callback<IRestRequest, Action<ConferenceResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            ConferenceListRequest options = new ConferenceListRequest();

            client.ListConferences(options, conferences => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ConferenceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ConferenceResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Conferences.json", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

    }
}
