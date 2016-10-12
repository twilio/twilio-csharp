using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ApplicationResource : SidResource {
        /// <summary>
        /// Create a new application within your account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <returns> ApplicationCreator capable of executing the create </returns> 
        public static ApplicationCreator Creator(string accountSid, string friendlyName) {
            return new ApplicationCreator(accountSid, friendlyName);
        }
    
        /// <summary>
        /// Create a ApplicationCreator to execute create.
        /// </summary>
        ///
        /// <param name="friendlyName"> Human readable description of this resource </param>
        /// <returns> ApplicationCreator capable of executing the create </returns> 
        public static ApplicationCreator Creator(string friendlyName) {
            return new ApplicationCreator(friendlyName);
        }
    
        /// <summary>
        /// Delete the application by the specified application sid
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The application sid to delete </param>
        /// <returns> ApplicationDeleter capable of executing the delete </returns> 
        public static ApplicationDeleter Deleter(string accountSid, string sid) {
            return new ApplicationDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ApplicationDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> The application sid to delete </param>
        /// <returns> ApplicationDeleter capable of executing the delete </returns> 
        public static ApplicationDeleter Deleter(string sid) {
            return new ApplicationDeleter(sid);
        }
    
        /// <summary>
        /// Fetch the application specified by the provided sid
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique Application Sid </param>
        /// <returns> ApplicationFetcher capable of executing the fetch </returns> 
        public static ApplicationFetcher Fetcher(string accountSid, string sid) {
            return new ApplicationFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ApplicationFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique Application Sid </param>
        /// <returns> ApplicationFetcher capable of executing the fetch </returns> 
        public static ApplicationFetcher Fetcher(string sid) {
            return new ApplicationFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of applications representing an application within the requesting account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> ApplicationReader capable of executing the read </returns> 
        public static ApplicationReader Reader(string accountSid) {
            return new ApplicationReader(accountSid);
        }
    
        /// <summary>
        /// Create a ApplicationReader to execute read.
        /// </summary>
        ///
        /// <returns> ApplicationReader capable of executing the read </returns> 
        public static ApplicationReader Reader() {
            return new ApplicationReader();
        }
    
        /// <summary>
        /// Updates the application's properties
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ApplicationUpdater capable of executing the update </returns> 
        public static ApplicationUpdater Updater(string accountSid, string sid) {
            return new ApplicationUpdater(accountSid, sid);
        }
    
        /// <summary>
        /// Create a ApplicationUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> ApplicationUpdater capable of executing the update </returns> 
        public static ApplicationUpdater Updater(string sid) {
            return new ApplicationUpdater(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ApplicationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ApplicationResource object represented by the provided JSON </returns> 
        public static ApplicationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ApplicationResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("message_status_callback")]
        private readonly Uri messageStatusCallback;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly Uri smsFallbackUrl;
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsMethod;
        [JsonProperty("sms_status_callback")]
        private readonly Uri smsStatusCallback;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("status_callback")]
        private readonly Uri statusCallback;
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("voice_caller_id_lookup")]
        private readonly bool? voiceCallerIdLookup;
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly Uri voiceFallbackUrl;
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceMethod;
        [JsonProperty("voice_url")]
        private readonly Uri voiceUrl;
    
        public ApplicationResource() {
        
        }
    
        private ApplicationResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("api_version")]
                                    string apiVersion, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("friendly_name")]
                                    string friendlyName, 
                                    [JsonProperty("message_status_callback")]
                                    Uri messageStatusCallback, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("sms_fallback_method")]
                                    Twilio.Http.HttpMethod smsFallbackMethod, 
                                    [JsonProperty("sms_fallback_url")]
                                    Uri smsFallbackUrl, 
                                    [JsonProperty("sms_method")]
                                    Twilio.Http.HttpMethod smsMethod, 
                                    [JsonProperty("sms_status_callback")]
                                    Uri smsStatusCallback, 
                                    [JsonProperty("sms_url")]
                                    Uri smsUrl, 
                                    [JsonProperty("status_callback")]
                                    Uri statusCallback, 
                                    [JsonProperty("status_callback_method")]
                                    Twilio.Http.HttpMethod statusCallbackMethod, 
                                    [JsonProperty("uri")]
                                    string uri, 
                                    [JsonProperty("voice_caller_id_lookup")]
                                    bool? voiceCallerIdLookup, 
                                    [JsonProperty("voice_fallback_method")]
                                    Twilio.Http.HttpMethod voiceFallbackMethod, 
                                    [JsonProperty("voice_fallback_url")]
                                    Uri voiceFallbackUrl, 
                                    [JsonProperty("voice_method")]
                                    Twilio.Http.HttpMethod voiceMethod, 
                                    [JsonProperty("voice_url")]
                                    Uri voiceUrl) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.messageStatusCallback = messageStatusCallback;
            this.sid = sid;
            this.smsFallbackMethod = smsFallbackMethod;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsMethod = smsMethod;
            this.smsStatusCallback = smsStatusCallback;
            this.smsUrl = smsUrl;
            this.statusCallback = statusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.uri = uri;
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.voiceMethod = voiceMethod;
            this.voiceUrl = voiceUrl;
        }
    
        /// <returns> A string that uniquely identifies this resource </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The API version to use </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> Date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> Date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> Human readable description of this resource </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> URL to make requests to with status updates </returns> 
        public Uri GetMessageStatusCallback() {
            return this.messageStatusCallback;
        }
    
        /// <returns> A string that uniquely identifies this resource </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> HTTP method to use with sms_fallback_method </returns> 
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /// <returns> Fallback URL if there's an error parsing TwiML </returns> 
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /// <returns> HTTP method to use with sms_url </returns> 
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /// <returns> URL Twilio with request with status updates </returns> 
        public Uri GetSmsStatusCallback() {
            return this.smsStatusCallback;
        }
    
        /// <returns> URL Twilio will request when receiving an SMS </returns> 
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /// <returns> URL to hit with status updates </returns> 
        public Uri GetStatusCallback() {
            return this.statusCallback;
        }
    
        /// <returns> HTTP method to use with the status callback </returns> 
        public Twilio.Http.HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /// <returns> URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> True or False </returns> 
        public bool? GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /// <returns> HTTP method to use with the fallback url </returns> 
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /// <returns> Fallback URL </returns> 
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /// <returns> HTTP method to use with the URL </returns> 
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /// <returns> URL Twilio will make requests to when relieving a call </returns> 
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}