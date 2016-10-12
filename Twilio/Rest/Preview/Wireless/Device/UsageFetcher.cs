using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Preview.Wireless.Device {

    public class UsageFetcher : Fetcher<UsageResource> {
        private string deviceSid;
        private string end;
        private string start;
    
        /**
         * Construct a new UsageFetcher
         * 
         * @param deviceSid The device_sid
         */
        public UsageFetcher(string deviceSid) {
            this.deviceSid = deviceSid;
        }
    
        /**
         * The end
         * 
         * @param end The end
         * @return this
         */
        public UsageFetcher setEnd(string end) {
            this.end = end;
            return this;
        }
    
        /**
         * The start
         * 
         * @param start The start
         * @return this
         */
        public UsageFetcher setStart(string start) {
            this.start = start;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched UsageResource
         */
        public override async Task<UsageResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.deviceSid + "/Usage"
            );
            
                AddQueryParams(request);
            
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("UsageResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return UsageResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched UsageResource
         */
        public override UsageResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.deviceSid + "/Usage"
            );
            
                AddQueryParams(request);
            
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("UsageResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return UsageResource.FromJson(response.Content);
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (end != null) {
                request.AddQueryParam("End", end);
            }
            
            if (start != null) {
                request.AddQueryParam("Start", start);
            }
        }
    }
}