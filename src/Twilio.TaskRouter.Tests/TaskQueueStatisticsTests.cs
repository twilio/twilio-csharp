using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class TaskQueueStatisticsTests
    {
        private const string TASK_QUEUE_SID = "WQ123";

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
        public void ShouldGetTaskQueueStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueueStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueueStatistics());
            var client = mockClient.Object;

            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetTaskQueueStatistics(WORKSPACE_SID, TASK_QUEUE_SID, options);

            mockClient.Verify(trc => trc.Execute<TaskQueueStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldGetTaskQueueStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueueStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatistics>>()))
                .Callback<IRestRequest, Action<TaskQueueStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            var options = new StatisticsRequest();
            options.Minutes = 10;
            client.GetTaskQueueStatistics(WORKSPACE_SID, TASK_QUEUE_SID, options, stats =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueueStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldListTaskQueueStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueueStatisticsResult());
            var client = mockClient.Object;

            client.ListTaskQueuesStatistics(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTaskQueueStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatisticsResult>>()))
                .Callback<IRestRequest, Action<TaskQueueStatisticsResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListTaskQueuesStatistics(WORKSPACE_SID, stats => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatisticsResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTaskQueueStatisticsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueueStatisticsResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();
            var minutes = 10;

            var options = new TaskQueuesStatisticsRequest();
            options.FriendlyName = friendlyName;
            options.Minutes = minutes;
            client.ListTaskQueuesStatistics(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull (friendlyNameParam);
            Assert.AreEqual (friendlyName, friendlyNameParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(minutes, minutesParam.Value);
        }

        [Test]
        public void ShouldListTaskQueueStatisticsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatisticsResult>>()))
                .Callback<IRestRequest, Action<TaskQueueStatisticsResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();
            var minutes = 10;
            var options = new TaskQueuesStatisticsRequest();
            options.FriendlyName = friendlyName;
            options.Minutes = minutes;

            client.ListTaskQueuesStatistics(WORKSPACE_SID, options, stats => {
                manualResetEvent.Set();
            });

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueueStatisticsResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueStatisticsResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull (friendlyNameParam);
            Assert.AreEqual (friendlyName, friendlyNameParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(minutes, minutesParam.Value);
        }
    }
}

