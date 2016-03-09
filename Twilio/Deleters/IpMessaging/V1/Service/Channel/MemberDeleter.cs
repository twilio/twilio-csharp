using Twilio.Clients;
using Twilio.Deleters.Deleter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.channel.Member;

namespace Twilio.Deleters.IpMessaging.V1.Service.Channel {

    public class MemberDeleter : Deleter<Member> {
        private string serviceSid;
        private string channelSid;
        private string sid;
    
        /**
         * Construct a new MemberDeleter
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         */
        public MemberDeleter(string serviceSid, string channelSid, string sid) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        [Override]
        public void execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.DELETE,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Member delete failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}