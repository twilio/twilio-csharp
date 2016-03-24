using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Trunking.V1.Trunk;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Trunking.V1.Trunk {

    public class PhoneNumberReader : Reader<PhoneNumberResource> {
        private string trunkSid;
    
        /**
         * Construct a new PhoneNumberReader
         * 
         * @param trunkSid The trunk_sid
         */
        public PhoneNumberReader(string trunkSid) {
            this.trunkSid = trunkSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return PhoneNumberResource ResourceSet
         */
        public override ResourceSet<PhoneNumberResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers"
            );
            
            addQueryParams(request);
            
            Page<PhoneNumberResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<PhoneNumberResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of PhoneNumberResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<PhoneNumberResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource read failed: Unable to connect to server");
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
            
            Page<PhoneNumberResource> result = new Page<>();
            result.deserialize("phone_numbers", response.GetContent(), PhoneNumberResource.class, client.getObjectMapper());
            
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