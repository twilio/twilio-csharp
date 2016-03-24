using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Trunking.V1;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Trunking.V1 {

    public class TrunkReader : Reader<TrunkResource> {
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return TrunkResource ResourceSet
         */
        public override ResourceSet<TrunkResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks"
            );
            
            addQueryParams(request);
            
            Page<TrunkResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TrunkResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of TrunkResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TrunkResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TrunkResource read failed: Unable to connect to server");
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
            
            Page<TrunkResource> result = new Page<>();
            result.deserialize("trunks", response.GetContent(), TrunkResource.class, client.getObjectMapper());
            
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