using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sip.credential_list.Credential;

namespace Twilio.Creators.Api.V2010.Account.Sip.Credentiallist {

    public class CredentialCreator : Creator<Credential> {
        private String accountSid;
        private String credentialListSid;
        private String username;
        private String password;
    
        /**
         * Construct a new CredentialCreator
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         */
        public CredentialCreator(String accountSid, String credentialListSid, String username, String password) {
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.password = password;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created Credential
         */
        [Override]
        public Credential execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Credential creation failed: Unable to connect to server");
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
            
            return Credential.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (username != null) {
                request.addPostParam("Username", username);
            }
            
            if (password != null) {
                request.addPostParam("Password", password);
            }
        }
    }
}