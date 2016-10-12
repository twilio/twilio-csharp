using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeReader : Reader<ShortCodeResource> {
        private string accountSid;
        private string friendlyName;
        private string shortCode;
    
        /**
         * Construct a new ShortCodeReader.
         */
        public ShortCodeReader() {
        }
    
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
        public ShortCodeReader ByFriendlyName(string friendlyName) {
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
        public ShortCodeReader ByShortCode(string shortCode) {
            this.shortCode = shortCode;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ShortCodeResource ResourceSet
         */
        public override Task<ResourceSet<ShortCodeResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SMS/ShortCodes.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ShortCodeResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ShortCodeResource ResourceSet
         */
        public override ResourceSet<ShortCodeResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SMS/ShortCodes.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ShortCodeResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ShortCodeResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ShortCodeResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ShortCodeResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<ShortCodeResource>.FromJson("short_codes", response.Content);
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
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}