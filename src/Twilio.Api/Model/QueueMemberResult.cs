using System.Collections.Generic;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class QueueMemberResult : TwilioListBase
    {
        /// <summary>
        /// List of QueueMember instances returned by the API
        /// </summary>
        public List<QueueMember> QueueMembers { get; set; }
    }
}
