using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class TollFreeCreator : Creator<TollFreeResource> 
    {
        public string ownerAccountSid { get; }
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        public string apiVersion { get; set; }
        public string friendlyName { get; set; }
        public string smsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsUrl { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public string voiceApplicationSid { get; set; }
        public bool? voiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri voiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new TollFreeCreator
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="apiVersion"> The api_version </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="smsApplicationSid"> The sms_application_sid </param>
        /// <param name="smsFallbackMethod"> The sms_fallback_method </param>
        /// <param name="smsFallbackUrl"> The sms_fallback_url </param>
        /// <param name="smsMethod"> The sms_method </param>
        /// <param name="smsUrl"> The sms_url </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="voiceApplicationSid"> The voice_application_sid </param>
        /// <param name="voiceCallerIdLookup"> The voice_caller_id_lookup </param>
        /// <param name="voiceFallbackMethod"> The voice_fallback_method </param>
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <param name="voiceMethod"> The voice_method </param>
        /// <param name="voiceUrl"> The voice_url </param>
        public TollFreeCreator(Twilio.Types.PhoneNumber phoneNumber, string ownerAccountSid=null, string apiVersion=null, string friendlyName=null, string smsApplicationSid=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsUrl=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string voiceApplicationSid=null, bool? voiceCallerIdLookup=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceUrl=null)
        {
            this.apiVersion = apiVersion;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsUrl = smsUrl;
            this.ownerAccountSid = ownerAccountSid;
            this.voiceApplicationSid = voiceApplicationSid;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.statusCallbackMethod = statusCallbackMethod;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            this.voiceMethod = voiceMethod;
            this.statusCallback = statusCallback;
            this.smsMethod = smsMethod;
            this.voiceUrl = voiceUrl;
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
            this.smsFallbackMethod = smsFallbackMethod;
            this.smsApplicationSid = smsApplicationSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TollFreeResource </returns> 
        public override async Task<TollFreeResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/TollFree.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TollFreeResource creation failed: Unable to connect to server");
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
            
            return TollFreeResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TollFreeResource </returns> 
        public override TollFreeResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/TollFree.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TollFreeResource creation failed: Unable to connect to server");
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
            
            return TollFreeResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (phoneNumber != null)
            {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (apiVersion != null)
            {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (smsApplicationSid != null)
            {
                request.AddPostParam("SmsApplicationSid", smsApplicationSid);
            }
            
            if (smsFallbackMethod != null)
            {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsFallbackUrl != null)
            {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsMethod != null)
            {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsUrl != null)
            {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (statusCallback != null)
            {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceApplicationSid != null)
            {
                request.AddPostParam("VoiceApplicationSid", voiceApplicationSid);
            }
            
            if (voiceCallerIdLookup != null)
            {
                request.AddPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
            }
            
            if (voiceFallbackMethod != null)
            {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceFallbackUrl != null)
            {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceMethod != null)
            {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}