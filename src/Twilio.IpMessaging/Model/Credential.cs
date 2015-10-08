using System;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents a Ip Messaging Credential.
    /// </summary>
    public class Credential : TwilioBase
    {
        /// <summary>
        /// The 34 character Credential Sid that uniquely identifies a credential.
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
        /// Public or Private type credential.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sandbox flag
        /// </summary>
        public string Sandbox { get; set; }

        /// <summary>
        /// The date that this Credential was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Credential was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }
    }
}
