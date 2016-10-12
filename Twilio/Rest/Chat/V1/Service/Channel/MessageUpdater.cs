using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Chat.V1.Service.Channel {

    public class MessageUpdater : Updater<MessageResource> {
        private string serviceSid;
        private string channelSid;
        private string sid;
        private string body;
        private Object attributes;
    
        /**
         * Construct a new MessageUpdater
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         * @param body The body
         */
        public MessageUpdater(string serviceSid, string channelSid, string sid, string body) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.sid = sid;
            this.body = body;
        }
    
        /**
         * The attributes
         * 
         * @param attributes The attributes
         * @return this
         */
        public MessageUpdater setAttributes(Object attributes) {
            this.attributes = attributes;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated MessageResource
         */
        public override async Task<MessageResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource update failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated MessageResource
         */
        public override MessageResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource update failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to update record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (body != null) {
                request.AddPostParam("Body", body);
            }
            
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes.ToString());
            }
        }
    }
}