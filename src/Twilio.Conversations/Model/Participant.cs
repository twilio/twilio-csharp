using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Conversations.Model
{
    public class Participant : TwilioBase
    {
        /// <summary>
        /// A 34 character string that uniquely identifies a Participant's interaction in this Conversation.
        /// </summary>
        public string Sid { get; set; }
        /// <summary>
        /// The endpoint identifier of this participant.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// A string representing the status of this Participant in the Conversation.
        /// May be "created", "connecting", "connected", "disconnected", or "failed".
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// A 34-character string that identifies the conversation this Participant is in.
        /// </summary>
        public string ConversationSid { get; set; }
        /// <summary>
        /// The date when this participant was created.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date when this participant connected to the conversation.
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// The date when this participant disconnected from the conversation
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// The length in seconds that this participant was connected to the conversation.
        /// This value is 0 for failed participants.
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// The unique ID of the Account that created this conversation.
        /// </summary>
        public string AccountSid { get; set; }
        /// <summary>
        /// The absolute URL for this resource.
        /// </summary>
        public string Url { get; set; }
    }
}
