using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Trunking.V1.Trunk {

    public class OriginationUrlUpdater : Updater<OriginationUrlResource> {
        private string trunkSid;
        private string sid;
        private int? weight;
        private int? priority;
        private bool? enabled;
        private string friendlyName;
        private Uri sipUrl;
    
        /**
         * Construct a new OriginationUrlUpdater
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public OriginationUrlUpdater(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * The weight
         * 
         * @param weight The weight
         * @return this
         */
        public OriginationUrlUpdater setWeight(int? weight) {
            this.weight = weight;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public OriginationUrlUpdater setPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * The enabled
         * 
         * @param enabled The enabled
         * @return this
         */
        public OriginationUrlUpdater setEnabled(bool? enabled) {
            this.enabled = enabled;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public OriginationUrlUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The sip_url
         * 
         * @param sipUrl The sip_url
         * @return this
         */
        public OriginationUrlUpdater setSipUrl(Uri sipUrl) {
            this.sipUrl = sipUrl;
            return this;
        }
    
        /**
         * The sip_url
         * 
         * @param sipUrl The sip_url
         * @return this
         */
        public OriginationUrlUpdater setSipUrl(string sipUrl) {
            return setSipUrl(Promoter.UriFromString(sipUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated OriginationUrlResource
         */
        public override async Task<OriginationUrlResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return OriginationUrlResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated OriginationUrlResource
         */
        public override OriginationUrlResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrlResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return OriginationUrlResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (weight != null) {
                request.AddPostParam("Weight", weight.ToString());
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (enabled != null) {
                request.AddPostParam("Enabled", enabled.ToString());
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (sipUrl != null) {
                request.AddPostParam("SipUrl", sipUrl.ToString());
            }
        }
    }
}