using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Wds
{
    public partial class TwilioWdsClient
    {
        /// <summary>
        /// Retrieve the details for a workflow statistics instance. Makes a GET request to a WorkflowStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workflowSid">The Sid of the workflow to retrieve</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        public virtual WorkflowStatistics GetWorkflowStatistics(string workspaceSid, string workflowSid, int? minutes)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkflowSid", workflowSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Statistics/Workflows/{WorkflowSid}.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkflowSid", workflowSid);

            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            return Execute<WorkflowStatistics>(request);
        }
    }
}

