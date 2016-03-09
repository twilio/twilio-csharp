using Twilio.Clients;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.trunk.CredentialList;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class CredentialListCreator : Creator<CredentialList> {
        private string trunkSid;
        private string credentialListSid;
    
        /**
         * Construct a new CredentialListCreator
         * 
         * @param trunkSid The trunk_sid
         * @param credentialListSid The credential_list_sid
         */
        public CredentialListCreator(string trunkSid, string credentialListSid) {
            this.trunkSid = trunkSid;
            this.credentialListSid = credentialListSid;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created CredentialList
         */
        [Override]
        public CredentialList execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/CredentialLists",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialList creation failed: Unable to connect to server");
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
            
            return CredentialList.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (credentialListSid != null) {
                request.addPostParam("CredentialListSid", credentialListSid);
            }
        }
    }
}