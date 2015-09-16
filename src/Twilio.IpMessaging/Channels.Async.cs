using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.IpMessaging
{
    public partial class IpMessagingClient
    {
        /// <summary>
        /// Retrieves all the Channels belonging to a Service Sid.
        /// </summary>
        public virtual void ListChannels(Action<ChannelResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels";

            ExecuteAsync<ChannelResult>(request, (response) =>
              callback(response));
        }

        /// <summary>
        /// Retrieves the Channel by Channel Sid.
        /// </summary>
        /// <param name="channelSid">The Channel Sid</param>
        public virtual void GetChannel(string channelSid,
          Action<Channel> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";
            request.AddUrlSegment("ChannelSid", channelSid);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Channel.
        /// </summary>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual void CreateChannel(string type, string friendlyName,
          string attributes, Action<Channel> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels";

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Modifies a Channel.
        /// </summary>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual void ModifyChannel(string channelSid, string type,
          string friendlyName, string attributes, Action<Channel> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Channel identified by Channel Sid.
        /// </summary>
        /// <param name="channelSid">Channel Sid</param>
        public virtual void DeleteChannel(string channelSid,
          Action<DeleteStatus> callback)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";
            request.AddUrlSegment("ChannelSid", channelSid);

            var response = Execute(request);
            ExecuteAsync(request, (response) => { callback(
              response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                DeleteStatus.Success :
                DeleteStatus.Failed); });
        }
    }
}
