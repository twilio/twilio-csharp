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
    
        /// <summary>
        /// Construct a new ApplicationUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public ApplicationUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new ApplicationUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        public ApplicationUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// A human readable descriptive text for this resource, up to 64 characters long.
        /// </summary>
        ///
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// Requests to this application will start a new TwiML session with this API version.
        /// </summary>
        ///
        /// <param name="apiVersion"> The API version to use </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setApiVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when a phone number assigned to this application receives a call.
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will make requests to when relieving a call </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceUrl(Uri voiceUrl) {
            this.voiceUrl = voiceUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when a phone number assigned to this application receives a call.
        /// </summary>
        ///
        /// <param name="voiceUrl"> URL Twilio will make requests to when relieving a call </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceUrl(string voiceUrl) {
            return setVoiceUrl(Promoter.UriFromString(voiceUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above `Url`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="voiceMethod"> HTTP method to use with the URL </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceMethod(Twilio.Http.HttpMethod voiceMethod) {
            this.voiceMethod = voiceMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by `Url`.
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> Fallback URL </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceFallbackUrl(Uri voiceFallbackUrl) {
            this.voiceFallbackUrl = voiceFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by `Url`.
        /// </summary>
        ///
        /// <param name="voiceFallbackUrl"> Fallback URL </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceFallbackUrl(string voiceFallbackUrl) {
            return setVoiceFallbackUrl(Promoter.UriFromString(voiceFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the `VoiceFallbackUrl`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="voiceFallbackMethod"> HTTP method to use with the fallback url </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceFallbackMethod(Twilio.Http.HttpMethod voiceFallbackMethod) {
            this.voiceFallbackMethod = voiceFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
        /// </summary>
        ///
        /// <param name="statusCallback"> URL to hit with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
        /// </summary>
        ///
        /// <param name="statusCallback"> URL to hit with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use to make requests to the `StatusCallback` URL. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="statusCallbackMethod"> HTTP method to use with the status callback </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setStatusCallbackMethod(Twilio.Http.HttpMethod statusCallbackMethod) {
            this.statusCallbackMethod = statusCallbackMethod;
            return this;
        }
    
        /// <summary>
        /// Look up the caller's caller-ID name from the CNAM database (additional charges apply). Either `true` or `false`.
        /// </summary>
        ///
        /// <param name="voiceCallerIdLookup"> True or False </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setVoiceCallerIdLookup(bool? voiceCallerIdLookup) {
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when a phone number assigned to this application receives an incoming SMS message.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsUrl(Uri smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /// <summary>
        /// The URL Twilio will request when a phone number assigned to this application receives an incoming SMS message.
        /// </summary>
        ///
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsUrl(string smsUrl) {
            return setSmsUrl(Promoter.UriFromString(smsUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when making requests to the `SmsUrl`. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsMethod"> HTTP method to use with sms_url </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsMethod(Twilio.Http.HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> Fallback URL if there's an error parsing TwiML </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsFallbackUrl(Uri smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from `SmsUrl`.
        /// </summary>
        ///
        /// <param name="smsFallbackUrl"> Fallback URL if there's an error parsing TwiML </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsFallbackUrl(string smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.UriFromString(smsFallbackUrl));
        }
    
        /// <summary>
        /// The HTTP method Twilio will use when requesting the above URL. Either `GET` or `POST`.
        /// </summary>
        ///
        /// <param name="smsFallbackMethod"> HTTP method to use with sms_fallback_method </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsFallbackMethod(Twilio.Http.HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will `POST` to when a message is sent via the `/SMS/Messages` endpoint if you specify the `Sid`
        /// of this application on an outgoing SMS request.
        /// </summary>
        ///
        /// <param name="smsStatusCallback"> URL Twilio with request with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsStatusCallback(Uri smsStatusCallback) {
            this.smsStatusCallback = smsStatusCallback;
            return this;
        }
    
        /// <summary>
        /// The URL that Twilio will `POST` to when a message is sent via the `/SMS/Messages` endpoint if you specify the `Sid`
        /// of this application on an outgoing SMS request.
        /// </summary>
        ///
        /// <param name="smsStatusCallback"> URL Twilio with request with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setSmsStatusCallback(string smsStatusCallback) {
            return setSmsStatusCallback(Promoter.UriFromString(smsStatusCallback));
        }
    
        /// <summary>
        /// Twilio will make a `POST` request to this URL to pass status parameters (such as sent or failed) to your application
        /// if you use the `/Messages` endpoint to send the message and specify this application's `Sid` as the `ApplicationSid`
        /// on an outgoing SMS request.
        /// </summary>
        ///
        /// <param name="messageStatusCallback"> URL to make requests to with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setMessageStatusCallback(Uri messageStatusCallback) {
            this.messageStatusCallback = messageStatusCallback;
            return this;
        }
    
        /// <summary>
        /// Twilio will make a `POST` request to this URL to pass status parameters (such as sent or failed) to your application
        /// if you use the `/Messages` endpoint to send the message and specify this application's `Sid` as the `ApplicationSid`
        /// on an outgoing SMS request.
        /// </summary>
        ///
        /// <param name="messageStatusCallback"> URL to make requests to with status updates </param>
        /// <returns> this </returns> 
        public ApplicationUpdater setMessageStatusCallback(string messageStatusCallback) {
            return setMessageStatusCallback(Promoter.UriFromString(messageStatusCallback));
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ApplicationResource </returns> 
        public override async Task<ApplicationResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Applications/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
            
            return ApplicationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ApplicationResource </returns> 
        public override ApplicationResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Applications/" + this.sid + ".json"
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ApplicationResource update failed: Unable to connect to server");
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
            
            return ApplicationResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != null) {
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