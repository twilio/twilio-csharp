using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.IncomingPhoneNumber;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Api.V2010.Account {

    public class IncomingPhoneNumberUpdater : Updater<IncomingPhoneNumber> {
        private String ownerAccountSid;
        private String sid;
        private String accountSid;
        private String apiVersion;
        private String friendlyName;
        private String smsApplicationSid;
        private HttpMethod smsFallbackMethod;
        private URI smsFallbackUrl;
        private HttpMethod smsMethod;
        private URI smsUrl;
        private URI statusCallback;
        private HttpMethod statusCallbackMethod;
        private String voiceApplicationSid;
        private Boolean voiceCallerIdLookup;
        private HttpMethod voiceFallbackMethod;
        private URI voiceFallbackUrl;
        private HttpMethod voiceMethod;
        private URI voiceUrl;
    
        /**
         * Construct a new IncomingPhoneNumberUpdater
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid The sid
         */
        public IncomingPhoneNumberUpdater(String ownerAccountSid, String sid) {
            this.ownerAccountSid = ownerAccountSid;
            this.sid = sid;
        }
    
        /**
         * The unique id of the Account to which you wish to transfer this phnoe number
         * 
         * @param accountSid The new owner of the phone number
         * @return this
         */
        public IncomingPhoneNumberUpdater setAccountSid(String accountSid) {
            this.accountSid = accountSid;
            return this;
        }
    
        /**
         * Calls to this phone number will start a new TwiML session with this API
         * version.
         * 
         * @param apiVersion The Twilio REST API version to use
         * @return this
         */
        public IncomingPhoneNumberUpdater setApiVersion(String apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * A human readable descriptive text for this resource, up to 64 characters
         * long. By default, the `FriendlyName` is a nicely formatted version of the
         * phone number.
         * 
         * @param friendlyName A human readable description of this resource
         * @return this
         */
        public IncomingPhoneNumberUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The 34 character sid of the application Twilio should use to handle SMSs sent
         * to this number. If a `SmsApplicationSid` is present, Twilio will ignore all
         * of the SMS urls above and use those set on the application.
         * 
         * @param smsApplicationSid Unique string that identifies the application
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsApplicationSid(String smsApplicationSid) {
            this.smsApplicationSid = smsApplicationSid;
            return this;
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above URL. Either `GET`
         * or `POST`.
         * 
         * @param smsFallbackMethod HTTP method used with sms fallback url
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsFallbackMethod(HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl URL Twilio will request if an error occurs in
         *                       executing TwiML
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsFallbackUrl(URI smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl URL Twilio will request if an error occurs in
         *                       executing TwiML
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsFallbackUrl(String smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.uriFromString(smsFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when making requests to the `SmsUrl`. Either
         * `GET` or `POST`.
         * 
         * @param smsMethod HTTP method to use with sms url
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsMethod(HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /**
         * The URL Twilio will request when receiving an incoming SMS message to this
         * number.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsUrl(URI smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when receiving an incoming SMS message to this
         * number.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public IncomingPhoneNumberUpdater setSmsUrl(String smsUrl) {
            return setSmsUrl(Promoter.uriFromString(smsUrl));
        }
    
        /**
         * The URL that Twilio will request to pass status parameters (such as call
         * ended) to your application.
         * 
         * @param statusCallback URL Twilio will use to pass status parameters
         * @return this
         */
        public IncomingPhoneNumberUpdater setStatusCallback(URI statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The URL that Twilio will request to pass status parameters (such as call
         * ended) to your application.
         * 
         * @param statusCallback URL Twilio will use to pass status parameters
         * @return this
         */
        public IncomingPhoneNumberUpdater setStatusCallback(String statusCallback) {
            return setStatusCallback(Promoter.uriFromString(statusCallback));
        }
    
        /**
         * The HTTP method Twilio will use to make requests to the `StatusCallback` URL.
         * Either `GET` or `POST`.
         * 
         * @param statusCallbackMethod HTTP method twilio will use with status callback
         * @return this
         */
        public IncomingPhoneNumberUpdater setStatusCallbackMethod(HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /**
         * The 34 character sid of the application Twilio should use to handle phone
         * calls to this number. If a `VoiceApplicationSid` is present, Twilio will
         * ignore all of the voice urls above and use those set on the application.
         * Setting a `VoiceApplicationSid` will automatically delete your `TrunkSid` and
         * vice versa.
         * 
         * @param voiceApplicationSid The unique sid of the application to handle this
         *                            number
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceApplicationSid(String voiceApplicationSid) {
            this.voiceApplicationSid = voiceApplicationSid;
            return this;
        }
    
        /**
         * Look up the caller's caller-ID name from the CNAM database ($0.01 per look
         * up). Either `true` or `false`.
         * 
         * @param voiceCallerIdLookup Look up the caller's caller-ID
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceCallerIdLookup(Boolean voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /**
         * The HTTP method Twilio will use when requesting the `VoiceFallbackUrl`.
         * Either `GET` or `POST`.
         * 
         * @param voiceFallbackMethod HTTP method used with fallback_url
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceFallbackMethod(HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML requested by `Url`.
         * 
         * @param voiceFallbackUrl URL Twilio will request when an error occurs in TwiML
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceFallbackUrl(URI voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML requested by `Url`.
         * 
         * @param voiceFallbackUrl URL Twilio will request when an error occurs in TwiML
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceFallbackUrl(String voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.uriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above `Url`. Either `GET`
         * or `POST`.
         * 
         * @param voiceMethod HTTP method used with the voice url
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceMethod(HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /**
         * The URL Twilio will request when this phone number receives a call. The
         * VoiceURL will  no longer be used if a `VoiceApplicationSid` or a `TrunkSid`
         * is set.
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceUrl(URI voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when this phone number receives a call. The
         * VoiceURL will  no longer be used if a `VoiceApplicationSid` or a `TrunkSid`
         * is set.
         * 
         * @param voiceUrl URL Twilio will request when receiving a call
         * @return this
         */
        public IncomingPhoneNumberUpdater setVoiceUrl(String voiceUrl) {
            return setVoiceUrl(Promoter.uriFromString(voiceUrl));
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated IncomingPhoneNumber
         */
        [Override]
        public IncomingPhoneNumber execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumber update failed: Unable to connect to server");
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
            
            return IncomingPhoneNumber.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (accountSid != null) {
                request.addPostParam("AccountSid", accountSid);
            }
            
            if (apiVersion != null) {
                request.addPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (smsApplicationSid != null) {
                request.addPostParam("SmsApplicationSid", smsApplicationSid);
            }
            
            if (smsFallbackMethod != null) {
                request.addPostParam("SmsFallbackMethod", smsFallbackMethod.toString());
            }
            
            if (smsFallbackUrl != null) {
                request.addPostParam("SmsFallbackUrl", smsFallbackUrl.toString());
            }
            
            if (smsMethod != null) {
                request.addPostParam("SmsMethod", smsMethod.toString());
            }
            
            if (smsUrl != null) {
                request.addPostParam("SmsUrl", smsUrl.toString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.toString());
            }
            
            if (statusCallbackMethod != null) {
                request.addPostParam("StatusCallbackMethod", statusCallbackMethod.toString());
            }
            
            if (voiceApplicationSid != null) {
                request.addPostParam("VoiceApplicationSid", voiceApplicationSid);
            }
            
            if (voiceCallerIdLookup != null) {
                request.addPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.toString());
            }
            
            if (voiceFallbackMethod != null) {
                request.addPostParam("VoiceFallbackMethod", voiceFallbackMethod.toString());
            }
            
            if (voiceFallbackUrl != null) {
                request.addPostParam("VoiceFallbackUrl", voiceFallbackUrl.toString());
            }
            
            if (voiceMethod != null) {
                request.addPostParam("VoiceMethod", voiceMethod.toString());
            }
            
            if (voiceUrl != null) {
                request.addPostParam("VoiceUrl", voiceUrl.toString());
            }
        }
    }
}