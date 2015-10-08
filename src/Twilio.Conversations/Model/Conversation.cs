using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Conversations.Model
{
    /// <summary>
    /// Represents an individual Conversation resource.
    /// 
    /// See https://www.twilio.com/docs/api/rest/conversations for more information.
    /// </summary>
    public class Conversation : TwilioBase
    {
        /// <summary>
        /// A 34-character string that uniquely identifies this Conversation.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// A string representing the status of the Conversation. May be "created", "in-progress", "ended", or "failed".
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The length of the entire Conversation in seconds. This property is 0 for failed conversations.
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// The date that this Conversation was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this Conversation started.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The date that this Conversation ended.
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// The unique ID of the Account responsible for creating this conversation.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The absolute URL of this conversation in the Twilio REST API.
        /// </summary>
        public string Url { get; set; }
    }
}
