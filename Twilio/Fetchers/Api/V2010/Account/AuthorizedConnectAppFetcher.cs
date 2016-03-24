using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class AuthorizedConnectAppFetcher : Fetcher<AuthorizedConnectAppResource> {
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
         * @return Fetched AuthorizedConnectAppResource
         */
        public override AuthorizedConnectAppResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AuthorizedConnectApps/" + this.connectAppSid + ".json"
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AuthorizedConnectAppResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return AuthorizedConnectAppResource.fromJson(response.GetContent());
        }
    }
}