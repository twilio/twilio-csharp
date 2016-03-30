using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service;
using Twilio.Updaters;

namespace Twilio.Updaters.IpMessaging.V1.Service {

    public class ChannelUpdater : Updater<ChannelResource> {
        private string serviceSid;
        private string sid;
        private string friendlyName;
        private string uniqueName;
        private Object attributes;
        private ChannelResource.ChannelType type;
    
        /**
         * Construct a new ChannelUpdater
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public ChannelUpdater(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ChannelUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The unique_name
         * 
         * @param uniqueName The unique_name
         * @return this
         */
        public ChannelUpdater setUniqueName(string uniqueName) {
            this.uniqueName = uniqueName;
            return this;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public ChannelUpdater setAttributes(Object attributes) {
            this.attributes = attributes;
            return this;
        }
    
        /**
         * The type
         * 
         * @param type The type
         * @return this
         */
        public ChannelUpdater setType(ChannelResource.ChannelType type) {
            this.type = type;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated ChannelResource
         */
        public override async Task<ChannelResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ChannelResource update failed: Unable to connect to server");
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
            
            return ChannelResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (uniqueName != null) {
                request.AddPostParam("UniqueName", uniqueName);
            }
            
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes.ToString());
            }
            
            if (type != null) {
                request.AddPostParam("Type", type.ToString());
            }
        }
    }
}