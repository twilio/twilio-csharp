using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1;

namespace Twilio.Creators.IpMessaging.V1 {

    public class ServiceCreator : Creator<ServiceResource> {
        private string friendlyName;
    
        /**
         * Construct a new ServiceCreator
         * 
         * @param friendlyName The friendly_name
         */
        public ServiceCreator(string friendlyName) {
            this.friendlyName = friendlyName;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override async Task<ServiceResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Services"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return ServiceResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created ServiceResource
         */
        public override ServiceResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Services"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ServiceResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return ServiceResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}