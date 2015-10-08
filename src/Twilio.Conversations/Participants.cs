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
        public virtual Participant GetParticipant(string conversationSid, string participantSid)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("ParticipantSid", participantSid);
            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}/Participants/{ParticipantSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);
            request.AddUrlSegment("ParticipantSid", participantSid);

            return Execute<Participant>(request);
        }

        public virtual ParticipantResult ListParticipants(string conversationSid)
        {
            Require.Argument("ConversationSid", conversationSid);

            var request = new RestRequest();
            request.Resource = "Conversations/{ConversationSid}/Participants";

            request.AddUrlSegment("ConversationSid", conversationSid);

            return Execute<ParticipantResult>(request);
        }

        public virtual Participant DisconnectParticipant(string conversationSid, string participantSid)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("ParticipantSid", participantSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Conversations/{ConversationSid}/Participants/{ParticipantSid}";

            request.AddUrlSegment("ConversationSid", conversationSid);
            request.AddUrlSegment("ParticipantSid", participantSid);

            request.AddParameter("Status", "disconnected");
            return Execute<Participant>(request);
        }

        public virtual Participant AddParticipant(string conversationSid, string to, string from)
        {
            Require.Argument("ConversationSid", conversationSid);
            Require.Argument("To", to);
            Require.Argument("From", from);

            var request = new RestRequest(Method.POST);
            request.Resource = "Conversations/{ConversationSid}/Participants";

            request.AddUrlSegment("ConversationSid", conversationSid);

            request.AddParameter("To", to);
            request.AddParameter("From", from);

            return Execute<Participant>(request);
        }
    }
}
