using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.AvailablePhoneNumberCountry;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class AvailablePhoneNumberCountryFetcher : Fetcher<AvailablePhoneNumberCountry> {
        private string accountSid;
        private string countryCode;
    
        /**
         * Construct a new AvailablePhoneNumberCountryFetcher
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         */
        public AvailablePhoneNumberCountryFetcher(string accountSid, string countryCode) {
            this.accountSid = accountSid;
            this.countryCode = countryCode;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched AvailablePhoneNumberCountry
         */
        [Override]
        public AvailablePhoneNumberCountry execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers/" + this.countryCode + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AvailablePhoneNumberCountry fetch failed: Unable to connect to server");
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
            
            return AvailablePhoneNumberCountry.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}