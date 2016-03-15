using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Create a new workspace.
        /// </summary>
        /// <param name="friendlyName">Friendly name.</param>
        /// <param name="eventCallbackUrl">Event callback URL.</param>
        /// <param name="template">Template.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddWorkspace(string friendlyName, string eventCallbackUrl, string template, Action<Workspace> callback)
        {
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces";

            request.AddParameter("FriendlyName", friendlyName);

            if (eventCallbackUrl.HasValue())
                request.AddParameter("EventCallbackUrl", eventCallbackUrl);
            if (template.HasValue())
                request.AddParameter("Template", template);

            ExecuteAsync<Workspace>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Deletea a workspace.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteWorkspace(string workspaceSid, Action<DeleteStatus> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Retrieve the details for a workspace instance. Makes a GET request to a Workspace Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkspace(string workspaceSid, Action<Workspace> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            ExecuteAsync<Workspace>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List workspaces.
        /// </summary>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkspaces(Action<WorkspaceResult> callback)
        {
            ListWorkspaces(null, null, null, null, callback);
        }

        /// <summary>
        /// List workspaces with filters
        /// </summary>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkspaces(string friendlyName, string afterSid, string beforeSid, int? count, Action<WorkspaceResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Workspaces";

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (afterSid.HasValue())
                request.AddParameter("AfterSid", afterSid);
            if (beforeSid.HasValue())
                request.AddParameter("BeforeSid", beforeSid);
            if (count.HasValue)
                request.AddParameter("PageSize", count.Value);

            ExecuteAsync<WorkspaceResult>(request, callback);
        }

        /// <summary>
        /// Updatea a workspace.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Optional friendly name.</param>
        /// <param name="eventCallbackUrl">Optional event callback URL.</param>
        /// <param name="template">Optional template.</param>
        /// <param name="defaultActivitySid">Optional default activity sid.</param>
        /// <param name="timeoutActivitySid">Optional timeout activity sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateWorkspace(string workspaceSid, string friendlyName, string eventCallbackUrl, string template, string defaultActivitySid, string timeoutActivitySid, Action<Workspace> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (eventCallbackUrl.HasValue())
                request.AddParameter("EventCallbackUrl", eventCallbackUrl);
            if (template.HasValue())
                request.AddParameter("Template", template);
            if (defaultActivitySid.HasValue())
                request.AddParameter("DefaultActivitySid", defaultActivitySid);
            if (timeoutActivitySid.HasValue())
                request.AddParameter("TimeoutActivitySid", timeoutActivitySid);

            ExecuteAsync<Workspace>(request, (response) => { callback(response); });
        }
    }
}

