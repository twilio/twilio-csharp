using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;
using System.Collections.Generic;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkflowTests
    {
        private const string WORKFLOW_SID = "WF123";

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
        public void ShouldSerializeWorkflowDefaultFilterConfiguration()
        {
            var workFlowConfiguration = new WorkflowConfiguration();
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var result = workFlowConfiguration.ToString();

            Assert.AreEqual("{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[]}", result);
        }

        [Test]
        public void ShouldDeserializeWorkflowDefaultFilterConfiguration()
        {
            var workFlow = new Workflow();
            workFlow.Configuration = "{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[]}";

            var workFlowConfiguration = new WorkflowConfiguration();
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var config = workFlow.WorkflowConfiguration;

            Assert.AreEqual(workFlowConfiguration.ToString(), config.ToString());
        }

        [Test]
        public void ShouldDeserializeComplexWorkflowConfiguration3()
        {
            var workFlow = new Workflow();
            workFlow.Configuration = "{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[{\"expression\":\"1==1\",\"friendly_name\":\"Prioritizing Filter\",\"targets\":[{\"priority\":\"1\",\"queue\":\"WQccc\",\"timeout\":\"300\"}]}]}";

            var workFlowConfiguration = new WorkflowConfiguration();
            var filter = new Filter
            {
                FriendlyName = "Prioritizing Filter",
                Expression = "1==1",
                Targets = new List<Target>() { 
                    new Target { 
                        Queue="WQccc",
                        Priority="1",
                        Timeout="300"
                    }
                }
            };

            workFlowConfiguration.Filters.Add(filter);
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var config = workFlow.WorkflowConfiguration;

            Assert.AreEqual(workFlowConfiguration.ToString(), config.ToString());
        }

        [Test]
        public void ShouldSerializeComplexWorkflowConfiguration1()
        {
            var workFlowConfiguration = new WorkflowConfiguration();
            var filter = new Filter
            {
                FriendlyName = "Prioritizing Filter",
                Expression = "1==1",
                Targets = new List<Target>() { 
                    new Target { 
                        Queue="WQccc",
                        Priority="1",
                        Timeout="300"
                    }
                }
            };

            workFlowConfiguration.Filters.Add(filter);
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var result = workFlowConfiguration.ToString();
            Assert.AreEqual("{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[{\"expression\":\"1==1\",\"friendly_name\":\"Prioritizing Filter\",\"targets\":[{\"priority\":\"1\",\"queue\":\"WQccc\",\"timeout\":\"300\"}]}]}", result);
        }

        [Test]
        public void ShouldSerializeComplexWorkflowConfigurationWithFilterFriendlyName()
        {
            var workFlowConfiguration = new WorkflowConfiguration();
            var filter = new Filter
            {
                FilterFriendlyName = "Prioritizing Filter",
                Expression = "1==1",
                Targets = new List<Target>() { 
                    new Target { 
                        Queue="WQccc",
                        Priority="1",
                        Timeout="300"
                    }
                }
            };

            workFlowConfiguration.Filters.Add(filter);
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var result = workFlowConfiguration.ToString();

            Assert.AreEqual("{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[{\"expression\":\"1==1\",\"friendly_name\":\"Prioritizing Filter\",\"targets\":[{\"priority\":\"1\",\"queue\":\"WQccc\",\"timeout\":\"300\"}]}]}", result);
        }

        [Test]
        public void ShouldDeserializeComplexWorkflowConfigurationWithFilterFriendlyName()
        {
            var workFlow = new Workflow();
            workFlow.Configuration = "{\"default_filter\":{\"queue\":\"WQccc\"},\"filters\":[{\"expression\":\"1==1\",\"filter_friendly_name\":\"Prioritizing Filter\",\"targets\":[{\"priority\":\"1\",\"queue\":\"WQccc\",\"timeout\":\"300\"}]}]}";

            var workFlowConfiguration = new WorkflowConfiguration();
            var filter = new Filter
            {
                FriendlyName = "Prioritizing Filter",
                Expression = "1==1",
                Targets = new List<Target>() { 
                    new Target { 
                        Queue="WQccc",
                        Priority="1",
                        Timeout="300"
                    }
                }
            };

            workFlowConfiguration.Filters.Add(filter);
            workFlowConfiguration.DefaultFilter = new Target() { Queue = "WQccc" };

            var config = workFlow.WorkflowConfiguration;

            Assert.AreEqual(workFlowConfiguration.ToString(), config.ToString());
        }

        [Test]
        public void ShouldAddNewWorkflow()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workflow());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorkflow(WORKSPACE_SID, friendlyName, "configuration", "http://www.example.com/assignment", "http://www.example.com/fallback", 60);

            mockClient.Verify(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentCallbackUrl");
            Assert.IsNotNull(assignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/assignment", assignmentCallbackUrlParam.Value);
            var fallbackAssignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "FallbackAssignmentCallbackUrl");
            Assert.IsNotNull(fallbackAssignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/fallback", fallbackAssignmentCallbackUrlParam.Value);
            var taskReservationTimeoutParam = savedRequest.Parameters.Find(x => x.Name == "TaskReservationTimeout");
            Assert.IsNotNull(taskReservationTimeoutParam);
            Assert.AreEqual(60, taskReservationTimeoutParam.Value);
        }

        [Test]
        public void ShouldAddNewWorkflowAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()))
                .Callback<IRestRequest, Action<Workflow>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorkflow(WORKSPACE_SID, friendlyName, "configuration", "http://www.example.com/assignment", "http://www.example.com/fallback", 60, workflow =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentCallbackUrl");
            Assert.IsNotNull(assignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/assignment", assignmentCallbackUrlParam.Value);
            var fallbackAssignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "FallbackAssignmentCallbackUrl");
            Assert.IsNotNull(fallbackAssignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/fallback", fallbackAssignmentCallbackUrlParam.Value);
            var taskReservationTimeoutParam = savedRequest.Parameters.Find(x => x.Name == "TaskReservationTimeout");
            Assert.IsNotNull(taskReservationTimeoutParam);
            Assert.AreEqual(60, taskReservationTimeoutParam.Value);
        }

        [Test]
        public void ShouldDeleteWorkflow()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteWorkflow(WORKSPACE_SID, WORKFLOW_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var workflowSid = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSid);
            Assert.AreEqual(WORKFLOW_SID, workflowSid.Value);
        }

        [Test]
        public void ShouldDeleteWorkflowAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteWorkflow(WORKSPACE_SID, WORKFLOW_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
            var workflowSid = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSid);
            Assert.AreEqual(WORKFLOW_SID, workflowSid.Value);
        }

        [Test]
        public void ShouldGetWorkflow()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workflow());
            var client = mockClient.Object;

            client.GetWorkflow(WORKSPACE_SID, WORKFLOW_SID);

            mockClient.Verify(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSid = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSid);
            Assert.AreEqual(WORKFLOW_SID, workflowSid.Value);
        }

        [Test]
        public void ShouldGetWorkflowAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()))
                .Callback<IRestRequest, Action<Workflow>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetWorkflow(WORKSPACE_SID, WORKFLOW_SID, workflow => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSid = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSid);
            Assert.AreEqual(WORKFLOW_SID, workflowSid.Value);
        }

        [Test]
        public void ShouldListWorkflows()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkflowResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkflowResult());
            var client = mockClient.Object;

            client.ListWorkflows(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<WorkflowResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkflowsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkflowResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowResult>>()))
                .Callback<IRestRequest, Action<WorkflowResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListWorkflows(WORKSPACE_SID, workflows => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkflowResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkflowsUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkflowResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkflowResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListWorkflows(WORKSPACE_SID, friendlyName, "afterSid", "beforeSid", 10);

            mockClient.Verify(trc => trc.Execute<WorkflowResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
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
        public void ShouldListWorkflowsUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkflowResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowResult>>()))
                .Callback<IRestRequest, Action<WorkflowResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListWorkflows(WORKSPACE_SID, friendlyName, "afterSid", "beforeSid", 10, workflows => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkflowResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
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
        public void ShouldUpdateWorkflow()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workflow());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorkflow(WORKSPACE_SID, WORKFLOW_SID, friendlyName, "http://www.example.com/assignment", "http://www.example.com/fallback", "configuration", 60);

            mockClient.Verify(trc => trc.Execute<Workflow>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(WORKFLOW_SID, workflowSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentCallbackUrl");
            Assert.IsNotNull(assignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/assignment", assignmentCallbackUrlParam.Value);
            var fallbackAssignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "FallbackAssignmentCallbackUrl");
            Assert.IsNotNull(fallbackAssignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/fallback", fallbackAssignmentCallbackUrlParam.Value);
            var taskReservationTimeoutParam = savedRequest.Parameters.Find(x => x.Name == "TaskReservationTimeout");
            Assert.IsNotNull(taskReservationTimeoutParam);
            Assert.AreEqual(60, taskReservationTimeoutParam.Value);
        }

        [Test]
        public void ShouldUpdateWorkflowAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()))
                .Callback<IRestRequest, Action<Workflow>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorkflow(WORKSPACE_SID, WORKFLOW_SID, friendlyName, "http://www.example.com/assignment", "http://www.example.com/fallback", "configuration", 60, workflow => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workflow>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workflow>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(7, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(WORKFLOW_SID, workflowSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var assignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "AssignmentCallbackUrl");
            Assert.IsNotNull(assignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/assignment", assignmentCallbackUrlParam.Value);
            var fallbackAssignmentCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "FallbackAssignmentCallbackUrl");
            Assert.IsNotNull(fallbackAssignmentCallbackUrlParam);
            Assert.AreEqual("http://www.example.com/fallback", fallbackAssignmentCallbackUrlParam.Value);
            var taskReservationTimeoutParam = savedRequest.Parameters.Find(x => x.Name == "TaskReservationTimeout");
            Assert.IsNotNull(taskReservationTimeoutParam);
            Assert.AreEqual(60, taskReservationTimeoutParam.Value);
        }
    }
}

