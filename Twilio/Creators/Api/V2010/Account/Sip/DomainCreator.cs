using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.Domain;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;

namespace Twilio.Creators.Api.V2010.Account.Sip {

    public class DomainCreator : Creator<Domain> {
        private String accountSid;
        private String domainName;
        private String friendlyName;
        private URI voiceUrl;
        private HttpMethod voiceMethod;
        private URI voiceFallbackUrl;
        private HttpMethod voiceFallbackMethod;
        private URI voiceStatusCallbackUrl;
        private HttpMethod voiceStatusCallbackMethod;
    
        /**
         * Construct a new DomainCreator
         * 
         * @param accountSid The account_sid
         * @param domainName The unique address on Twilio to route SIP traffic
         */
        public DomainCreator(String accountSid, String domainName) {
            this.accountSid = accountSid;
            this.domainName = domainName;
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public DomainCreator setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The URL Twilio will request when this domain receives a call
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public DomainCreator setVoiceUrl(URI voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when this domain receives a call
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public DomainCreator setVoiceUrl(String voiceUrl) {
            return setVoiceUrl(Promoter.uriFromString(voiceUrl));
        }
    
        /**
         * The HTTP method to use with the voice_url
         * 
         * @param voiceMethod HTTP method to use with voice_url
         * @return this
         */
        public DomainCreator setVoiceMethod(HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will use if an error occurs retrieving or executing the
         * TwiML requested by VoiceUrl
         * 
         * @param voiceFallbackUrl URL Twilio will request if an error occurs in
         *                         executing TwiML
         * @return this
         */
        public DomainCreator setVoiceFallbackUrl(URI voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will use if an error occurs retrieving or executing the
         * TwiML requested by VoiceUrl
         * 
         * @param voiceFallbackUrl URL Twilio will request if an error occurs in
         *                         executing TwiML
         * @return this
         */
        public DomainCreator setVoiceFallbackUrl(String voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.uriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the VoiceFallbackUrl
         * 
         * @param voiceFallbackMethod HTTP method used with voice_fallback_url
         * @return this
         */
        public DomainCreator setVoiceFallbackMethod(HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request to pass status parameters
         * 
         * @param voiceStatusCallbackUrl URL that Twilio will request with status
         *                               updates
         * @return this
         */
        public DomainCreator setVoiceStatusCallbackUrl(URI voiceStatusCallbackUrl) {
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request to pass status parameters
         * 
         * @param voiceStatusCallbackUrl URL that Twilio will request with status
         *                               updates
         * @return this
         */
        public DomainCreator setVoiceStatusCallbackUrl(String voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.uriFromString(voiceStatusCallbackUrl));
        }
    
        /**
         * The voice_status_callback_method
         * 
         * @param voiceStatusCallbackMethod The voice_status_callback_method
         * @return this
         */
        public DomainCreator setVoiceStatusCallbackMethod(HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Domain
         */
        [Override]
        public Domain execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Domain creation failed: Unable to connect to server");
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
            
            return Domain.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (domainName != null) {
                request.addPostParam("DomainName", domainName);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (voiceUrl != null) {
                request.addPostParam("VoiceUrl", voiceUrl.toString());
            }
            
            if (voiceMethod != null) {
                request.addPostParam("VoiceMethod", voiceMethod.toString());
            }
            
            if (voiceFallbackUrl != null) {
                request.addPostParam("VoiceFallbackUrl", voiceFallbackUrl.toString());
            }
            
            if (voiceFallbackMethod != null) {
                request.addPostParam("VoiceFallbackMethod", voiceFallbackMethod.toString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.addPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.toString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.addPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.toString());
            }
        }
    }
}