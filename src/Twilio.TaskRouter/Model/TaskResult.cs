using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class TaskResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        public List<Task> Tasks { get; set; }
    }
}

