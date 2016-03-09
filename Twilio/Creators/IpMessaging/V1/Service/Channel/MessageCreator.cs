using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.channel.Message;

namespace Twilio.Creators.IpMessaging.V1.Service.Channel {

    public class MessageCreator : Creator<Message> {
        private string serviceSid;
        private string channelSid;
        private string body;
        private string from;
    
        /**
         * Construct a new MessageCreator
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param body The body
         */
        public MessageCreator(string serviceSid, string channelSid, string body) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.body = body;
        }
    
        /**
         * The from
         * 
         * @param from The from
         * @return this
         */
        public MessageCreator setFrom(string from) {
            this.from = from;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Message
         */
        [Override]
        public Message execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Message creation failed: Unable to connect to server");
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
            
            return Message.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (body != null) {
                request.addPostParam("Body", body);
            }
            
            if (from != null) {
                request.addPostParam("From", from);
            }
        }
    }
}