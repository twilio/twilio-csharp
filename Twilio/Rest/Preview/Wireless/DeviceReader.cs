using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Wireless {

    public class DeviceReader : Reader<DeviceResource> {
        private string status;
        private string simIdentifier;
        private string ratePlan;
    
        /**
         * The status
         * 
         * @param status The status
         * @return this
         */
        public DeviceReader ByStatus(string status) {
            this.status = status;
            return this;
        }
    
        /**
         * The sim_identifier
         * 
         * @param simIdentifier The sim_identifier
         * @return this
         */
        public DeviceReader BySimIdentifier(string simIdentifier) {
            this.simIdentifier = simIdentifier;
            return this;
        }
    
        /**
         * The rate_plan
         * 
         * @param ratePlan The rate_plan
         * @return this
         */
        public DeviceReader ByRatePlan(string ratePlan) {
            this.ratePlan = ratePlan;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return DeviceResource ResourceSet
         */
        public override Task<ResourceSet<DeviceResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<DeviceResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return DeviceResource ResourceSet
         */
        public override ResourceSet<DeviceResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<DeviceResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<DeviceResource> NextPage(Page<DeviceResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.PREVIEW
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of DeviceResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<DeviceResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource read failed: Unable to connect to server");
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
            
            return Page<DeviceResource>.FromJson("devices", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (status != null) {
                request.AddQueryParam("Status", status);
            }
            
            if (simIdentifier != null) {
                request.AddQueryParam("SimIdentifier", simIdentifier);
            }
            
            if (ratePlan != null) {
                request.AddQueryParam("RatePlan", ratePlan);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}