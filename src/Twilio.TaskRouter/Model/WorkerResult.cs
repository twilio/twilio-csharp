using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class WorkerResult : TwilioListBase
    {
        /// <summary>
        /// Gets or sets the workers.
        /// </summary>
        public List<Worker> Workers { get; set; }
    }
}

