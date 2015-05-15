using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Validation;
using RestSharp.Extensions;


using Twilio.Conversations.Model;

namespace Twilio.Conversations
{
    public partial class ConversationsClient
    {
        /// <summary>
        /// Get a Conversation by its unique ID.
        /// </summary>
        /// <param name="conversationSid">Conversation sid</param>
        /// <returns></returns>
        public virtual Conversation GetConversation(string conversationSid)
        {
            Require.Argument("ConversationSid", conversationSid);

            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);

            return Execute<Conversation>(request);
        }

        /// <summary>
        /// Retrieve a list of current in-progress Conversations.
        /// </summary>
        /// <returns>Conversation list</returns>
        public virtual ConversationResult ListInProgressConversations()
        {
            var request = new RestRequest();
            request.Resource = "Conversations/InProgress";

            return Execute<ConversationResult>(request);
        }

        /// <summary>
        /// Retrieve a list of your completed Conversations.
        /// </summary>
        /// <returns>Conversation list</returns>
        public virtual ConversationResult ListCompletedConversations()
        {
            var request = new RestRequest();
            request.Resource = "Conversations/Completed";

            return Execute<ConversationResult>(request);
        }
    }
}
