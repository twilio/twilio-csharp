using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber 
{

    public class TollFreeResource : Resource 
    {
        public sealed class AddressRequirementEnum : StringEnum 
        {
            private AddressRequirementEnum(string value) : base(value) {}
            public AddressRequirementEnum() {}
        
            public static readonly AddressRequirementEnum None = new AddressRequirementEnum("none");
            public static readonly AddressRequirementEnum Any = new AddressRequirementEnum("any");
            public static readonly AddressRequirementEnum Local = new AddressRequirementEnum("local");
            public static readonly AddressRequirementEnum Foreign = new AddressRequirementEnum("foreign");
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader()
        {
            return new TollFreeReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> TollFreeCreator capable of executing the create </returns> 
        public static TollFreeCreator Creator(Types.PhoneNumber phoneNumber)
        {
            return new TollFreeCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a TollFreeResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TollFreeResource object represented by the provided JSON </returns> 
        public static TollFreeResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TollFreeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TollFreeResource.AddressRequirementEnum AddressRequirements { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("beta")]
        public bool? Beta { get; set; }
        [JsonProperty("capabilities")]
        public PhoneNumberCapabilities Capabilities { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("sms_application_sid")]
        public string SmsApplicationSid { get; set; }
        [JsonProperty("sms_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; set; }
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; set; }
        [JsonProperty("sms_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod SmsMethod { get; set; }
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; set; }
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; set; }
        [JsonProperty("status_callback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("voice_application_sid")]
        public string VoiceApplicationSid { get; set; }
        [JsonProperty("voice_caller_id_lookup")]
        public bool? VoiceCallerIdLookup { get; set; }
        [JsonProperty("voice_fallback_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; set; }
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; set; }
        [JsonProperty("voice_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod VoiceMethod { get; set; }
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; set; }
    
        public TollFreeResource()
        {
        
        }
    
        private TollFreeResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("address_requirements")]
                                 TollFreeResource.AddressRequirementEnum addressRequirements, 
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
                                 Types.PhoneNumber phoneNumber, 
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
            AccountSid = accountSid;
            AddressRequirements = addressRequirements;
            ApiVersion = apiVersion;
            Beta = beta;
            Capabilities = capabilities;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            PhoneNumber = phoneNumber;
            Sid = sid;
            SmsApplicationSid = smsApplicationSid;
            SmsFallbackMethod = smsFallbackMethod;
            SmsFallbackUrl = smsFallbackUrl;
            SmsMethod = smsMethod;
            SmsUrl = smsUrl;
            StatusCallback = statusCallback;
            StatusCallbackMethod = statusCallbackMethod;
            TrunkSid = trunkSid;
            Uri = uri;
            VoiceApplicationSid = voiceApplicationSid;
            VoiceCallerIdLookup = voiceCallerIdLookup;
            VoiceFallbackMethod = voiceFallbackMethod;
            VoiceFallbackUrl = voiceFallbackUrl;
            VoiceMethod = voiceMethod;
            VoiceUrl = voiceUrl;
        }
    }
}