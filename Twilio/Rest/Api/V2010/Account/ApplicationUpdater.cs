using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ApplicationUpdater : Updater<ApplicationResource> {
        public string accountSid { get; }
        public string sid { get; }
        public string friendlyName { get; set; }
        public string apiVersion { get; set; }
        public Uri voiceUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public bool? voiceCallerIdLookup { get; set; }
        public Uri smsUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        public Uri smsStatusCallback { get; set; }
        public Uri messageStatusCallback { get; set; }
    
        /// <summary>
        /// Construct a new ApplicationUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <param name="apiVersion"> The API version to use </param>
        /// <param name="voiceUrl"> URL Twilio will make requests to when relieving a call </param>
        /// <param name="voiceMethod"> HTTP method to use with the URL </param>
        /// <param name="voiceFallbackUrl"> Fallback URL </param>
        /// <param name="voiceFallbackMethod"> HTTP method to use with the fallback url </param>
        /// <param name="statusCallback"> URL to hit with status updates </param>
        /// <param name="statusCallbackMethod"> HTTP method to use with the status callback </param>
        /// <param name="voiceCallerIdLookup"> True or False </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="smsMethod"> HTTP method to use with sms_url </param>
        /// <param name="smsFallbackUrl"> Fallback URL if there's an error parsing TwiML </param>
        /// <param name="smsFallbackMethod"> HTTP method to use with sms_fallback_method </param>
        /// <param name="smsStatusCallback"> URL Twilio with request with status updates </param>
        /// <param name="messageStatusCallback"> URL to make requests to with status updates </param>
        public ApplicationUpdater(string sid, string accountSid=null, string friendlyName=null, string apiVersion=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, bool? voiceCallerIdLookup=null, Uri smsUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsStatusCallback=null, Uri messageStatusCallback=null) {
            this.apiVersion = apiVersion;
            this.smsUrl = smsUrl;
            this.sid = sid;
            this.smsFallbackUrl = smsFallbackUrl;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.messageStatusCallback = messageStatusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            this.voiceMethod = voiceMethod;
            this.statusCallback = statusCallback;
            this.smsMethod = smsMethod;
            this.accountSid = accountSid;
            this.voiceUrl = voiceUrl;
            this.smsStatusCallback = smsStatusCallback;
            this.friendlyName = friendlyName;
            this.smsFallbackMethod = smsFallbackMethod;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ApplicationResource </returns> 
        public override async Task<ApplicationResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Applications/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ApplicationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ApplicationResource </returns> 
        public override ApplicationResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Applications/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ApplicationResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != null) {
                request.AddPostParam("ApiVersion", apiVersion);
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
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceCallerIdLookup != null) {
                request.AddPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsFallbackMethod != null) {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsStatusCallback != null) {
                request.AddPostParam("SmsStatusCallback", smsStatusCallback.ToString());
            }
            
            if (messageStatusCallback != null) {
                request.AddPostParam("MessageStatusCallback", messageStatusCallback.ToString());
            }
        }
    }
}