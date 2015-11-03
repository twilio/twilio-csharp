using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class ActivityTests
    {
        private const string ACTIVITY_SID = "WA123";

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
        public void ShouldAddNewActivity()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Activity());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddActivity(WORKSPACE_SID, friendlyName, true);

            mockClient.Verify(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var availableParam = savedRequest.Parameters.Find(x => x.Name == "Available");
            Assert.IsNotNull(availableParam);
            Assert.AreEqual(true, availableParam.Value);
        }

        [Test]
        public void ShouldAddNewActivityAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()))
                .Callback<IRestRequest, Action<Activity>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddActivity(WORKSPACE_SID, friendlyName, true, activity =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var availableParam = savedRequest.Parameters.Find(x => x.Name == "Available");
            Assert.IsNotNull(availableParam);
            Assert.AreEqual(true, availableParam.Value);
        }

        [Test]
        public void ShouldDeleteActivity()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteActivity(WORKSPACE_SID, ACTIVITY_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
        }

        [Test]
        public void ShouldDeleteActivityAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteActivity(WORKSPACE_SID, ACTIVITY_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
        }

        [Test]
        public void ShouldGetActivity()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Activity());
            var client = mockClient.Object;

            client.GetActivity(WORKSPACE_SID, ACTIVITY_SID);

            mockClient.Verify(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
        }

        [Test]
        public void ShouldGetActivityAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()))
                .Callback<IRestRequest, Action<Activity>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetActivity(WORKSPACE_SID, ACTIVITY_SID, activity => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
        }

        [Test]
        public void ShouldListActivities()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ActivityResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ActivityResult());
            var client = mockClient.Object;

            client.ListActivities(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<ActivityResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListActivitiesAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ActivityResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ActivityResult>>()))
                .Callback<IRestRequest, Action<ActivityResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListActivities(WORKSPACE_SID, activities => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ActivityResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ActivityResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListActivitiesUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<ActivityResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new ActivityResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListActivities(WORKSPACE_SID, true, friendlyName, "afterSid", "beforeSid", 10);

            mockClient.Verify(trc => trc.Execute<ActivityResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var availableParam = savedRequest.Parameters.Find(x => x.Name == "Available");
            Assert.IsNotNull(availableParam);
            Assert.AreEqual(true, availableParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var afterSidParam = savedRequest.Parameters.Find(x => x.Name == "AfterSid");
            Assert.IsNotNull(afterSidParam);
            Assert.AreEqual("afterSid", afterSidParam.Value);
            var beforeSidParam = savedRequest.Parameters.Find(x => x.Name == "BeforeSid");
            Assert.IsNotNull(beforeSidParam);
            Assert.AreEqual("beforeSid", beforeSidParam.Value);
            var countSidParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countSidParam);
            Assert.AreEqual(10, countSidParam.Value);
        }

        [Test]
        public void ShouldListActivitiesUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<ActivityResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ActivityResult>>()))
                .Callback<IRestRequest, Action<ActivityResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListActivities(WORKSPACE_SID, true, friendlyName, "afterSid", "beforeSid", 10, activities => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<ActivityResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<ActivityResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var availableParam = savedRequest.Parameters.Find(x => x.Name == "Available");
            Assert.IsNotNull(availableParam);
            Assert.AreEqual(true, availableParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var afterSidParam = savedRequest.Parameters.Find(x => x.Name == "AfterSid");
            Assert.IsNotNull(afterSidParam);
            Assert.AreEqual("afterSid", afterSidParam.Value);
            var beforeSidParam = savedRequest.Parameters.Find(x => x.Name == "BeforeSid");
            Assert.IsNotNull(beforeSidParam);
            Assert.AreEqual("beforeSid", beforeSidParam.Value);
            var countSidParam = savedRequest.Parameters.Find(x => x.Name == "PageSize");
            Assert.IsNotNull(countSidParam);
            Assert.AreEqual(10, countSidParam.Value);
        }

        [Test]
        public void ShouldUpdateActivity()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Activity());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateActivity(WORKSPACE_SID, ACTIVITY_SID, friendlyName);

            mockClient.Verify(trc => trc.Execute<Activity>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }

        [Test]
        public void ShouldUpdateActivityAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()))
                .Callback<IRestRequest, Action<Activity>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateActivity(WORKSPACE_SID, ACTIVITY_SID, friendlyName, activity => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Activity>(It.IsAny<IRestRequest>(), It.IsAny<Action<Activity>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Activities/{ActivitySid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(ACTIVITY_SID, activitySidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
        }
    }
}

