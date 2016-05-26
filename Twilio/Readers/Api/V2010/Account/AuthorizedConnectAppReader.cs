using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class AuthorizedConnectAppReader : Reader<AuthorizedConnectAppResource> {
        private string accountSid;
    
        /**
         * Construct a new AuthorizedConnectAppReader
         * 
         * @param accountSid The account_sid
         */
        public AuthorizedConnectAppReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return AuthorizedConnectAppResource ResourceSet
         */
        public override Task<ResourceSet<AuthorizedConnectAppResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AuthorizedConnectApps.json"
            );
            
            AddQueryParams(request);
            
            Page<AuthorizedConnectAppResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<AuthorizedConnectAppResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return AuthorizedConnectAppResource ResourceSet
         */
        public override ResourceSet<AuthorizedConnectAppResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AuthorizedConnectApps.json"
            );
            
            AddQueryParams(request);
            
            Page<AuthorizedConnectAppResource> page = PageForRequest(client, request);
            
            return new ResourceSet<AuthorizedConnectAppResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<AuthorizedConnectAppResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of AuthorizedConnectAppResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<AuthorizedConnectAppResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AuthorizedConnectAppResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            Page<AuthorizedConnectAppResource> result = new Page<AuthorizedConnectAppResource>();
            result.deserialize("authorized_connect_apps", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}