using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.IpMessaging.V1;
using Twilio.Updaters;

namespace Twilio.Updaters.IpMessaging.V1 {

    public class CredentialUpdater : Updater<CredentialResource> {
        private string sid;
        private string friendlyName;
        private CredentialResource.PushService type;
        private string certificate;
        private string privateKey;
        private bool? sandbox;
        private string apiKey;
    
        /**
         * Construct a new CredentialUpdater
         * 
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @param type The type
         */
        public CredentialUpdater(string sid, string friendlyName, CredentialResource.PushService type) {
            this.sid = sid;
            this.friendlyName = friendlyName;
            this.type = type;
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
        public override async Task<CredentialResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Credentials/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
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
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated CredentialResource
         */
        public override CredentialResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.IPMESSAGING,
                "/v1/Credentials/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
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
        #endif
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (type != null) {
                request.AddPostParam("Type", type.ToString());
            }
            
            if (certificate != "") {
                request.AddPostParam("Certificate", certificate);
            }
            
            if (privateKey != "") {
                request.AddPostParam("PrivateKey", privateKey);
            }
            
            if (sandbox != null) {
                request.AddPostParam("Sandbox", sandbox.ToString());
            }
            
            if (apiKey != "") {
                request.AddPostParam("ApiKey", apiKey);
            }
        }
    }
}