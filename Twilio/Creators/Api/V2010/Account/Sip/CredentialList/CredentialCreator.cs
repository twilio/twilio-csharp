using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sip.CredentialList;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account.Sip.CredentialList {

    public class CredentialCreator : Creator<CredentialResource> {
        private string accountSid;
        private string credentialListSid;
        private string username;
        private string password;
    
        /**
         * Construct a new CredentialCreator.
         * 
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         */
        public CredentialCreator(string credentialListSid, string username, string password) {
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.password = password;
        }
    
        /**
         * Construct a new CredentialCreator
         * 
         * @param accountSid The account_sid
         * @param credentialListSid The credential_list_sid
         * @param username The username
         * @param password The password
         */
        public CredentialCreator(string accountSid, string credentialListSid, string username, string password) {
            this.accountSid = accountSid;
            this.credentialListSid = credentialListSid;
            this.username = username;
            this.password = password;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialResource
         */
        public override async Task<CredentialResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created CredentialResource
         */
        public override CredentialResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/CredentialLists/" + this.credentialListSid + "/Credentials.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("CredentialResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            if (username != null) {
                request.AddPostParam("Username", username);
            }
            
            if (password != null) {
                request.AddPostParam("Password", password);
            }
        }
    }
}