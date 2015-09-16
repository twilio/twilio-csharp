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
        public virtual void ListMessages(Action<MessageResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

            ExecuteAsync<MessageResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves Message by Message Sid.
        /// </summary>
        /// <param name="messageSid">Message Sid</param>
        public virtual void GetMessage(string messageSid,
          Action<Message> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";
            
            request.AddUrlSegment("MessageSid", messageSid);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Message.
        /// </summary>
        /// <param name="from">Identity of the message author</param>
        /// <param name="body">Message body</param>
        public virtual void CreateMessage(string type, string friendlyName,
          string attributes, Action<Message> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages";

              request.AddParameter("From", from);
              request.AddParameter("Body", body);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }

        /// <summary>
        /// Edits a message.
        /// </summary>
        /// <param name="body">Message body</param>
        public virtual void ModifyMessage(string body, Action<Message> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource =
              "/Services/{ServiceSid}/Channels/{ChannelSid}/Messages/{MessageSid}";

            request.AddUrlSegment("MessageSid", messageSid);

            request.AddParameter("Body", body);

            ExecuteAsync<Message>(request, (response) => callback(response));
        }
    }
}
