using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.OutgoingCallerId;

namespace Twilio.Fetchers.Api.V2010.Account {

    public class OutgoingCallerIdFetcher : Fetcher<OutgoingCallerId> {
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
         * @return Fetched OutgoingCallerId
         */
        [Override]
        public OutgoingCallerId execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerId fetch failed: Unable to connect to server");
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
            
            return OutgoingCallerId.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}