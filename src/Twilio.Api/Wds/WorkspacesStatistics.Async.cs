using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Wds
{
    public partial class TwilioWdsClient
    {
        /// <summary>
        /// Retrieve the details for a workspace statistics instance. Makes a GET request to a WorkspaceStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkspaceStatistics(string workspaceSid, int? minutes, Action<WorkspaceStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Statistics.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            ExecuteAsync<WorkspaceStatistics>(request, (response) => { callback(response); });
        }
    }
}

