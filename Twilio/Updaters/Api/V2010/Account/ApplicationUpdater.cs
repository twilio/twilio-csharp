using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Api.V2010.Account {

    public class ApplicationUpdater : Updater<ApplicationResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
        private string apiVersion;
        private Uri voiceUrl;
        private Twilio.Http.HttpMethod voiceMethod;
        private Uri voiceFallbackUrl;
        private Twilio.Http.HttpMethod voiceFallbackMethod;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
        private bool? voiceCallerIdLookup;
        private Uri smsUrl;
        private Twilio.Http.HttpMethod smsMethod;
        private Uri smsFallbackUrl;
        private Twilio.Http.HttpMethod smsFallbackMethod;
        private Uri smsStatusCallback;
        private Uri messageStatusCallback;
    
        /**
         * Construct a new ApplicationUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public ApplicationUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * A human readable descriptive text for this resource, up to 64 characters
         * long.
         * 
         * @param friendlyName Human readable description of this resource
         * @return this
         */
        public ApplicationUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * Requests to this application will start a new TwiML session with this API
         * version.
         * 
         * @param apiVersion The API version to use
         * @return this
         */
        public ApplicationUpdater setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * The URL Twilio will request when a phone number assigned to this application
         * receives a call.
         * 
         * @param voiceUrl URL Twilio will make requests to when relieving a call
         * @return this
         */
        public ApplicationUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when a phone number assigned to this application
         * receives a call.
         * 
         * @param voiceUrl URL Twilio will make requests to when relieving a call
         * @return this
         */
        public ApplicationUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above `Url`. Either `GET`
         * or `POST`.
         * 
         * @param voiceMethod HTTP method to use with the URL
         * @return this
         */
        public ApplicationUpdater setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML requested by `Url`.
         * 
         * @param voiceFallbackUrl Fallback URL
         * @return this
         */
        public ApplicationUpdater setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML requested by `Url`.
         * 
         * @param voiceFallbackUrl Fallback URL
         * @return this
         */
        public ApplicationUpdater setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the `VoiceFallbackUrl`.
         * Either `GET` or `POST`.
         * 
         * @param voiceFallbackMethod HTTP method to use with the fallback url
         * @return this
         */
        public ApplicationUpdater setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request to pass status parameters (such as call
         * ended) to your application.
         * 
         * @param statusCallback URL to hit with status updates
         * @return this
         */
        public ApplicationUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The URL that Twilio will request to pass status parameters (such as call
         * ended) to your application.
         * 
         * @param statusCallback URL to hit with status updates
         * @return this
         */
        public ApplicationUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The HTTP method Twilio will use to make requests to the `StatusCallback` URL.
         * Either `GET` or `POST`.
         * 
         * @param statusCallbackMethod HTTP method to use with the status callback
         * @return this
         */
        public ApplicationUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * Look up the caller's caller-ID name from the CNAM database (additional
         * charges apply). Either `true` or `false`.
         * 
         * @param voiceCallerIdLookup True or False
         * @return this
         */
        public ApplicationUpdater setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /**
         * The URL Twilio will request when a phone number assigned to this application
         * receives an incoming SMS message.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public ApplicationUpdater setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when a phone number assigned to this application
         * receives an incoming SMS message.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public ApplicationUpdater setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /**
         * The HTTP method Twilio will use when making requests to the `SmsUrl`. Either
         * `GET` or `POST`.
         * 
         * @param smsMethod HTTP method to use with sms_url
         * @return this
         */
        public ApplicationUpdater setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl Fallback URL if there's an error parsing TwiML
         * @return this
         */
        public ApplicationUpdater setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl Fallback URL if there's an error parsing TwiML
         * @return this
         */
        public ApplicationUpdater setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above URL. Either `GET`
         * or `POST`.
         * 
         * @param smsFallbackMethod HTTP method to use with sms_fallback_method
         * @return this
         */
        public ApplicationUpdater setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will `POST` to when a message is sent via the
         * `/SMS/Messages` endpoint if you specify the `Sid` of this application on an
         * outgoing SMS request.
         * 
         * @param smsStatusCallback URL Twilio with request with status updates
         * @return this
         */
        public ApplicationUpdater setSmsStatusCallback(Uri smsStatusCallback) {
            this.smsStatusCallback = smsStatusCallback;
            return this;
        }
    
        /**
         * The URL that Twilio will `POST` to when a message is sent via the
         * `/SMS/Messages` endpoint if you specify the `Sid` of this application on an
         * outgoing SMS request.
         * 
         * @param smsStatusCallback URL Twilio with request with status updates
         * @return this
         */
        public ApplicationUpdater setSmsStatusCallback(string smsStatusCallback) {
            return setSmsStatusCallback(Promoter.UriFromString(smsStatusCallback));
        }
    
        /**
         * Twilio will make a `POST` request to this URL to pass status parameters (such
         * as sent or failed) to your application if you use the `/Messages` endpoint to
         * send the message and specify this application's `Sid` as the `ApplicationSid`
         * on an outgoing SMS request.
         * 
         * @param messageStatusCallback URL to make requests to with status updates
         * @return this
         */
        public ApplicationUpdater setMessageStatusCallback(Uri messageStatusCallback) {
            this.messageStatusCallback = messageStatusCallback;
            return this;
        }
    
        /**
         * Twilio will make a `POST` request to this URL to pass status parameters (such
         * as sent or failed) to your application if you use the `/Messages` endpoint to
         * send the message and specify this application's `Sid` as the `ApplicationSid`
         * on an outgoing SMS request.
         * 
         * @param messageStatusCallback URL to make requests to with status updates
         * @return this
         */
        public ApplicationUpdater setMessageStatusCallback(string messageStatusCallback) {
            return setMessageStatusCallback(Promoter.UriFromString(messageStatusCallback));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ApplicationResource
         */
        public override async Task<ApplicationResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Applications/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
            
            return ApplicationResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ApplicationResource
         */
        public override ApplicationResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Applications/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
            
            return ApplicationResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != "") {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != "") {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceCallerIdLookup != null) {
                request.AddPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsFallbackMethod != null) {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsStatusCallback != null) {
                request.AddPostParam("SmsStatusCallback", smsStatusCallback.ToString());
            }
            
            if (messageStatusCallback != null) {
                request.AddPostParam("MessageStatusCallback", messageStatusCallback.ToString());
            }
        }
    }
}