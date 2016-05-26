using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Trunking.V1.Trunk;

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return IpAccessControlListResource ResourceSet
         */
        public override Task<ResourceSet<IpAccessControlListResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            AddQueryParams(request);
            
            Page<IpAccessControlListResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<IpAccessControlListResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return IpAccessControlListResource ResourceSet
         */
        public override ResourceSet<IpAccessControlListResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/IpAccessControlLists"
            );
            
            AddQueryParams(request);
            
            Page<IpAccessControlListResource> page = PageForRequest(client, request);
            
            return new ResourceSet<IpAccessControlListResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<IpAccessControlListResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of IpAccessControlListResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<IpAccessControlListResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IpAccessControlListResource read failed: Unable to connect to server");
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
            
            Page<IpAccessControlListResource> result = new Page<IpAccessControlListResource>();
            result.deserialize("ip_access_control_lists", response.GetContent());
            
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