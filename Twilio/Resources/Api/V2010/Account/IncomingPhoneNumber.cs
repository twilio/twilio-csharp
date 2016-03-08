using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.types.PhoneNumberCapabilities;
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class IncomingPhoneNumber : SidResource {
        public enum AddressRequirement {
            NONE="none",
            ANY="any",
            LOCAL="local",
            FOREIGN="foreign"
        };
    
        /**
         * Update an incoming-phone-number instance
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid The sid
         * @return IncomingPhoneNumberUpdater capable of executing the update
         */
        public static IncomingPhoneNumberUpdater update(String ownerAccountSid, String sid) {
            return new IncomingPhoneNumberUpdater(ownerAccountSid, sid);
        }
    
        /**
         * Fetch an incoming-phone-number belonging to the account used to make the
         * request
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid Fetch by unique incoming-phone-number Sid
         * @return IncomingPhoneNumberFetcher capable of executing the fetch
         */
        public static IncomingPhoneNumberFetcher fetch(String ownerAccountSid, String sid) {
            return new IncomingPhoneNumberFetcher(ownerAccountSid, sid);
        }
    
        /**
         * Delete a phone-numbers belonging to the account used to make the request
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param sid Delete by unique phone-number Sid
         * @return IncomingPhoneNumberDeleter capable of executing the delete
         */
        public static IncomingPhoneNumberDeleter delete(String ownerAccountSid, String sid) {
            return new IncomingPhoneNumberDeleter(ownerAccountSid, sid);
        }
    
        /**
         * Retrieve a list of incoming-phone-numbers belonging to the account used to
         * make the request
         * 
         * @param ownerAccountSid The owner_account_sid
         * @return IncomingPhoneNumberReader capable of executing the read
         */
        public static IncomingPhoneNumberReader read(String ownerAccountSid) {
            return new IncomingPhoneNumberReader(ownerAccountSid);
        }
    
        /**
         * Purchase a phone-number for the account
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param phoneNumber The phone number
         * @return IncomingPhoneNumberCreator capable of executing the create
         */
        public static IncomingPhoneNumberCreator create(String ownerAccountSid, com.twilio.types.PhoneNumber phoneNumber) {
            return new IncomingPhoneNumberCreator(ownerAccountSid, phoneNumber);
        }
    
        /**
         * Purchase a phone-number for the account
         * 
         * @param ownerAccountSid The owner_account_sid
         * @param areaCode The desired area code for the new number
         * @return IncomingPhoneNumberCreator capable of executing the create
         */
        public static IncomingPhoneNumberCreator create(String ownerAccountSid, String areaCode) {
            return new IncomingPhoneNumberCreator(ownerAccountSid, areaCode);
        }
    
        /**
         * Converts a JSON string into a IncomingPhoneNumber object
         * 
         * @param json Raw JSON string
         * @return IncomingPhoneNumber object represented by the provided JSON
         */
        public static IncomingPhoneNumber fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IncomingPhoneNumber>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("address_requirements")]
        private readonly IncomingPhoneNumber.AddressRequirement addressRequirements;
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
    
        private IncomingPhoneNumber([JsonProperty("account_sid")]
                                    String accountSid, 
                                    [JsonProperty("address_requirements")]
                                    IncomingPhoneNumber.AddressRequirement addressRequirements, 
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
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return Indicates if the customer requires an address
         */
        public IncomingPhoneNumber.AddressRequirement GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /**
         * @return The Twilio REST API version to use
         */
        public String GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return Indicates if the phone number is a beta number
         */
        public Boolean GetBeta() {
            return this.beta;
        }
    
        /**
         * @return Indicate if a phone can receive calls or messages
         */
        public PhoneNumberCapabilities GetCapabilities() {
            return this.capabilities;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return A human readable description of this resouce
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The incoming phone number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return A string that uniquely identifies this resource
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return Unique string that identifies the application
         */
        public String GetSmsApplicationSid() {
            return this.smsApplicationSid;
        }
    
        /**
         * @return HTTP method used with sms fallback url
         */
        public HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request if an error occurs in executing TwiML
         */
        public URI GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /**
         * @return HTTP method to use with sms url
         */
        public HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /**
         * @return URL Twilio will request when receiving an SMS
         */
        public URI GetSmsUrl() {
            return this.smsUrl;
        }
    
        /**
         * @return URL Twilio will use to pass status parameters
         */
        public URI GetStatusCallback() {
            return this.statusCallback;
        }
    
        /**
         * @return HTTP method twilio will use with status callback
         */
        public HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    
        /**
         * @return The unique sid of the application to handle this number
         */
        public String GetVoiceApplicationSid() {
            return this.voiceApplicationSid;
        }
    
        /**
         * @return Look up the caller's caller-ID
         */
        public Boolean GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /**
         * @return HTTP method used with fallback_url
         */
        public HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /**
         * @return URL Twilio will request when an error occurs in TwiML
         */
        public URI GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /**
         * @return HTTP method used with the voice url
         */
        public HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /**
         * @return URL Twilio will request when receiving a call
         */
        public URI GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}