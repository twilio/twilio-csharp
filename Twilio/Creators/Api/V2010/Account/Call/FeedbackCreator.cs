using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Call;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account.Call {

    public class FeedbackCreator : Creator<FeedbackResource> {
        private string accountSid;
        private string callSid;
        private int? qualityScore;
        private List<FeedbackResource.Issues> issue;
    
        /**
         * Construct a new FeedbackCreator
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore The quality_score
         */
        public FeedbackCreator(string accountSid, string callSid, int? qualityScore) {
            this.accountSid = accountSid;
            this.callSid = callSid;
            this.qualityScore = qualityScore;
        }
    
        /**
         * The issue
         * 
         * @param issue The issue
         * @return this
         */
        public FeedbackCreator setIssue(List<FeedbackResource.Issues> issue) {
            this.issue = issue;
            return this;
        }
    
        /**
         * The issue
         * 
         * @param issue The issue
         * @return this
         */
        public FeedbackCreator setIssue(FeedbackResource.Issues issue) {
            return setIssue(Promoter.ListOfOne(issue));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created FeedbackResource
         */
        public override async Task<FeedbackResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.Created) {
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
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created FeedbackResource
         */
        public override FeedbackResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Feedback.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.Created) {
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