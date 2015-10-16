using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class TaskTests
    {
        private const string TASK_SID = "WT123";

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
        public void ShouldAddNewTask()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Task());
            var client = mockClient.Object;

            client.AddTask(WORKSPACE_SID, "attributes", "WF123", 60, 5);

            mockClient.Verify(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual("WF123", workflowSidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
            var timeoutParam = savedRequest.Parameters.Find(x => x.Name == "Timeout");
            Assert.IsNotNull(timeoutParam);
            Assert.AreEqual(60, timeoutParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(5, priorityParam.Value);
        }

        [Test]
        public void ShouldAddNewTaskAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()))
                .Callback<IRestRequest, Action<Task>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.AddTask(WORKSPACE_SID, "attributes", "WF123", 60, 5, task =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual("WF123", workflowSidParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
            var timeoutParam = savedRequest.Parameters.Find(x => x.Name == "Timeout");
            Assert.IsNotNull(timeoutParam);
            Assert.AreEqual(60, timeoutParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(5, priorityParam.Value);
        }

        [Test]
        public void ShouldDeleteTask()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteTask(WORKSPACE_SID, TASK_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldDeleteTaskAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteTask(WORKSPACE_SID, TASK_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldGetTask()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Task());
            var client = mockClient.Object;

            client.GetTask(WORKSPACE_SID, TASK_SID);

            mockClient.Verify(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldGetTaskAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()))
                .Callback<IRestRequest, Action<Task>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetTask(WORKSPACE_SID, TASK_SID, task => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
        }

        [Test]
        public void ShouldListTasks()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskResult());
            var client = mockClient.Object;

            client.ListTasks(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<TaskResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTasksAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskResult>>()))
                .Callback<IRestRequest, Action<TaskResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListTasks(WORKSPACE_SID, tasks => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListTasksUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<TaskResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new TaskResult());
            var client = mockClient.Object;
            var options = new TaskListRequest();
            options.AssignmentStatus = "assignmentStatus";
            options.Priority = "10";
            options.WorkflowName = "workflowName";
            options.WorkflowSid = "WF123";
            options.AfterSid = "afterSid";
            options.BeforeSid = "beforeSid";
            options.Count = 10;
            options.TaskQueueName = "taskQueueName";
            options.TaskQueueSid = "WQ123";

            client.ListTasks(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<TaskResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(10, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var assignmentStatusParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentStatus");
            Assert.IsNotNull(assignmentStatusParam);
            Assert.AreEqual(options.AssignmentStatus, assignmentStatusParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(options.Priority, priorityParam.Value);
            var workflowNameParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowName");
            Assert.IsNotNull(workflowNameParam);
            Assert.AreEqual(options.WorkflowName, workflowNameParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(options.WorkflowSid, workflowSidParam.Value);
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
        public void ShouldListTasksUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<TaskResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskResult>>()))
                .Callback<IRestRequest, Action<TaskResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new TaskListRequest();
            options.AssignmentStatus = "assignmentStatus";
            options.Priority = "10";
            options.WorkflowName = "workflowName";
            options.WorkflowSid = "WF123";
            options.AfterSid = "afterSid";
            options.BeforeSid = "beforeSid";
            options.Count = 10;
            options.TaskQueueName = "taskQueueName";
            options.TaskQueueSid = "WQ123";

            client.ListTasks(WORKSPACE_SID, options, tasks => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<TaskResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<TaskResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(10, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var assignmentStatusParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentStatus");
            Assert.IsNotNull(assignmentStatusParam);
            Assert.AreEqual(options.AssignmentStatus, assignmentStatusParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(options.Priority, priorityParam.Value);
            var workflowNameParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowName");
            Assert.IsNotNull(workflowNameParam);
            Assert.AreEqual(options.WorkflowName, workflowNameParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(options.WorkflowSid, workflowSidParam.Value);
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
        public void ShouldUpdateTask()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Task());
            var client = mockClient.Object;

            client.UpdateTask(WORKSPACE_SID, TASK_SID, "attributes", 5, "assignmentStatus", "reason");

            mockClient.Verify(trc => trc.Execute<Task>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var assignmentStatusParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentStatus");
            Assert.IsNotNull(assignmentStatusParam);
            Assert.AreEqual("assignmentStatus", assignmentStatusParam.Value);
            var reasonParam = savedRequest.Parameters.Find(x => x.Name == "Reason");
            Assert.IsNotNull(reasonParam);
            Assert.AreEqual("reason", reasonParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(5, priorityParam.Value);
        }

        [Test]
        public void ShouldUpdateTaskAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()))
                .Callback<IRestRequest, Action<Task>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.UpdateTask(WORKSPACE_SID, TASK_SID, "attributes", 5, "assignmentStatus", "reason", task => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Task>(It.IsAny<IRestRequest>(), It.IsAny<Action<Task>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Tasks/{TaskSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var taskSidParam = savedRequest.Parameters.Find(x => x.Name == "TaskSid");
            Assert.IsNotNull(taskSidParam);
            Assert.AreEqual(TASK_SID, taskSidParam.Value);
            var assignmentStatusParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentStatus");
            Assert.IsNotNull(assignmentStatusParam);
            Assert.AreEqual("assignmentStatus", assignmentStatusParam.Value);
            var reasonParam = savedRequest.Parameters.Find(x => x.Name == "Reason");
            Assert.IsNotNull(reasonParam);
            Assert.AreEqual("reason", reasonParam.Value);
            var attributesParam = savedRequest.Parameters.Find(x => x.Name == "Attributes");
            Assert.IsNotNull(attributesParam);
            Assert.AreEqual("attributes", attributesParam.Value);
            var priorityParam = savedRequest.Parameters.Find(x => x.Name == "Priority");
            Assert.IsNotNull(priorityParam);
            Assert.AreEqual(5, priorityParam.Value);
        }
    }
}

