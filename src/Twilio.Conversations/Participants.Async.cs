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
        public virtual void GetParticipant(string conversationSid, string participantSid, Action<Participant> callback)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("ParticipantSid", participantSid);

            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}/Participants/{ParticipantSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);
            request.AddUrlSegment("ParticipantSid", participantSid);

            ExecuteAsync<Participant>(request, response => callback(response));
        }

        public virtual void ListParticipants(string conversationSid, Action<ParticipantResult> callback)
        {
            Require.Argument("ConversationSid", conversationSid);

            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}/Participants";

            request.AddUrlSegment("ConversationSid", conversationSid);

            ExecuteAsync<ParticipantResult>(request, response => callback(response));
        }

        public virtual void DisconnectParticipant(string conversationSid, string participantSid, Action<Participant> callback)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("ParticipantSid", participantSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Conversations/{ConversationSid}/Participants/{ParticipantSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);
            request.AddUrlSegment("ParticipantSid", participantSid);

            request.AddParameter("Status", "disconnected");
            ExecuteAsync<Participant>(request, response => callback(response));
        }

        public virtual void AddParticipant(string conversationSid, string to, string from, Action<Participant> callback)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("To", to);
            Require.Argument("From", from);

            var request = new RestRequest(Method.POST);
            request.Resource = "Conversations/{ConversationSid}/Participants";

            request.AddUrlSegment("ConversationSid", conversationSid);
            request.AddParameter("To", to);
            request.AddParameter("From", from);

            ExecuteAsync<Participant>(request, response => callback(response));
        }
    }
}
