using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.IpMessaging.V1.Service.Channel;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service.Channel {

    public class MessageDeleter : Deleter<MessageResource> {
        private string serviceSid;
        private string channelSid;
        private string sid;
    
        /**
         * Construct a new MessageDeleter
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         */
        public MessageDeleter(string serviceSid, string channelSid, string sid) {
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
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client ITwilioRestClient with which to make the request
         */
        public override void Delete(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}