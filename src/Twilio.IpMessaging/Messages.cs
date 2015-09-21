using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Messages belonging to a Channel.
        /// </summary>
        public virtual MessageResult ListMessages()
        {
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            return Execute<MessageResult>(request);
        }

        /// <summary>
        /// Retrieves Message by Message Sid.
        /// </summary>
        /// <param name="messageSid">Message Sid</param>
        public virtual Message GetMessage(string messageSid)
        {
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";
            request.AddUrlSegment("MessageSid", messageSid);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Creates a Message.
        /// </summary>
        /// <param name="from">Identity of the message author</param>
        /// <param name="body">Message body</param>
        public virtual Message CreateMessage(string from, string body)
        {
            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            request.AddParameter("From", from);
            request.AddParameter("Body", body);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="body">Message body</param>
        public virtual Message UpdateMessage(string messageSid,
          string from)
        {
            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";

            request.AddUrlSegment("MessageSid", messageSid);

            request.AddParameter("Body", body);

            return Execute<Message>(request);
        }
    }
}
