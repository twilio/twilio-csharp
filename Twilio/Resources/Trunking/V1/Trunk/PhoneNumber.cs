using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Trunking.V1.Trunk;
using Twilio.Deleters.Trunking.V1.Trunk;
using Twilio.Exceptions;
using Twilio.Fetchers.Trunking.V1.Trunk;
using Twilio.Http;
using Twilio.Readers.Trunking.V1.Trunk;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Trunking.V1.Trunk {

    public class PhoneNumber : SidResource {
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
        public static PhoneNumberFetcher fetch(String trunkSid, String sid) {
            return new PhoneNumberFetcher(trunkSid, sid);
        }
    
        /**
         * delete
         * 
         * @param trunkSid The trunk_sid
         * @param sid The sid
         * @return PhoneNumberDeleter capable of executing the delete
         */
        public static PhoneNumberDeleter delete(String trunkSid, String sid) {
            return new PhoneNumberDeleter(trunkSid, sid);
        }
    
        /**
         * create
         * 
         * @param trunkSid The trunk_sid
         * @param phoneNumberSid The phone_number_sid
         * @return PhoneNumberCreator capable of executing the create
         */
        public static PhoneNumberCreator create(String trunkSid, String phoneNumberSid) {
            return new PhoneNumberCreator(trunkSid, phoneNumberSid);
        }
    
        /**
         * read
         * 
         * @param trunkSid The trunk_sid
         * @return PhoneNumberReader capable of executing the read
         */
        public static PhoneNumberReader read(String trunkSid) {
            return new PhoneNumberReader(trunkSid);
        }
    
        /**
         * Converts a JSON string into a PhoneNumber object
         * 
         * @param json Raw JSON string
         * @return PhoneNumber object represented by the provided JSON
         */
        public static PhoneNumber fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<PhoneNumber>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("address_requirements")]
        private readonly PhoneNumber.AddressRequirement addressRequirements;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("beta")]
        private readonly Boolean beta;
        [JsonProperty("capabilities")]
        private readonly Map<String, String> capabilities;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("links")]
        private readonly Map<String, String> links;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("sms_application_sid")]
        private readonly String smsApplicationSid;
        [JsonProperty("sms_fallback_method")]
        private readonly HttpMethod smsFallbackMethod;
        [JsonProperty("sms_fallback_url")]
        private readonly URI smsFallbackUrl;
        [JsonProperty("sms_method")]
        private readonly HttpMethod smsMethod;
        [JsonProperty("sms_url")]
        private readonly URI smsUrl;
        [JsonProperty("status_callback")]
        private readonly URI statusCallback;
        [JsonProperty("status_callback_method")]
        private readonly HttpMethod statusCallbackMethod;
        [JsonProperty("trunk_sid")]
        private readonly String trunkSid;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("voice_application_sid")]
        private readonly String voiceApplicationSid;
        [JsonProperty("voice_caller_id_lookup")]
        private readonly Boolean voiceCallerIdLookup;
        [JsonProperty("voice_fallback_method")]
        private readonly HttpMethod voiceFallbackMethod;
        [JsonProperty("voice_fallback_url")]
        private readonly URI voiceFallbackUrl;
        [JsonProperty("voice_method")]
        private readonly HttpMethod voiceMethod;
        [JsonProperty("voice_url")]
        private readonly URI voiceUrl;
    
        private PhoneNumber([JsonProperty("account_sid")]
                            String accountSid, 
                            [JsonProperty("address_requirements")]
                            PhoneNumber.AddressRequirement addressRequirements, 
                            [JsonProperty("api_version")]
                            String apiVersion, 
                            [JsonProperty("beta")]
                            Boolean beta, 
                            [JsonProperty("capabilities")]
                            Map<String, String> capabilities, 
                            [JsonProperty("date_created")]
                            String dateCreated, 
                            [JsonProperty("date_updated")]
                            String dateUpdated, 
                            [JsonProperty("friendly_name")]
                            String friendlyName, 
                            [JsonProperty("links")]
                            Map<String, String> links, 
                            [JsonProperty("phone_number")]
                            com.twilio.types.PhoneNumber phoneNumber, 
                            [JsonProperty("sid")]
                            String sid, 
                            [JsonProperty("sms_application_sid")]
                            String smsApplicationSid, 
                            [JsonProperty("sms_fallback_method")]
                            HttpMethod smsFallbackMethod, 
                            [JsonProperty("sms_fallback_url")]
                            URI smsFallbackUrl, 
                            [JsonProperty("sms_method")]
                            HttpMethod smsMethod, 
                            [JsonProperty("sms_url")]
                            URI smsUrl, 
                            [JsonProperty("status_callback")]
                            URI statusCallback, 
                            [JsonProperty("status_callback_method")]
                            HttpMethod statusCallbackMethod, 
                            [JsonProperty("trunk_sid")]
                            String trunkSid, 
                            [JsonProperty("url")]
                            URI url, 
                            [JsonProperty("voice_application_sid")]
                            String voiceApplicationSid, 
                            [JsonProperty("voice_caller_id_lookup")]
                            Boolean voiceCallerIdLookup, 
                            [JsonProperty("voice_fallback_method")]
                            HttpMethod voiceFallbackMethod, 
                            [JsonProperty("voice_fallback_url")]
                            URI voiceFallbackUrl, 
                            [JsonProperty("voice_method")]
                            HttpMethod voiceMethod, 
                            [JsonProperty("voice_url")]
                            URI voiceUrl) {
            this.accountSid = accountSid;
            this.addressRequirements = addressRequirements;
            this.apiVersion = apiVersion;
            this.beta = beta;
            this.capabilities = capabilities;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The address_requirements
         */
        public PhoneNumber.AddressRequirement GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The beta
         */
        public Boolean GetBeta() {
            return this.beta;
        }
    
        /**
         * @return The capabilities
         */
        public Map<String, String> GetCapabilities() {
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
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The links
         */
        public Map<String, String> GetLinks() {
            return this.links;
        }
    
        /**
         * @return The phone_number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The sms_application_sid
         */
        public String GetSmsApplicationSid() {
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
        public URI GetSmsFallbackUrl() {
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
        public URI GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return The status_callback
         */
        public URI GetStatusCallback() {
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
        public String GetTrunkSid() {
            return this.trunkSid;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    
        /**
         * @return The voice_application_sid
         */
        public String GetVoiceApplicationSid() {
            return this.voiceApplicationSid;
        }
    
        /**
         * @return The voice_caller_id_lookup
         */
        public Boolean GetVoiceCallerIdLookup() {
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
        public URI GetVoiceFallbackUrl() {
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
        public URI GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}