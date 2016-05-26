using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.IpMessaging.V1.Service;

namespace Twilio.Readers.IpMessaging.V1.Service {

    public class ChannelReader : Reader<ChannelResource> {
        private string serviceSid;
    
        /**
         * Construct a new ChannelReader
         * 
         * @param serviceSid The service_sid
         */
        public ChannelReader(string serviceSid) {
            this.serviceSid = serviceSid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ChannelResource ResourceSet
         */
        public override Task<ResourceSet<ChannelResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels"
            );
            
            AddQueryParams(request);
            
            Page<ChannelResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<ChannelResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ChannelResource ResourceSet
         */
        public override ResourceSet<ChannelResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels"
            );
            
            AddQueryParams(request);
            
            Page<ChannelResource> page = PageForRequest(client, request);
            
            return new ResourceSet<ChannelResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ChannelResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of ChannelResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ChannelResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ChannelResource read failed: Unable to connect to server");
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
            
            Page<ChannelResource> result = new Page<ChannelResource>();
            result.deserialize("channels", response.GetContent());
            
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