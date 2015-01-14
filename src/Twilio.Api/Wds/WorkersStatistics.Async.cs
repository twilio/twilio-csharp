using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Wds
{
    public partial class TwilioWdsClient
    {
        /// <summary>
        /// Retrieve the details for a worker statistics instance. Makes a GET request to a WorkerStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workerSid">The Sid of the worker to retrieve</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkerStatistics(string workspaceSid, string workerSid, int? minutes, Action<WorkerStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Statistics.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            ExecuteAsync<WorkerStatistics>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List workers statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void ListWorkersStatistics(string workspaceSid, Action<WorkersStatistics> callback)
        {
            ListWorkersStatistics (workspaceSid, null, null, null, null, callback);
        }

        /// <summary>
        /// List workers statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="friendlyName">Optional friendly name to match.</param>
        /// <param name="taskQueueSid">Optional task queue sid to match.</param>
        /// <param name="taskQueueName">Optional task queue name to match.</param>
        /// <param name="minutes">Definition of the interval in minutes prior to now. Default to 15.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void ListWorkersStatistics(string workspaceSid, string friendlyName, string taskQueueSid, string taskQueueName, int? minutes, Action<WorkersStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Workspaces/{WorkspaceSid}/Workers/Statistics.json";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (taskQueueSid.HasValue())
                request.AddParameter("TaskQueueSid", taskQueueSid);
            if (taskQueueName.HasValue())
                request.AddParameter("TaskQueueName", taskQueueName);
            if (minutes.HasValue)
                request.AddParameter("Minutes", minutes.Value);

            ExecuteAsync<WorkersStatistics>(request, callback);
        }
    }
}

