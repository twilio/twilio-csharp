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
        /// <returns>List of Channels</returns>
		public virtual ChannelResult ListChannels(string serviceSid)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels";

            request.AddUrlSegment("ServiceSid", serviceSid);

            return Execute<ChannelResult>(request);
        }

        /// <summary>
        /// Retrieves the Channel by Channel Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <returns>Channel</returns>
        public virtual Channel GetChannel(string serviceSid, string channelSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Creates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        /// <returns>A new Channel</returns>
        public virtual Channel CreateChannel(string serviceSid, string type,
            string friendlyName, string attributes)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.POST) {Resource = "/Services/{ServiceSid}/Channels"};

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Creates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="uniqueName">Unique Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        /// <returns>A new Channel</returns>
        public virtual Channel CreateChannel(string serviceSid, string type,
            string friendlyName, string uniqueName, string attributes)
        {
            Require.Argument("ServiceSid", serviceSid);

            var request = new RestRequest(Method.POST) {Resource = "/Services/{ServiceSid}/Channels"};

            request.AddUrlSegment("ServiceSid", serviceSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("UniqueName", uniqueName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Updates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        /// <returns>Updated Channel</returns>
        public virtual Channel UpdateChannel(string serviceSid,
            string channelSid, string type, string friendlyName,
            string attributes)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.POST) {Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}"};

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Updates a Channel.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="uniqueName">Unique Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        /// <returns>Updated Channel</returns>
        public virtual Channel UpdateChannel(string serviceSid,
            string channelSid, string type, string friendlyName, string uniqueName,
            string attributes)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.POST) {Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}"};

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("UniqueName", uniqueName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Deletes a Channel identified by Channel Sid.
        /// </summary>
        /// <param name="serviceSid">Service Sid</param>
        /// <param name="channelSid">Channel Sid</param>]
        /// <returns>Channel deletion status</returns>
        public virtual DeleteStatus DeleteChannel(string serviceSid,
            string channelSid)
        {
            Require.Argument("ServiceSid", serviceSid);
            Require.Argument("ChannelSid", channelSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ServiceSid", serviceSid);
            request.AddUrlSegment("ChannelSid", channelSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                                            DeleteStatus.Success :
                                            DeleteStatus.Failed;
        }
    }
}
