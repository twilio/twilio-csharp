using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account {

    public class OutgoingCallerIdReader : Reader<OutgoingCallerIdResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
    
        /**
         * Construct a new OutgoingCallerIdReader.
         */
        public OutgoingCallerIdReader() {
        }
    
        /**
         * Construct a new OutgoingCallerIdReader
         * 
         * @param accountSid The account_sid
         */
        public OutgoingCallerIdReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show the caller id resource that exactly matches this phone number
         * 
         * @param phoneNumber Filter by phone number
         * @return this
         */
        public OutgoingCallerIdReader ByPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Only show the caller id resource that exactly matches this name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public OutgoingCallerIdReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return OutgoingCallerIdResource ResourceSet
         */
        public override Task<ResourceSet<OutgoingCallerIdResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            AddQueryParams(request);
            
            Page<OutgoingCallerIdResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<OutgoingCallerIdResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return OutgoingCallerIdResource ResourceSet
         */
        public override ResourceSet<OutgoingCallerIdResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            AddQueryParams(request);
            
            Page<OutgoingCallerIdResource> page = PageForRequest(client, request);
            
            return new ResourceSet<OutgoingCallerIdResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<OutgoingCallerIdResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of OutgoingCallerIdResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<OutgoingCallerIdResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            Page<OutgoingCallerIdResource> result = new Page<OutgoingCallerIdResource>();
            result.deserialize("outgoing_caller_ids", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (phoneNumber != null) {
                request.AddQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}