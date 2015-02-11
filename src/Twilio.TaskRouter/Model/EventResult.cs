using System;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class EventResult : TwilioListBase
    {
        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        public List<Event> Events { get; set; }
    }
}

