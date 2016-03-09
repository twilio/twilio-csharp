using System;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.incoming_phone_number.TollFree;

namespace Twilio.Creators.Api.V2010.Account.Incomingphonenumber {

    public class TollFreeCreator : Creator<TollFree> {
        private string ownerAccountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string apiVersion;
        private string friendlyName;
        private string smsApplicationSid;
        private HttpMethod smsFallbackMethod;
        private Uri smsFallbackUrl;
        private HttpMethod smsMethod;
        private Uri smsUrl;
        private Uri statusCallback;
        private HttpMethod statusCallbackMethod;
        private string voiceApplicationSid;
        private bool voiceCallerIdLookup;
        private HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private HttpMethod voiceMethod;
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
        public TollFreeCreator setSmsFallbackMethod(HttpMethod smsFallbackMethod) {
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
        public TollFreeCreator setSmsMethod(HttpMethod smsMethod) {
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
        public TollFreeCreator setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
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
        public TollFreeCreator setVoiceCallerIdLookup(bool voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /**
         * The voice_fallback_method
         * 
         * @param voiceFallbackMethod The voice_fallback_method
         * @return this
         */
        public TollFreeCreator setVoiceFallbackMethod(HttpMethod voiceFallbackMethod) {
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
        public TollFreeCreator setVoiceMethod(HttpMethod voiceMethod) {
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
         * @return Created TollFree
         */
        [Override]
        public TollFree execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers/TollFree.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TollFree creation failed: Unable to connect to server");
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
            
            return TollFree.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.addPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (apiVersion != null) {
                request.addPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (smsApplicationSid != null) {
                request.addPostParam("SmsApplicationSid", smsApplicationSid);
            }
            
            if (smsFallbackMethod != null) {
                request.addPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.addPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.addPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsUrl != null) {
                request.addPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceApplicationSid != null) {
                request.addPostParam("VoiceApplicationSid", voiceApplicationSid);
            }
            
            if (voiceCallerIdLookup != null) {
                request.addPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
            }
            
            if (voiceFallbackMethod != null) {
                request.addPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.addPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.addPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceUrl != null) {
                request.addPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}