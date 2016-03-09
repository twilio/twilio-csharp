using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.queue.Member;

namespace Twilio.Fetchers.Api.V2010.Account.Queue {

    public class MemberFetcher : Fetcher<Member> {
        private string accountSid;
        private string queueSid;
        private string callSid;
    
        /**
         * Construct a new MemberFetcher
         * 
         * @param accountSid The account_sid
         * @param queueSid The Queue in which to find the members
         * @param callSid The call_sid
         */
        public MemberFetcher(string accountSid, string queueSid, string callSid) {
            this.accountSid = accountSid;
            this.queueSid = queueSid;
            this.callSid = callSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched Member
         */
        [Override]
        public Member execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Queues/" + this.queueSid + "/Members/" + this.callSid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Member fetch failed: Unable to connect to server");
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
            
            return Member.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}