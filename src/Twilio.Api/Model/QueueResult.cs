using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class QueueResult : TwilioListBase
    {
        /// <summary>
        /// List of Queue instances returned by the API
        /// </summary>
        public List<Queue> Queues { get; set; }
    }
}
