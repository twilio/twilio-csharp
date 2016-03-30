using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Creators.Api.V2010.Account.Sip {

    public class DomainCreator : Creator<DomainResource> {
        private string accountSid;
        private string domainName;
        private string friendlyName;
        private Uri voiceUrl;
        private System.Net.Http.HttpMethod voiceMethod;
        private Uri voiceFallbackUrl;
        private System.Net.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceStatusCallbackUrl;
        private System.Net.Http.HttpMethod voiceStatusCallbackMethod;
    
        /**
         * Construct a new DomainCreator
         * 
         * @param accountSid The account_sid
         * @param domainName The unique address on Twilio to route SIP traffic
         */
        public DomainCreator(string accountSid, string domainName) {
            this.accountSid = accountSid;
            this.domainName = domainName;
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public DomainCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The URL Twilio will request when this domain receives a call
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public DomainCreator setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when this domain receives a call
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public DomainCreator setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /**
         * The HTTP method to use with the voice_url
         * 
         * @param voiceMethod HTTP method to use with voice_url
         * @return this
         */
        public DomainCreator setVoiceMethod(System.Net.Http.HttpMethod voiceMethod) {
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
        public DomainCreator setVoiceFallbackUrl(Uri voiceFallbackUrl) {
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
        public DomainCreator setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the VoiceFallbackUrl
         * 
         * @param voiceFallbackMethod HTTP method used with voice_fallback_url
         * @return this
         */
        public DomainCreator setVoiceFallbackMethod(System.Net.Http.HttpMethod voiceFallbackMethod) {
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
        public DomainCreator setVoiceStatusCallbackUrl(Uri voiceStatusCallbackUrl) {
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
        public DomainCreator setVoiceStatusCallbackUrl(string voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.UriFromString(voiceStatusCallbackUrl));
        }
    
        /**
         * The voice_status_callback_method
         * 
         * @param voiceStatusCallbackMethod The voice_status_callback_method
         * @return this
         */
        public DomainCreator setVoiceStatusCallbackMethod(System.Net.Http.HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created DomainResource
         */
        public override async Task<DomainResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains.json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("DomainResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return DomainResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (domainName != null) {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
        }
    }
}