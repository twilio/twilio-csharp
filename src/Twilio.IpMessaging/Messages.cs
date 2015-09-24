using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using Twilio.IpMessaging.Model;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Messages belonging to a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <returns>List of Messages</returns>
        public virtual MessageResult ListMessages(string serviceSid, 
            string channelSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            return Execute<MessageResult>(request);
        }

        /// <summary>
        /// Retrieves Message by Message Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="messageSid">Message Sid</param>
        /// <returns>Message</returns>
        public virtual Message GetMessage(string serviceSid, string channelSid, 
            string messageSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MessageSid", messageSid);

            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MessageSid", messageSid);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Creates a Message.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="from">Identity of the message author</param>
        /// <param name="body">Message body</param>
        /// <returns>A new Message</returns>
        public virtual Message CreateMessage(string serviceSid, 
            string channelSid, string from, string body)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("Body", body);
            
            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("From", from);
            request.AddParameter("Body", body);

            return Execute<Message>(request);
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="messageSid">Message Sid</param>
        /// <param name="body">Message body</param>
        /// <returns>Updated Message</returns>
        public virtual Message UpdateMessage(string serviceSid, 
            string channelSid, string messageSid, string body)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            Require.Argument("MessageSid", messageSid);
            Require.Argument("Body", body);

            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);
            request.AddUrlSegment("MessageSid", messageSid);

            request.AddParameter("Body", body);

            return Execute<Message>(request);
        }
    }
}
