using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class IpAddressResult : TwilioListBase
    {
        /// <summary>
        /// The IP Addresses that an IpAccessControlList contains
        /// </summary>
        public List<IpAddress> IpAddresses { get; set; }
    }
}
