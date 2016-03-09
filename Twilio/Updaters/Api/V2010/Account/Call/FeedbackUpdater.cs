using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.call.Feedback;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account.Call {

    public class FeedbackUpdater : Updater<Feedback> {
        private string accountSid;
        private string callSid;
        private int qualityScore;
        private List<Feedback.Issues> issue;
    
        /**
         * Construct a new FeedbackUpdater
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         * @param qualityScore An integer from 1 to 5
         */
        public FeedbackUpdater(string accountSid, string callSid, int qualityScore) {
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
        public FeedbackUpdater setIssue(List<Feedback.Issues> issue) {
            this.issue = issue;
            return this;
        }
    
        /**
         * One or more of the issues experienced during the call
         * 
         * @param issue Issues experienced during the call
         * @return this
         */
        public FeedbackUpdater setIssue(Feedback.Issues issue) {
            return setIssue(Promoter.listOfOne(issue));
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Feedback
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
                throw new ApiConnectionException("Feedback update failed: Unable to connect to server");
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
            
            return Feedback.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (qualityScore != null) {
                request.addPostParam("QualityScore", qualityScore.ToString());
            }
            
            if (issue != null) {
                request.addPostParam("Issue", issue.ToString());
            }
        }
    }
}