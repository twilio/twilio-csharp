using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Fetcher;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.PhoneNumber;

namespace Twilio.Fetchers.Trunking.V1.Trunk {

    public class PhoneNumberFetcher : Fetcher<PhoneNumber> {
        private string trunkSid;
        private string sid;
    
        /**
         * Construct a new PhoneNumberFetcher
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public PhoneNumberFetcher(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched PhoneNumber
         */
        [Override]
        public PhoneNumber execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers/" + this.sid + "",
                client.getAccountSid()
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumber fetch failed: Unable to connect to server");
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
            
            return PhoneNumber.fromJson(response.getStream(), client.getObjectMapper());
        }
    }
}