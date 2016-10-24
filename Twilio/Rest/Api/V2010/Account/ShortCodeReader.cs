using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ShortCodeReader : Reader<ShortCodeResource> {
        public string accountSid { get; }
        public string friendlyName { get; set; }
        public string shortCode { get; set; }
    
        /// <summary>
        /// Construct a new ShortCodeReader.
        /// </summary>
        public ShortCodeReader() {
        }
    
        /// <summary>
        /// Construct a new ShortCodeReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        public ShortCodeReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /// <summary>
        /// Only show the ShortCode resources with friendly names that exactly match this name
        /// </summary>
        ///
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <returns> this </returns> 
        public ShortCodeReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// Only show the ShortCode resources that match this pattern. You can specify partial numbers and use '*' as a wildcard
        /// for any digit
        /// </summary>
        ///
        /// <param name="shortCode"> Filter by ShortCode </param>
        /// <returns> this </returns> 
        public ShortCodeReader ByShortCode(string shortCode) {
            this.shortCode = shortCode;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ShortCodeResource ResourceSet </returns> 
        public override Task<ResourceSet<ShortCodeResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SMS/ShortCodes.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ShortCodeResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ShortCodeResource ResourceSet </returns> 
        public override ResourceSet<ShortCodeResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SMS/ShortCodes.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ShortCodeResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ShortCodeResource> NextPage(Page<ShortCodeResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of ShortCodeResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
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
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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