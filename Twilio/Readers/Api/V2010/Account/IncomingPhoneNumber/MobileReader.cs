using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.incoming_phone_number.Mobile;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Incomingphonenumber {

    public class MobileReader : Reader<Mobile> {
        private String ownerAccountSid;
        private Boolean beta;
        private String friendlyName;
        private com.twilio.types.PhoneNumber phoneNumber;
    
        /**
         * Construct a new MobileReader
         * 
         * @param ownerAccountSid The owner_account_sid
         */
        public MobileReader(String ownerAccountSid) {
            this.ownerAccountSid = ownerAccountSid;
        }
    
        /**
         * The beta
         * 
         * @param beta The beta
         * @return this
         */
        public MobileReader byBeta(Boolean beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public MobileReader byFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The phone_number
         * 
         * @param phoneNumber The phone_number
         * @return this
         */
        public MobileReader byPhoneNumber(com.twilio.types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Mobile ResourceSet
         */
        [Override]
        public ResourceSet<Mobile> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers/Mobile.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Mobile> page = pageForRequest(client, request);
            
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
        public Page<Mobile> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Mobile Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Mobile> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Mobile read failed: Unable to connect to server");
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
            
            Page<Mobile> result = new Page<>();
            result.deserialize("incoming_phone_numbers", response.getContent(), Mobile.class, client.getObjectMapper());
            
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