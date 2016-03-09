using System;
using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.OriginationUrl;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class OriginationUrlCreator : Creator<OriginationUrl> {
        private string trunkSid;
        private int weight;
        private int priority;
        private bool enabled;
        private string friendlyName;
        private Uri sipUrl;
    
        /**
         * Construct a new OriginationUrlCreator
         * 
         * @param trunkSid The trunk_sid
         * @param weight The weight
         * @param priority The priority
         * @param enabled The enabled
         * @param friendlyName The friendly_name
         * @param sipUrl The sip_url
         */
        public OriginationUrlCreator(string trunkSid, int weight, int priority, bool enabled, string friendlyName, Uri sipUrl) {
            this.trunkSid = trunkSid;
            this.weight = weight;
            this.priority = priority;
            this.enabled = enabled;
            this.friendlyName = friendlyName;
            this.sipUrl = sipUrl;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created OriginationUrl
         */
        [Override]
        public OriginationUrl execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrl creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return OriginationUrl.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (weight != null) {
                request.addPostParam("Weight", weight.ToString());
            }
            
            if (priority != null) {
                request.addPostParam("Priority", priority.ToString());
            }
            
            if (enabled != null) {
                request.addPostParam("Enabled", enabled.ToString());
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (sipUrl != null) {
                request.addPostParam("SipUrl", sipUrl.ToString());
            }
        }
    }
}