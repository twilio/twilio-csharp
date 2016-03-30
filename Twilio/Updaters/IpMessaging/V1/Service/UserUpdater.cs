using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;
using Twilio.Updaters;

namespace Twilio.Updaters.IpMessaging.V1.Service {

    public class UserUpdater : Updater<UserResource> {
        private string serviceSid;
        private string sid;
        private string roleSid;
    
        /**
         * Construct a new UserUpdater
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @param roleSid The role_sid
         */
        public UserUpdater(string serviceSid, string sid, string roleSid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
            this.roleSid = roleSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated UserResource
         */
        public override async Task<UserResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource update failed: Unable to connect to server");
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (roleSid != null) {
                request.AddPostParam("RoleSid", roleSid);
            }
        }
    }
}