using System;
using System.Collections.Generic;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents a Ip Messaging Service.
    /// </summary>
    public class Service : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies the service instance.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the account that
        /// owns this resource.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// A human readable description of this account, up to 64 characters
        /// long. By default the FriendlyName is your email address.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The date that this Service was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Service was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Default Service Role Sid
        /// </summary>
        public string DefaultServiceRoleSid { get; set; }

        /// <summary>
        /// Default Channel Role Sid
        /// </summary>
        public string DefaultChannelRoleSid { get; set; }

        /// <summary>
        /// Typing Indicator time out
        /// </summary>
        public int TypingIndicatorTimeout { get; set; }

        /// <summary>
        /// Webhooks data.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> Webhooks { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        public Dictionary<string, string> Links { get; set; }
    }
}
