using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.OriginationUrl;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Trunking.V1.Trunk {

    public class OriginationUrlUpdater : Updater<OriginationUrl> {
        private String trunkSid;
        private String sid;
        private Integer weight;
        private Integer priority;
        private Boolean enabled;
        private String friendlyName;
        private URI sipUrl;
    
        /**
         * Construct a new OriginationUrlUpdater
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public OriginationUrlUpdater(String trunkSid, String sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * The weight
         * 
         * @param weight The weight
         * @return this
         */
        public OriginationUrlUpdater setWeight(Integer weight) {
            this.weight = weight;
            return this;
        }
    
        /**
         * The priority
         * 
         * @param priority The priority
         * @return this
         */
        public OriginationUrlUpdater setPriority(Integer priority) {
            this.priority = priority;
            return this;
        }
    
        /**
         * The enabled
         * 
         * @param enabled The enabled
         * @return this
         */
        public OriginationUrlUpdater setEnabled(Boolean enabled) {
            this.enabled = enabled;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public OriginationUrlUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The sip_url
         * 
         * @param sipUrl The sip_url
         * @return this
         */
        public OriginationUrlUpdater setSipUrl(URI sipUrl) {
            this.sipUrl = sipUrl;
            return this;
        }
    
        /**
         * The sip_url
         * 
         * @param sipUrl The sip_url
         * @return this
         */
        public OriginationUrlUpdater setSipUrl(String sipUrl) {
            return setSipUrl(Promoter.uriFromString(sipUrl));
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated OriginationUrl
         */
        [Override]
        public OriginationUrl execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrl update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
                request.addPostParam("Weight", weight.toString());
            }
            
            if (priority != null) {
                request.addPostParam("Priority", priority.toString());
            }
            
            if (enabled != null) {
                request.addPostParam("Enabled", enabled.toString());
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (sipUrl != null) {
                request.addPostParam("SipUrl", sipUrl.toString());
            }
        }
    }
}