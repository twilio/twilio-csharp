using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class IncomingPhoneNumberResource : Resource 
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
        /// Update an incoming-phone-number instance
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> IncomingPhoneNumberUpdater capable of executing the update </returns> 
        public static IncomingPhoneNumberUpdater Updater(string sid)
        {
            return new IncomingPhoneNumberUpdater(sid);
        }
    
        /// <summary>
        /// Fetch an incoming-phone-number belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique incoming-phone-number Sid </param>
        /// <returns> IncomingPhoneNumberFetcher capable of executing the fetch </returns> 
        public static IncomingPhoneNumberFetcher Fetcher(string sid)
        {
            return new IncomingPhoneNumberFetcher(sid);
        }
    
        /// <summary>
        /// Delete a phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique phone-number Sid </param>
        /// <returns> IncomingPhoneNumberDeleter capable of executing the delete </returns> 
        public static IncomingPhoneNumberDeleter Deleter(string sid)
        {
            return new IncomingPhoneNumberDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> IncomingPhoneNumberReader capable of executing the read </returns> 
        public static IncomingPhoneNumberReader Reader()
        {
            return new IncomingPhoneNumberReader();
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(Types.PhoneNumber phoneNumber)
        {
            return new IncomingPhoneNumberCreator(phoneNumber);
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="areaCode"> The desired area code for the new number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(string areaCode)
        {
            return new IncomingPhoneNumberCreator(areaCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a IncomingPhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IncomingPhoneNumberResource object represented by the provided JSON </returns> 
        public static IncomingPhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IncomingPhoneNumberResource>(json);
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
        public IncomingPhoneNumberResource.AddressRequirementEnum AddressRequirements { get; set; }
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
    
        public IncomingPhoneNumberResource()
        {
        
        }
    
        private IncomingPhoneNumberResource([JsonProperty("account_sid")]
                                            string accountSid, 
                                            [JsonProperty("address_requirements")]
                                            IncomingPhoneNumberResource.AddressRequirementEnum addressRequirements, 
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