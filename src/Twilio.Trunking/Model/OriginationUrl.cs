using System;
using System.Collections.Generic;

namespace Twilio.Trunking
{
    /// <summary>
    /// A OriginationUrl instance resource that represents a single OriginationUrl.
    /// </summary>
    public class OriginationUrl : TwilioBase
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
        /// The SIP address you want Twilio to route your Origination calls to.
        /// This must be a sip: schema.
        /// </summary>
        public string SipUrl { get; set; }
        /// <summary>
        /// Priority ranks the importance of the URI. Values range from 0 to 65535,
        /// where the lowest number represents the highest importance. Defaults to 10.
        /// </summary>
        public int Priority { get; set; }
        /// <summary>
        /// Weight is used to determine the share of load when more than one URI has the same priority.
        /// Its values range from 1 to 65535. The higher the value, the more load a URI is given. Defaults to 10.
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// A boolean value indicating whether the URL is enabled or disabled.
        /// Defaults to true.
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// The URL for this resource, relative to https://trunking.twilio.com
        /// </summary>
        public bool Url { get; set; }
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
