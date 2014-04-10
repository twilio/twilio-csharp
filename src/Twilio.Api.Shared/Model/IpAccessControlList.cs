using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A set of IPs that are allowed to reach your SIP Domain
    /// </summary>
    public class IpAccessControlList : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The unique id of the Account that sent this message.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// A human readable descriptive text, up to 64 characters long.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The date that this resource was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated, given as GMT 
        /// </summary>
        public DateTime DateUpdated { get; set; }

    }
}
