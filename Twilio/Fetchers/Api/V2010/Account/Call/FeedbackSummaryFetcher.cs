using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Call;

namespace Twilio.Fetchers.Api.V2010.Account.Call {

    public class FeedbackSummaryFetcher : Fetcher<FeedbackSummaryResource> {
        private string accountSid;
        private string sid;
    
        /**
         * Construct a new FeedbackSummaryFetcher
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public FeedbackSummaryFetcher(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched FeedbackSummaryResource
         */
        public override async Task<FeedbackSummaryResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/FeedbackSummary/" + this.sid + ".json"
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackSummaryResource fetch failed: Unable to connect to server");
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
            
            return FeedbackSummaryResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched FeedbackSummaryResource
         */
        public override FeedbackSummaryResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/FeedbackSummary/" + this.sid + ".json"
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackSummaryResource fetch failed: Unable to connect to server");
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
            
            return FeedbackSummaryResource.FromJson(response.GetContent());
        }
        #endif
    }
}