using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Sandbox : Resource {
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @return SandboxFetcher capable of executing the fetch
         */
        public static SandboxFetcher fetch(String accountSid) {
            return new SandboxFetcher(accountSid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @return SandboxUpdater capable of executing the update
         */
        public static SandboxUpdater update(String accountSid) {
            return new SandboxUpdater(accountSid);
        }
    
        /**
         * Converts a JSON string into a Sandbox object
         * 
         * @param json Raw JSON string
         * @return Sandbox object represented by the provided JSON
         */
        public static Sandbox fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Sandbox>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("pin")]
        private readonly Integer pin;
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("application_sid")]
        private readonly String applicationSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("voice_url")]
        private readonly URI voiceUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("sms_url")]
        private readonly URI smsUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("status_callback")]
        private readonly URI statusCallback;
        [JsonProperty("status_callback_method")]
        private readonly HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly URI uri;
    
        private Sandbox([JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("pin")]
                        Integer pin, 
                        [JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("phone_number")]
                        com.twilio.types.PhoneNumber phoneNumber, 
                        [JsonProperty("application_sid")]
                        String applicationSid, 
                        [JsonProperty("api_version")]
                        String apiVersion, 
                        [JsonProperty("voice_url")]
                        URI voiceUrl, 
                        [JsonProperty("voice_method")]
                        HttpMethod voiceMethod, 
                        [JsonProperty("sms_url")]
                        URI smsUrl, 
                        [JsonProperty("sms_method")]
                        HttpMethod smsMethod, 
                        [JsonProperty("status_callback")]
                        URI statusCallback, 
                        [JsonProperty("status_callback_method")]
                        HttpMethod statusCallbackMethod, 
                        [JsonProperty("uri")]
                        URI uri) {
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public Integer GetPin() {
            return this.pin;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The phone_number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The application_sid
         */
        public String GetApplicationSid() {
            return this.applicationSid;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The voice_url
         */
        public URI GetVoiceUrl() {
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
        public URI GetSmsUrl() {
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
        public URI GetStatusCallback() {
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
        public URI GetUri() {
            return this.uri;
        }
    }
}