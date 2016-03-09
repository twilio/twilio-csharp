using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010 {

    public class AccountReader : Reader<Account> {
        private string friendlyName;
        private Account.Status status;
    
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
        public AccountReader byStatus(Account.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Account ResourceSet
         */
        [Override]
        public ResourceSet<Account> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Account> page = pageForRequest(client, request);
            
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
        public Page<Account> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Account Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Account> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Account read failed: Unable to connect to server");
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
            
            Page<Account> result = new Page<>();
            result.deserialize("accounts", response.getContent(), Account.class, client.getObjectMapper());
            
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
            
            if (status != null) {
                request.addQueryParam("Status", status.ToString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}