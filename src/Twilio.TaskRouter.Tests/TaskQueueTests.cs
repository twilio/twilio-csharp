using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class TaskQueueTests
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
        public void ShouldAddNewTaskQueue()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueue());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddTaskQueue(WORKSPACE_SID, friendlyName, "WA123", "WA234", "1==1", 2);

            mockClient.Verify(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentActivitySid");
            Assert.IsNotNull(assignmentActivitySidParam);
            Assert.AreEqual("WA123", assignmentActivitySidParam.Value);
            var reservationActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationActivitySid");
            Assert.IsNotNull(reservationActivitySidParam);
            Assert.AreEqual("WA234", reservationActivitySidParam.Value);
            var targetWorkersParam = savedRequest.Parameters.Find(x => x.Name == "TargetWorkers");
            //Assert.IsNotNull(targetWorkersParam);
            //Assert.AreEqual("1==1", targetWorkersParam.Value);
            var maxReservedWorkersParam = savedRequest.Parameters.Find(x => x.Name == "MaxReservedWorkers");
            Assert.IsNotNull(maxReservedWorkersParam);
            Assert.AreEqual(2, maxReservedWorkersParam.Value);
        }

        [Test]
        public void ShouldAddNewTaskQueueAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()))
                .Callback<IRestRequest, Action<TaskQueue>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddTaskQueue(WORKSPACE_SID, friendlyName, "WA123", "WA234", taskQueue =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentActivitySid");
            Assert.IsNotNull(assignmentActivitySidParam);
            Assert.AreEqual("WA123", assignmentActivitySidParam.Value);
            var reservationActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationActivitySid");
            Assert.IsNotNull(reservationActivitySidParam);
            Assert.AreEqual("WA234", reservationActivitySidParam.Value);
        }

        [Test]
        public void ShouldDeleteTaskQueue()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
        }

        [Test]
        public void ShouldDeleteTaskQueueAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
        }

        [Test]
        public void ShouldGetTaskQueue()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueue());
            var client = mockClient.Object;

            client.GetTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID);

            mockClient.Verify(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
        }

        [Test]
        public void ShouldGetTaskQueueAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()))
                .Callback<IRestRequest, Action<TaskQueue>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID, taskQueue => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
        }

        [Test]
        public void ShouldListTaskQueues()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueueResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueueResult());
            var client = mockClient.Object;

            client.ListTaskQueues(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<TaskQueueResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTaskQueuesAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueueResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueResult>>()))
                .Callback<IRestRequest, Action<TaskQueueResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListTaskQueues(WORKSPACE_SID, taskQueues => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueueResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTaskQueuesUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueueResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueueResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListTaskQueues(WORKSPACE_SID, friendlyName, "evaluateWorkerAttributes", "afterSid", "beforeSid", 10);

            mockClient.Verify(trc => trc.Execute<TaskQueueResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var evaluateWorkerAttributesParam = savedRequest.Parameters.Find(x => x.Name == "EvaluateWorkerAttributes");
            Assert.IsNotNull(evaluateWorkerAttributesParam);
            Assert.AreEqual("evaluateWorkerAttributes", evaluateWorkerAttributesParam.Value);
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
        public void ShouldListTaskQueuesUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueueResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueResult>>()))
                .Callback<IRestRequest, Action<TaskQueueResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListTaskQueues(WORKSPACE_SID, friendlyName, "evaluateWorkerAttributes", "afterSid", "beforeSid", 10, taskQueues => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueueResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueueResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var evaluateWorkerAttributesParam = savedRequest.Parameters.Find(x => x.Name == "EvaluateWorkerAttributes");
            Assert.IsNotNull(evaluateWorkerAttributesParam);
            Assert.AreEqual("evaluateWorkerAttributes", evaluateWorkerAttributesParam.Value);
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
        public void ShouldUpdateTaskQueue()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskQueue());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID, friendlyName, "WA123", "WA234", "1==1", 5);

            mockClient.Verify(trc => trc.Execute<TaskQueue>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentActivitySid");
            Assert.IsNotNull(assignmentActivitySidParam);
            Assert.AreEqual("WA123", assignmentActivitySidParam.Value);
            var reservationActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationActivitySid");
            Assert.IsNotNull(reservationActivitySidParam);
            Assert.AreEqual("WA234", reservationActivitySidParam.Value);
            var targetWorkersParam = savedRequest.Parameters.Find(x => x.Name == "TargetWorkers");
            Assert.IsNotNull(targetWorkersParam);
            Assert.AreEqual("1==1", targetWorkersParam.Value);
            var maxReservedWorkersParam = savedRequest.Parameters.Find(x => x.Name == "MaxReservedWorkers");
            Assert.IsNotNull(maxReservedWorkersParam);
            Assert.AreEqual(5, maxReservedWorkersParam.Value);
        }

        [Test]
        public void ShouldUpdateTaskQueueAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()))
                .Callback<IRestRequest, Action<TaskQueue>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateTaskQueue(WORKSPACE_SID, TASK_QUEUE_SID, friendlyName, "WA123", "WA234", "targetWorkers", taskQueue => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskQueue>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskQueue>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskQueueSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskQueueSid");
            Assert.IsNotNull(taskQueueSidParam);
            Assert.AreEqual(TASK_QUEUE_SID, taskQueueSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentActivitySid");
            Assert.IsNotNull(assignmentActivitySidParam);
            Assert.AreEqual("WA123", assignmentActivitySidParam.Value);
            var reservationActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "ReservationActivitySid");
            Assert.IsNotNull(reservationActivitySidParam);
            Assert.AreEqual("WA234", reservationActivitySidParam.Value);
            var targetWorkersParam = savedRequest.Parameters.Find(x => x.Name == "TargetWorkers");
            Assert.IsNotNull(targetWorkersParam);
            Assert.AreEqual("targetWorkers", targetWorkersParam.Value);
        }
    }
}

