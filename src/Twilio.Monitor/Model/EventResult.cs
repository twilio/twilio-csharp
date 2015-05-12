using System;
using System.Collections.Generic;

using Twilio.Model;

namespace Twilio.Monitor
{
    /// <summary>
    /// Twilio API call result with paging information.
    /// </summary>
    public class EventResult : NextGenListBase
    {
        /// <summary>
        /// List of Events returned by the API.
        /// </summary>
        public List<Event> Events { get; set; }
    }
}

