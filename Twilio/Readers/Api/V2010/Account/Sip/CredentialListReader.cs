using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Readers.Api.V2010.Account.Sip {

    public class CredentialListReader : Reader<CredentialListResource> {
        private string accountSid;
    
        /**
         * Construct a new CredentialListReader
         * 
         * @param accountSid The account_sid
         */
        public CredentialListReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CredentialListResource ResourceSet
         */
        public override Task<ResourceSet<CredentialListResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists.json"
            );
            
            AddQueryParams(request);
            
            Page<CredentialListResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<CredentialListResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CredentialListResource ResourceSet
         */
        public override ResourceSet<CredentialListResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists.json"
            );
            
            AddQueryParams(request);
            
            Page<CredentialListResource> page = PageForRequest(client, request);
            
            return new ResourceSet<CredentialListResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<CredentialListResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of CredentialListResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<CredentialListResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListResource read failed: Unable to connect to server");
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
            
            Page<CredentialListResource> result = new Page<CredentialListResource>();
            result.deserialize("credential_lists", response.GetContent());
            
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