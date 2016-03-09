using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.Role;

namespace Twilio.Creators.IpMessaging.V1.Service {

    public class RoleCreator : Creator<Role> {
        private string serviceSid;
        private string friendlyName;
        private Role.RoleType type;
        private List<string> permission;
    
        /**
         * Construct a new RoleCreator
         * 
         * @param serviceSid The service_sid
         * @param friendlyName The friendly_name
         * @param type The type
         * @param permission The permission
         */
        public RoleCreator(string serviceSid, string friendlyName, Role.RoleType type, List<string> permission) {
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.permission = permission;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Role
         */
        [Override]
        public Role execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Roles",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Role creation failed: Unable to connect to server");
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
            
            if (type != null) {
                request.addPostParam("Type", type.ToString());
            }
            
            if (permission != null) {
                request.addPostParam("Permission", permission.ToString());
            }
        }
    }
}