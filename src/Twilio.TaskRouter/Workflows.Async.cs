using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Create a workflow.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Friendly name.</param>
        /// <param name="configuration">Configuration.</param>
        /// <param name="assignmentCallbackUrl">Assignment callback URL.</param>
        /// <param name="fallbackAssignmentCallbackUrl">Optional fallback assignment callback URL.</param>
        /// <param name="taskReservationTimeout">Optional task reservation timeout.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddWorkflow(string workspaceSid, string friendlyName, string configuration, string assignmentCallbackUrl, string fallbackAssignmentCallbackUrl, int? taskReservationTimeout, Action<Workflow> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("FriendlyName", friendlyName);
            Require.Argument("Configuration", configuration);
            Require.Argument("AssignmentCallbackUrl", assignmentCallbackUrl);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Configuration", configuration);
            request.AddParameter("AssignmentCallbackUrl", assignmentCallbackUrl);

            if (fallbackAssignmentCallbackUrl.HasValue())
                request.AddParameter("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl);
            if (taskReservationTimeout.HasValue)
                request.AddParameter("TaskReservationTimeout", taskReservationTimeout.Value);

            ExecuteAsync<Workflow>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Delete a workflow.
        /// </summary>
        /// <returns>The workflow.</returns>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workflowSid">Workflow sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteWorkflow(string workspaceSid, string workflowSid, Action<DeleteStatus> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkflowSid", workflowSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkflowSid", workflowSid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Retrieve the details for a workflow instance. Makes a GET request to a Workflow Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the workflow belongs to</param>
        /// <param name="workflowSid">The Sid of the workflow to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkflow(string workspaceSid, string workflowSid, Action<Workflow> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkflowSid", workflowSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkflowSid", workflowSid);

            ExecuteAsync<Workflow>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List workflows on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the workflows belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkflows(string workspaceSid, Action<WorkflowResult> callback)
        {
            ListWorkflows(workspaceSid, null, null, null, null, callback);
        }

        /// <summary>
        /// List workflows on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the workflows belong to</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkflows(string workspaceSid, string friendlyName, string afterSid, string beforeSid, int? count, Action<WorkflowResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (afterSid.HasValue())
                request.AddParameter("AfterSid", afterSid);
            if (beforeSid.HasValue())
                request.AddParameter("BeforeSid", beforeSid);
            if (count.HasValue)
                request.AddParameter("PageSize", count.Value);

            ExecuteAsync<WorkflowResult>(request, callback);
        }

        /// <summary>
        /// Updatea a workflow.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workflowSid">Workflow sid.</param>
        /// <param name="friendlyName">Optional firendly name.</param>
        /// <param name="assignmentCallbackUrl">Optional assignment callback URL.</param>
        /// <param name="fallbackAssignmentCallbackUrl">Optional fallback assignment callback URL.</param>
        /// <param name="configuration">Optional configuration.</param>
        /// <param name="taskReservationTimeout">Optional task reservation timeout.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateWorkflow(string workspaceSid, string workflowSid, string friendlyName, string assignmentCallbackUrl, string fallbackAssignmentCallbackUrl, string configuration, int? taskReservationTimeout, Action<Workflow> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkflowSid", workflowSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkflowSid", workflowSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (assignmentCallbackUrl.HasValue())
                request.AddParameter("AssignmentCallbackUrl", assignmentCallbackUrl);
            if (fallbackAssignmentCallbackUrl.HasValue())
                request.AddParameter("FallbackAssignmentCallbackUrl", fallbackAssignmentCallbackUrl);
            if (configuration.HasValue())
                request.AddParameter("Configuration", configuration);
            if (taskReservationTimeout.HasValue)
                request.AddParameter("TaskReservationTimeout", taskReservationTimeout.Value);

            ExecuteAsync<Workflow>(request, (response) => { callback(response); });
        }
    }
}

