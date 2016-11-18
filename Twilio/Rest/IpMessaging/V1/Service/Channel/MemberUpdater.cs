using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
{

    public class MemberUpdater : Updater<MemberResource> 
    {
        public string ServiceSid { get; }
        public string ChannelSid { get; }
        public string Sid { get; }
        public string RoleSid { get; set; }
        public int? LastConsumedMessageIndex { get; set; }
    
        /// <summary>
        /// Construct a new MemberUpdater
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="sid"> The sid </param>
        public MemberUpdater(string serviceSid, string channelSid, string sid)
        {
            ServiceSid = serviceSid;
            ChannelSid = channelSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated MemberResource </returns> 
        public override async System.Threading.Tasks.Task<MemberResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels/" + ChannelSid + "/Members/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated MemberResource </returns> 
        public override MemberResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels/" + ChannelSid + "/Members/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (RoleSid != null)
            {
                request.AddPostParam("RoleSid", RoleSid);
            }
            
            if (LastConsumedMessageIndex != null)
            {
                request.AddPostParam("LastConsumedMessageIndex", LastConsumedMessageIndex.ToString());
            }
        }
    }
}