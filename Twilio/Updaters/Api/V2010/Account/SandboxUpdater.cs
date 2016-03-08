using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Sandbox;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Api.V2010.Account {

    public class SandboxUpdater : Updater<Sandbox> {
        private String accountSid;
        private URI voiceUrl;
        private HttpMethod voiceMethod;
        private URI smsUrl;
        private HttpMethod smsMethod;
        private URI statusCallback;
        private HttpMethod statusCallbackMethod;
    
        /**
         * Construct a new SandboxUpdater
         * 
         * @param accountSid The account_sid
         */
        public SandboxUpdater(String accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public SandboxUpdater setVoiceUrl(URI voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The voice_url
         * 
         * @param voiceUrl The voice_url
         * @return this
         */
        public SandboxUpdater setVoiceUrl(String voiceUrl) {
            return setVoiceUrl(Promoter.uriFromString(voiceUrl));
        }
    
        /**
         * The voice_method
         * 
         * @param voiceMethod The voice_method
         * @return this
         */
        public SandboxUpdater setVoiceMethod(HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The sms_url
         * 
         * @param smsUrl The sms_url
         * @return this
         */
        public SandboxUpdater setSmsUrl(URI smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /**
         * The sms_url
         * 
         * @param smsUrl The sms_url
         * @return this
         */
        public SandboxUpdater setSmsUrl(String smsUrl) {
            return setSmsUrl(Promoter.uriFromString(smsUrl));
        }
    
        /**
         * The sms_method
         * 
         * @param smsMethod The sms_method
         * @return this
         */
        public SandboxUpdater setSmsMethod(HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SandboxUpdater setStatusCallback(URI statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SandboxUpdater setStatusCallback(String statusCallback) {
            return setStatusCallback(Promoter.uriFromString(statusCallback));
        }
    
        /**
         * The status_callback_method
         * 
         * @param statusCallbackMethod The status_callback_method
         * @return this
         */
        public SandboxUpdater setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Sandbox
         */
        [Override]
        public Sandbox execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Sandbox.json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Sandbox update failed: Unable to connect to server");
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
            
            return Sandbox.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (voiceUrl != null) {
                request.addPostParam("VoiceUrl", voiceUrl.toString());
            }
            
            if (voiceMethod != null) {
                request.addPostParam("VoiceMethod", voiceMethod.toString());
            }
            
            if (smsUrl != null) {
                request.addPostParam("SmsUrl", smsUrl.toString());
            }
            
            if (smsMethod != null) {
                request.addPostParam("SmsMethod", smsMethod.toString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.toString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.toString());
            }
        }
    }
}