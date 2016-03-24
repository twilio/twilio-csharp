using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Trunking.V1.Trunk;
using Twilio.Deleters.Trunking.V1.Trunk;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1.Trunk;
using Twilio.Http;
using Twilio.Readers.Trunking.V1.Trunk;
using Twilio.Resources;

namespace Twilio.Resources.Trunking.V1.Trunk {

    public class PhoneNumberResource : SidResource {
        public enum AddressRequirement {
            NONE="none",
            ANY="any",
            LOCAL="local",
            FOREIGN="foreign"
        };
    
        /**
         * fetch
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return PhoneNumberFetcher capable of executing the fetch
         */
        public static PhoneNumberFetcher fetch(string trunkSid, string sid) {
            return new PhoneNumberFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return PhoneNumberDeleter capable of executing the delete
         */
        public static PhoneNumberDeleter delete(string trunkSid, string sid) {
            return new PhoneNumberDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param phoneNumberSid The phone_number_sid
         * @return PhoneNumberCreator capable of executing the create
         */
        public static PhoneNumberCreator create(string trunkSid, string phoneNumberSid) {
            return new PhoneNumberCreator(trunkSid, phoneNumberSid);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return PhoneNumberReader capable of executing the read
         */
        public static PhoneNumberReader read(string trunkSid) {
            return new PhoneNumberReader(trunkSid);
        }
    
        /**
         * Converts a JSON string into a PhoneNumberResource object
         * 
         * @param json Raw JSON string
         * @return PhoneNumberResource object represented by the provided JSON
         */
        public static PhoneNumberResource fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("address_requirements")]
        private readonly PhoneNumberResource.AddressRequirement addressRequirements;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("beta")]
        private readonly bool beta;
        [JsonProperty("capabilities")]
        private readonly Dictionary<string, string> capabilities;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
        [JsonProperty("phone_number")]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("sms_application_sid")]
        private readonly string smsApplicationSid;
        [JsonProperty("sms_fallback_method")]
        private readonly HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly Uri smsFallbackUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly Uri smsUrl;
        [JsonProperty("status_callback")]
        private readonly Uri statusCallback;
        [JsonProperty("status_callback_method")]
        private readonly HttpMethod statusCallbackMethod;
        [JsonProperty("trunk_sid")]
        private readonly string trunkSid;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("voice_application_sid")]
        private readonly string voiceApplicationSid;
        [JsonProperty("voice_caller_id_lookup")]
        private readonly bool voiceCallerIdLookup;
        [JsonProperty("voice_fallback_method")]
        private readonly HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly Uri voiceFallbackUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("voice_url")]
        private readonly Uri voiceUrl;
    
        private PhoneNumberResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("address_requirements")]
                                    PhoneNumberResource.AddressRequirement addressRequirements, 
                                    [JsonProperty("api_version")]
                                    string apiVersion, 
                                    [JsonProperty("beta")]
                                    bool beta, 
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
                                    Twilio.Types.PhoneNumber phoneNumber, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("sms_application_sid")]
                                    string smsApplicationSid, 
                                    [JsonProperty("sms_fallback_method")]
                                    HttpMethod smsFallbackMethod, 
                                    [JsonProperty("sms_fallback_url")]
                                    Uri smsFallbackUrl, 
                                    [JsonProperty("sms_method")]
                                    HttpMethod smsMethod, 
                                    [JsonProperty("sms_url")]
                                    Uri smsUrl, 
                                    [JsonProperty("status_callback")]
                                    Uri statusCallback, 
                                    [JsonProperty("status_callback_method")]
                                    HttpMethod statusCallbackMethod, 
                                    [JsonProperty("trunk_sid")]
                                    string trunkSid, 
                                    [JsonProperty("url")]
                                    Uri url, 
                                    [JsonProperty("voice_application_sid")]
                                    string voiceApplicationSid, 
                                    [JsonProperty("voice_caller_id_lookup")]
                                    bool voiceCallerIdLookup, 
                                    [JsonProperty("voice_fallback_method")]
                                    HttpMethod voiceFallbackMethod, 
                                    [JsonProperty("voice_fallback_url")]
                                    Uri voiceFallbackUrl, 
                                    [JsonProperty("voice_method")]
                                    HttpMethod voiceMethod, 
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
            this.links = links;
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
            this.url = url;
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
        public PhoneNumberResource.AddressRequirement GetAddressRequirements() {
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
        public bool GetBeta() {
            return this.beta;
        }
    
        /**
         * @return The capabilities
         */
        public Dictionary<string, string> GetCapabilities() {
            return this.capabilities;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The links
         */
        public Dictionary<string, string> GetLinks() {
            return this.links;
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
        public HttpMethod GetSmsFallbackMethod() {
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
        public HttpMethod GetSmsMethod() {
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
        public HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return The trunk_sid
         */
        public string GetTrunkSid() {
            return this.trunkSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
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
        public bool GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /**
         * @return The voice_fallback_method
         */
        public HttpMethod GetVoiceFallbackMethod() {
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
        public HttpMethod GetVoiceMethod() {
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