using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010;

namespace Twilio.Readers.Api.V2010 {

    public class AccountReader : Reader<AccountResource> {
        private string friendlyName;
        private AccountResource.Status status;
    
        /**
         * Filter accounts where the friendly name exactly matches the desired
         * FriendlyName
         * 
         * @param friendlyName FriendlyName to filter on
         * @return this
         */
        public AccountReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Only show accounts with the given Status
         * 
         * @param status Status to filter on
         * @return this
         */
        public AccountReader byStatus(AccountResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return AccountResource ResourceSet
         */
        public override async Task<ResourceSet<AccountResource>> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts.json"
            );
            
            AddQueryParams(request);
            
            Page<AccountResource> page = await pageForRequest(client, request);
            
            return new ResourceSet<AccountResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<AccountResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = pageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of AccountResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<AccountResource>> pageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AccountResource read failed: Unable to connect to server");
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
            
            Page<AccountResource> result = new Page<AccountResource>();
            result.deserialize("accounts", response.GetContent());
            
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
            
            if (status != null) {
                request.AddQueryParam("Status", status.ToString());
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}