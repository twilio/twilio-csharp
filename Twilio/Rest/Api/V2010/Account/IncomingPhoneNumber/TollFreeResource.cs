using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber {

    public class TollFreeResource : Resource {
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
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader(string ownerAccountSid) {
            return new TollFreeReader(ownerAccountSid);
        }
    
        /// <summary>
        /// Create a TollFreeReader to execute read.
        /// </summary>
        ///
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader() {
            return new TollFreeReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> TollFreeCreator capable of executing the create </returns> 
        public static TollFreeCreator Creator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new TollFreeCreator(ownerAccountSid, phoneNumber);
        }
    
        /// <summary>
        /// Create a TollFreeCreator to execute create.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> TollFreeCreator capable of executing the create </returns> 
        public static TollFreeCreator Creator(Twilio.Types.PhoneNumber phoneNumber) {
            return new TollFreeCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a TollFreeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TollFreeResource object represented by the provided JSON </returns> 
        public static TollFreeResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TollFreeResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TollFreeResource.AddressRequirement addressRequirements;
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
    
        public TollFreeResource() {
        
        }
    
        private TollFreeResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("address_requirements")]
                                 TollFreeResource.AddressRequirement addressRequirements, 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The address_requirements </returns> 
        public TollFreeResource.AddressRequirement GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The beta </returns> 
        public bool? GetBeta() {
            return this.beta;
        }
    
        /// <returns> The capabilities </returns> 
        public PhoneNumberCapabilities GetCapabilities() {
            return this.capabilities;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The phone_number </returns> 
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /// <returns> The sid </returns> 
        public string GetSid() {
            return this.sid;
        }
    
        /// <returns> The sms_application_sid </returns> 
        public string GetSmsApplicationSid() {
            return this.smsApplicationSid;
        }
    
        /// <returns> The sms_fallback_method </returns> 
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /// <returns> The sms_fallback_url </returns> 
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /// <returns> The sms_method </returns> 
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /// <returns> The sms_url </returns> 
        public Uri GetSmsUrl() {
            return this.smsUrl;
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
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> The voice_application_sid </returns> 
        public string GetVoiceApplicationSid() {
            return this.voiceApplicationSid;
        }
    
        /// <returns> The voice_caller_id_lookup </returns> 
        public bool? GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /// <returns> The voice_fallback_method </returns> 
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /// <returns> The voice_fallback_url </returns> 
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /// <returns> The voice_method </returns> 
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /// <returns> The voice_url </returns> 
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}