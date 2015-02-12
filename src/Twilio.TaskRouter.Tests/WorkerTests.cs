using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkerTests
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
        public void ShouldAddNewWorker()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Worker());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorker(WORKSPACE_SID, friendlyName, "WA123", "attributes");

            mockClient.Verify(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual("WA123", activitySidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
        }

        [Test]
        public void ShouldAddNewWorkerAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()))
                .Callback<IRestRequest, Action<Worker>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorker(WORKSPACE_SID, friendlyName, "WA123", "attributes", worker =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual("WA123", activitySidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
        }

        [Test]
        public void ShouldDeleteWorker()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteWorker(WORKSPACE_SID, WORKER_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
        }

        [Test]
        public void ShouldDeleteWorkerAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteWorker(WORKSPACE_SID, WORKER_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
        }

        [Test]
        public void ShouldGetWorker()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Worker());
            var client = mockClient.Object;

            client.GetWorker(WORKSPACE_SID, WORKER_SID);

            mockClient.Verify(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
        }

        [Test]
        public void ShouldGetWorkerAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()))
                .Callback<IRestRequest, Action<Worker>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetWorker(WORKSPACE_SID, WORKER_SID, worker => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
        }

        [Test]
        public void ShouldListWorkers()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkerResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkerResult());
            var client = mockClient.Object;

            client.ListWorkers(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<WorkerResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerResult>>()))
                .Callback<IRestRequest, Action<WorkerResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListWorkers(WORKSPACE_SID, workers => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkersUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkerResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkerResult());
            var client = mockClient.Object;
            var options = new WorkerListRequest();
            var friendlyName = Utilities.MakeRandomFriendlyName();
            options.FriendlyName = friendlyName;
            options.ActivityName = "activityName";
            options.ActivitySid = "WA123";
            options.AfterSid = "afterSid";
            options.BeforeSid = "beforeSid";
            options.Count = 10;
            options.TargetWorkersExpression = "expression";
            options.TaskQueueName = "taskQueueName";
            options.TaskQueueSid = "WQ123";

            client.ListWorkers(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<WorkerResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(10, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activityNameParam = savedRequest.Parameters.Find(x => x.Name == "ActivityName");
            Assert.IsNotNull(activityNameParam);
            Assert.AreEqual(options.ActivityName, activityNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(options.ActivitySid, activitySidParam.Value);
            var targetWorkersExpressionParam = savedRequest.Parameters.Find(x => x.Name == "TargetWorkersExpression");
            Assert.IsNotNull(targetWorkersExpressionParam);
            Assert.AreEqual(options.TargetWorkersExpression, targetWorkersExpressionParam.Value);
            var taskQueueNameParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueName");
            Assert.IsNotNull(taskQueueNameParam);
            Assert.AreEqual(options.TaskQueueName, taskQueueNameParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(options.TaskQueueSid, taskQueueSidParam.Value);
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
        public void ShouldListWorkersUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerResult>>()))
                .Callback<IRestRequest, Action<WorkerResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new WorkerListRequest();
            var friendlyName = Utilities.MakeRandomFriendlyName();
            options.FriendlyName = friendlyName;
            options.ActivityName = "activityName";
            options.ActivitySid = "WA123";
            options.AfterSid = "afterSid";
            options.BeforeSid = "beforeSid";
            options.Count = 10;
            options.TargetWorkersExpression = "expression";
            options.TaskQueueName = "taskQueueName";
            options.TaskQueueSid = "WQ123";

            client.ListWorkers(WORKSPACE_SID, options, workers => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkerResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkerResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(10, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activityNameParam = savedRequest.Parameters.Find(x => x.Name == "ActivityName");
            Assert.IsNotNull(activityNameParam);
            Assert.AreEqual(options.ActivityName, activityNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual(options.ActivitySid, activitySidParam.Value);
            var targetWorkersExpressionParam = savedRequest.Parameters.Find(x => x.Name == "TargetWorkersExpression");
            Assert.IsNotNull(targetWorkersExpressionParam);
            Assert.AreEqual(options.TargetWorkersExpression, targetWorkersExpressionParam.Value);
            var taskQueueNameParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueName");
            Assert.IsNotNull(taskQueueNameParam);
            Assert.AreEqual(options.TaskQueueName, taskQueueNameParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(options.TaskQueueSid, taskQueueSidParam.Value);
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
        public void ShouldUpdateWorker()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Worker());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorker(WORKSPACE_SID, WORKER_SID, "WA123", "attributes", friendlyName);

            mockClient.Verify(trc => trc.Execute<Worker>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual("WA123", activitySidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
        }

        [Test]
        public void ShouldUpdateWorkerAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()))
                .Callback<IRestRequest, Action<Worker>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorker(WORKSPACE_SID, WORKER_SID, "WA123", "attributes", friendlyName, worker => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Worker>(It.IsAny<IRestRequest>(), It.IsAny<Action<Worker>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workers/{WorkerSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workerSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkerSid");
            Assert.IsNotNull(workerSidParam);
            Assert.AreEqual(WORKER_SID, workerSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var activitySidParam = savedRequest.Parameters.Find(x => x.Name == "ActivitySid");
            Assert.IsNotNull(activitySidParam);
            Assert.AreEqual("WA123", activitySidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
        }
    }
}

