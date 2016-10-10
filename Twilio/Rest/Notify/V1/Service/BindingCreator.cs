using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Notify.V1.Service {

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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created BindingResource
         */
        public override async Task<BindingResource> CreateAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("BindingResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return BindingResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created BindingResource
         */
        public override BindingResource Create(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.NOTIFY,
                "/v1/Services/" + this.serviceSid + "/Bindings"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("BindingResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to create record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
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
            if (endpoint != null) {
                request.AddPostParam("Endpoint", endpoint);
            }
            
            if (identity != null) {
                request.AddPostParam("Identity", identity);
            }
            
            if (bindingType != null) {
                request.AddPostParam("BindingType", bindingType.ToString());
            }
            
            if (address != null) {
                request.AddPostParam("Address", address);
            }
            
            if (tag != null) {
                request.AddPostParam("Tag", tag.ToString());
            }
            
            if (notificationProtocolVersion != null) {
                request.AddPostParam("NotificationProtocolVersion", notificationProtocolVersion);
            }
        }
    }
}