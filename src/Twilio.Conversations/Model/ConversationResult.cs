using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Twilio.Model;

namespace Twilio.Conversations.Model
{
    public class ConversationResult : NextGenListBase
    {
        /// <summary>
        /// List of Conversations retrieved from the API.
        /// </summary>
        public List<Conversation> Conversations { get; set; }
    }
}
