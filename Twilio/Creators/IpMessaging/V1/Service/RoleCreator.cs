using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;

namespace Twilio.Creators.IpMessaging.V1.Service {

    public class RoleCreator : Creator<RoleResource> {
        private string serviceSid;
        private string friendlyName;
        private RoleResource.RoleType type;
        private List<string> permission;
    
        /**
         * Construct a new RoleCreator
         * 
         * @param serviceSid The service_sid
         * @param friendlyName The friendly_name
         * @param type The type
         * @param permission The permission
         */
        public RoleCreator(string serviceSid, string friendlyName, RoleResource.RoleType type, List<string> permission) {
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.type = type;
            this.permission = permission;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created RoleResource
         */
        public override async Task<RoleResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Roles"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("RoleResource creation failed: Unable to connect to server");
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
            
            return RoleResource.FromJson(response.GetContent());
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created RoleResource
         */
        public override RoleResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Roles"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RoleResource creation failed: Unable to connect to server");
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
            
            return RoleResource.FromJson(response.GetContent());
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
            
            if (type != null) {
                request.AddPostParam("Type", type.ToString());
            }
            
            if (permission != null) {
                request.AddPostParam("Permission", permission.ToString());
            }
        }
    }
}