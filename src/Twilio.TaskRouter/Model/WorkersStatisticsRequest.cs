using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Filtering options for listing worker statistics.
    /// </summary>
    public class WorkersStatisticsRequest : StatisticsRequest
    {
        /// <summary>
        /// Only retrieve statistics for workers performing tasks in this TaskQueue.
        /// </summary>
        /// <value>Sid of the TaskQueue to filter by</value>
        public string TaskQueueSid { get; set; }

        /// <summary>
        /// Only retrieve statistics for workers performing tasks in this TaskQueue.
        /// </summary>
        /// <value>FriendlyName of the TaskQueue to filter by</value>
        public string TaskQueueName { get; set; }

        /// <summary>
        /// Only retrieve statistics for the worker with this FriendlyName.
        /// </summary>
        /// <value>FriendlyName of the Worker to restrict results to</value>
        public string FriendlyName { get; set; }
    }
}

