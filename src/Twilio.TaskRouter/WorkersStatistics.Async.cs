using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Retrieve the details for a worker statistics instance. Makes a GET request to a WorkerStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workerSid">The Sid of the worker to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkerStatistics(string workspaceSid, string workerSid, Action<WorkerStatistics> callback)
        {
            GetWorkerStatistics(workspaceSid, workerSid, new StatisticsRequest(), callback);
        }

        /// <summary>
        /// Retrieve the details for a worker statistics instance. Makes a GET request to a WorkerStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workerSid">The Sid of the worker to retrieve</param>
        /// <param name="options">Time-interval options.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorkerStatistics(string workspaceSid, string workerSid, StatisticsRequest options, Action<WorkerStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            AddStatisticsDateOptions(options, request);

            ExecuteAsync<WorkerStatistics>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List workers statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkersStatistics(string workspaceSid, Action<WorkersStatistics> callback)
        {
            ListWorkersStatistics (workspaceSid, new WorkersStatisticsRequest(), callback);
        }

        /// <summary>
        /// List workers statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkersStatistics(string workspaceSid, WorkersStatisticsRequest options, Action<WorkersStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddWorkersStatisticsOptions(options, request);

            ExecuteAsync<WorkersStatistics>(request, callback);
        }
    }
}

