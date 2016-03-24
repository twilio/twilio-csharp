using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account.Sip.Domain;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

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
        public override ResourceSet<CredentialListMappingResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/Domains/" + this.domainSid + "/CredentialListMappings.json"
            );
            
            addQueryParams(request);
            
            Page<CredentialListMappingResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<CredentialListMappingResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of CredentialListMappingResource Resources for a given
         * request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<CredentialListMappingResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListMappingResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            Page<CredentialListMappingResource> result = new Page<>();
            result.deserialize("credential_list_mappings", response.GetContent(), CredentialListMappingResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}