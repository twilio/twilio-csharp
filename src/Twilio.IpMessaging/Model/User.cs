using System;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents a Ip Messaging User.
    /// </summary>
    public class User : TwilioBase
    {
        /// <summary>
        /// The 34 character User Sid that uniquely identifies a User.
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
        /// Deployment role SID for user.
        /// </summary>
        public string RoleSid { get; set; }

        /// <summary>
        /// User’s Identity, must be unique for deployment
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// The date that this User resource was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this User resource was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }
    }
}
