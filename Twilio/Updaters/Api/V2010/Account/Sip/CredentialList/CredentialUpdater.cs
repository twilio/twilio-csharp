using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.CredentialList;
using Twilio.Updaters;

namespace Twilio.Updaters.Api.V2010.Account.Sip.CredentialList {

    public class CredentialUpdater : Updater<CredentialResource> {
        private string accountSid;
        private string credentialListSid;
        private string sid;
        private string username;
        private string password;
    
        /**
         * Construct a new CredentialUpdater
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param sid The sid
         * @param username The username
         * @param password The password
         */
        public CredentialUpdater(string accountSid, string credentialListSid, string sid, string username, string password) {
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.sid = sid;
            this.username = username;
            this.password = password;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialResource
         */
        public override async Task<CredentialResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            return CredentialResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (username != "") {
                request.AddPostParam("Username", username);
            }
            
            if (password != "") {
                request.AddPostParam("Password", password);
            }
        }
    }
}