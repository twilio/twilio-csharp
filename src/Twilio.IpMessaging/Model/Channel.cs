using System;
using System.Collections.Generic;

namespace Twilio.IpMessaging.Model
{
    /// <summary>
    /// Represents a Ip Messaging Channel.
    /// </summary>
    public class Channel : TwilioBase
    {
        /// <summary>
        /// The 34 character Channel Sid that uniquely identifies a channel.
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
        /// A human readable description of this account, up to 64 characters
        /// long. By default the FriendlyName is your email address.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// A unique, addressable name for the Channel. Up to 64 characters
        /// long.
        /// </summary>
        public string UniqueName { get; set; }

        /// <summary>
        /// An opaque value, available for developer to store any
        /// developer-specific string
        /// </summary>
        public string Attributes { get; set; }

        /// <summary>
        /// Public or Private type channel.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The date that this Channel was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date that this Channel was last updated, given in as GMT
        /// </summary>
        public DateTime DateUpdated { get; set; }

        /// <summary>
        /// Identity of the channel creator.
        /// If the channel is created through this API - the value will be
        /// “system”.
        /// </summary>
        public string CreatedBy { get; set; }

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
