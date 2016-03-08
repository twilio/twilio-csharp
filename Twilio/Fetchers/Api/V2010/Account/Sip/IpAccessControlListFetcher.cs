using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.IpAccessControlList;

namespace Twilio.Fetchers.Api.V2010.Account.Sip {

    public class IpAccessControlListFetcher : Fetcher<IpAccessControlList> {
        private String accountSid;
        private String sid;
    
        /**
         * Construct a new IpAccessControlListFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique ip-access-control-list Sid
         */
        public IpAccessControlListFetcher(String accountSid, String sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched IpAccessControlList
         */
        [Override]
        public IpAccessControlList execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/IpAccessControlLists/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlList fetch failed: Unable to connect to server");
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
            
            return IpAccessControlList.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}