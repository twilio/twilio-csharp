using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1 
{

    public class TrunkCreator : Creator<TrunkResource> 
    {
        public string friendlyName { get; set; }
        public string domainName { get; set; }
        public Uri disasterRecoveryUrl { get; set; }
        public Twilio.Http.HttpMethod disasterRecoveryMethod { get; set; }
        public string recording { get; set; }
        public bool? secure { get; set; }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TrunkResource </returns> 
        public override async Task<TrunkResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource creation failed: Unable to connect to server");
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
            
            return TrunkResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TrunkResource </returns> 
        public override TrunkResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource creation failed: Unable to connect to server");
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
            
            return TrunkResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (domainName != null)
            {
                request.AddPostParam("DomainName", domainName);
            }
            
            if (disasterRecoveryUrl != null)
            {
                request.AddPostParam("DisasterRecoveryUrl", disasterRecoveryUrl.ToString());
            }
            
            if (disasterRecoveryMethod != null)
            {
                request.AddPostParam("DisasterRecoveryMethod", disasterRecoveryMethod.ToString());
            }
            
            if (recording != null)
            {
                request.AddPostParam("Recording", recording);
            }
            
            if (secure != null)
            {
                request.AddPostParam("Secure", secure.ToString());
            }
        }
    }
}