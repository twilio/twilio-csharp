using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1.Service.Channel;

namespace Twilio.Deleters.IpMessaging.V1.Service.Channel {

    public class MemberDeleter : Deleter<MemberResource> {
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override async Task ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + ""
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("MemberResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_NO_CONTENT) {
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
            
            return;
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override void Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + ""
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MemberResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_NO_CONTENT) {
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
            
            return;
        }
        #endif
    }
}