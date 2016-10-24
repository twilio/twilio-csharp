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
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <returns> LocalReader capable of executing the read </returns> 
        public static LocalReader Reader(string ownerAccountSid) {
            return new LocalReader(ownerAccountSid);
        }
    
        /// <summary>
        /// Create a LocalReader to execute read.
        /// </summary>
        ///
        /// <returns> LocalReader capable of executing the read </returns> 
        public static LocalReader Reader() {
            return new LocalReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> LocalCreator capable of executing the create </returns> 
        public static LocalCreator Creator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new LocalCreator(ownerAccountSid, phoneNumber);
        }
    
        /// <summary>
        /// Create a LocalCreator to execute create.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> LocalCreator capable of executing the create </returns> 
        public static LocalCreator Creator(Twilio.Types.PhoneNumber phoneNumber) {
            return new LocalCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a LocalResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> LocalResource object represented by the provided JSON </returns> 
        public static LocalResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<LocalResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LocalResource.AddressRequirement addressRequirements { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("beta")]
        public bool? beta { get; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities capabilities { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("sms_application_sid")]
        public string smsApplicationSid { get; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsFallbackMethod { get; }
        [JsonProperty("sms_fallback_url")]
        public Uri smsFallbackUrl { get; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsMethod { get; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; }
        [JsonProperty("status_callback")]
        public Uri statusCallback { get; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod statusCallbackMethod { get; }
        [JsonProperty("uri")]
        public string uri { get; }
        [JsonProperty("voice_application_sid")]
        public string voiceApplicationSid { get; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? voiceCallerIdLookup { get; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; }
        [JsonProperty("voice_fallback_url")]
        public Uri voiceFallbackUrl { get; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; }
    
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
    }
}