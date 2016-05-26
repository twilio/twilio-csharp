using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sip {

    public class DomainUpdater : Updater<DomainResource> {
        private string accountSid;
        private string sid;
        private string apiVersion;
        private string friendlyName;
        private System.Net.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private System.Net.Http.HttpMethod voiceMethod;
        private System.Net.Http.HttpMethod voiceStatusCallbackMethod;
        private Uri voiceStatusCallbackUrl;
        private Uri voiceUrl;
    
        /**
         * Construct a new DomainUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public DomainUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The api_version
         * 
         * @param apiVersion The api_version
         * @return this
         */
        public DomainUpdater setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * A user-specified, human-readable name for the trigger.
         * 
         * @param friendlyName A user-specified, human-readable name for the trigger.
         * @return this
         */
        public DomainUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The voice_fallback_method
         * 
         * @param voiceFallbackMethod The voice_fallback_method
         * @return this
         */
        public DomainUpdater setVoiceFallbackMethod(System.Net.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public DomainUpdater setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public DomainUpdater setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method to use with the voice_url
         * 
         * @param voiceMethod HTTP method to use with voice_url
         * @return this
         */
        public DomainUpdater setVoiceMethod(System.Net.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The voice_status_callback_method
         * 
         * @param voiceStatusCallbackMethod The voice_status_callback_method
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackMethod(System.Net.Http.HttpMethod voiceStatusCallbackMethod) {
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            return this;
        }
    
        /**
         * The voice_status_callback_url
         * 
         * @param voiceStatusCallbackUrl The voice_status_callback_url
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackUrl(Uri voiceStatusCallbackUrl) {
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            return this;
        }
    
        /**
         * The voice_status_callback_url
         * 
         * @param voiceStatusCallbackUrl The voice_status_callback_url
         * @return this
         */
        public DomainUpdater setVoiceStatusCallbackUrl(string voiceStatusCallbackUrl) {
            return setVoiceStatusCallbackUrl(Promoter.UriFromString(voiceStatusCallbackUrl));
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public DomainUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public DomainUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated DomainResource
         */
        public override async Task<DomainResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated DomainResource
         */
        public override DomainResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (apiVersion != "") {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceStatusCallbackMethod != null) {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null) {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}