using System.Threading.Tasks;
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched OutgoingCallerIdResource
         */
        public override async Task<OutgoingCallerIdResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return OutgoingCallerIdResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched OutgoingCallerIdResource
         */
        public override OutgoingCallerIdResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds/" + this.sid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return OutgoingCallerIdResource.FromJson(response.GetContent());
        }
        #endif
    }
}