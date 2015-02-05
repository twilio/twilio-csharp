using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class TaskQueueStatisticsResult : TwilioListBase
    {
        /// <summary>
        /// Gets or sets the task queues statistics.
        /// </summary>
        public List<TaskQueueStatistics> TaskQueuesStatistics { get; set; }
    }
}

