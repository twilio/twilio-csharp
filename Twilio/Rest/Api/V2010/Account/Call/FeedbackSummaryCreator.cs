using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class FeedbackSummaryCreator : Creator<FeedbackSummaryResource> {
        private string accountSid;
        private DateTime? startDate;
        private DateTime? endDate;
        private bool? includeSubaccounts;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new FeedbackSummaryCreator.
         * 
         * @param startDate The start_date
         * @param endDate The end_date
         */
        public FeedbackSummaryCreator(DateTime? startDate, DateTime? endDate) {
            this.startDate = startDate;
            this.endDate = endDate;
        }
    
        /**
         * Construct a new FeedbackSummaryCreator
         * 
         * @param accountSid The account_sid
         * @param startDate The start_date
         * @param endDate The end_date
         */
        public FeedbackSummaryCreator(string accountSid, DateTime? startDate, DateTime? endDate) {
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
        public FeedbackSummaryCreator setIncludeSubaccounts(bool? includeSubaccounts) {
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
        public FeedbackSummaryCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created FeedbackSummaryResource
         */
        public override async Task<FeedbackSummaryResource> CreateAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackSummaryResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return FeedbackSummaryResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created FeedbackSummaryResource
         */
        public override FeedbackSummaryResource Create(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/FeedbackSummary.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("FeedbackSummaryResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return FeedbackSummaryResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (startDate != null) {
                request.AddPostParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.AddPostParam("EndDate", endDate.ToString());
            }
            
            if (includeSubaccounts != null) {
                request.AddPostParam("IncludeSubaccounts", includeSubaccounts.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
        }
    }
}