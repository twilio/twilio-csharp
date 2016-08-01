using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account {

    public class IncomingPhoneNumberCreator : Creator<IncomingPhoneNumberResource> {
        private string ownerAccountSid;
        private Twilio.Types.PhoneNumber phoneNumber;
        private string areaCode;
        private string apiVersion;
        private string friendlyName;
        private string smsApplicationSid;
        private Twilio.Http.HttpMethod smsFallbackMethod;
        private Uri smsFallbackUrl;
        private Twilio.Http.HttpMethod smsMethod;
        private Uri smsUrl;
        private Uri statusCallback;
        private Twilio.Http.HttpMethod statusCallbackMethod;
        private string voiceApplicationSid;
        private bool? voiceCallerIdLookup;
        private Twilio.Http.HttpMethod voiceFallbackMethod;
        private Uri voiceFallbackUrl;
        private Twilio.Http.HttpMethod voiceMethod;
        private Uri voiceUrl;
    
        /**
         * Construct a new IncomingPhoneNumberCreator.
         * 
         * @param phoneNumber The phone number
         */
        public IncomingPhoneNumberCreator(Twilio.Types.PhoneNumber phoneNumber) {
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * Construct a new IncomingPhoneNumberCreator
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param phoneNumber The phone number
         */
        public IncomingPhoneNumberCreator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            this.ownerAccountSid = ownerAccountSid;
            this.phoneNumber = phoneNumber;
        }
    
        /**
         * Construct a new IncomingPhoneNumberCreator.
         * 
         * @param areaCode The desired area code for the new number
         */
        public IncomingPhoneNumberCreator(string areaCode) {
            this.areaCode = areaCode;
        }
    
        /**
         * Construct a new IncomingPhoneNumberCreator
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param areaCode The desired area code for the new number
         */
        public IncomingPhoneNumberCreator(string ownerAccountSid, string areaCode) {
            this.ownerAccountSid = ownerAccountSid;
            this.areaCode = areaCode;
        }
    
        /**
         * Calls to this phone number will start a new TwiML session with this API
         * version.
         * 
         * @param apiVersion The Twilio Rest API version to use
         * @return this
         */
        public IncomingPhoneNumberCreator setApiVersion(string apiVersion) {
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
        public IncomingPhoneNumberCreator setFriendlyName(string friendlyName) {
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
        public IncomingPhoneNumberCreator setSmsApplicationSid(string smsApplicationSid) {
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
        public IncomingPhoneNumberCreator setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
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
        public IncomingPhoneNumberCreator setSmsFallbackUrl(Uri smsFallbackUrl) {
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
        public IncomingPhoneNumberCreator setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when making requests to the `SmsUrl`. Either
         * `GET` or `POST`.
         * 
         * @param smsMethod HTTP method to use with sms url
         * @return this
         */
        public IncomingPhoneNumberCreator setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
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
        public IncomingPhoneNumberCreator setSmsUrl(Uri smsUrl) {
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
        public IncomingPhoneNumberCreator setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /**
         * The URL that Twilio will request to pass status parameters (such as call
         * ended) to your application.
         * 
         * @param statusCallback URL Twilio will use to pass status parameters
         * @return this
         */
        public IncomingPhoneNumberCreator setStatusCallback(Uri statusCallback) {
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
        public IncomingPhoneNumberCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The HTTP method Twilio will use to make requests to the `StatusCallback` URL.
         * Either `GET` or `POST`.
         * 
         * @param statusCallbackMethod HTTP method twilio will use with status callback
         * @return this
         */
        public IncomingPhoneNumberCreator setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
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
        public IncomingPhoneNumberCreator setVoiceApplicationSid(string voiceApplicationSid) {
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
        public IncomingPhoneNumberCreator setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
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
        public IncomingPhoneNumberCreator setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
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
        public IncomingPhoneNumberCreator setVoiceFallbackUrl(Uri voiceFallbackUrl) {
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
        public IncomingPhoneNumberCreator setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above `Url`. Either `GET`
         * or `POST`.
         * 
         * @param voiceMethod HTTP method used with the voice url
         * @return this
         */
        public IncomingPhoneNumberCreator setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
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
        public IncomingPhoneNumberCreator setVoiceUrl(Uri voiceUrl) {
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
        public IncomingPhoneNumberCreator setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IncomingPhoneNumberResource
         */
        public override async Task<IncomingPhoneNumberResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumberResource creation failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created IncomingPhoneNumberResource
         */
        public override IncomingPhoneNumberResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.ownerAccountSid + "/IncomingPhoneNumbers.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("IncomingPhoneNumberResource creation failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (phoneNumber != null) {
                request.AddPostParam("PhoneNumber", phoneNumber.ToString());
            }
            
            if (areaCode != null) {
                request.AddPostParam("AreaCode", areaCode);
            }
            
            if (apiVersion != null) {
                request.AddPostParam("ApiVersion", apiVersion);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (smsApplicationSid != null) {
                request.AddPostParam("SmsApplicationSid", smsApplicationSid);
            }
            
            if (smsFallbackMethod != null) {
                request.AddPostParam("SmsFallbackMethod", smsFallbackMethod.ToString());
            }
            
            if (smsFallbackUrl != null) {
                request.AddPostParam("SmsFallbackUrl", smsFallbackUrl.ToString());
            }
            
            if (smsMethod != null) {
                request.AddPostParam("SmsMethod", smsMethod.ToString());
            }
            
            if (smsUrl != null) {
                request.AddPostParam("SmsUrl", smsUrl.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (statusCallbackMethod != null) {
                request.AddPostParam("StatusCallbackMethod", statusCallbackMethod.ToString());
            }
            
            if (voiceApplicationSid != null) {
                request.AddPostParam("VoiceApplicationSid", voiceApplicationSid);
            }
            
            if (voiceCallerIdLookup != null) {
                request.AddPostParam("VoiceCallerIdLookup", voiceCallerIdLookup.ToString());
            }
            
            if (voiceFallbackMethod != null) {
                request.AddPostParam("VoiceFallbackMethod", voiceFallbackMethod.ToString());
            }
            
            if (voiceFallbackUrl != null) {
                request.AddPostParam("VoiceFallbackUrl", voiceFallbackUrl.ToString());
            }
            
            if (voiceMethod != null) {
                request.AddPostParam("VoiceMethod", voiceMethod.ToString());
            }
            
            if (voiceUrl != null) {
                request.AddPostParam("VoiceUrl", voiceUrl.ToString());
            }
        }
    }
}