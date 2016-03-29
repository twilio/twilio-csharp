using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sms;

namespace Twilio.Fetchers.Api.V2010.Account.Sms {

    public class ShortCodeFetcher : Fetcher<ShortCodeResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new ShortCodeFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique short-code Sid
         */
        public ShortCodeFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched ShortCodeResource
         */
        public override async Task<ShortCodeResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/ShortCodes/" + this.sid + ".json"
            );
            
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ShortCodeResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            return ShortCodeResource.FromJson(response.GetContent());
        }
    }
}