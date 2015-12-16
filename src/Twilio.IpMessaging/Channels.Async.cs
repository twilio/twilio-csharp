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
        /// Retrieves all the Channels belonging to a Service Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        public virtual void ListChannels(string serviceSid, 
            Action<ChannelResult> callback)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels";

            request.AddUrlSegment("ServiceSid", serviceSid);

            ExecuteAsync<ChannelResult>(request, (response) => 
                callback(response));
        }

        /// <summary>
        /// Retrieves the Channel by Channel Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">The Channel Sid</param>
        public virtual void GetChannel(string serviceSid, string channelSid, 
            Action<Channel> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual void CreateChannel(string serviceSid, string type, 
            string friendlyName, string attributes, Action<Channel> callback)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels";

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual void UpdateChannel(string serviceSid, string channelSid, 
            string type, string friendlyName, string attributes, 
            Action<Channel> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Channel>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Channel identified by Channel Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        public virtual void DeleteChannel(string serviceSid, string channelSid, 
            Action<DeleteStatus> callback)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            ExecuteAsync(request, (response) =>
            {
                callback(
                    response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                    DeleteStatus.Success :
                    DeleteStatus.Failed);
            });
        }
    }
}
