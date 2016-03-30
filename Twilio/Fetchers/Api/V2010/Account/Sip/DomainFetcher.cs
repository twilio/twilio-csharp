using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Fetchers.Api.V2010.Account.Sip {

    public class DomainFetcher : Fetcher<DomainResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new DomainFetcher
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique Domain Sid
         */
        public DomainFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched DomainResource
         */
        public override async Task<DomainResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.sid + ".json"
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("DomainResource fetch failed: Unable to connect to server");
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
            
            return DomainResource.FromJson(response.GetContent());
        }
    }
}