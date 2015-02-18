using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkspaceStatisticsTests
    {
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
        public void ShouldGetWorkspaceStatistics()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkspaceStatistics>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkspaceStatistics());
            var client = mockClient.Object;
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkspaceStatistics(WORKSPACE_SID, options);

            mockClient.Verify(trc => trc.Execute<WorkspaceStatistics>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }

        [Test]
        public void ShouldGetWorkspaceStatisticsAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkspaceStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceStatistics>>()))
                .Callback<IRestRequest, Action<WorkspaceStatistics>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var options = new StatisticsRequest();
            options.Minutes = 10;

            client.GetWorkspaceStatistics(WORKSPACE_SID, options, stats =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkspaceStatistics>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceStatistics>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}/Statistics", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(2, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull (workspaceSidParam);
            Assert.AreEqual (WORKSPACE_SID, workspaceSidParam.Value);
            var minutesParam = savedRequest.Parameters.Find(x => x.Name == "Minutes");
            Assert.IsNotNull(minutesParam);
            Assert.AreEqual(10, minutesParam.Value);
        }
    }
}

