using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1.Trunk {

    public class OriginationUrlUpdater : Updater<OriginationUrlResource> {
        public string trunkSid { get; }
        public string sid { get; }
        public int? weight { get; set; }
        public int? priority { get; set; }
        public bool? enabled { get; set; }
        public string friendlyName { get; set; }
        public Uri sipUrl { get; set; }
    
        /// <summary>
        /// Construct a new OriginationUrlUpdater
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public OriginationUrlUpdater(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The weight
        /// </summary>
        ///
        /// <param name="weight"> The weight </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setWeight(int? weight) {
            this.weight = weight;
            return this;
        }
    
        /// <summary>
        /// The priority
        /// </summary>
        ///
        /// <param name="priority"> The priority </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /// <summary>
        /// The enabled
        /// </summary>
        ///
        /// <param name="enabled"> The enabled </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setEnabled(bool? enabled) {
            this.enabled = enabled;
            return this;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The sip_url
        /// </summary>
        ///
        /// <param name="sipUrl"> The sip_url </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setSipUrl(Uri sipUrl) {
            this.sipUrl = sipUrl;
            return this;
        }
    
        /// <summary>
        /// The sip_url
        /// </summary>
        ///
        /// <param name="sipUrl"> The sip_url </param>
        /// <returns> this </returns> 
        public OriginationUrlUpdater setSipUrl(string sipUrl) {
            return setSipUrl(Promoter.UriFromString(sipUrl));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated OriginationUrlResource </returns> 
        public override async Task<OriginationUrlResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated OriginationUrlResource </returns> 
        public override OriginationUrlResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
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
            
            return OriginationUrlResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (weight != null) {
                request.AddPostParam("Weight", weight.ToString());
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (enabled != null) {
                request.AddPostParam("Enabled", enabled.ToString());
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (sipUrl != null) {
                request.AddPostParam("SipUrl", sipUrl.ToString());
            }
        }
    }
}