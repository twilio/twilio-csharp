using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.Domain;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Api.V2010.Account.Sip {

    public class DomainUpdater : Updater<Domain> {
        private String accountSid;
        private String sid;
        private String apiVersion;
        private String friendlyName;
        private HttpMethod voiceFallbackMethod;
        private URI voiceFallbackUrl;
        private HttpMethod voiceMethod;
        private HttpMethod voiceStatusCallbackMethod;
        private URI voiceStatusCallbackUrl;
        private URI voiceUrl;
    
        /**
         * Construct a new DomainUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public DomainUpdater(String accountSid, String sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The api_version
         * 
         * @param apiVersion The api_version
         * @return this
         */
        public DomainUpdater setApiVersion(String apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public DomainUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The voice_fallback_method
         * 
         * @param voiceFallbackMethod The voice_fallback_method
         * @return this
         */
        public DomainUpdater setVoiceFallbackMethod(HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public DomainUpdater setVoiceFallbackUrl(URI voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public DomainUpdater setVoiceFallbackUrl(String voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.uriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method to use with the voice_url
         * 
         * @param voiceMethod HTTP method to use with voice_url
         * @return this
         */
        public DomainUpdater setVoiceMethod(HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The voice_status_callback_method
         * 
         * @param voiceStatusCallbackMethod The voice_status_callback_method
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackMethod(HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        /**
         * The voice_status_callback_url
         * 
         * @param voiceStatusCallbackUrl The voice_status_callback_url
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackUrl(URI voiceStatusCallbackUrl) {
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            return this;
        }
    
        /**
         * The voice_status_callback_url
         * 
         * @param voiceStatusCallbackUrl The voice_status_callback_url
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackUrl(String voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.uriFromString(voiceStatusCallbackUrl));
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public DomainUpdater setVoiceUrl(URI voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public DomainUpdater setVoiceUrl(String voiceUrl) {
            return setVoiceUrl(Promoter.uriFromString(voiceUrl));
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Domain
         */
        [Override]
        public Domain execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Domain update failed: Unable to connect to server");
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
            
            return Domain.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (apiVersion != null) {
                request.addPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (voiceFallbackMethod != null) {
                request.addPostParam("VoiceFallbackMethod", voiceFallbackMethod.toString());
            }
            
            if (voiceFallbackUrl != null) {
                request.addPostParam("VoiceFallbackUrl", voiceFallbackUrl.toString());
            }
            
            if (voiceMethod != null) {
                request.addPostParam("VoiceMethod", voiceMethod.toString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.addPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.toString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.addPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.toString());
            }
            
            if (voiceUrl != null) {
                request.addPostParam("VoiceUrl", voiceUrl.toString());
            }
        }
    }
}