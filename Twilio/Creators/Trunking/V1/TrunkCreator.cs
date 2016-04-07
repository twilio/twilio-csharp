using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1;

namespace Twilio.Creators.Trunking.V1 {

    public class TrunkCreator : Creator<TrunkResource> {
        private string friendlyName;
        private string domainName;
        private Uri disasterRecoveryUrl;
        private System.Net.Http.HttpMethod disasterRecoveryMethod;
        private string recording;
        private bool? secure;
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TrunkCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The domain_name
         * 
         * @param domainName The domain_name
         * @return this
         */
        public TrunkCreator setDomainName(string domainName) {
            this.domainName = domainName;
            return this;
        }
    
        /**
         * The disaster_recovery_url
         * 
         * @param disasterRecoveryUrl The disaster_recovery_url
         * @return this
         */
        public TrunkCreator setDisasterRecoveryUrl(Uri disasterRecoveryUrl) {
            this.disasterRecoveryUrl = disasterRecoveryUrl;
            return this;
        }
    
        /**
         * The disaster_recovery_url
         * 
         * @param disasterRecoveryUrl The disaster_recovery_url
         * @return this
         */
        public TrunkCreator setDisasterRecoveryUrl(string disasterRecoveryUrl) {
            return setDisasterRecoveryUrl(Promoter.UriFromString(disasterRecoveryUrl));
        }
    
        /**
         * The disaster_recovery_method
         * 
         * @param disasterRecoveryMethod The disaster_recovery_method
         * @return this
         */
        public TrunkCreator setDisasterRecoveryMethod(System.Net.Http.HttpMethod disasterRecoveryMethod) {
            this.disasterRecoveryMethod = disasterRecoveryMethod;
            return this;
        }
    
        /**
         * The recording
         * 
         * @param recording The recording
         * @return this
         */
        public TrunkCreator setRecording(string recording) {
            this.recording = recording;
            return this;
        }
    
        /**
         * The secure
         * 
         * @param secure The secure
         * @return this
         */
        public TrunkCreator setSecure(bool? secure) {
            this.secure = secure;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created TrunkResource
         */
        public override async Task<TrunkResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TrunkResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return TrunkResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (domainName != null) {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (disasterRecoveryUrl != null) {
                request.AddPostParam("DisasterRecoveryUrl", disasterRecoveryUrl.ToString());
            }
            
            if (disasterRecoveryMethod != null) {
                request.AddPostParam("DisasterRecoveryMethod", disasterRecoveryMethod.ToString());
            }
            
            if (recording != null) {
                request.AddPostParam("Recording", recording);
            }
            
            if (secure != null) {
                request.AddPostParam("Secure", secure.ToString());
            }
        }
    }
}