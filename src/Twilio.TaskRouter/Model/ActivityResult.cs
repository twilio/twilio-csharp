using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class ActivityResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the activities.
        /// </summary>
        public List<Activity> Activities { get; set; }
    }
}

