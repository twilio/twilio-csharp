using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.Credential;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.IpMessaging.V1 {

    public class CredentialUpdater : Updater<Credential> {
        private string sid;
        private string friendlyName;
        private Credential.PushService type;
        private string certificate;
        private string privateKey;
        private bool sandbox;
        private string apiKey;
    
        /**
         * Construct a new CredentialUpdater
         * 
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @param type The type
         */
        public CredentialUpdater(string sid, string friendlyName, Credential.PushService type) {
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
        public CredentialUpdater setSandbox(bool sandbox) {
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
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Credential
         */
        [Override]
        public Credential execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Credentials/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Credential update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (type != null) {
                request.addPostParam("Type", type.ToString());
            }
            
            if (certificate != null) {
                request.addPostParam("Certificate", certificate);
            }
            
            if (privateKey != null) {
                request.addPostParam("PrivateKey", privateKey);
            }
            
            if (sandbox != null) {
                request.addPostParam("Sandbox", sandbox.ToString());
            }
            
            if (apiKey != null) {
                request.addPostParam("ApiKey", apiKey);
            }
        }
    }
}