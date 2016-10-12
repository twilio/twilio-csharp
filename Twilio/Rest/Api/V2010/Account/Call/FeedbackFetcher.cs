using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class FeedbackFetcher : Fetcher<FeedbackResource> {
        private string accountSid;
        private string callSid;
    
        /// <summary>
        /// Construct a new FeedbackFetcher.
        /// </summary>
        ///
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        public FeedbackFetcher(string callSid) {
            this.callSid = callSid;
        }
    
        /// <summary>
        /// Construct a new FeedbackFetcher
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="callSid"> The call sid that uniquely identifies the call </param>
        public FeedbackFetcher(string accountSid, string callSid) {
            this.accountSid = accountSid;
            this.callSid = callSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched FeedbackResource </returns> 
        public override async Task<FeedbackResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched FeedbackResource </returns> 
        public override FeedbackResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource fetch failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
    }
}