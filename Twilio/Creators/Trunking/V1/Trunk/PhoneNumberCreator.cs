using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.PhoneNumber;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class PhoneNumberCreator : Creator<PhoneNumber> {
        private string trunkSid;
        private string phoneNumberSid;
    
        /**
         * Construct a new PhoneNumberCreator
         * 
         * @param trunkSid The trunk_sid
         * @param phoneNumberSid The phone_number_sid
         */
        public PhoneNumberCreator(string trunkSid, string phoneNumberSid) {
            this.trunkSid = trunkSid;
            this.phoneNumberSid = phoneNumberSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created PhoneNumber
         */
        [Override]
        public PhoneNumber execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumber creation failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumberSid != null) {
                request.addPostParam("PhoneNumberSid", phoneNumberSid);
            }
        }
    }
}