using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class PhoneNumberCreator : Creator<PhoneNumberResource> {
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
         * @return Created PhoneNumberResource
         */
        public override async Task<PhoneNumberResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers"
            );
            
            addPostParams(request);
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("PhoneNumberResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return PhoneNumberResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumberSid != null) {
                request.AddPostParam("PhoneNumberSid", phoneNumberSid);
            }
        }
    }
}