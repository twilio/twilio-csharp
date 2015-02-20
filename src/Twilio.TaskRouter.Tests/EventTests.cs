using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class EventTests
    {
        private const string EVENT_SID = "EV123";

        private const string WORKSPACE_SID = "WS123";

        ManualResetEvent manualResetEvent = null;

        private Mock<TaskRouterClient> mockClient;

        [SetUp]
        public void Setup()
        {
            mockClient = new Mock<TaskRouterClient>(Credentials.AccountSid, Credentials.AuthToken);
            mockClient.CallBase = true;
        }

        [Test]
        public void ShouldGetEvent()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Event>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Event());
            var client = mockClient.Object;

            client.GetEvent(WORKSPACE_SID, EVENT_SID);

            mockClient.Verify(trc => trc.Execute<Event>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events/{EventSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var eventSidParam = savedRequest.Parameters.Find(x => x.Name == "EventSid");
            Assert.IsNotNull(eventSidParam);
            Assert.AreEqual(EVENT_SID, eventSidParam.Value);
        }

        [Test]
        public void ShouldGetEventAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Event>(It.IsAny<IRestRequest>(), It.IsAny<Action<Event>>()))
                .Callback<IRestRequest, Action<Event>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetEvent(WORKSPACE_SID, EVENT_SID, Event => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Event>(It.IsAny<IRestRequest>(), It.IsAny<Action<Event>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events/{EventSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var eventSidParam = savedRequest.Parameters.Find(x => x.Name == "EventSid");
            Assert.IsNotNull(eventSidParam);
            Assert.AreEqual(EVENT_SID, eventSidParam.Value);
        }

        [Test]
        public void ShouldListEvents()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<EventResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new EventResult());
            var client = mockClient.Object;

            client.ListEvents(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<EventResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListEventsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<EventResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<EventResult>>()))
                .Callback<IRestRequest, Action<EventResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListEvents(WORKSPACE_SID, workers => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<EventResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<EventResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListEventsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<EventResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new EventResult());
            var client = mockClient.Object;
            var options = new EventListRequest();
            options.Minutes = 15;
            options.StartDate = DateTime.UtcNow;
            options.EndDate = DateTime.UtcNow;
            options.ResourceSid = "WK123";
            options.EventType = "update";
            options.Count = 10;
            options.PageToken = "pageToken";

            client.ListEvents(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<EventResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(8, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var minutesNameParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesNameParam);
            Assert.AreEqual(options.Minutes, minutesNameParam.Value);
            var startDateNameParam = savedRequest.Parameters.Find(x => x.Name == "StartDate");
            Assert.IsNotNull(startDateNameParam);
            Assert.AreEqual(options.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"), startDateNameParam.Value);
            var endDateNameParam = savedRequest.Parameters.Find(x => x.Name == "EndDate");
            Assert.IsNotNull(endDateNameParam);
            Assert.AreEqual(options.EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"), endDateNameParam.Value);
            var ResourceSidNameParam = savedRequest.Parameters.Find(x => x.Name == "ResourceSid");
            Assert.IsNotNull(ResourceSidNameParam);
            Assert.AreEqual(options.ResourceSid, ResourceSidNameParam.Value);
            var eventTypeNameParam = savedRequest.Parameters.Find(x => x.Name == "EventType");
            Assert.IsNotNull(eventTypeNameParam);
            Assert.AreEqual(options.EventType, eventTypeNameParam.Value);
            var countNameParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countNameParam);
            Assert.AreEqual(options.Count, countNameParam.Value);
            var pageTokenNameParam = savedRequest.Parameters.Find(x => x.Name == "PageToken");
            Assert.IsNotNull(pageTokenNameParam);
            Assert.AreEqual(options.PageToken, pageTokenNameParam.Value);
        }

        [Test]
        public void ShouldListEventsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<EventResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<EventResult>>()))
                .Callback<IRestRequest, Action<EventResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new EventListRequest();
            options.Minutes = 15;
            options.StartDate = DateTime.UtcNow;
            options.EndDate = DateTime.UtcNow;
            options.ResourceSid = "WK123";
            options.EventType = "update";
            options.Count = 10;
            options.PageToken = "pageToken";

            client.ListEvents(WORKSPACE_SID, options, workers => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<EventResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<EventResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Events", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(8, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var minutesNameParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesNameParam);
            Assert.AreEqual(options.Minutes, minutesNameParam.Value);
            var startDateNameParam = savedRequest.Parameters.Find(x => x.Name == "StartDate");
            Assert.IsNotNull(startDateNameParam);
            Assert.AreEqual(options.StartDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"), startDateNameParam.Value);
            var endDateNameParam = savedRequest.Parameters.Find(x => x.Name == "EndDate");
            Assert.IsNotNull(endDateNameParam);
            Assert.AreEqual(options.EndDate.Value.ToString("yyyy-MM-ddTHH:mm:ssK"), endDateNameParam.Value);
            var ResourceSidNameParam = savedRequest.Parameters.Find(x => x.Name == "ResourceSid");
            Assert.IsNotNull(ResourceSidNameParam);
            Assert.AreEqual(options.ResourceSid, ResourceSidNameParam.Value);
            var eventTypeNameParam = savedRequest.Parameters.Find(x => x.Name == "EventType");
            Assert.IsNotNull(eventTypeNameParam);
            Assert.AreEqual(options.EventType, eventTypeNameParam.Value);
            var countNameParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countNameParam);
            Assert.AreEqual(options.Count, countNameParam.Value);
            var pageTokenNameParam = savedRequest.Parameters.Find(x => x.Name == "PageToken");
            Assert.IsNotNull(pageTokenNameParam);
            Assert.AreEqual(options.PageToken, pageTokenNameParam.Value);
        }
    }
}

