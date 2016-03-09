using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.Channel;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.IpMessaging.V1.Service {

    public class ChannelUpdater : Updater<Channel> {
        private string serviceSid;
        private string sid;
        private string friendlyName;
        private string uniqueName;
        private Object attributes;
        private Channel.ChannelType type;
    
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
        public ChannelUpdater setType(Channel.ChannelType type) {
            this.type = type;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Channel
         */
        [Override]
        public Channel execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Channel update failed: Unable to connect to server");
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
            
            return Channel.fromJson(response.getStream(), client.getObjectMapper());
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