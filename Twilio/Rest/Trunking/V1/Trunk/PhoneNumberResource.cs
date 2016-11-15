using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class PhoneNumberResource : Resource 
    {
        public sealed class AddressRequirementEnum : StringEnum 
        {
            private AddressRequirementEnum(string value) : base(value) {}
            public AddressRequirementEnum() {}
        
            public static AddressRequirementEnum None = new AddressRequirementEnum("none");
            public static AddressRequirementEnum Any = new AddressRequirementEnum("any");
            public static AddressRequirementEnum Local = new AddressRequirementEnum("local");
            public static AddressRequirementEnum Foreign = new AddressRequirementEnum("foreign");
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> PhoneNumberFetcher capable of executing the fetch </returns> 
        public static PhoneNumberFetcher Fetcher(string trunkSid, string sid)
        {
            return new PhoneNumberFetcher(trunkSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> PhoneNumberDeleter capable of executing the delete </returns> 
        public static PhoneNumberDeleter Deleter(string trunkSid, string sid)
        {
            return new PhoneNumberDeleter(trunkSid, sid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="phoneNumberSid"> The phone_number_sid </param>
        /// <returns> PhoneNumberCreator capable of executing the create </returns> 
        public static PhoneNumberCreator Creator(string trunkSid, string phoneNumberSid)
        {
            return new PhoneNumberCreator(trunkSid, phoneNumberSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <returns> PhoneNumberReader capable of executing the read </returns> 
        public static PhoneNumberReader Reader(string trunkSid)
        {
            return new PhoneNumberReader(trunkSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a PhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PhoneNumberResource object represented by the provided JSON </returns> 
        public static PhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
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
        public PhoneNumberResource.AddressRequirementEnum AddressRequirements { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("beta")]
        public bool? Beta { get; set; }
        [JsonProperty("capabilities")]
        public Dictionary<string, string> Capabilities { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
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
        [JsonProperty("url")]
        public Uri Url { get; set; }
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
    
        public PhoneNumberResource()
        {
        
        }
    
        private PhoneNumberResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("address_requirements")]
                                    PhoneNumberResource.AddressRequirementEnum addressRequirements, 
                                    [JsonProperty("api_version")]
                                    string apiVersion, 
                                    [JsonProperty("beta")]
                                    bool? beta, 
                                    [JsonProperty("capabilities")]
                                    Dictionary<string, string> capabilities, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("friendly_name")]
                                    string friendlyName, 
                                    [JsonProperty("links")]
                                    Dictionary<string, string> links, 
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
                                    [JsonProperty("url")]
                                    Uri url, 
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
            Links = links;
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
            Url = url;
            VoiceApplicationSid = voiceApplicationSid;
            VoiceCallerIdLookup = voiceCallerIdLookup;
            VoiceFallbackMethod = voiceFallbackMethod;
            VoiceFallbackUrl = voiceFallbackUrl;
            VoiceMethod = voiceMethod;
            VoiceUrl = voiceUrl;
        }
    }
}