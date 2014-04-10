using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class IpAccessControlListMappingResult : TwilioListBase
    {
        /// <summary>
        ///  The list of IpAccessControlList instances associated with a domain
        /// </summary>
        public List<IpAccessControlListMapping> IpAccessControlListMappings { get; set; }
    }
}
