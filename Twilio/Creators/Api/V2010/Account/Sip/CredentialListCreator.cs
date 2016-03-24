using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip;

namespace Twilio.Creators.Api.V2010.Account.Sip {

    public class CredentialListCreator : Creator<CredentialListResource> {
        private string accountSid;
        private string friendlyName;
    
        /**
         * Construct a new CredentialListCreator
         * 
         * @param accountSid The account_sid
         * @param friendlyName The friendly_name
         */
        public CredentialListCreator(string accountSid, string friendlyName) {
            this.accountSid = accountSid;
            this.friendlyName = friendlyName;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created CredentialListResource
         */
        public override CredentialListResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists.json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialListResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return CredentialListResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
        }
    }
}