using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;

namespace Twilio.Readers.Api.V2010.Account.Sip.Domain {

    public class CredentialListMappingReader : Reader<CredentialListMappingResource> {
        private string accountSid;
        private string domainSid;
    
        /**
         * Construct a new CredentialListMappingReader
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         */
        public CredentialListMappingReader(string accountSid, string domainSid) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return CredentialListMappingResource ResourceSet
         */
        public override async Task<ResourceSet<CredentialListMappingResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            AddQueryParams(request);
            
            Page<CredentialListMappingResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<CredentialListMappingResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<CredentialListMappingResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of CredentialListMappingResource Resources for a given
         * request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<CredentialListMappingResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource read failed: Unable to connect to server");
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
            
            Page<CredentialListMappingResource> result = new Page<CredentialListMappingResource>();
            result.deserialize("credential_list_mappings", response.GetContent());
            
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