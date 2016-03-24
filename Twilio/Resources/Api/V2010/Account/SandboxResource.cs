using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

namespace Twilio.Resources.Api.V2010.Account {

    public class SandboxResource : Resource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @return SandboxFetcher capable of executing the fetch
         */
        public static SandboxFetcher fetch(string accountSid) {
            return new SandboxFetcher(accountSid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @return SandboxUpdater capable of executing the update
         */
        public static SandboxUpdater update(string accountSid) {
            return new SandboxUpdater(accountSid);
        }
    
        /**
         * Converts a JSON string into a SandboxResource object
         * 
         * @param json Raw JSON string
         * @return SandboxResource object represented by the provided JSON
         */
        public static SandboxResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SandboxResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("pin")]
        private readonly int pin;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("phone_number")]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("application_sid")]
        private readonly string applicationSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("voice_url")]
        private readonly Uri voiceUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("status_callback")]
        private readonly Uri statusCallback;
        [JsonProperty("status_callback_method")]
        private readonly HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly Uri uri;
    
        private SandboxResource([JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("pin")]
                                int pin, 
                                [JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("phone_number")]
                                Twilio.Types.PhoneNumber phoneNumber, 
                                [JsonProperty("application_sid")]
                                string applicationSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("voice_url")]
                                Uri voiceUrl, 
                                [JsonProperty("voice_method")]
                                HttpMethod voiceMethod, 
                                [JsonProperty("sms_url")]
                                Uri smsUrl, 
                                [JsonProperty("sms_method")]
                                HttpMethod smsMethod, 
                                [JsonProperty("status_callback")]
                                Uri statusCallback, 
                                [JsonProperty("status_callback_method")]
                                HttpMethod statusCallbackMethod, 
                                [JsonProperty("uri")]
                                Uri uri) {
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.pin = pin;
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.applicationSid = applicationSid;
            this.apiVersion = apiVersion;
            this.voiceUrl = voiceUrl;
            this.voiceMethod = voiceMethod;
            this.smsUrl = smsUrl;
            this.smsMethod = smsMethod;
            this.statusCallback = statusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.uri = uri;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The pin
         */
        public int GetPin() {
            return this.pin;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The phone_number
         */
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The application_sid
         */
        public string GetApplicationSid() {
            return this.applicationSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The voice_url
         */
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    
        /**
         * @return The voice_method
         */
        public HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return The sms_url
         */
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return The sms_method
         */
        public HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return The status_callback
         */
        public Uri GetStatusCallback() {
            return this.statusCallback;
        }
    
        /**
         * @return The status_callback_method
         */
        public HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return The uri
         */
        public Uri GetUri() {
            return this.uri;
        }
    }
}