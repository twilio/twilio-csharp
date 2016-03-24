using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class ConnectAppFetcher : Fetcher<ConnectAppResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new ConnectAppFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique connect-app Sid
         */
        public ConnectAppFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched ConnectAppResource
         */
        public override ConnectAppResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/ConnectApps/" + this.sid + ".json"
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ConnectAppResource fetch failed: Unable to connect to server");
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
            
            return ConnectAppResource.fromJson(response.GetContent());
        }
    }
}