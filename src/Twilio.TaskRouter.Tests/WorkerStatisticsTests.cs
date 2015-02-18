using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkerStatisticsTests
    {
        private const string WORKER_SID = "WK123";

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
        public void ShouldGetWorkerStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkerStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkerStatistics());
            var client = mockClient.Object;
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkerStatistics(WORKSPACE_SID, WORKER_SID, options);

            mockClient.Verify(trc => trc.Execute<WorkerStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldGetWorkerStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkerStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerStatistics>>()))
                .Callback<IRestRequest, Action<WorkerStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkerStatistics(WORKSPACE_SID, WORKER_SID, options, stats =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkerStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldListWorkersStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkersStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkersStatistics());
            var client = mockClient.Object;

            client.ListWorkersStatistics(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<WorkersStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkersStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkersStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkersStatistics>>()))
                .Callback<IRestRequest, Action<WorkersStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListWorkersStatistics(WORKSPACE_SID, stats => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkersStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkersStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkersStatisticsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkersStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkersStatistics());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();
            var minutes = 10;
            var taskQueueSid = "WQ123";
            var taskQueueName = Utilities.MakeRandomFriendlyName ();
            var options = new WorkersStatisticsRequest();
            options.Minutes = minutes;
            options.FriendlyName = friendlyName;
            options.TaskQueueSid = taskQueueSid;
            options.TaskQueueName = taskQueueName;

            client.ListWorkersStatistics(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<WorkersStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull (friendlyNameParam);
            Assert.AreEqual (friendlyName, friendlyNameParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull (taskQueueSidParam);
            Assert.AreEqual (taskQueueSid, taskQueueSidParam.Value);
            var taskQueueNameParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueName");
            Assert.IsNotNull (taskQueueNameParam);
            Assert.AreEqual (taskQueueName, taskQueueNameParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(minutes, minutesParam.Value);
        }

        [Test]
        public void ShouldListWorkersStatisticsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkersStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkersStatistics>>()))
                .Callback<IRestRequest, Action<WorkersStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new WorkersStatisticsRequest();
            options.FriendlyName = Utilities.MakeRandomFriendlyName();
            options.Minutes = 10;
            options.TaskQueueSid = "WQ123";
            options.TaskQueueName = Utilities.MakeRandomFriendlyName();;

            client.ListWorkersStatistics(WORKSPACE_SID, options, stats => {
                manualResetEvent.Set();
            });

            mockClient.Verify(trc => trc.ExecuteAsync<WorkersStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkersStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull (friendlyNameParam);
            Assert.AreEqual (options.FriendlyName, friendlyNameParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull (taskQueueSidParam);
            Assert.AreEqual (options.TaskQueueSid, taskQueueSidParam.Value);
            var taskQueueNameParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueName");
            Assert.IsNotNull (taskQueueNameParam);
            Assert.AreEqual (options.TaskQueueName, taskQueueNameParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(options.Minutes, minutesParam.Value);
        }
    }
}

