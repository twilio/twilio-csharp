using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.User;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.IpMessaging.V1.Service {

    public class UserUpdater : Updater<User> {
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
         * @return Updated User
         */
        [Override]
        public User execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("User update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return User.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (roleSid != null) {
                request.addPostParam("RoleSid", roleSid);
            }
        }
    }
}