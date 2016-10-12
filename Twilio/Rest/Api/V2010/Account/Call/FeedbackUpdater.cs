using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class FeedbackUpdater : Updater<FeedbackResource> {
        private string accountSid;
        private string callSid;
        private int? qualityScore;
        private List<FeedbackResource.Issues> issue;
    
        /**
         * Construct a new FeedbackUpdater.
         * 
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         */
        public FeedbackUpdater(string callSid, int? qualityScore) {
            this.callSid = callSid;
            this.qualityScore = qualityScore;
        }
    
        /**
         * Construct a new FeedbackUpdater
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         */
        public FeedbackUpdater(string accountSid, string callSid, int? qualityScore) {
            this.accountSid = accountSid;
            this.callSid = callSid;
            this.qualityScore = qualityScore;
        }
    
        /**
         * One or more of the issues experienced during the call
         * 
         * @param issue Issues experienced during the call
         * @return this
         */
        public FeedbackUpdater setIssue(List<FeedbackResource.Issues> issue) {
            this.issue = issue;
            return this;
        }
    
        /**
         * One or more of the issues experienced during the call
         * 
         * @param issue Issues experienced during the call
         * @return this
         */
        public FeedbackUpdater setIssue(FeedbackResource.Issues issue) {
            return setIssue(Promoter.ListOfOne(issue));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated FeedbackResource
         */
        public override async Task<FeedbackResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.callSid + "/Feedback.json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated FeedbackResource
         */
        public override FeedbackResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.callSid + "/Feedback.json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("FeedbackResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return FeedbackResource.FromJson(response.Content);
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (qualityScore != null) {
                request.AddPostParam("QualityScore", qualityScore.ToString());
            }
            
            if (issue != null) {
                request.AddPostParam("Issue", issue.ToString());
            }
        }
    }
}