using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class AvailablePhoneNumberCountryFetcher : Fetcher<AvailablePhoneNumberCountryResource> {
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
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched AvailablePhoneNumberCountryResource
         */
        public override async Task<AvailablePhoneNumberCountryResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers/" + this.countryCode + ".json"
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource fetch failed: Unable to connect to server");
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
            
            return AvailablePhoneNumberCountryResource.FromJson(response.GetContent());
        }
    }
}