using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.service.channel.Member;

namespace Twilio.Fetchers.IpMessaging.V1.Service.Channel {

    public class MemberFetcher : Fetcher<Member> {
        private string serviceSid;
        private string channelSid;
        private string sid;
    
        /**
         * Construct a new MemberFetcher
         * 
         * @param serviceSid The service_sid
         * @param channelSid The channel_sid
         * @param sid The sid
         */
        public MemberFetcher(string serviceSid, string channelSid, string sid) {
            this.serviceSid = serviceSid;
            this.channelSid = channelSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched Member
         */
        [Override]
        public Member execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Member fetch failed: Unable to connect to server");
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
            
            return Member.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}