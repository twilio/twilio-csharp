using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Retrieve the details for a task queue statistics instance. Makes a GET request to a TaskQueueStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="taskQueueSid">The Sid of the task queue to retrieve</param>
        /// <param name="options">Time-interval options</param>
        public virtual TaskQueueStatistics GetTaskQueueStatistics(string workspaceSid, string taskQueueSid, StatisticsRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskQueueSid", taskQueueSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskQueueSid", taskQueueSid);

            AddStatisticsDateOptions(options, request);

            return Execute<TaskQueueStatistics>(request);
        }

        /// <summary>
        /// List task queues statistics on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
		public virtual TaskQueueStatisticsResult ListTaskQueuesStatistics(string workspaceSid)
        {
            return ListTaskQueuesStatistics(workspaceSid, new TaskQueuesStatisticsRequest());
        }

        /// <summary>
        /// List task queues statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="options">Time-interval and filtering options.</param>
		public virtual TaskQueueStatisticsResult ListTaskQueuesStatistics(string workspaceSid, TaskQueuesStatisticsRequest options)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/TaskQueues/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddTaskQueuesStatisticsOptions(options, request);

            return Execute<TaskQueueStatisticsResult>(request);
        }

        private void AddTaskQueuesStatisticsOptions(TaskQueuesStatisticsRequest options, RestRequest request)
        {
            AddStatisticsDateOptions(options, request);

            if (options.FriendlyName.HasValue()) {
                request.AddParameter("FriendlyName", options.FriendlyName);
            }

            if (options.Count.HasValue) {
                request.AddParameter("PageSize", options.Count.Value);
            }

            if (options.PageNumber.HasValue) {
                request.AddParameter("Page", options.PageNumber.Value);
            }

            if (options.BeforeSid.HasValue()) {
                request.AddParameter("BeforeSid", options.BeforeSid);
            }

            if (options.AfterSid.HasValue()) {
                request.AddParameter("AfterSid", options.AfterSid);
            }
        }
    }
}

