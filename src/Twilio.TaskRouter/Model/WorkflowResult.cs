using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class WorkflowResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the workflows.
        /// </summary>
        public List<Workflow> Workflows { get; set; }
    }
}

