using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class LocalResource : Resource 
    {
        public sealed class LocalAddressRequirement : IStringEnum 
        {
            public const string None = "none";
            public const string Any = "any";
            public const string Local = "local";
            public const string Foreign = "foreign";
        
            private string _value;
            
            public LocalAddressRequirement() {}
            
            public LocalAddressRequirement(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator LocalAddressRequirement(string value)
            {
                return new LocalAddressRequirement(value);
            }
            
            public static implicit operator string(LocalAddressRequirement value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> LocalReader capable of executing the read </returns> 
        public static LocalReader Reader()
        {
            return new LocalReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> LocalCreator capable of executing the create </returns> 
        public static LocalCreator Creator(Twilio.Types.PhoneNumber phoneNumber)
        {
            return new LocalCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a LocalResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> LocalResource object represented by the provided JSON </returns> 
        public static LocalResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<LocalResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LocalResource.LocalAddressRequirement addressRequirements { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("beta")]
        public bool? beta { get; set; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities capabilities { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("sms_application_sid")]
        public string smsApplicationSid { get; set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsFallbackMethod { get; set; }
        [JsonProperty("sms_fallback_url")]
        public Uri smsFallbackUrl { get; set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod smsMethod { get; set; }
        [JsonProperty("sms_url")]
        public Uri smsUrl { get; set; }
        [JsonProperty("status_callback")]
        public Uri statusCallback { get; set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod statusCallbackMethod { get; set; }
        [JsonProperty("trunk_sid")]
        public string trunkSid { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
        [JsonProperty("voice_application_sid")]
        public string voiceApplicationSid { get; set; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? voiceCallerIdLookup { get; set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceFallbackMethod { get; set; }
        [JsonProperty("voice_fallback_url")]
        public Uri voiceFallbackUrl { get; set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod voiceMethod { get; set; }
        [JsonProperty("voice_url")]
        public Uri voiceUrl { get; set; }
    
        public LocalResource()
        {
        
        }
    
        private LocalResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("address_requirements")]
                              LocalResource.LocalAddressRequirement addressRequirements, 
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
                              [JsonProperty("trunk_sid")]
                              string trunkSid, 
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
                              Uri voiceUrl)
                              {
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
            this.trunkSid = trunkSid;
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