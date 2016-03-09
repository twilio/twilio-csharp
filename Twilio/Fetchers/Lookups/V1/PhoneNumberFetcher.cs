using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Lookups.V1.PhoneNumber;

namespace Twilio.Fetchers.Lookups.V1 {

    public class PhoneNumberFetcher : Fetcher<PhoneNumber> {
        private Twilio.Types.PhoneNumber phoneNumber;
        private string countryCode;
        private string type;
    
        /**
         * Construct a new PhoneNumberFetcher
         * 
         * @param phoneNumber The phone_number
         */
        public PhoneNumberFetcher(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * The country_code
         * 
         * @param countryCode The country_code
         * @return this
         */
        public PhoneNumberFetcher setCountryCode(string countryCode) {
            this.countryCode = countryCode;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public PhoneNumberFetcher setType(string type) {
            this.type = type;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched PhoneNumber
         */
        [Override]
        public PhoneNumber execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.LOOKUPS,
                "/v1/PhoneNumbers/" + this.phoneNumber + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumber fetch failed: Unable to connect to server");
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
            
            return PhoneNumber.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}