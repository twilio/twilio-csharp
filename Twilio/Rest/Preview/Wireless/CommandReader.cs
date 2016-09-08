using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Wireless {

    public class CommandReader : Reader<CommandResource> {
        private string device;
        private string status;
        private string direction;
    
        /**
         * The device
         * 
         * @param device The device
         * @return this
         */
        public CommandReader ByDevice(string device) {
            this.device = device;
            return this;
        }
    
        /**
         * The status
         * 
         * @param status The status
         * @return this
         */
        public CommandReader ByStatus(string status) {
            this.status = status;
            return this;
        }
    
        /**
         * The direction
         * 
         * @param direction The direction
         * @return this
         */
        public CommandReader ByDirection(string direction) {
            this.direction = direction;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CommandResource ResourceSet
         */
        public override Task<ResourceSet<CommandResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            AddQueryParams(request);
            
            Page<CommandResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<CommandResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return CommandResource ResourceSet
         */
        public override ResourceSet<CommandResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Commands"
            );
            
            AddQueryParams(request);
            
            Page<CommandResource> page = PageForRequest(client, request);
            
            return new ResourceSet<CommandResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<CommandResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of CommandResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<CommandResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CommandResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            Page<CommandResource> result = new Page<CommandResource>();
            result.deserialize("commands", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (device != null) {
                request.AddQueryParam("Device", device);
            }
            
            if (status != null) {
                request.AddQueryParam("Status", status);
            }
            
            if (direction != null) {
                request.AddQueryParam("Direction", direction);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}