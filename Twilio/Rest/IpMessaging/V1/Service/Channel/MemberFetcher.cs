using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1.Service.Channel {

    public class MemberFetcher : Fetcher<MemberResource> {
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MemberResource
         */
        public override async Task<MemberResource> FetchAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Fetched MemberResource
         */
        public override MemberResource Fetch(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.IP_MESSAGING,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Members/" + this.sid + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MemberResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return MemberResource.FromJson(response.GetContent());
        }
    }
}