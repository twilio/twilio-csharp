using System;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;

namespace Twilio.Creators.IpMessaging.V1.Service {

    public class ChannelCreator : Creator<ChannelResource> {
        private string serviceSid;
        private string friendlyName;
        private string uniqueName;
        private Object attributes;
        private ChannelResource.ChannelType type;
    
        /**
         * Construct a new ChannelCreator
         * 
         * @param serviceSid The service_sid
         * @param friendlyName The friendly_name
         * @param uniqueName The unique_name
         */
        public ChannelCreator(string serviceSid, string friendlyName, string uniqueName) {
            this.serviceSid = serviceSid;
            this.friendlyName = friendlyName;
            this.uniqueName = uniqueName;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public ChannelCreator setAttributes(Object attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public ChannelCreator setType(ChannelResource.ChannelType type) {
            this.type = type;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created ChannelResource
         */
        public ChannelResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ChannelResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return ChannelResource.fromJson(response.GetContent());
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
            
            if (uniqueName != null) {
                request.addPostParam("UniqueName", uniqueName);
            }
            
            if (attributes != null) {
                request.addPostParam("Attributes", attributes.ToString());
            }
            
            if (type != null) {
                request.addPostParam("Type", type.ToString());
            }
        }
    }
}