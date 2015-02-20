using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class EventResult : NextGenListBase
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public List<Event> Events { get; set; }
    }
}

