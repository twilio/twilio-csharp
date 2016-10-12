using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber {

    public class LocalCreator : Creator<LocalResource> {
        private string ownerAccountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string apiVersion;
        private string friendlyName;
        private string smsApplicationSid;
        private Twilio.Http.HttpMethod smsFallbackMethod;
        private Uri smsFallbackUrl;
        private Twilio.Http.HttpMethod smsMethod;
        private Uri smsUrl;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
        private string voiceApplicationSid;
        private bool? voiceCallerIdLookup;
        private Twilio.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private Twilio.Http.HttpMethod voiceMethod;
        private Uri voiceUrl;
    
        /// <summary>
        /// Construct a new LocalCreator.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public LocalCreator(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// Construct a new LocalCreator
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="phoneNumber"> The phone_number </param>
        public LocalCreator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            this.ownerAccountSid = ownerAccountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /// <summary>
        /// The api_version
        /// </summary>
        ///
        /// <param name="apiVersion"> The api_version </param>
        /// <returns> this </returns> 
        public LocalCreator setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public LocalCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The sms_application_sid
        /// </summary>
        ///
        /// <param name="smsApplicationSid"> The sms_application_sid </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsApplicationSid(string smsApplicationSid) {
            this.smsApplicationSid = smsApplicationSid;
            return this;
        }
    
        /// <summary>
        /// The sms_fallback_method
        /// </summary>
        ///
        /// <param name="smsFallbackMethod"> The sms_fallback_method </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The sms_fallback_url
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> The sms_fallback_url </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The sms_fallback_url
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> The sms_fallback_url </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /// <summary>
        /// The sms_method
        /// </summary>
        ///
        /// <param name="smsMethod"> The sms_method </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /// <summary>
        /// The sms_url
        /// </summary>
        ///
        /// <param name="smsUrl"> The sms_url </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /// <summary>
        /// The sms_url
        /// </summary>
        ///
        /// <param name="smsUrl"> The sms_url </param>
        /// <returns> this </returns> 
        public LocalCreator setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public LocalCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public LocalCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The status_callback_method
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> this </returns> 
        public LocalCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_application_sid
        /// </summary>
        ///
        /// <param name="voiceApplicationSid"> The voice_application_sid </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceApplicationSid(string voiceApplicationSid) {
            this.voiceApplicationSid = voiceApplicationSid;
            return this;
        }
    
        /// <summary>
        /// The voice_caller_id_lookup
        /// </summary>
        ///
        /// <param name="voiceCallerIdLookup"> The voice_caller_id_lookup </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_method
        /// </summary>
        ///
        /// <param name="voiceFallbackMethod"> The voice_fallback_method </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_url
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_fallback_url
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /// <summary>
        /// The voice_method
        /// </summary>
        ///
        /// <param name="voiceMethod"> The voice_method </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public LocalCreator setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created LocalResource </returns> 
        public override async Task<LocalResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("LocalResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return LocalResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created LocalResource </returns> 
        public override LocalResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("LocalResource creation failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return LocalResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
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