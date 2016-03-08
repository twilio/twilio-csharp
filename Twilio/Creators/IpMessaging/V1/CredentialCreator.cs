using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Creator;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Ipmessaging.V1.Credential;

namespace Twilio.Creators.IpMessaging.V1 {

    public class CredentialCreator : Creator<Credential> {
        private String friendlyName;
        private Credential.PushService type;
        private String certificate;
        private String privateKey;
        private Boolean sandbox;
        private String apiKey;
    
        /**
         * Construct a new CredentialCreator
         * 
         * @param friendlyName The friendly_name
         * @param type The type
         */
        public CredentialCreator(String friendlyName, Credential.PushService type) {
            this.friendlyName = friendlyName;
            this.type = type;
        }
    
        /**
         * The certificate
         * 
         * @param certificate The certificate
         * @return this
         */
        public CredentialCreator setCertificate(String certificate) {
            this.certificate = certificate;
            return this;
        }
    
        /**
         * The private_key
         * 
         * @param privateKey The private_key
         * @return this
         */
        public CredentialCreator setPrivateKey(String privateKey) {
            this.privateKey = privateKey;
            return this;
        }
    
        /**
         * The sandbox
         * 
         * @param sandbox The sandbox
         * @return this
         */
        public CredentialCreator setSandbox(Boolean sandbox) {
            this.sandbox = sandbox;
            return this;
        }
    
        /**
         * The api_key
         * 
         * @param apiKey The api_key
         * @return this
         */
        public CredentialCreator setApiKey(String apiKey) {
            this.apiKey = apiKey;
            return this;
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
                TwilioRestClient.Domains.IPMESSAGING,
                "/v1/Credentials",
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
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (type != null) {
                request.addPostParam("Type", type.toString());
            }
            
            if (certificate != null) {
                request.addPostParam("Certificate", certificate);
            }
            
            if (privateKey != null) {
                request.addPostParam("PrivateKey", privateKey);
            }
            
            if (sandbox != null) {
                request.addPostParam("Sandbox", sandbox.toString());
            }
            
            if (apiKey != null) {
                request.addPostParam("ApiKey", apiKey);
            }
        }
    }
}