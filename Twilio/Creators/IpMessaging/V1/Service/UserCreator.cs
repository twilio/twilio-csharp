using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;

namespace Twilio.Creators.IpMessaging.V1.Service {

    public class UserCreator : Creator<UserResource> {
        private string serviceSid;
        private string identity;
        private string roleSid;
    
        /**
         * Construct a new UserCreator
         * 
         * @param serviceSid The service_sid
         * @param identity The identity
         * @param roleSid The role_sid
         */
        public UserCreator(string serviceSid, string identity, string roleSid) {
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.roleSid = roleSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created UserResource
         */
        public override async Task<UserResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (identity != null) {
                request.AddPostParam("Identity", identity);
            }
            
            if (roleSid != null) {
                request.AddPostParam("RoleSid", roleSid);
            }
        }
    }
}