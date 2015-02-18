using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class TaskQueueStatisticsResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the task queues statistics.
        /// </summary>
        public List<TaskQueueStatistics> TaskQueuesStatistics { get; set; }
    }
}

