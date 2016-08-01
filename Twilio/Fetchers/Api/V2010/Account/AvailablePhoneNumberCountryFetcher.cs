using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Fetchers.Api.V2010.Account {

    public class AvailablePhoneNumberCountryFetcher : Fetcher<AvailablePhoneNumberCountryResource> {
        private string accountSid;
        private string countryCode;
    
        /**
         * Construct a new AvailablePhoneNumberCountryFetcher.
         * 
         * @param countryCode The country_code
         */
        public AvailablePhoneNumberCountryFetcher(string countryCode) {
            this.countryCode = countryCode;
        }
    
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched AvailablePhoneNumberCountryResource
         */
        public override async Task<AvailablePhoneNumberCountryResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched AvailablePhoneNumberCountryResource
         */
        public override AvailablePhoneNumberCountryResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AvailablePhoneNumberCountryResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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