using System;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents an Ip Message.
    /// </summary>
    public class Message : TwilioBase
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
        /// A 34 character string that uniquely identifies the service instance
        /// that owns this resource
        /// </summary>
        public string ServiceSid { get; set; }

        /// <summary>
        /// A 34 character that uniquely identifies the channel this message
        /// belongs to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// The date that this Message was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Message was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Indicates if a message was edited at some point.
        /// </summary>
        public bool WasEdited { get; set; }

        /// <summary>
        /// Identity of the message author.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Message body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Resource api location.
        /// </summary>
        public string Url { get; set; }
    }
}
