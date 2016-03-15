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
        public virtual WorkerStatistics GetWorkerStatistics(string workspaceSid, string workerSid)
        {
            return GetWorkerStatistics(workspaceSid, workerSid, new StatisticsRequest());
        }

        /// <summary>
        /// Retrieve the details for a worker statistics instance. Makes a GET request to a WorkerStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="workerSid">The Sid of the worker to retrieve</param>
        /// <param name="options">Filtering options for statistics</param>
        public virtual WorkerStatistics GetWorkerStatistics(string workspaceSid, string workerSid, StatisticsRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            AddStatisticsDateOptions(options, request);

            return Execute<WorkerStatistics>(request);
        }

        /// <summary>
        /// List workers statistics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
		public virtual WorkersStatistics ListWorkersStatistics(string workspaceSid)
        {
            return ListWorkersStatistics(workspaceSid, new WorkersStatisticsRequest());
        }

        /// <summary>
        /// List workers statistics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="options">Filtering options for the statistics request</param>>
		public virtual WorkersStatistics ListWorkersStatistics(string workspaceSid, WorkersStatisticsRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddWorkersStatisticsOptions(options, request);

            return Execute<WorkersStatistics>(request);
        }

        private void AddWorkersStatisticsOptions(WorkersStatisticsRequest options, RestRequest request)
        {
            AddStatisticsDateOptions(options, request);
            if (options.FriendlyName.HasValue()) {
                request.AddParameter("FriendlyName", options.FriendlyName);
            }
            if (options.TaskQueueSid.HasValue()) {
                request.AddParameter("TaskQueueSid", options.TaskQueueSid);
            }
            if (options.TaskQueueName.HasValue()) {
                request.AddParameter("TaskQueueName", options.TaskQueueName);
            }
        }
    }
}

