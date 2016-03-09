using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Call;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class CallReader : Reader<Call> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string parentCallSid;
        private Call.Status status;
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
        public CallReader byStatus(Call.Status status) {
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
         * @return Call ResourceSet
         */
        [Override]
        public ResourceSet<Call> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Calls.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Call> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<Call> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Call Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Call> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Call read failed: Unable to connect to server");
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
            
            Page<Call> result = new Page<>();
            result.deserialize("calls", response.getContent(), Call.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (to != null) {
                request.addQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.addQueryParam("From", from.ToString());
            }
            
            if (parentCallSid != null) {
                request.addQueryParam("ParentCallSid", parentCallSid);
            }
            
            if (status != null) {
                request.addQueryParam("Status", status.ToString());
            }
            
            if (startTime != null) {
                request.addQueryParam("StartTime", startTime);
            }
            
            if (endTime != null) {
                request.addQueryParam("EndTime", endTime);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}