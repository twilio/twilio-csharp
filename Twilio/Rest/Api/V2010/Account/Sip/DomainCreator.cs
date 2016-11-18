using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip 
{

    public class DomainCreator : Creator<DomainResource> 
    {
        public string AccountSid { get; set; }
        public string DomainName { get; }
        public string FriendlyName { get; set; }
        public string AuthType { get; set; }
        public Uri VoiceUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        public Uri VoiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        public Uri VoiceStatusCallbackUrl { get; set; }
        public Twilio.Http.HttpMethod VoiceStatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new DomainCreator
        /// </summary>
        ///
        /// <param name="domainName"> The unique address on Twilio to route SIP traffic </param>
        public DomainCreator(string domainName)
        {
            DomainName = domainName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created DomainResource </returns> 
        public override async System.Threading.Tasks.Task<DomainResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/SIP/Domains.json",
                client.Region
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
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/SIP/Domains.json",
                client.Region
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
            if (DomainName != null)
            {
                request.AddPostParam("DomainName", DomainName);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (AuthType != null)
            {
                request.AddPostParam("AuthType", AuthType);
            }
            
            if (VoiceUrl != null)
            {
                request.AddPostParam("VoiceUrl", VoiceUrl.ToString());
            }
            
            if (VoiceMethod != null)
            {
                request.AddPostParam("VoiceMethod", VoiceMethod.ToString());
            }
            
            if (VoiceFallbackUrl != null)
            {
                request.AddPostParam("VoiceFallbackUrl", VoiceFallbackUrl.ToString());
            }
            
            if (VoiceFallbackMethod != null)
            {
                request.AddPostParam("VoiceFallbackMethod", VoiceFallbackMethod.ToString());
            }
            
            if (VoiceStatusCallbackUrl != null)
            {
                request.AddPostParam("VoiceStatusCallbackUrl", VoiceStatusCallbackUrl.ToString());
            }
            
            if (VoiceStatusCallbackMethod != null)
            {
                request.AddPostParam("VoiceStatusCallbackMethod", VoiceStatusCallbackMethod.ToString());
            }
        }
    }
}