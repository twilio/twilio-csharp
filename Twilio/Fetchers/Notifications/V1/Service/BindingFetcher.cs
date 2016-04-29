using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Notifications.V1.Service;

namespace Twilio.Fetchers.Notifications.V1.Service {

    public class BindingFetcher : Fetcher<BindingResource> {
        private string serviceSid;
        private string sid;
    
        /**
         * Construct a new BindingFetcher
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public BindingFetcher(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched BindingResource
         */
        public override async Task<BindingResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.serviceSid + "/Bindings/" + this.sid + ""
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("BindingResource fetch failed: Unable to connect to server");
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
            
            return BindingResource.FromJson(response.GetContent());
        }
    }
}