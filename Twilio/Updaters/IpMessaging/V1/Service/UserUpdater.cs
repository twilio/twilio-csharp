using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated UserResource
         */
        public override async Task<UserResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource update failed: Unable to connect to server");
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
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated UserResource
         */
        public override UserResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("UserResource update failed: Unable to connect to server");
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
            if (roleSid != "") {
                request.AddPostParam("RoleSid", roleSid);
            }
        }
    }
}