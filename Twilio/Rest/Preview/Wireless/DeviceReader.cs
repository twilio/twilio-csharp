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
    
        /// <summary>
        /// The status
        /// </summary>
        ///
        /// <param name="status"> The status </param>
        /// <returns> this </returns> 
        public DeviceReader ByStatus(string status) {
            this.status = status;
            return this;
        }
    
        /// <summary>
        /// The sim_identifier
        /// </summary>
        ///
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <returns> this </returns> 
        public DeviceReader BySimIdentifier(string simIdentifier) {
            this.simIdentifier = simIdentifier;
            return this;
        }
    
        /// <summary>
        /// The rate_plan
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <returns> this </returns> 
        public DeviceReader ByRatePlan(string ratePlan) {
            this.ratePlan = ratePlan;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> DeviceResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> DeviceResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<DeviceResource> NextPage(Page<DeviceResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.PREVIEW
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of DeviceResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<DeviceResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("DeviceResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<DeviceResource>.FromJson("devices", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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