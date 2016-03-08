using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Application : SidResource {
        /**
         * Create a new application within your account
         * 
         * @param accountSid The account_sid
         * @param friendlyName Human readable description of this resource
         * @return ApplicationCreator capable of executing the create
         */
        public static ApplicationCreator create(String accountSid, String friendlyName) {
            return new ApplicationCreator(accountSid, friendlyName);
        }
    
        /**
         * Delete the application by the specified application sid
         * 
         * @param accountSid The account_sid
         * @param sid The application sid to delete
         * @return ApplicationDeleter capable of executing the delete
         */
        public static ApplicationDeleter delete(String accountSid, String sid) {
            return new ApplicationDeleter(accountSid, sid);
        }
    
        /**
         * Fetch the application specified by the provided sid
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique Application Sid
         * @return ApplicationFetcher capable of executing the fetch
         */
        public static ApplicationFetcher fetch(String accountSid, String sid) {
            return new ApplicationFetcher(accountSid, sid);
        }
    
        /**
         * Retrieve a list of applications representing an application within the
         * requesting account
         * 
         * @param accountSid The account_sid
         * @return ApplicationReader capable of executing the read
         */
        public static ApplicationReader read(String accountSid) {
            return new ApplicationReader(accountSid);
        }
    
        /**
         * Updates the application's properties
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return ApplicationUpdater capable of executing the update
         */
        public static ApplicationUpdater update(String accountSid, String sid) {
            return new ApplicationUpdater(accountSid, sid);
        }
    
        /**
         * Converts a JSON string into a Application object
         * 
         * @param json Raw JSON string
         * @return Application object represented by the provided JSON
         */
        public static Application fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Application>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("message_status_callback")]
        private readonly URI messageStatusCallback;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("sms_fallback_method")]
        private readonly HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly URI smsFallbackUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("sms_status_callback")]
        private readonly URI smsStatusCallback;
        [JsonProperty("sms_url")]
        private readonly URI smsUrl;
        [JsonProperty("status_callback")]
        private readonly URI statusCallback;
        [JsonProperty("status_callback_method")]
        private readonly HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly String uri;
        [JsonProperty("voice_caller_id_lookup")]
        private readonly Boolean voiceCallerIdLookup;
        [JsonProperty("voice_fallback_method")]
        private readonly HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly URI voiceFallbackUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("voice_url")]
        private readonly URI voiceUrl;
    
        private Application([JsonProperty("account_sid")]
                            String accountSid, 
                            [JsonProperty("api_version")]
                            String apiVersion, 
                            [JsonProperty("date_created")]
                            String dateCreated, 
                            [JsonProperty("date_updated")]
                            String dateUpdated, 
                            [JsonProperty("friendly_name")]
                            String friendlyName, 
                            [JsonProperty("message_status_callback")]
                            URI messageStatusCallback, 
                            [JsonProperty("sid")]
                            String sid, 
                            [JsonProperty("sms_fallback_method")]
                            HttpMethod smsFallbackMethod, 
                            [JsonProperty("sms_fallback_url")]
                            URI smsFallbackUrl, 
                            [JsonProperty("sms_method")]
                            HttpMethod smsMethod, 
                            [JsonProperty("sms_status_callback")]
                            URI smsStatusCallback, 
                            [JsonProperty("sms_url")]
                            URI smsUrl, 
                            [JsonProperty("status_callback")]
                            URI statusCallback, 
                            [JsonProperty("status_callback_method")]
                            HttpMethod statusCallbackMethod, 
                            [JsonProperty("uri")]
                            String uri, 
                            [JsonProperty("voice_caller_id_lookup")]
                            Boolean voiceCallerIdLookup, 
                            [JsonProperty("voice_fallback_method")]
                            HttpMethod voiceFallbackMethod, 
                            [JsonProperty("voice_fallback_url")]
                            URI voiceFallbackUrl, 
                            [JsonProperty("voice_method")]
                            HttpMethod voiceMethod, 
                            [JsonProperty("voice_url")]
                            URI voiceUrl) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The API version to use
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return Date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return Date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return Human readable description of this resource
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return URL to make requests to with status updates
         */
        public URI GetMessageStatusCallback() {
            return this.messageStatusCallback;
        }
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return HTTP method to use with sms_fallback_method
         */
        public HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return Fallback URL if there's an error parsing TwiML
         */
        public URI GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with sms_url
         */
        public HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return URL Twilio with request with status updates
         */
        public URI GetSmsStatusCallback() {
            return this.smsStatusCallback;
        }
    
        /**
         * @return URL Twilio will request when receiving an SMS
         */
        public URI GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return URL to hit with status updates
         */
        public URI GetStatusCallback() {
            return this.statusCallback;
        }
    
        /**
         * @return HTTP method to use with the status callback
         */
        public HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return True or False
         */
        public Boolean GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /**
         * @return HTTP method to use with the fallback url
         */
        public HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return Fallback URL
         */
        public URI GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with the URL
         */
        public HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return URL Twilio will make requests to when relieving a call
         */
        public URI GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}