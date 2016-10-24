using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class IncomingPhoneNumberUpdater : Updater<IncomingPhoneNumberResource> {
        public string ownerAccountSid { get; }
        public string sid { get; }
        public string accountSid { get; set; }
        public string apiVersion { get; set; }
        public string friendlyName { get; set; }
        public string smsApplicationSid { get; set; }
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        public Uri smsFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        public Uri smsUrl { get; set; }
        public Uri statusCallback { get; set; }
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        public string trunkSid { get; set; }
        public string voiceApplicationSid { get; set; }
        public bool? voiceCallerIdLookup { get; set; }
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        public Uri voiceFallbackUrl { get; set; }
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        public Uri voiceUrl { get; set; }
    
        /// <summary>
        /// Construct a new IncomingPhoneNumberUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public IncomingPhoneNumberUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new IncomingPhoneNumberUpdater
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="sid"> The sid </param>
        public IncomingPhoneNumberUpdater(string ownerAccountSid, string sid) {
            this.ownerAccountSid = ownerAccountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The unique id of the Account to which you wish to transfer this phnoe number
        /// </summary>
        ///
        /// <param name="accountSid"> The new owner of the phone number </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setAccountSid(string accountSid) {
            this.accountSid = accountSid;
            return this;
        }
    
        /// <summary>
        /// Calls to this phone number will start a new TwiML session with this API version.
        /// </summary>
        ///
        /// <param name="apiVersion"> The Twilio REST API version to use </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /// <summary>
        /// A human readable descriptive text for this resource, up to 64 characters long. By default, the `FriendlyName` is a
        /// nicely formatted version of the phone number.
        /// </summary>
        ///
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The 34 character sid of the application Twilio should use to handle SMSs sent to this number. If a
        /// `SmsApplicationSid` is present, Twilio will ignore all of the SMS urls above and use those set on the application.
        /// </summary>
        ///
        /// <param name="smsApplicationSid"> Unique string that identifies the application </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsApplicationSid(string smsApplicationSid) {
            this.smsApplicationSid = smsApplicationSid;
            return this;
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above URL. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsFallbackMethod"> HTTP method used with sms fallback url </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when making requests to the `SmsUrl`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsMethod"> HTTP method to use with sms url </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when receiving an incoming SMS message to this number.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when receiving an incoming SMS message to this number.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
        /// </summary>
        ///
        /// <param name="statusCallback"> URL Twilio will use to pass status parameters </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
        /// </summary>
        ///
        /// <param name="statusCallback"> URL Twilio will use to pass status parameters </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use to make requests to the `StatusCallback` URL. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> HTTP method twilio will use with status callback </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The 34 character sid of the Trunk Twilio should use to handle phone calls to this number. If a `TrunkSid` is
        /// present, Twilio will ignore all of the voice urls  and voice applications above and use those set on the Trunk.
        /// Setting a `TrunkSid` will automatically delete your `VoiceApplicationSid` and vice versa.
        /// </summary>
        ///
        /// <param name="trunkSid"> Unique string to identify the trunk </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setTrunkSid(string trunkSid) {
            this.trunkSid = trunkSid;
            return this;
        }
    
        /// <summary>
        /// The 34 character sid of the application Twilio should use to handle phone calls to this number. If a
        /// `VoiceApplicationSid` is present, Twilio will ignore all of the voice urls above and use those set on the
        /// application. Setting a `VoiceApplicationSid` will automatically delete your `TrunkSid` and vice versa.
        /// </summary>
        ///
        /// <param name="voiceApplicationSid"> The unique sid of the application to handle this number </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceApplicationSid(string voiceApplicationSid) {
            this.voiceApplicationSid = voiceApplicationSid;
            return this;
        }
    
        /// <summary>
        /// Look up the caller's caller-ID name from the CNAM database ($0.01 per look up). Either `true` or `false`.
        /// </summary>
        ///
        /// <param name="voiceCallerIdLookup"> Look up the caller's caller-ID </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the `VoiceFallbackUrl`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="voiceFallbackMethod"> HTTP method used with fallback_url </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by `Url`.
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> URL Twilio will request when an error occurs in TwiML </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by `Url`.
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> URL Twilio will request when an error occurs in TwiML </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above `Url`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="voiceMethod"> HTTP method used with the voice url </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when this phone number receives a call. The VoiceURL will  no longer be used if a
        /// `VoiceApplicationSid` or a `TrunkSid` is set.
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when this phone number receives a call. The VoiceURL will  no longer be used if a
        /// `VoiceApplicationSid` or a `TrunkSid` is set.
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> this </returns> 
        public IncomingPhoneNumberUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated IncomingPhoneNumberResource </returns> 
        public override async Task<IncomingPhoneNumberResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource update failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated IncomingPhoneNumberResource </returns> 
        public override IncomingPhoneNumberResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (ownerAccountSid ?? client.GetAccountSid()) + "/IncomingPhoneNumbers/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IncomingPhoneNumberResource update failed: Unable to connect to server");
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
            
            return IncomingPhoneNumberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request) {
            if (accountSid != null) {
                request.AddPostParam("AccountSid", accountSid);
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
            
            if (trunkSid != null) {
                request.AddPostParam("TrunkSid", trunkSid);
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