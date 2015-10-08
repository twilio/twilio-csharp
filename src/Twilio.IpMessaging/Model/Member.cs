using System;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents an Ip Messaging Member.
    /// </summary>
    public class Member : TwilioBase
    {
        /// <summary>
        /// The 34 character Message Sid that uniquely identifies a message.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the account that
        /// owns this resource.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the channel instance
        /// that owns this resource
        /// </summary>
        public string ChannelSid { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the service instance
        /// that owns this resource
        /// </summary>
        public string ServiceSid { get; set; }

        /// <summary>
        /// Identity of the member.
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// A 34 character string that uniquely identifies the role sid of the
        /// member
        /// </summary>
        public string RoleSid { get; set; }

        /// <summary>
        /// The date that this Member was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Member was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }
    }
}
