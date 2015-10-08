using System;
using System.Collections.Generic;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents a Role.
    /// </summary>
    public class Role : TwilioBase
    {
        /// <summary>
        /// The 34 character Role Sid that uniquely identifies a role.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the account that
        /// owns this resource.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the service instance
        /// that owns this resource
        /// </summary>
        public string ServiceSid { get; set; }

        /// <summary>
        /// A human readable description of this role.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Role's type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Role's permissions.
        /// </summary>
        public List<string> Permissions { get; set; }

        /// <summary>
        /// The date that this Role was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Role was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }
    }
}
