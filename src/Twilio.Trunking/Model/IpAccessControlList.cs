using System;
using System.Collections.Generic;

namespace Twilio.Trunking
{
    /// <summary>
    /// A IpAccessControlList instance resource that represents a single IpAccessControlList.
    /// </summary>
    public class IpAccessControlList : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The unique id of the Account responsible for this Alert.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// A 34 character string that uniquely identifies the trunk.
        /// </summary>
        public string TrunkSid { get; set; }
        /// <summary>
        /// The friendly name that identifies this SIP Trunk.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The date that this resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
