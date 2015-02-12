using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Retrieve the details for a workflow statistics instance. Makes a GET request to a WorkflowStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workflowSid">The Sid of the workflow to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkflowStatistics(string workspaceSid, string workflowSid, Action<WorkflowStatistics> callback)
        {
            GetWorkflowStatistics(workspaceSid, workflowSid, new StatisticsRequest(), callback);
        }

        /// <summary>
        /// Retrieve the details for a workflow statistics instance. Makes a GET request to a WorkflowStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workflowSid">The Sid of the workflow to retrieve</param>
        /// <param name="options">Time-interval options.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkflowStatistics(string workspaceSid, string workflowSid, StatisticsRequest options, Action<WorkflowStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkflowSid", workflowSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkflowSid", workflowSid);

            AddStatisticsDateOptions(options, request);

            ExecuteAsync<WorkflowStatistics>(request, (response) => { callback(response); });
        }
    }
}

