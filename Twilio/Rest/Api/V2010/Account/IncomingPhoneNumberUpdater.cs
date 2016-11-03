using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class IncomingPhoneNumberUpdater : Updater<IncomingPhoneNumberResource> 
    {
        public string ownerAccountSid { get; set; }
        public string sid { get; }
        public string accountSid { get; set; }
        public string apiVersion { get; set; }
        public string friendlyName { get; set; }
        public string smsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsUrl { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public string trunkSid { get; set; }
        public string voiceApplicationSid { get; set; }
        public bool? voiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri voiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new IncomingPhoneNumberUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public IncomingPhoneNumberUpdater(string sid)
        {
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated IncomingPhoneNumberResource </returns> 
        public override async Task<IncomingPhoneNumberResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource update failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated IncomingPhoneNumberResource </returns> 
        public override IncomingPhoneNumberResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource update failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (accountSid != null)
            {
                request.AddPostParam("AccountSid", accountSid);
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
            
            if (trunkSid != null)
            {
                request.AddPostParam("TrunkSid", trunkSid);
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