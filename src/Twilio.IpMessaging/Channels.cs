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
        public virtual ChannelResult ListChannels()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels";

            return Execute<ChannelResult>(request);
        }

        /// <summary>
        /// Retrieves the Channel by Channel Sid.
        /// </summary>
        /// <param name="channelSid">The Channel Sid</param>
        public virtual Channel GetChannel(string channelSid)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";
            request.AddUrlSegment("ChannelSid", channelSid);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Creates a Channel.
        /// </summary>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual Channel CreateChannel(string type, string friendlyName,
          string attributes)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels";

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Modifies a Channel.
        /// </summary>
        /// <param name="channelSid">Channel Sid</param>
        /// <param name="type">Channel type</param>
        /// <param name="friendlyName">Friendly Name for the Channel</param>
        /// <param name="attributes">Developer specific values to be stored as is</param>
        public virtual Channel ModifyChannel(string channelSid, string type,
          string friendlyName, string attributes)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";

            request.AddUrlSegment("ChannelSid", channelSid);

            request.AddParameter("Type", type);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Attributes", attributes);

            return Execute<Channel>(request);
        }

        /// <summary>
        /// Deletes a Channel identified by Channel Sid.
        /// </summary>
        /// <param name="channelSid">Channel Sid</param>
        public virtual DeleteStatus DeleteChannel(string channelSid)
        {
            var request = new RestRequest(Method.DELETE);
            request.Resource = "/Services/{ServiceSid}/Channels/{ChannelSid}";
            request.AddUrlSegment("ChannelSid", channelSid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ?
                                            DeleteStatus.Success :
                                            DeleteStatus.Failed;
        }
    }
}
