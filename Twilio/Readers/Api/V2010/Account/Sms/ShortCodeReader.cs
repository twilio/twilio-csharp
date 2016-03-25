using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Sms;

namespace Twilio.Readers.Api.V2010.Account.Sms {

    public class ShortCodeReader : Reader<ShortCodeResource> {
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
         * @return ShortCodeResource ResourceSet
         */
        public ResourceSet<ShortCodeResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/ShortCodes.json"
            );
            
            AddQueryParams(request);
            
            Page<ShortCodeResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public Page<ShortCodeResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ShortCodeResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ShortCodeResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ShortCodeResource read failed: Unable to connect to server");
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
            
            Page<ShortCodeResource> result = new Page<>();
            result.deserialize("short_codes", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (shortCode != null) {
                request.AddQueryParam("ShortCode", shortCode);
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}