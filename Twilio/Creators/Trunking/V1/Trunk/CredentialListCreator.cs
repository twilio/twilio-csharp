using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Trunking.V1.Trunk;

namespace Twilio.Creators.Trunking.V1.Trunk {

    public class CredentialListCreator : Creator<CredentialListResource> {
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
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialListResource
         */
        public override async Task<CredentialListResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/CredentialLists"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return CredentialListResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (credentialListSid != null) {
                request.AddPostParam("CredentialListSid", credentialListSid);
            }
        }
    }
}