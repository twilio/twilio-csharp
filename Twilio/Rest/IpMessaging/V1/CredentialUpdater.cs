using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.IpMessaging.V1 {

    public class CredentialUpdater : Updater<CredentialResource> {
        private string sid;
        private string friendlyName;
        private string certificate;
        private string privateKey;
        private bool? sandbox;
        private string apiKey;
    
        /**
         * Construct a new CredentialUpdater
         * 
         * @param sid The sid
         */
        public CredentialUpdater(string sid) {
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public CredentialUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The certificate
         * 
         * @param certificate The certificate
         * @return this
         */
        public CredentialUpdater setCertificate(string certificate) {
            this.certificate = certificate;
            return this;
        }
    
        /**
         * The private_key
         * 
         * @param privateKey The private_key
         * @return this
         */
        public CredentialUpdater setPrivateKey(string privateKey) {
            this.privateKey = privateKey;
            return this;
        }
    
        /**
         * The sandbox
         * 
         * @param sandbox The sandbox
         * @return this
         */
        public CredentialUpdater setSandbox(bool? sandbox) {
            this.sandbox = sandbox;
            return this;
        }
    
        /**
         * The api_key
         * 
         * @param apiKey The api_key
         * @return this
         */
        public CredentialUpdater setApiKey(string apiKey) {
            this.apiKey = apiKey;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialResource
         */
        public override async Task<CredentialResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Credentials/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialResource
         */
        public override CredentialResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.IP_MESSAGING,
                "/v1/Credentials/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("CredentialResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return CredentialResource.FromJson(response.Content);
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (certificate != null) {
                request.AddPostParam("Certificate", certificate);
            }
            
            if (privateKey != null) {
                request.AddPostParam("PrivateKey", privateKey);
            }
            
            if (sandbox != null) {
                request.AddPostParam("Sandbox", sandbox.ToString());
            }
            
            if (apiKey != null) {
                request.AddPostParam("ApiKey", apiKey);
            }
        }
    }
}