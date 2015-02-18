using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class WorkerResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the workers.
        /// </summary>
        public List<Worker> Workers { get; set; }
    }
}

