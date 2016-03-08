using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.OriginationUrl;

namespace Twilio.Fetchers.Trunking.V1.Trunk {

    public class OriginationUrlFetcher : Fetcher<OriginationUrl> {
        private String trunkSid;
        private String sid;
    
        /**
         * Construct a new OriginationUrlFetcher
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public OriginationUrlFetcher(String trunkSid, String sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched OriginationUrl
         */
        [Override]
        public OriginationUrl execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/OriginationUrls/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("OriginationUrl fetch failed: Unable to connect to server");
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
            
            return OriginationUrl.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}