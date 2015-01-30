using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class WorkspaceResult : TwilioListBase
    {
        /// <summary>
        /// Gets or sets the workspaces.
        /// </summary>
        public List<Workspace> workspaces { get; set; }
    }
}

