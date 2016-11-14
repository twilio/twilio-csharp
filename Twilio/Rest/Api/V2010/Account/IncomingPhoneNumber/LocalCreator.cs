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

    public class LocalCreator : Creator<LocalResource> 
    {
        public string OwnerAccountSid { get; set; }
        public Twilio.Types.PhoneNumber PhoneNumber { get; }
        public string ApiVersion { get; set; }
        public string FriendlyName { get; set; }
        public string SmsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        public Uri SmsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        public Uri SmsUrl { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string VoiceApplicationSid { get; set; }
        public bool? VoiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new LocalCreator
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        public LocalCreator(Twilio.Types.PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created LocalResource </returns> 
        public override async Task<LocalResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (OwnerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            
            AddPostParams(request);
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
        public override LocalResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (OwnerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/Local.json"
            );
            
            AddPostParams(request);
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
        private void AddPostParams(Request request)
        {
            if (PhoneNumber != null)
            {
                request.AddPostParam("PhoneNumber", PhoneNumber.ToString());
            }
            
            if (ApiVersion != null)
            {
                request.AddPostParam("ApiVersion", ApiVersion);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (SmsApplicationSid != null)
            {
                request.AddPostParam("SmsApplicationSid", SmsApplicationSid);
            }
            
            if (SmsFallbackMethod != null)
            {
                request.AddPostParam("SmsFallbackMethod", SmsFallbackMethod.ToString());
            }
            
            if (SmsFallbackUrl != null)
            {
                request.AddPostParam("SmsFallbackUrl", SmsFallbackUrl.ToString());
            }
            
            if (SmsMethod != null)
            {
                request.AddPostParam("SmsMethod", SmsMethod.ToString());
            }
            
            if (SmsUrl != null)
            {
                request.AddPostParam("SmsUrl", SmsUrl.ToString());
            }
            
            if (StatusCallback != null)
            {
                request.AddPostParam("StatusCallback", StatusCallback.ToString());
            }
            
            if (StatusCallbackMethod != null)
            {
                request.AddPostParam("StatusCallbackMethod", StatusCallbackMethod.ToString());
            }
            
            if (VoiceApplicationSid != null)
            {
                request.AddPostParam("VoiceApplicationSid", VoiceApplicationSid);
            }
            
            if (VoiceCallerIdLookup != null)
            {
                request.AddPostParam("VoiceCallerIdLookup", VoiceCallerIdLookup.ToString());
            }
            
            if (VoiceFallbackMethod != null)
            {
                request.AddPostParam("VoiceFallbackMethod", VoiceFallbackMethod.ToString());
            }
            
            if (VoiceFallbackUrl != null)
            {
                request.AddPostParam("VoiceFallbackUrl", VoiceFallbackUrl.ToString());
            }
            
            if (VoiceMethod != null)
            {
                request.AddPostParam("VoiceMethod", VoiceMethod.ToString());
            }
            
            if (VoiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", VoiceUrl.ToString());
            }
        }
    }
}