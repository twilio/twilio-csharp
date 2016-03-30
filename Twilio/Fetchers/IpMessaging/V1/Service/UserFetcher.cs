using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;

namespace Twilio.Fetchers.IpMessaging.V1.Service {

    public class UserFetcher : Fetcher<UserResource> {
        private string serviceSid;
        private string sid;
    
        /**
         * Construct a new UserFetcher
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public UserFetcher(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched UserResource
         */
        public override async Task<UserResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users/" + this.sid + ""
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource fetch failed: Unable to connect to server");
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
            
            return UserResource.FromJson(response.GetContent());
        }
    }
}