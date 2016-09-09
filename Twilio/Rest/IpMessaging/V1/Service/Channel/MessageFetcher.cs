using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service.Channel {

    public class MessageFetcher : Fetcher<MessageResource> {
        private string serviceSid;
        private string channelSid;
        private string sid;
    
        /**
         * Construct a new MessageFetcher
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         */
        public MessageFetcher(string serviceSid, string channelSid, string sid) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.sid = sid;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MessageResource
         */
        public override async Task<MessageResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("MessageResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to fetch record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return MessageResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MessageResource
         */
        public override MessageResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages/" + this.sid + ""
            );
            
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MessageResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to fetch record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return MessageResource.FromJson(response.GetContent());
        }
    }
}