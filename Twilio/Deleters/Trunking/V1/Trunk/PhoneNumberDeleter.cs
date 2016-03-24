using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Deleters.Trunking.V1.Trunk {

    public class PhoneNumberDeleter : Deleter<PhoneNumberResource> {
        private string trunkSid;
        private string sid;
    
        /**
         * Construct a new PhoneNumberDeleter
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         */
        public PhoneNumberDeleter(string trunkSid, string sid) {
            this.trunkSid = trunkSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        public override void execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
                RestException restException = RestException.fromJson(response.GetContent());
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
        }
    }
}