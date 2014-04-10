using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// An IpAccessControlList instance associated with this domain
    /// </summary>
    public class IpAccessControlListMapping : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies an IpAccessControlList you have mapped to the domain
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The friendly name of this credential list mapping
        /// </summary>
        public string FriendlyName { get; set; }
    }
}
