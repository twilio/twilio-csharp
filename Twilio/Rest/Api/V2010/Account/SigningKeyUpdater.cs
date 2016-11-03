using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class SigningKeyUpdater : Updater<SigningKeyResource> 
    {
        public string accountSid { get; set; }
        public string sid { get; }
        public string friendlyName { get; set; }
    
        /// <summary>
        /// Construct a new SigningKeyUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public SigningKeyUpdater(string sid)
        {
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SigningKeyResource </returns> 
        public override async Task<SigningKeyResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SigningKeys/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("SigningKeyResource update failed: Unable to connect to server");
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
            
            return SigningKeyResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated SigningKeyResource </returns> 
        public override SigningKeyResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SigningKeys/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("SigningKeyResource update failed: Unable to connect to server");
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
            
            return SigningKeyResource.FromJson(response.Content);
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
        }
    }
}