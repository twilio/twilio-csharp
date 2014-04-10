using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// Twilio API call result with paging information
    /// </summary>
    public class IpAccessControlListResult : TwilioListBase
    {
        /// <summary>
        /// A list of all IpAccessControlLists under this account
        /// </summary>
        public List<IpAccessControlList> IpAccessControlLists { get; set; }
    }
}
