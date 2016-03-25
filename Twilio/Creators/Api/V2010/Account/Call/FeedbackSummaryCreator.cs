using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Call;

namespace Twilio.Creators.Api.V2010.Account.Call {

    public class FeedbackSummaryCreator : Creator<FeedbackSummaryResource> {
        private string accountSid;
        private DateTime startDate;
        private DateTime endDate;
        private bool includeSubaccounts;
        private Uri statusCallback;
        private System.Net.Http.HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new FeedbackSummaryCreator
         * 
         * @param accountSid The account_sid
         * @param startDate The start_date
         * @param endDate The end_date
         */
        public FeedbackSummaryCreator(string accountSid, DateTime startDate, DateTime endDate) {
            this.accountSid = accountSid;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    
        /**
         * The include_subaccounts
         * 
         * @param includeSubaccounts The include_subaccounts
         * @return this
         */
        public FeedbackSummaryCreator setIncludeSubaccounts(bool includeSubaccounts) {
            this.includeSubaccounts = includeSubaccounts;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public FeedbackSummaryCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public FeedbackSummaryCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The status_callback_method
         * 
         * @param statusCallbackMethod The status_callback_method
         * @return this
         */
        public FeedbackSummaryCreator setStatusCallbackMethod(System.Net.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created FeedbackSummaryResource
         */
        public FeedbackSummaryResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls/FeedbackSummary.json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackSummaryResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return FeedbackSummaryResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (startDate != null) {
                request.addPostParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.addPostParam("EndDate", endDate.ToString());
            }
            
            if (includeSubaccounts != null) {
                request.addPostParam("IncludeSubaccounts", includeSubaccounts.ToString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}