using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class OutgoingCallerIdFetcher : Fetcher<OutgoingCallerIdResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new OutgoingCallerIdFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique outgoing-caller-id Sid
         */
        public OutgoingCallerIdFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched OutgoingCallerIdResource
         */
        public override OutgoingCallerIdResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json"
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource fetch failed: Unable to connect to server");
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
            
            return OutgoingCallerIdResource.fromJson(response.GetContent());
        }
    }
}