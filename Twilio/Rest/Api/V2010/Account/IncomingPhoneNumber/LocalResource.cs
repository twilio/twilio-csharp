using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber {

    public class LocalResource : Resource {
        public sealed class AddressRequirement : IStringEnum {
            public const string NONE="none";
            public const string ANY="any";
            public const string LOCAL="local";
            public const string FOREIGN="foreign";
        
            private string value;
            
            public AddressRequirement() { }
            
            public AddressRequirement(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator AddressRequirement(string value) {
                return new AddressRequirement(value);
            }
            
            public static implicit operator string(AddressRequirement value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * read
         * 
         * @param ownerAccountSid The owner_account_sid
         * @return LocalReader capable of executing the read
         */
        public static LocalReader Reader(string ownerAccountSid) {
            return new LocalReader(ownerAccountSid);
        }
    
        /**
         * Create a LocalReader to execute read.
         * 
         * @return LocalReader capable of executing the read
         */
        public static LocalReader Reader() {
            return new LocalReader();
        }
    
        /**
         * create
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param phoneNumber The phone_number
         * @return LocalCreator capable of executing the create
         */
        public static LocalCreator Creator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new LocalCreator(ownerAccountSid, phoneNumber);
        }
    
        /**
         * Create a LocalCreator to execute create.
         * 
         * @param phoneNumber The phone_number
         * @return LocalCreator capable of executing the create
         */
        public static LocalCreator Creator(Twilio.Types.PhoneNumber phoneNumber) {
            return new LocalCreator(phoneNumber);
        }
    
        /**
         * Converts a JSON string into a LocalResource object
         * 
         * @param json Raw JSON string
         * @return LocalResource object represented by the provided JSON
         */
        public static LocalResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<LocalResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly LocalResource.AddressRequirement addressRequirements;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("beta")]
        private readonly bool? beta;
        [JsonProperty("capabilities")]
        private readonly PhoneNumberCapabilities capabilities;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("sms_application_sid")]
        private readonly string smsApplicationSid;
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly Uri smsFallbackUrl;
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("status_callback")]
        private readonly Uri statusCallback;
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        private readonly Twilio.Http.HttpMethod statusCallbackMethod;
        [JsonProperty("uri")]
        private readonly string uri;
        [JsonProperty("voice_application_sid")]
        private readonly string voiceApplicationSid;
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
    
        public LocalResource() {
        
        }
    
        private LocalResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("address_requirements")]
                              LocalResource.AddressRequirement addressRequirements, 
                              [JsonProperty("api_version")]
                              string apiVersion, 
                              [JsonProperty("beta")]
                              bool? beta, 
                              [JsonProperty("capabilities")]
                              PhoneNumberCapabilities capabilities, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("friendly_name")]
                              string friendlyName, 
                              [JsonProperty("phone_number")]
                              Twilio.Types.PhoneNumber phoneNumber, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("sms_application_sid")]
                              string smsApplicationSid, 
                              [JsonProperty("sms_fallback_method")]
                              Twilio.Http.HttpMethod smsFallbackMethod, 
                              [JsonProperty("sms_fallback_url")]
                              Uri smsFallbackUrl, 
                              [JsonProperty("sms_method")]
                              Twilio.Http.HttpMethod smsMethod, 
                              [JsonProperty("sms_url")]
                              Uri smsUrl, 
                              [JsonProperty("status_callback")]
                              Uri statusCallback, 
                              [JsonProperty("status_callback_method")]
                              Twilio.Http.HttpMethod statusCallbackMethod, 
                              [JsonProperty("uri")]
                              string uri, 
                              [JsonProperty("voice_application_sid")]
                              string voiceApplicationSid, 
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
            this.addressRequirements = addressRequirements;
            this.apiVersion = apiVersion;
            this.beta = beta;
            this.capabilities = capabilities;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
            this.sid = sid;
            this.smsApplicationSid = smsApplicationSid;
            this.smsFallbackMethod = smsFallbackMethod;
            this.smsFallbackUrl = smsFallbackUrl;
            this.smsMethod = smsMethod;
            this.smsUrl = smsUrl;
            this.statusCallback = statusCallback;
            this.statusCallbackMethod = statusCallbackMethod;
            this.uri = uri;
            this.voiceApplicationSid = voiceApplicationSid;
            this.voiceCallerIdLookup = voiceCallerIdLookup;
            this.voiceFallbackMethod = voiceFallbackMethod;
            this.voiceFallbackUrl = voiceFallbackUrl;
            this.voiceMethod = voiceMethod;
            this.voiceUrl = voiceUrl;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The address_requirements
         */
        public LocalResource.AddressRequirement GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The beta
         */
        public bool? GetBeta() {
            return this.beta;
        }
    
        /**
         * @return The capabilities
         */
        public PhoneNumberCapabilities GetCapabilities() {
            return this.capabilities;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The phone_number
         */
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The sms_application_sid
         */
        public string GetSmsApplicationSid() {
            return this.smsApplicationSid;
        }
    
        /**
         * @return The sms_fallback_method
         */
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return The sms_fallback_url
         */
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return The sms_method
         */
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return The sms_url
         */
        public Uri GetSmsUrl() {
            return this.smsUrl;
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
        public Twilio.Http.HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    
        /**
         * @return The voice_application_sid
         */
        public string GetVoiceApplicationSid() {
            return this.voiceApplicationSid;
        }
    
        /**
         * @return The voice_caller_id_lookup
         */
        public bool? GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /**
         * @return The voice_fallback_method
         */
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return The voice_fallback_url
         */
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return The voice_method
         */
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return The voice_url
         */
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}