using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class UsageTriggerResult : TwilioListBase
    {
        /// <summary>
        /// List of UsageTrigger resources returned by API
        /// </summary>
        public List<UsageTrigger> UsageTriggers { get; set; }
    }
}
