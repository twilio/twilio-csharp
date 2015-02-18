using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkflowStatisticsTests
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
        public void ShouldGetWorkflowStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkflowStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkflowStatistics());
            var client = mockClient.Object;
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkflowStatistics(WORKSPACE_SID, WORKFLOW_SID, options);

            mockClient.Verify(trc => trc.Execute<WorkflowStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(WORKFLOW_SID, workflowSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldGetWorkflowStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkflowStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowStatistics>>()))
                .Callback<IRestRequest, Action<WorkflowStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkflowStatistics(WORKSPACE_SID, WORKFLOW_SID, options, stats =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkflowStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkflowStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var workflowSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkflowSid");
            Assert.IsNotNull(workflowSidParam);
            Assert.AreEqual(WORKFLOW_SID, workflowSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }
    }
}

