using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;

#if NET40
using System.Threading.Tasks;
#endif

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created UserResource
         */
        public override async Task<UserResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created UserResource
         */
        public override UserResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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