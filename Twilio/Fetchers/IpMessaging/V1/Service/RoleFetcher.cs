using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.Service;

namespace Twilio.Fetchers.IpMessaging.V1.Service {

    public class RoleFetcher : Fetcher<RoleResource> {
        private string serviceSid;
        private string sid;
    
        /**
         * Construct a new RoleFetcher
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public RoleFetcher(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched RoleResource
         */
        public override RoleResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Roles/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RoleResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return RoleResource.fromJson(response.GetContent());
        }
    }
}