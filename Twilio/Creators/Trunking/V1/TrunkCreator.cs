using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;

namespace Twilio.Creators.Trunking.V1 {

    public class TrunkCreator : Creator<Trunk> {
        private String friendlyName;
        private String domainName;
        private URI disasterRecoveryUrl;
        private HttpMethod disasterRecoveryMethod;
        private String recording;
        private Boolean secure;
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TrunkCreator setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The domain_name
         * 
         * @param domainName The domain_name
         * @return this
         */
        public TrunkCreator setDomainName(String domainName) {
            this.domainName = domainName;
            return this;
        }
    
        /**
         * The disaster_recovery_url
         * 
         * @param disasterRecoveryUrl The disaster_recovery_url
         * @return this
         */
        public TrunkCreator setDisasterRecoveryUrl(URI disasterRecoveryUrl) {
            this.disasterRecoveryUrl = disasterRecoveryUrl;
            return this;
        }
    
        /**
         * The disaster_recovery_url
         * 
         * @param disasterRecoveryUrl The disaster_recovery_url
         * @return this
         */
        public TrunkCreator setDisasterRecoveryUrl(String disasterRecoveryUrl) {
            return setDisasterRecoveryUrl(Promoter.uriFromString(disasterRecoveryUrl));
        }
    
        /**
         * The disaster_recovery_method
         * 
         * @param disasterRecoveryMethod The disaster_recovery_method
         * @return this
         */
        public TrunkCreator setDisasterRecoveryMethod(HttpMethod disasterRecoveryMethod) {
            this.disasterRecoveryMethod = disasterRecoveryMethod;
            return this;
        }
    
        /**
         * The recording
         * 
         * @param recording The recording
         * @return this
         */
        public TrunkCreator setRecording(String recording) {
            this.recording = recording;
            return this;
        }
    
        /**
         * The secure
         * 
         * @param secure The secure
         * @return this
         */
        public TrunkCreator setSecure(Boolean secure) {
            this.secure = secure;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Trunk
         */
        [Override]
        public Trunk execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Trunk creation failed: Unable to connect to server");
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
            
            return Trunk.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (domainName != null) {
                request.addPostParam("DomainName", domainName);
            }
            
            if (disasterRecoveryUrl != null) {
                request.addPostParam("DisasterRecoveryUrl", disasterRecoveryUrl.toString());
            }
            
            if (disasterRecoveryMethod != null) {
                request.addPostParam("DisasterRecoveryMethod", disasterRecoveryMethod.toString());
            }
            
            if (recording != null) {
                request.addPostParam("Recording", recording);
            }
            
            if (secure != null) {
                request.addPostParam("Secure", secure.toString());
            }
        }
    }
}