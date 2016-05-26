using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Call;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Call {

    public class FeedbackUpdater : Updater<FeedbackResource> {
        private string accountSid;
        private string callSid;
        private int? qualityScore;
        private List<FeedbackResource.Issues> issue;
    
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
        public override async Task<FeedbackResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackResource update failed: Unable to connect to server");
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
            
            return FeedbackResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated FeedbackResource
         */
        public override FeedbackResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackResource update failed: Unable to connect to server");
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
            
            return FeedbackResource.FromJson(response.GetContent());
        }
        #endif
    
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