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
            public const string None = "none";
            public const string Any = "any";
            public const string Local = "local";
            public const string Foreign = "foreign";
        
            private string _value;
            
            public AddressRequirement() { }
            
            public AddressRequirement(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator AddressRequirement(string value) {
                return new AddressRequirement(value);
            }
            
            public static implicit operator string(AddressRequirement value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="beta"> The beta </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> TollFreeReader capable of executing the read </returns> 
        public static TollFreeReader Reader(string ownerAccountSid=null, bool? beta=null, string friendlyName=null, Twilio.Types.PhoneNumber phoneNumber=null) {
            return new TollFreeReader(ownerAccountSid:ownerAccountSid, beta:beta, friendlyName:friendlyName, phoneNumber:phoneNumber);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="apiVersion"> The api_version </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="smsApplicationSid"> The sms_application_sid </param>
        /// <param name="smsFallbackMethod"> The sms_fallback_method </param>
        /// <param name="smsFallbackUrl"> The sms_fallback_url </param>
        /// <param name="smsMethod"> The sms_method </param>
        /// <param name="smsUrl"> The sms_url </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <param name="voiceApplicationSid"> The voice_application_sid </param>
        /// <param name="voiceCallerIdLookup"> The voice_caller_id_lookup </param>
        /// <param name="voiceFallbackMethod"> The voice_fallback_method </param>
        /// <param name="voiceFallbackUrl"> The voice_fallback_url </param>
        /// <param name="voiceMethod"> The voice_method </param>
        /// <param name="voiceUrl"> The voice_url </param>
        /// <returns> TollFreeCreator capable of executing the create </returns> 
        public static TollFreeCreator Creator(Twilio.Types.PhoneNumber phoneNumber, string ownerAccountSid=null, string apiVersion=null, string friendlyName=null, string smsApplicationSid=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsUrl=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string voiceApplicationSid=null, bool? voiceCallerIdLookup=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceUrl=null) {
            return new TollFreeCreator(phoneNumber, ownerAccountSid:ownerAccountSid, apiVersion:apiVersion, friendlyName:friendlyName, smsApplicationSid:smsApplicationSid, smsFallbackMethod:smsFallbackMethod, smsFallbackUrl:smsFallbackUrl, smsMethod:smsMethod, smsUrl:smsUrl, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, voiceApplicationSid:voiceApplicationSid, voiceCallerIdLookup:voiceCallerIdLookup, voiceFallbackMethod:voiceFallbackMethod, voiceFallbackUrl:voiceFallbackUrl, voiceMethod:voiceMethod, voiceUrl:voiceUrl);
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
        public string accountSid { get; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TollFreeResource.AddressRequirement addressRequirements { get; }
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
        [JsonProperty("trunk_sid")]
        public string trunkSid { get; }
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