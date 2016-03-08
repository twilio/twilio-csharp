using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.IncomingPhoneNumber;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class IncomingPhoneNumberReader : Reader<IncomingPhoneNumber> {
        private String ownerAccountSid;
        private Boolean beta;
        private String friendlyName;
        private com.twilio.types.PhoneNumber phoneNumber;
    
        /**
         * Construct a new IncomingPhoneNumberReader
         * 
         * @param ownerAccountSid The owner_account_sid
         */
        public IncomingPhoneNumberReader(String ownerAccountSid) {
            this.ownerAccountSid = ownerAccountSid;
        }
    
        /**
         * Include phone numbers new to the Twilio platform
         * 
         * @param beta Include new phone numbers
         * @return this
         */
        public IncomingPhoneNumberReader byBeta(Boolean beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * Only show the incoming phone number resources with friendly names that
         * exactly match this name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public IncomingPhoneNumberReader byFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Only show the incoming phone number resources that match this pattern
         * 
         * @param phoneNumber Filter by incoming phone number
         * @return this
         */
        public IncomingPhoneNumberReader byPhoneNumber(com.twilio.types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return IncomingPhoneNumber ResourceSet
         */
        [Override]
        public ResourceSet<IncomingPhoneNumber> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<IncomingPhoneNumber> page = pageForRequest(client, request);
            
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
        public Page<IncomingPhoneNumber> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of IncomingPhoneNumber Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<IncomingPhoneNumber> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumber read failed: Unable to connect to server");
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
            
            Page<IncomingPhoneNumber> result = new Page<>();
            result.deserialize("incoming_phone_numbers", response.getContent(), IncomingPhoneNumber.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (beta != null) {
                request.addQueryParam("Beta", beta.toString());
            }
            
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            if (phoneNumber != null) {
                request.addQueryParam("PhoneNumber", phoneNumber.toString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}