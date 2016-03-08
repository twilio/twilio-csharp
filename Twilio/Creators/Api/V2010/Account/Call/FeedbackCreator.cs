using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.call.Feedback;
using java.util.List;

namespace Twilio.Creators.Api.V2010.Account.Call {

    public class FeedbackCreator : Creator<Feedback> {
        private String accountSid;
        private String callSid;
        private Integer qualityScore;
        private List<Feedback.Issues> issue;
    
        /**
         * Construct a new FeedbackCreator
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore The quality_score
         */
        public FeedbackCreator(String accountSid, String callSid, Integer qualityScore) {
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
        public FeedbackCreator setIssue(List<Feedback.Issues> issue) {
            this.issue = issue;
            return this;
        }
    
        /**
         * The issue
         * 
         * @param issue The issue
         * @return this
         */
        public FeedbackCreator setIssue(Feedback.Issues issue) {
            return setIssue(Promoter.listOfOne(issue));
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Feedback
         */
        [Override]
        public Feedback execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/" + this.callSid + "/Feedback.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Feedback creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return Feedback.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (qualityScore != null) {
                request.addPostParam("QualityScore", qualityScore.toString());
            }
            
            if (issue != null) {
                request.addPostParam("Issue", issue.toString());
            }
        }
    }
}