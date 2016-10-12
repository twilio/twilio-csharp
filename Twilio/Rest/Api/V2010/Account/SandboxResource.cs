using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class SandboxResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SandboxFetcher capable of executing the fetch </returns> 
        public static SandboxFetcher Fetcher(string accountSid) {
            return new SandboxFetcher(accountSid);
        }
    
        /// <summary>
        /// Create a SandboxFetcher to execute fetch.
        /// </summary>
        ///
        /// <returns> SandboxFetcher capable of executing the fetch </returns> 
        public static SandboxFetcher Fetcher() {
            return new SandboxFetcher();
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> SandboxUpdater capable of executing the update </returns> 
        public static SandboxUpdater Updater(string accountSid) {
            return new SandboxUpdater(accountSid);
        }
    
        /// <summary>
        /// Create a SandboxUpdater to execute update.
        /// </summary>
        ///
        /// <returns> SandboxUpdater capable of executing the update </returns> 
        public static SandboxUpdater Updater() {
            return new SandboxUpdater();
        }
    
        /// <summary>
        /// Converts a JSON string into a SandboxResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SandboxResource object represented by the provided JSON </returns> 
        public static SandboxResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<SandboxResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("pin")]
        private readonly int? pin;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("application_sid")]
        private readonly string applicationSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("voice_url")]
        private readonly Uri voiceUrl;
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod voiceMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsMethod;
        [JsonProperty("status_callback")]
        private readonly Uri statusCallback;
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly Uri uri;
    
        public SandboxResource() {
        
        }
    
        private SandboxResource([JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("pin")]
                                int? pin, 
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
                                Twilio.Http.HttpMethod voiceMethod, 
                                [JsonProperty("sms_url")]
                                Uri smsUrl, 
                                [JsonProperty("sms_method")]
                                Twilio.Http.HttpMethod smsMethod, 
                                [JsonProperty("status_callback")]
                                Uri statusCallback, 
                                [JsonProperty("status_callback_method")]
                                Twilio.Http.HttpMethod statusCallbackMethod, 
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
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The pin </returns> 
        public int? GetPin() {
            return this.pin;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The phone_number </returns> 
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /// <returns> The application_sid </returns> 
        public string GetApplicationSid() {
            return this.applicationSid;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The voice_url </returns> 
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    
        /// <returns> The voice_method </returns> 
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /// <returns> The sms_url </returns> 
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /// <returns> The sms_method </returns> 
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /// <returns> The status_callback </returns> 
        public Uri GetStatusCallback() {
            return this.statusCallback;
        }
    
        /// <returns> The status_callback_method </returns> 
        public Twilio.Http.HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /// <returns> The uri </returns> 
        public Uri GetUri() {
            return this.uri;
        }
    }
}