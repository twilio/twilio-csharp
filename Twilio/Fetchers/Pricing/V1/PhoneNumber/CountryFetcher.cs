using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Pricing.V1.PhoneNumber;

namespace Twilio.Fetchers.Pricing.V1.PhoneNumber {

    public class CountryFetcher : Fetcher<CountryResource> {
        private string isoCountry;
    
        /**
         * Construct a new CountryFetcher
         * 
         * @param isoCountry The iso_country
         */
        public CountryFetcher(string isoCountry) {
            this.isoCountry = isoCountry;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched CountryResource
         */
        public override async Task<CountryResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.PRICING,
                "/v1/PhoneNumbers/Countries/" + this.isoCountry + ""
            );
            
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CountryResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return CountryResource.FromJson(response.GetContent());
        }
    }
}