using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class UsageResult : TwilioListBase
    {
        /// <summary>
        /// List of Usage resources returned by API
        /// </summary>
        public List<UsageRecord> UsageRecords { get; set; }
    }
}
