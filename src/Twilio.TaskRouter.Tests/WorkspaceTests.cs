using System;
using System.Threading;
using Moq;
using NUnit.Framework;
using RestSharp;

using Twilio.Api.Tests.Integration;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class WorkspaceTests
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
        public void ShouldAddNewWorkspace()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workspace());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorkspace(friendlyName, "http://www.example.com", "template");

            mockClient.Verify(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var eventCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "EventCallbackUrl");
            Assert.IsNotNull(eventCallbackUrlParam);
            Assert.AreEqual("http://www.example.com", eventCallbackUrlParam.Value);
            var templateParam = savedRequest.Parameters.Find(x => x.Name == "Template");
            Assert.IsNotNull(templateParam);
            Assert.AreEqual("template", templateParam.Value);
        }

        [Test]
        public void ShouldAddNewWorkspaceAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()))
                .Callback<IRestRequest, Action<Workspace>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.AddWorkspace(friendlyName, "http://www.example.com", "template", workspace =>
                {
                    manualResetEvent.Set();
                });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(3, savedRequest.Parameters.Count);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var eventCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "EventCallbackUrl");
            Assert.IsNotNull(eventCallbackUrlParam);
            Assert.AreEqual("http://www.example.com", eventCallbackUrlParam.Value);
            var templateParam = savedRequest.Parameters.Find(x => x.Name == "Template");
            Assert.IsNotNull(templateParam);
            Assert.AreEqual("template", templateParam.Value);
        }

        [Test]
        public void ShouldDeleteWorkspace()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new RestResponse());
            var client = mockClient.Object;

            client.DeleteWorkspace(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
        }

        [Test]
        public void ShouldDeleteWorkspaceAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()))
                .Callback<IRestRequest, Action<IRestResponse>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.DeleteWorkspace(WORKSPACE_SID, status => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync(It.IsAny<IRestRequest>(), It.IsAny<Action<IRestResponse>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.DELETE, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSid = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSid);
            Assert.AreEqual(WORKSPACE_SID, workspaceSid.Value);
        }

        [Test]
        public void ShouldGetWorkspace()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workspace());
            var client = mockClient.Object;

            client.GetWorkspace(WORKSPACE_SID);

            mockClient.Verify(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldGetWorkspaceAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()))
                .Callback<IRestRequest, Action<Workspace>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.GetWorkspace(WORKSPACE_SID, workspace => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(1, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
        }

        [Test]
        public void ShouldListWorkspaces()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkspaceResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkspaceResult());
            var client = mockClient.Object;

            client.ListWorkspaces();

            mockClient.Verify(trc => trc.Execute<WorkspaceResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListWorkspacesAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkspaceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceResult>>()))
                .Callback<IRestRequest, Action<WorkspaceResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);

            client.ListWorkspaces(workspaces => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkspaceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(0, savedRequest.Parameters.Count);
        }

        [Test]
        public void ShouldListWorkspacesUsingFilters()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<WorkspaceResult>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new WorkspaceResult());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListWorkspaces(friendlyName, "afterSid", "beforeSid", 10);

            mockClient.Verify(trc => trc.Execute<WorkspaceResult>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
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
        public void ShouldListWorkspacesUsingFiltersAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<WorkspaceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceResult>>()))
                .Callback<IRestRequest, Action<WorkspaceResult>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.ListWorkspaces(friendlyName, "afterSid", "beforeSid", 10, workspaces => {
                manualResetEvent.Set();
            });

            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<WorkspaceResult>(It.IsAny<IRestRequest>(), It.IsAny<Action<WorkspaceResult>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces", savedRequest.Resource);
            Assert.AreEqual(Method.GET, savedRequest.Method);
            Assert.AreEqual(4, savedRequest.Parameters.Count);
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
        public void ShouldUpdateWorkspace()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()))
                .Callback<IRestRequest>((request) => savedRequest = request)
                .Returns(new Workspace());
            var client = mockClient.Object;
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorkspace(WORKSPACE_SID, friendlyName, "http://www.example.com", "WA123", "WA234");

            mockClient.Verify(trc => trc.Execute<Workspace>(It.IsAny<IRestRequest>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(5, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var eventCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "EventCallbackUrl");
            Assert.IsNotNull(eventCallbackUrlParam);
            Assert.AreEqual("http://www.example.com", eventCallbackUrlParam.Value);
            var defaultActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "DefaultActivitySid");
            Assert.IsNotNull(defaultActivitySidParam);
            Assert.AreEqual("WA123", defaultActivitySidParam.Value);
            var timeoutActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "TimeoutActivitySid");
            Assert.IsNotNull(timeoutActivitySidParam);
            Assert.AreEqual("WA234", timeoutActivitySidParam.Value);
        }

        [Test]
        public void ShouldUpdateWorkspaceAsynchronously()
        {
            IRestRequest savedRequest = null;
            mockClient.Setup(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()))
                .Callback<IRestRequest, Action<Workspace>>((request, action) => savedRequest = request);
            var client = mockClient.Object;
            manualResetEvent = new ManualResetEvent(false);
            var friendlyName = Utilities.MakeRandomFriendlyName();

            client.UpdateWorkspace(WORKSPACE_SID, friendlyName, "http://www.example.com", "template", "WA123", "WA234", workspace => {
                manualResetEvent.Set();
            });
            manualResetEvent.WaitOne(1);

            mockClient.Verify(trc => trc.ExecuteAsync<Workspace>(It.IsAny<IRestRequest>(), It.IsAny<Action<Workspace>>()), Times.Once);
            Assert.IsNotNull(savedRequest);
            Assert.AreEqual("Workspaces/{WorkspaceSid}", savedRequest.Resource);
            Assert.AreEqual(Method.POST, savedRequest.Method);
            Assert.AreEqual(6, savedRequest.Parameters.Count);
            var workspaceSidParam = savedRequest.Parameters.Find(x => x.Name == "WorkspaceSid");
            Assert.IsNotNull(workspaceSidParam);
            Assert.AreEqual(WORKSPACE_SID, workspaceSidParam.Value);
            var friendlyNameParam = savedRequest.Parameters.Find(x => x.Name == "FriendlyName");
            Assert.IsNotNull(friendlyNameParam);
            Assert.AreEqual(friendlyName, friendlyNameParam.Value);
            var eventCallbackUrlParam = savedRequest.Parameters.Find(x => x.Name == "EventCallbackUrl");
            Assert.IsNotNull(eventCallbackUrlParam);
            Assert.AreEqual("http://www.example.com", eventCallbackUrlParam.Value);
            var defaultActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "DefaultActivitySid");
            Assert.IsNotNull(defaultActivitySidParam);
            Assert.AreEqual("WA123", defaultActivitySidParam.Value);
            var timeoutActivitySidParam = savedRequest.Parameters.Find(x => x.Name == "TimeoutActivitySid");
            Assert.IsNotNull(timeoutActivitySidParam);
            Assert.AreEqual("WA234", timeoutActivitySidParam.Value);
        }
    }
}

