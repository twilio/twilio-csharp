using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.AuthorizedConnectApp;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class AuthorizedConnectAppFetcher : Fetcher<AuthorizedConnectApp> {
        private string accountSid;
        private string connectAppSid;
    
        /**
         * Construct a new AuthorizedConnectAppFetcher
         * 
         * @param accountSid The account_sid
         * @param connectAppSid The connect_app_sid
         */
        public AuthorizedConnectAppFetcher(string accountSid, string connectAppSid) {
            this.accountSid = accountSid;
            this.connectAppSid = connectAppSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched AuthorizedConnectApp
         */
        [Override]
        public AuthorizedConnectApp execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AuthorizedConnectApps/" + this.connectAppSid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AuthorizedConnectApp fetch failed: Unable to connect to server");
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
            
            return AuthorizedConnectApp.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}