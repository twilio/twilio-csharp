using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class DomainUpdater : Updater<DomainResource> 
    {
        public string accountSid { get; set; }
        public string sid { get; }
        public string authType { get; set; }
        public string friendlyName { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Twilio.Http.HttpMethod voiceStatusCallbackMethod { get; set; }
        public Uri voiceStatusCallbackUrl { get; set; }
        public Uri voiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new DomainUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DomainUpdater(string sid)
        {
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override async Task<DomainResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated DomainResource </returns> 
        public override DomainResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource update failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (authType != null)
            {
                request.AddPostParam("AuthType", authType);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
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
            
            if (voiceStatusCallbackMethod != null)
            {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null)
            {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}