using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AvailablePhoneNumberCountryFetcher : Fetcher<AvailablePhoneNumberCountryResource> 
    {
        public string accountSid { get; set; }
        public string countryCode { get; }
    
        /// <summary>
        /// Construct a new AvailablePhoneNumberCountryFetcher
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        public AvailablePhoneNumberCountryFetcher(string countryCode)
        {
            this.countryCode = countryCode;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched AvailablePhoneNumberCountryResource </returns> 
        public override async Task<AvailablePhoneNumberCountryResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource fetch failed: Unable to connect to server");
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
            
            return AvailablePhoneNumberCountryResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched AvailablePhoneNumberCountryResource </returns> 
        public override AvailablePhoneNumberCountryResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource fetch failed: Unable to connect to server");
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
            
            return AvailablePhoneNumberCountryResource.FromJson(response.Content);
        }
    }
}