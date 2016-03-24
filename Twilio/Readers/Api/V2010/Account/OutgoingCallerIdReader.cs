using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class OutgoingCallerIdReader : Reader<OutgoingCallerIdResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string friendlyName;
    
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
        public OutgoingCallerIdReader byPhoneNumber(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Only show the caller id resource that exactly matches this name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public OutgoingCallerIdReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return OutgoingCallerIdResource ResourceSet
         */
        public override ResourceSet<OutgoingCallerIdResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/OutgoingCallerIds.json"
            );
            
            addQueryParams(request);
            
            Page<OutgoingCallerIdResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<OutgoingCallerIdResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of OutgoingCallerIdResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<OutgoingCallerIdResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OutgoingCallerIdResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            Page<OutgoingCallerIdResource> result = new Page<>();
            result.deserialize("outgoing_caller_ids", response.GetContent(), OutgoingCallerIdResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (phoneNumber != null) {
                request.addQueryParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}