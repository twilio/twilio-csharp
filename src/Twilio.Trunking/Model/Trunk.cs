using System;
using System.Collections.Generic;

namespace Twilio.Trunking
{
    /// <summary>
    /// A Trunk instance resource that represents a single Twilio SIP Trunk.
    /// </summary>
    public class Trunk : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The date that this resource was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated.
        /// </summary>
        public DateTime DateUpdated { get; set; }
        /// <summary>
        /// The unique id of the Account responsible for this Alert.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The domain name for this SIP trunk.
        /// Must end with "pstn.twilio.com", eg. "test1.pstn.twilio.com"
        /// </summary>
        public string DomainName { get; set; }
        /// <summary>
        /// The HTTP method to use when sending requests to the DisasterRecoveryUrl.
        /// </summary>
        public string DisasterRecoveryMethod { get; set; }
        /// <summary>
        /// The url for the fallback TwiML in the event of a call failure.
        /// </summary>
        public string DisasterRecoveryUrl { get; set; }
        /// <summary>
        /// The friendly name that identifies this SIP Trunk.
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// Whether SRTP is used for media and TLS signaling.
        /// </summary>
        public bool Secure { get; set; }
        /// <summary>
        /// The recording settings for call to/from this SIP trunk.
        /// </summary>
        public Dictionary<string, string> Recording { get; set; }
        /// <summary>
        /// The authentication types for this SIP Trunk.
        /// </summary>
        public string AuthType { get; set; }
        /// <summary>
        /// The authentication types for this SIP Trunk, as a set.
        /// </summary>
        public string AuthTypeSet { get; set; }
        /// <summary>
        /// The url for this instance resource.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Links to subresources for this SIP Trunk.
        /// </summary>
        public Dictionary<string, string> Links { get; set; }
    }
}
