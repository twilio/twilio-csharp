using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account.IncomingPhoneNumber;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.IncomingPhoneNumber;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.types.PhoneNumberCapabilities;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Incomingphonenumber {

    public class Mobile : Resource {
        public enum AddressRequirement {
            NONE="none",
            ANY="any",
            LOCAL="local",
            FOREIGN="foreign"
        };
    
        /**
         * read
         * 
         * @param ownerAccountSid The owner_account_sid
         * @return MobileReader capable of executing the read
         */
        public static MobileReader read(String ownerAccountSid) {
            return new MobileReader(ownerAccountSid);
        }
    
        /**
         * create
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param phoneNumber The phone_number
         * @return MobileCreator capable of executing the create
         */
        public static MobileCreator create(String ownerAccountSid, com.twilio.types.PhoneNumber phoneNumber) {
            return new MobileCreator(ownerAccountSid, phoneNumber);
        }
    
        /**
         * Converts a JSON string into a Mobile object
         * 
         * @param json Raw JSON string
         * @return Mobile object represented by the provided JSON
         */
        public static Mobile fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Mobile>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("address_requirements")]
        private readonly Mobile.AddressRequirement addressRequirements;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("beta")]
        private readonly Boolean beta;
        [JsonProperty("capabilities")]
        private readonly PhoneNumberCapabilities capabilities;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
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
        [JsonProperty("uri")]
        private readonly String uri;
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
    
        private Mobile([JsonProperty("account_sid")]
                       String accountSid, 
                       [JsonProperty("address_requirements")]
                       Mobile.AddressRequirement addressRequirements, 
                       [JsonProperty("api_version")]
                       String apiVersion, 
                       [JsonProperty("beta")]
                       Boolean beta, 
                       [JsonProperty("capabilities")]
                       PhoneNumberCapabilities capabilities, 
                       [JsonProperty("date_created")]
                       String dateCreated, 
                       [JsonProperty("date_updated")]
                       String dateUpdated, 
                       [JsonProperty("friendly_name")]
                       String friendlyName, 
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
                       [JsonProperty("uri")]
                       String uri, 
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The address_requirements
         */
        public Mobile.AddressRequirement GetAddressRequirements() {
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
        public PhoneNumberCapabilities GetCapabilities() {
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
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
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