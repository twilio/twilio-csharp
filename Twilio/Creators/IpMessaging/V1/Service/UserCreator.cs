using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.User;

namespace Twilio.Creators.IpMessaging.V1.Service {

    public class UserCreator : Creator<User> {
        private String serviceSid;
        private String identity;
        private String roleSid;
    
        /**
         * Construct a new UserCreator
         * 
         * @param serviceSid The service_sid
         * @param identity The identity
         * @param roleSid The role_sid
         */
        public UserCreator(String serviceSid, String identity, String roleSid) {
            this.serviceSid = serviceSid;
            this.identity = identity;
            this.roleSid = roleSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created User
         */
        [Override]
        public User execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Users",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("User creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            if (identity != null) {
                request.addPostParam("Identity", identity);
            }
            
            if (roleSid != null) {
                request.addPostParam("RoleSid", roleSid);
            }
        }
    }
}