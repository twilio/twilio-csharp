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
        public virtual void ListMessages(string serviceSid, string channelSid, 
            Action<MessageResult> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);
            
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            ExecuteAsync<MessageResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves Message by Message Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="messageSid">Message Sid</param>
        public virtual void GetMessage(string serviceSid, string channelSid, 
            string messageSid, Action<Message> callback)
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

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Message.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="from">Identity of the message author</param>
        /// <param name="body">Message body</param>
        public virtual void CreateMessage(string serviceSid, string channelSid, 
            string from, string body, Action<Message> callback)
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

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="messageSid">Message Sid</param>
        /// <param name="body">Message body</param>
        public virtual void UpdateMessage(string serviceSid, string channelSid, 
            string messageSid, string body, Action<Message> callback)
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

            ExecuteAsync<Message>(request, (response) => callback(response));
        }
    }
}
