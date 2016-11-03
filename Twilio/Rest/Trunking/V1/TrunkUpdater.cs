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

    public class TrunkUpdater : Updater<TrunkResource> 
    {
        public string sid { get; }
        public string friendlyName { get; set; }
        public string domainName { get; set; }
        public Uri disasterRecoveryUrl { get; set; }
        public Twilio.Http.HttpMethod disasterRecoveryMethod { get; set; }
        public string recording { get; set; }
        public bool? secure { get; set; }
    
        /// <summary>
        /// Construct a new TrunkUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public TrunkUpdater(string sid)
        {
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TrunkResource </returns> 
        public override async Task<TrunkResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource update failed: Unable to connect to server");
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
            
            return TrunkResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TrunkResource </returns> 
        public override TrunkResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TrunkResource update failed: Unable to connect to server");
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