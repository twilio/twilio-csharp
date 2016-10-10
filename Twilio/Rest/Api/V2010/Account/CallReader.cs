using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class CallReader : Reader<CallResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string parentCallSid;
        private CallResource.Status status;
        private string startTime;
        private string endTime;
    
        /**
         * Construct a new CallReader.
         */
        public CallReader() {
        }
    
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
        public CallReader ByTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /**
         * Only show calls from this phone number or Client identifier
         * 
         * @param from Phone number or Client identifier to filter `from` on
         * @return this
         */
        public CallReader ByFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /**
         * Only show calls spawned by the call with this Sid
         * 
         * @param parentCallSid Parent Call Sid to filter on
         * @return this
         */
        public CallReader ByParentCallSid(string parentCallSid) {
            this.parentCallSid = parentCallSid;
            return this;
        }
    
        /**
         * Only show calls currently in this status
         * 
         * @param status Status to filter on
         * @return this
         */
        public CallReader ByStatus(CallResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Only show calls that started on this date
         * 
         * @param startTime StartTime to filter on
         * @return this
         */
        public CallReader ByStartTime(string startTime) {
            this.startTime = startTime;
            return this;
        }
    
        /**
         * Only show call that ended on this date
         * 
         * @param endTime EndTime to filter on
         * @return this
         */
        public CallReader ByEndTime(string endTime) {
            this.endTime = endTime;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CallResource ResourceSet
         */
        public override Task<ResourceSet<CallResource>> ReadAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls.json"
            );
            
            AddQueryParams(request);
            
            Page<CallResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<CallResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CallResource ResourceSet
         */
        public override ResourceSet<CallResource> Read(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls.json"
            );
            
            AddQueryParams(request);
            
            Page<CallResource> page = PageForRequest(client, request);
            
            return new ResourceSet<CallResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<CallResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of CallResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<CallResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CallResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            Page<CallResource> result = new Page<CallResource>();
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
            
            
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}