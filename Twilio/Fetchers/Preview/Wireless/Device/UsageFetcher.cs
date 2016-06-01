using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Preview.Wireless.Device;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Fetchers.Preview.Wireless.Device {

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
        public override async Task<UsageResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.deviceSid + "/Usage"
            );
            
            
                AddQueryParams(request);
            
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("UsageResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
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
            
            return UsageResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched UsageResource
         */
        public override UsageResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.PREVIEW,
                "/wireless/Devices/" + this.deviceSid + "/Usage"
            );
            
            
                AddQueryParams(request);
            
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UsageResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
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
            
            return UsageResource.FromJson(response.GetContent());
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