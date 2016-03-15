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
        public virtual Workspace AddWorkspace(string friendlyName, string eventCallbackUrl, string template)
        {
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces";

            request.AddParameter("FriendlyName", friendlyName);

            if (eventCallbackUrl.HasValue())
                request.AddParameter("EventCallbackUrl", eventCallbackUrl);
            if (template.HasValue())
                request.AddParameter("Template", template);

            return Execute<Workspace>(request);
        }

        /// <summary>
        /// Deletea a workspace.
        /// </summary>
       /// <param name="workspaceSid">Workspace sid.</param>
        public virtual DeleteStatus DeleteWorkspace(string workspaceSid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Retrieve the details for a workspace instance. Makes a GET request to a Workspace Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace</param>
        public virtual Workspace GetWorkspace(string workspaceSid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            return Execute<Workspace>(request);
        }

        /// <summary>
        /// List workspaces.
        /// </summary>
        public virtual WorkspaceResult ListWorkspaces()
        {
            return ListWorkspaces(null, null, null, null);
        }

        /// <summary>
        /// List workspaces with filters
        /// </summary>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
		public virtual WorkspaceResult ListWorkspaces(string friendlyName, string afterSid, string beforeSid, int? count)
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

            return Execute<WorkspaceResult>(request);
        }

        /// <summary>
        /// Updatea a workspace.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Optional friendly name.</param>
        /// <param name="eventCallbackUrl">Optional event callback URL.</param>
        /// <param name="defaultActivitySid">Optional default activity sid.</param>
        /// <param name="timeoutActivitySid">Optional timeout activity sid.</param>
        public virtual Workspace UpdateWorkspace(string workspaceSid, string friendlyName, string eventCallbackUrl, string defaultActivitySid, string timeoutActivitySid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (eventCallbackUrl.HasValue())
                request.AddParameter("EventCallbackUrl", eventCallbackUrl);
            if (defaultActivitySid.HasValue())
                request.AddParameter("DefaultActivitySid", defaultActivitySid);
            if (timeoutActivitySid.HasValue())
                request.AddParameter("TimeoutActivitySid", timeoutActivitySid);

            return Execute<Workspace>(request);
        }
    }
}

