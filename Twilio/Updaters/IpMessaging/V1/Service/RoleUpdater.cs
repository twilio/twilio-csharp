using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.Role;
using com.twilio.sdk.updaters.Updater;
using java.util.List;

namespace Twilio.Updaters.IpMessaging.V1.Service {

    public class RoleUpdater : Updater<Role> {
        private String serviceSid;
        private String sid;
        private String friendlyName;
        private List<String> permission;
    
        /**
         * Construct a new RoleUpdater
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @param permission The permission
         */
        public RoleUpdater(String serviceSid, String sid, String friendlyName, List<String> permission) {
            this.serviceSid = serviceSid;
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.permission = permission;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Role
         */
        [Override]
        public Role execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Roles/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Role update failed: Unable to connect to server");
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
            
            return Role.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (permission != null) {
                request.addPostParam("Permission", permission.toString());
            }
        }
    }
}