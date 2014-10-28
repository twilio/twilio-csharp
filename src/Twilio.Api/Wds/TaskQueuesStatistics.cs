using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Wds
{
    public partial class TwilioWdsClient
    {
        /// <summary>
        /// Retrieve the details for a task queue statistics instance. Makes a GET request to a TaskQueueStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="taskQueueSid">The Sid of the task queue to retrieve</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        public virtual TaskQueueStatistics GetTaskQueueStatistics(string workspaceSid, string taskQueueSid, int? minutes)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskQueueSid", taskQueueSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Statistics/TaskQueues/{TaskQueueSid}.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskQueueSid", taskQueueSid);

            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            return Execute<TaskQueueStatistics>(request);
        }

        /// <summary>
        /// List task queues statictics on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        public virtual TaskQueueStatisticsResult ListTaskQueuesStatistics(string workspaceSid)
        {
            return ListTaskQueuesStatistics(workspaceSid, null, null);
        }

        /// <summary>
        /// List task queues statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="friendlyName">Optional friendly name to match.</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        public virtual TaskQueueStatisticsResult ListTaskQueuesStatistics(string workspaceSid, string friendlyName, int? minutes)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Statistics/TaskQueues.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            return Execute<TaskQueueStatisticsResult>(request);
        }
    }
}

