using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Rest.Api.V2010.Account {

    public class Application : SidResource {
        /**
         * Create a new application within your account
         * 
         * @param accountSid The account_sid
         * @param friendlyName Human readable description of this resource
         * @return ApplicationCreator capable of executing the create
         */
        public static ApplicationCreator Create(string accountSid, string friendlyName) {
            return new ApplicationCreator(accountSid, friendlyName);
        }
    
        /**
         * Create a ApplicationCreator to execute create.
         * 
         * @param friendlyName Human readable description of this resource
         * @return ApplicationCreator capable of executing the create
         */
        public static ApplicationCreator Create(string friendlyName) {
            return new ApplicationCreator(friendlyName);
        }
    
        /**
         * Delete the application by the specified application sid
         * 
         * @param accountSid The account_sid
         * @param sid The application sid to delete
         * @return ApplicationDeleter capable of executing the delete
         */
        public static ApplicationDeleter Delete(string accountSid, string sid) {
            return new ApplicationDeleter(accountSid, sid);
        }
    
        /**
         * Create a ApplicationDeleter to execute delete.
         * 
         * @param sid The application sid to delete
         * @return ApplicationDeleter capable of executing the delete
         */
        public static ApplicationDeleter Delete(string sid) {
            return new ApplicationDeleter(sid);
        }
    
        /**
         * Fetch the application specified by the provided sid
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique Application Sid
         * @return ApplicationFetcher capable of executing the fetch
         */
        public static ApplicationFetcher Fetch(string accountSid, string sid) {
            return new ApplicationFetcher(accountSid, sid);
        }
    
        /**
         * Create a ApplicationFetcher to execute fetch.
         * 
         * @param sid Fetch by unique Application Sid
         * @return ApplicationFetcher capable of executing the fetch
         */
        public static ApplicationFetcher Fetch(string sid) {
            return new ApplicationFetcher(sid);
        }
    
        /**
         * Retrieve a list of applications representing an application within the
         * requesting account
         * 
         * @param accountSid The account_sid
         * @return ApplicationReader capable of executing the read
         */
        public static ApplicationReader Read(string accountSid) {
            return new ApplicationReader(accountSid);
        }
    
        /**
         * Create a ApplicationReader to execute read.
         * 
         * @return ApplicationReader capable of executing the read
         */
        public static ApplicationReader Read() {
            return new ApplicationReader();
        }
    
        /**
         * Updates the application's properties
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ApplicationUpdater capable of executing the update
         */
        public static ApplicationUpdater Update(string accountSid, string sid) {
            return new ApplicationUpdater(accountSid, sid);
        }
    
        /**
         * Create a ApplicationUpdater to execute update.
         * 
         * @param sid The sid
         * @return ApplicationUpdater capable of executing the update
         */
        public static ApplicationUpdater Update(string sid) {
            return new ApplicationUpdater(sid);
        }
    
        /**
         * Converts a JSON string into a Application object
         * 
         * @param json Raw JSON string
         * @return Application object represented by the provided JSON
         */
        public static Application FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Application>(json);
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
    
        public Application() {
        
        }
    
        private Application([JsonProperty("account_sid")]
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
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The API version to use
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return Date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return Date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return Human readable description of this resource
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return URL to make requests to with status updates
         */
        public Uri GetMessageStatusCallback() {
            return this.messageStatusCallback;
        }
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return HTTP method to use with sms_fallback_method
         */
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return Fallback URL if there's an error parsing TwiML
         */
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with sms_url
         */
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return URL Twilio with request with status updates
         */
        public Uri GetSmsStatusCallback() {
            return this.smsStatusCallback;
        }
    
        /**
         * @return URL Twilio will request when receiving an SMS
         */
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return URL to hit with status updates
         */
        public Uri GetStatusCallback() {
            return this.statusCallback;
        }
    
        /**
         * @return HTTP method to use with the status callback
         */
        public Twilio.Http.HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return True or False
         */
        public bool? GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /**
         * @return HTTP method to use with the fallback url
         */
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return Fallback URL
         */
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with the URL
         */
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return URL Twilio will make requests to when relieving a call
         */
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}