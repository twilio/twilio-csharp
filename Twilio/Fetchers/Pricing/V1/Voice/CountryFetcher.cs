using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Pricing.V1.voice.Country;

namespace Twilio.Fetchers.Pricing.V1.Voice {

    public class CountryFetcher : Fetcher<Country> {
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
         * @return Fetched Country
         */
        [Override]
        public Country execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.PRICING,
                "/v1/Voice/Countries/" + this.isoCountry + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Country fetch failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Country.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}