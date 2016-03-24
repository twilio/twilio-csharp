using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Trunking.V1.Trunk;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Trunking.V1.Trunk {

    public class IpAccessControlListReader : Reader<IpAccessControlListResource> {
        private string trunkSid;
    
        /**
         * Construct a new IpAccessControlListReader
         * 
         * @param trunkSid The trunk_sid
         */
        public IpAccessControlListReader(string trunkSid) {
            this.trunkSid = trunkSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return IpAccessControlListResource ResourceSet
         */
        public override ResourceSet<IpAccessControlListResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            addQueryParams(request);
            
            Page<IpAccessControlListResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<IpAccessControlListResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of IpAccessControlListResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<IpAccessControlListResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource read failed: Unable to connect to server");
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
            
            Page<IpAccessControlListResource> result = new Page<>();
            result.deserialize("ip_access_control_lists", response.GetContent(), IpAccessControlListResource.class, client.getObjectMapper());
            
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