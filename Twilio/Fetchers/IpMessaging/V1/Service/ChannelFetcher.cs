using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.Channel;

namespace Twilio.Fetchers.IpMessaging.V1.Service {

    public class ChannelFetcher : Fetcher<Channel> {
        private string serviceSid;
        private string sid;
    
        /**
         * Construct a new ChannelFetcher
         * 
         * @param serviceSid The service_sid
         * @param sid The sid
         */
        public ChannelFetcher(string serviceSid, string sid) {
            this.serviceSid = serviceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched Channel
         */
        [Override]
        public Channel execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Channel fetch failed: Unable to connect to server");
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
    }
}