using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class SandboxUpdater : Updater<SandboxResource> {
        public string accountSid { get; }
        public Uri voiceUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri smsUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new SandboxUpdater.
        /// </summary>
        public SandboxUpdater() {
        }
    
        /// <summary>
        /// Construct a new SandboxUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public SandboxUpdater(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public SandboxUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The voice_url
        /// </summary>
        ///
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> this </returns> 
        public SandboxUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /// <summary>
        /// The voice_method
        /// </summary>
        ///
        /// <param name="voiceMethod"> The voice_method </param>
        /// <returns> this </returns> 
        public SandboxUpdater setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The sms_url
        /// </summary>
        ///
        /// <param name="smsUrl"> The sms_url </param>
        /// <returns> this </returns> 
        public SandboxUpdater setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /// <summary>
        /// The sms_url
        /// </summary>
        ///
        /// <param name="smsUrl"> The sms_url </param>
        /// <returns> this </returns> 
        public SandboxUpdater setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /// <summary>
        /// The sms_method
        /// </summary>
        ///
        /// <param name="smsMethod"> The sms_method </param>
        /// <returns> this </returns> 
        public SandboxUpdater setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public SandboxUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// The status_callback
        /// </summary>
        ///
        /// <param name="statusCallback"> The status_callback </param>
        /// <returns> this </returns> 
        public SandboxUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The status_callback_method
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> this </returns> 
        public SandboxUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SandboxResource </returns> 
        public override async Task<SandboxResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Sandbox.json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SandboxResource update failed: Unable to connect to server");
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
            
            return SandboxResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SandboxResource </returns> 
        public override SandboxResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Sandbox.json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SandboxResource update failed: Unable to connect to server");
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
            
            return SandboxResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}