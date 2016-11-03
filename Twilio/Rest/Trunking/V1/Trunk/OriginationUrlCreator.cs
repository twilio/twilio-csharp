using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class OriginationUrlCreator : Creator<OriginationUrlResource> 
    {
        public string trunkSid { get; }
        public int? weight { get; }
        public int? priority { get; }
        public bool? enabled { get; }
        public string friendlyName { get; }
        public Uri sipUrl { get; }
    
        /// <summary>
        /// Construct a new OriginationUrlCreator
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="weight"> The weight </param>
        /// <param name="priority"> The priority </param>
        /// <param name="enabled"> The enabled </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="sipUrl"> The sip_url </param>
        public OriginationUrlCreator(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl)
        {
            this.trunkSid = trunkSid;
            this.weight = weight;
            this.priority = priority;
            this.enabled = enabled;
            this.friendlyName = friendlyName;
            this.sipUrl = sipUrl;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created OriginationUrlResource </returns> 
        public override async Task<OriginationUrlResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource creation failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created OriginationUrlResource </returns> 
        public override OriginationUrlResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource creation failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (weight != null)
            {
                request.AddPostParam("Weight", weight.ToString());
            }
            
            if (priority != null)
            {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (enabled != null)
            {
                request.AddPostParam("Enabled", enabled.ToString());
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (sipUrl != null)
            {
                request.AddPostParam("SipUrl", sipUrl.ToString());
            }
        }
    }
}