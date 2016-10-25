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

    public class DomainCreator : Creator<DomainResource> 
    {
        public string accountSid { get; }
        public string domainName { get; }
        public string friendlyName { get; set; }
        public string authType { get; set; }
        public Uri voiceUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri voiceStatusCallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceStatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new DomainCreator
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> A user-specified, human-readable name for the trigger. </param>
        /// <param name="authType"> The types of authentication mapped to the domain </param>
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <param name="voiceMethod"> HTTP method to use with voice_url </param>
        /// <param name="voiceFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="voiceFallbackMethod"> HTTP method used with voice_fallback_url </param>
        /// <param name="voiceStatusCallbackUrl"> URL that Twilio will request with status updates </param>
        /// <param name="voiceStatusCallbackMethod"> The voice_status_callback_method </param>
        public DomainCreator(string domainName, string accountSid=null, string friendlyName=null, string authType=null, Uri voiceUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceStatusCallbackUrl=null, Twilio.Http.HttpMethod voiceStatusCallbackMethod=null)
        {
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceMethod = voiceMethod;
            this.authType = authType;
            this.voiceStatusCallbackUrl = voiceStatusCallbackUrl;
            this.accountSid = accountSid;
            this.voiceUrl = voiceUrl;
            this.voiceStatusCallbackMethod = voiceStatusCallbackMethod;
            this.friendlyName = friendlyName;
            this.domainName = domainName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DomainResource </returns> 
        public override async Task<DomainResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource creation failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DomainResource </returns> 
        public override DomainResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DomainResource creation failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (domainName != null)
            {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (authType != null)
            {
                request.AddPostParam("AuthType", authType);
            }
            
            if (voiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
            
            if (voiceMethod != null)
            {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceFallbackUrl != null)
            {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceFallbackMethod != null)
            {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceStatusCallbackUrl != null)
            {
                request.AddPostParam("VoiceStatusCallbackUrl", voiceStatusCallbackUrl.ToString());
            }
            
            if (voiceStatusCallbackMethod != null)
            {
                request.AddPostParam("VoiceStatusCallbackMethod", voiceStatusCallbackMethod.ToString());
            }
        }
    }
}