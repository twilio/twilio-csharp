using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class WorkspaceResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the workspaces.
        /// </summary>
        public List<Workspace> Workspaces { get; set; }
    }
}

