using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class DomainResult : TwilioListBase
    {
        /// <summary>
        ///  The list of SIP Domains associated with a domain
        /// </summary>
        public List<Domain> Domains { get; set; }
    }
}
