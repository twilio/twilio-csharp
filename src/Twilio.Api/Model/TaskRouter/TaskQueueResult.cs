using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class TaskQueueResult : TwilioListBase
    {
        /// <summary>
        /// Gets or sets the task queues.
        /// </summary>
        public List<TaskQueue> taskQueues { get; set; }
    }
}

