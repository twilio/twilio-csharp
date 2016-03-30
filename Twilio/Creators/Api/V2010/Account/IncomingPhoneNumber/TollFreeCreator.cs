using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.IncomingPhoneNumber;

namespace Twilio.Creators.Api.V2010.Account.IncomingPhoneNumber {

    public class TollFreeCreator : Creator<TollFreeResource> {
        private string ownerAccountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string apiVersion;
        private string friendlyName;
        private string smsApplicationSid;
        private System.Net.Http.HttpMethod smsFallbackMethod;
        private Uri smsFallbackUrl;
        private System.Net.Http.HttpMethod smsMethod;
        private Uri smsUrl;
        private Uri statusCallback;
        private System.Net.Http.HttpMethod statusCallbackMethod;
        private string voiceApplicationSid;
        private bool? voiceCallerIdLookup;
        private System.Net.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private System.Net.Http.HttpMethod voiceMethod;
        private Uri voiceUrl;
    
        /**
         * Construct a new TollFreeCreator
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param phoneNumber The phone_number
         */
        public TollFreeCreator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            this.ownerAccountSid = ownerAccountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The api_version
         * 
         * @param apiVersion The api_version
         * @return this
         */
        public TollFreeCreator setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TollFreeCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The sms_application_sid
         * 
         * @param smsApplicationSid The sms_application_sid
         * @return this
         */
        public TollFreeCreator setSmsApplicationSid(string smsApplicationSid) {
            this.smsApplicationSid = smsApplicationSid;
            return this;
        }
    
        /**
         * The sms_fallback_method
         * 
         * @param smsFallbackMethod The sms_fallback_method
         * @return this
         */
        public TollFreeCreator setSmsFallbackMethod(System.Net.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /**
         * The sms_fallback_url
         * 
         * @param smsFallbackUrl The sms_fallback_url
         * @return this
         */
        public TollFreeCreator setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /**
         * The sms_fallback_url
         * 
         * @param smsFallbackUrl The sms_fallback_url
         * @return this
         */
        public TollFreeCreator setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /**
         * The sms_method
         * 
         * @param smsMethod The sms_method
         * @return this
         */
        public TollFreeCreator setSmsMethod(System.Net.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /**
         * The sms_url
         * 
         * @param smsUrl The sms_url
         * @return this
         */
        public TollFreeCreator setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /**
         * The sms_url
         * 
         * @param smsUrl The sms_url
         * @return this
         */
        public TollFreeCreator setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public TollFreeCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public TollFreeCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The status_callback_method
         * 
         * @param statusCallbackMethod The status_callback_method
         * @return this
         */
        public TollFreeCreator setStatusCallbackMethod(System.Net.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * The voice_application_sid
         * 
         * @param voiceApplicationSid The voice_application_sid
         * @return this
         */
        public TollFreeCreator setVoiceApplicationSid(string voiceApplicationSid) {
            this.voiceApplicationSid = voiceApplicationSid;
            return this;
        }
    
        /**
         * The voice_caller_id_lookup
         * 
         * @param voiceCallerIdLookup The voice_caller_id_lookup
         * @return this
         */
        public TollFreeCreator setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /**
         * The voice_fallback_method
         * 
         * @param voiceFallbackMethod The voice_fallback_method
         * @return this
         */
        public TollFreeCreator setVoiceFallbackMethod(System.Net.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public TollFreeCreator setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The voice_fallback_url
         * 
         * @param voiceFallbackUrl The voice_fallback_url
         * @return this
         */
        public TollFreeCreator setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /**
         * The voice_method
         * 
         * @param voiceMethod The voice_method
         * @return this
         */
        public TollFreeCreator setVoiceMethod(System.Net.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public TollFreeCreator setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public TollFreeCreator setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created TollFreeResource
         */
        public override async Task<TollFreeResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers/TollFree.json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TollFreeResource creation failed: Unable to connect to server");
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
            
            return TollFreeResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (apiVersion != null) {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (smsApplicationSid != null) {
                request.AddPostParam("SmsApplicationSid", smsApplicationSid);
            }
            
            if (smsFallbackMethod != null) {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceApplicationSid != null) {
                request.AddPostParam("VoiceApplicationSid", voiceApplicationSid);
            }
            
            if (voiceCallerIdLookup != null) {
                request.AddPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
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
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}