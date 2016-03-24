using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class CallReader : Reader<CallResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string parentCallSid;
        private CallResource.Status status;
        private string startTime;
        private string endTime;
    
        /**
         * Construct a new CallReader
         * 
         * @param accountSid The account_sid
         */
        public CallReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show calls to this phone number or Client identifier
         * 
         * @param to Phone number or Client identifier to filter `to` on
         * @return this
         */
        public CallReader byTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /**
         * Only show calls from this phone number or Client identifier
         * 
         * @param from Phone number or Client identifier to filter `from` on
         * @return this
         */
        public CallReader byFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /**
         * Only show calls spawned by the call with this Sid
         * 
         * @param parentCallSid Parent Call Sid to filter on
         * @return this
         */
        public CallReader byParentCallSid(string parentCallSid) {
            this.parentCallSid = parentCallSid;
            return this;
        }
    
        /**
         * Only show calls currently in this status
         * 
         * @param status Status to filter on
         * @return this
         */
        public CallReader byStatus(CallResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Only show calls that started on this date
         * 
         * @param startTime StartTime to filter on
         * @return this
         */
        public CallReader byStartTime(string startTime) {
            this.startTime = startTime;
            return this;
        }
    
        /**
         * Only show call that ended on this date
         * 
         * @param endTime EndTime to filter on
         * @return this
         */
        public CallReader byEndTime(string endTime) {
            this.endTime = endTime;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return CallResource ResourceSet
         */
        public override ResourceSet<CallResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls.json"
            );
            
            AddQueryParams(request);
            
            Page<CallResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public Page<CallResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of CallResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<CallResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            Page<CallResource> result = new Page<>();
            result.deserialize("calls", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (to != null) {
                request.AddQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from.ToString());
            }
            
            if (parentCallSid != null) {
                request.AddQueryParam("ParentCallSid", parentCallSid);
            }
            
            if (status != null) {
                request.AddQueryParam("Status", status.ToString());
            }
            
            if (startTime != null) {
                request.AddQueryParam("StartTime", startTime);
            }
            
            if (endTime != null) {
                request.AddQueryParam("EndTime", endTime);
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}