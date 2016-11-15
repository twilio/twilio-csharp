using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service 
{

    public class ChannelCreator : Creator<ChannelResource> 
    {
        public string ServiceSid { get; }
        public string FriendlyName { get; set; }
        public string UniqueName { get; set; }
        public string Attributes { get; set; }
        public ChannelResource.ChannelTypeEnum Type { get; set; }
    
        /// <summary>
        /// Construct a new ChannelCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        public ChannelCreator(string serviceSid)
        {
            ServiceSid = serviceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ChannelResource </returns> 
        public override async System.Threading.Tasks.Task<ChannelResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ChannelResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ChannelResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created ChannelResource </returns> 
        public override ChannelResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + ServiceSid + "/Channels"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ChannelResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ChannelResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (UniqueName != null)
            {
                request.AddPostParam("UniqueName", UniqueName);
            }
            
            if (Attributes != null)
            {
                request.AddPostParam("Attributes", Attributes);
            }
            
            if (Type != null)
            {
                request.AddPostParam("Type", Type.ToString());
            }
        }
    }
}