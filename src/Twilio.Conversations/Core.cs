using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Conversations
{
    /// <summary>
    /// The Twilio Conversations API allows you to retrieve information about your
    /// current and past Conversations and manipulate the state of current participants.
    /// 
    /// See https://www.twilio.com/docs/conversations for more details.
    /// </summary>
    public partial class ConversationsClient : TwilioClient
    {
        public ConversationsClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        public ConversationsClient(string accountSid, string authToken, string accountResourceSid)
            : base(accountSid, authToken, accountResourceSid, "v1", "https://conversations.twilio.com")
        {
            DateFormat = null;
        }

        public ConversationsClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) :
            base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl)
        {
            DateFormat = null;
        }
    }
}
