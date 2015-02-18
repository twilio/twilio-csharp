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
        public virtual WorkspaceStatistics GetWorkspaceStatistics(string workspaceSid)
        {
            return GetWorkspaceStatistics(workspaceSid, new StatisticsRequest());
        }

        /// <summary>
        /// Retrieve the details for a workspace statistics instance. Makes a GET request to a WorkspaceStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="options">Time-interval options.</param>
        public virtual WorkspaceStatistics GetWorkspaceStatistics(string workspaceSid, StatisticsRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddStatisticsDateOptions(options, request);

            return Execute<WorkspaceStatistics>(request);
        }
    }
}

