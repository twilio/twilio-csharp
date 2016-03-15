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
        public virtual void GetTaskQueueStatistics(string workspaceSid, string taskQueueSid, Action<TaskQueueStatistics> callback)
        {
            GetTaskQueueStatistics(workspaceSid, taskQueueSid, new StatisticsRequest(), callback);
        }

        /// <summary>
        /// Retrieve the details for a task queue statistics instance. Makes a GET request to a TaskQueueStatistics Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="taskQueueSid">The Sid of the task queue to retrieve</param>
        /// <param name="options">Time interval options</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetTaskQueueStatistics(string workspaceSid, string taskQueueSid, StatisticsRequest options, Action<TaskQueueStatistics> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("TaskQueueSid", taskQueueSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("TaskQueueSid", taskQueueSid);

            AddStatisticsDateOptions(options, request);

            ExecuteAsync<TaskQueueStatistics>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List task queues statictics on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListTaskQueuesStatistics(string workspaceSid, Action<TaskQueueStatisticsResult> callback)
        {
            ListTaskQueuesStatistics(workspaceSid, new TaskQueuesStatisticsRequest(), callback);
        }

        /// <summary>
        /// List task queues statictics on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the task queues belong to</param>
        /// <param name="options">Filtering and time interval options.</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListTaskQueuesStatistics(string workspaceSid, TaskQueuesStatisticsRequest options, Action<TaskQueueStatisticsResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/TaskQueues/Statistics";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddTaskQueuesStatisticsOptions(options, request);

            ExecuteAsync<TaskQueueStatisticsResult>(request, callback);
        }
    }
}

