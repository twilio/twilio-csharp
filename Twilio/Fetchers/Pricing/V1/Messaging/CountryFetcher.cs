using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Pricing.V1.Messaging;

namespace Twilio.Fetchers.Pricing.V1.Messaging {

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched CountryResource
         */
        public override async Task<CountryResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.PRICING,
                "/v1/Messaging/Countries/" + this.isoCountry + ""
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CountryResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched CountryResource
         */
        public override CountryResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.PRICING,
                "/v1/Messaging/Countries/" + this.isoCountry + ""
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CountryResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
        #endif
    }
}