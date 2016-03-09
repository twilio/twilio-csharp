using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.ShortCode;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Sms {

    public class ShortCodeReader : Reader<ShortCode> {
        private string accountSid;
        private string friendlyName;
        private string shortCode;
    
        /**
         * Construct a new ShortCodeReader
         * 
         * @param accountSid The account_sid
         */
        public ShortCodeReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show the ShortCode resources with friendly names that exactly match this
         * name
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public ShortCodeReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Only show the ShortCode resources that match this pattern. You can specify
         * partial numbers and use '*' as a wildcard for any digit
         * 
         * @param shortCode Filter by ShortCode
         * @return this
         */
        public ShortCodeReader byShortCode(string shortCode) {
            this.shortCode = shortCode;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return ShortCode ResourceSet
         */
        [Override]
        public ResourceSet<ShortCode> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/ShortCodes.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<ShortCode> page = pageForRequest(client, request);
            
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
        public Page<ShortCode> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ShortCode Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ShortCode> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ShortCode read failed: Unable to connect to server");
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
            
            Page<ShortCode> result = new Page<>();
            result.deserialize("short_codes", response.getContent(), ShortCode.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            if (shortCode != null) {
                request.addQueryParam("ShortCode", shortCode);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}