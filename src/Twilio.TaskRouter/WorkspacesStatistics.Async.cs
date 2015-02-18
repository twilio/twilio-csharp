using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Retrieve the details for a workspace statistics instance. Makes a GET request to a WorkspaceStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkspaceStatistics(string workspaceSid, Action<WorkspaceStatistics> callback)
        {
            GetWorkspaceStatistics(workspaceSid, new StatisticsRequest(), callback);
        }

        /// <summary>
        /// Retrieve the details for a workspace statistics instance. Makes a GET request to a WorkspaceStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="options">Time-interval options.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkspaceStatistics(string workspaceSid, StatisticsRequest options, Action<WorkspaceStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddStatisticsDateOptions(options, request);

            ExecuteAsync<WorkspaceStatistics>(request, (response) => { callback(response); });
        }
    }
}

