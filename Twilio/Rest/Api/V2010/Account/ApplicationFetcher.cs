using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ApplicationFetcher : Fetcher<ApplicationResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new ApplicationFetcher
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Application Sid </param>
        public ApplicationFetcher(string sid)
        {
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched ApplicationResource </returns> 
        public override async System.Threading.Tasks.Task<ApplicationResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Applications/" + Sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ApplicationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched ApplicationResource </returns> 
        public override ApplicationResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Applications/" + Sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ApplicationResource.FromJson(response.Content);
        }
    }
}