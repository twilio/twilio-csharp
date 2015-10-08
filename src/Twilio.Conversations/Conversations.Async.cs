using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

using Twilio.Conversations.Model;

namespace Twilio.Conversations
{
    public partial class ConversationsClient
    {
        public virtual void GetConversation(string conversationSid, Action<Conversation> callback)
        {
            Require.Argument("ConversationSid", conversationSid);

            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);
            ExecuteAsync<Conversation>(request, response => callback(response));
        }

        public virtual void ListInProgressConversations(Action<ConversationResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Conversations/InProgress";

            ExecuteAsync<ConversationResult>(request, response => callback(response));
        }

        public virtual void ListCompletedConversations(Action<ConversationResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Conversations/Completed";

            ExecuteAsync<ConversationResult>(request, response => callback(response));
        }
    }
}
