using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Readers.Trunking.V1.Trunk {

    public class OriginationUrlReader : Reader<OriginationUrlResource> {
        private string trunkSid;
    
        /**
         * Construct a new OriginationUrlReader
         * 
         * @param trunkSid The trunk_sid
         */
        public OriginationUrlReader(string trunkSid) {
            this.trunkSid = trunkSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return OriginationUrlResource ResourceSet
         */
        public override async Task<ResourceSet<OriginationUrlResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls"
            );
            
            AddQueryParams(request);
            
            Page<OriginationUrlResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<OriginationUrlResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<OriginationUrlResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of OriginationUrlResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<OriginationUrlResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrlResource read failed: Unable to connect to server");
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
            
            Page<OriginationUrlResource> result = new Page<OriginationUrlResource>();
            result.deserialize("origination_urls", response.GetContent());
            
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