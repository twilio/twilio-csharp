using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Notifications.V1.Service;

namespace Twilio.Creators.Notifications.V1.Service {

    public class BindingCreator : Creator<BindingResource> {
        private string serviceSid;
        private string endpoint;
        private string identity;
        private BindingResource.BindingType bindingType;
        private string address;
        private List<string> tag;
        private string notificationProtocolVersion;
    
        /**
         * Construct a new BindingCreator
         * 
         * @param serviceSid The service_sid
         * @param endpoint The endpoint
         * @param identity The identity
         * @param bindingType The binding_type
         * @param address The address
         */
        public BindingCreator(string serviceSid, string endpoint, string identity, BindingResource.BindingType bindingType, string address) {
            this.serviceSid = serviceSid;
            this.endpoint = endpoint;
            this.identity = identity;
            this.bindingType = bindingType;
            this.address = address;
        }
    
        /**
         * The tag
         * 
         * @param tag The tag
         * @return this
         */
        public BindingCreator setTag(List<string> tag) {
            this.tag = tag;
            return this;
        }
    
        /**
         * The tag
         * 
         * @param tag The tag
         * @return this
         */
        public BindingCreator setTag(string tag) {
            return setTag(Promoter.ListOfOne(tag));
        }
    
        /**
         * The notification_protocol_version
         * 
         * @param notificationProtocolVersion The notification_protocol_version
         * @return this
         */
        public BindingCreator setNotificationProtocolVersion(string notificationProtocolVersion) {
            this.notificationProtocolVersion = notificationProtocolVersion;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created BindingResource
         */
        public override async Task<BindingResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.NOTIFICATIONS,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("BindingResource creation failed: Unable to connect to server");
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
            
            return BindingResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (endpoint != "") {
                request.AddPostParam("Endpoint", endpoint);
            }
            
            if (identity != "") {
                request.AddPostParam("Identity", identity);
            }
            
            if (bindingType != null) {
                request.AddPostParam("BindingType", bindingType.ToString());
            }
            
            if (address != "") {
                request.AddPostParam("Address", address);
            }
            
            if (tag != null) {
                request.AddPostParam("Tag", tag.ToString());
            }
            
            if (notificationProtocolVersion != "") {
                request.AddPostParam("NotificationProtocolVersion", notificationProtocolVersion);
            }
        }
    }
}