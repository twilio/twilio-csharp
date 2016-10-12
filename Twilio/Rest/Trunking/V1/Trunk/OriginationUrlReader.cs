using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1.Trunk {

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return OriginationUrlResource ResourceSet
         */
        public override Task<ResourceSet<OriginationUrlResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<OriginationUrlResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return OriginationUrlResource ResourceSet
         */
        public override ResourceSet<OriginationUrlResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<OriginationUrlResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<OriginationUrlResource> NextPage(Page<OriginationUrlResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TRUNKING
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of OriginationUrlResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<OriginationUrlResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("OriginationUrlResource read failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to read records, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return Page<OriginationUrlResource>.FromJson("origination_urls", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}