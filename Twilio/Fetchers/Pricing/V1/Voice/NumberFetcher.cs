using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Pricing.V1.voice.Number;

namespace Twilio.Fetchers.Pricing.V1.Voice {

    public class NumberFetcher : Fetcher<Number> {
        private com.twilio.types.PhoneNumber number;
    
        /**
         * Construct a new NumberFetcher
         * 
         * @param number The number
         */
        public NumberFetcher(com.twilio.types.PhoneNumber number) {
            this.number = number;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched Number
         */
        [Override]
        public Number execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.PRICING,
                "/v1/Voice/Numbers/" + this.number + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Number fetch failed: Unable to connect to server");
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
            
            return Number.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}