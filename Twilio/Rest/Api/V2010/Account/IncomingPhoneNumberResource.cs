using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account {

    public class IncomingPhoneNumberResource : SidResource {
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
        /// Update an incoming-phone-number instance
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> IncomingPhoneNumberUpdater capable of executing the update </returns> 
        public static IncomingPhoneNumberUpdater Updater(string ownerAccountSid, string sid) {
            return new IncomingPhoneNumberUpdater(ownerAccountSid, sid);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberUpdater to execute update.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> IncomingPhoneNumberUpdater capable of executing the update </returns> 
        public static IncomingPhoneNumberUpdater Updater(string sid) {
            return new IncomingPhoneNumberUpdater(sid);
        }
    
        /// <summary>
        /// Fetch an incoming-phone-number belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="sid"> Fetch by unique incoming-phone-number Sid </param>
        /// <returns> IncomingPhoneNumberFetcher capable of executing the fetch </returns> 
        public static IncomingPhoneNumberFetcher Fetcher(string ownerAccountSid, string sid) {
            return new IncomingPhoneNumberFetcher(ownerAccountSid, sid);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique incoming-phone-number Sid </param>
        /// <returns> IncomingPhoneNumberFetcher capable of executing the fetch </returns> 
        public static IncomingPhoneNumberFetcher Fetcher(string sid) {
            return new IncomingPhoneNumberFetcher(sid);
        }
    
        /// <summary>
        /// Delete a phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="sid"> Delete by unique phone-number Sid </param>
        /// <returns> IncomingPhoneNumberDeleter capable of executing the delete </returns> 
        public static IncomingPhoneNumberDeleter Deleter(string ownerAccountSid, string sid) {
            return new IncomingPhoneNumberDeleter(ownerAccountSid, sid);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique phone-number Sid </param>
        /// <returns> IncomingPhoneNumberDeleter capable of executing the delete </returns> 
        public static IncomingPhoneNumberDeleter Deleter(string sid) {
            return new IncomingPhoneNumberDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <returns> IncomingPhoneNumberReader capable of executing the read </returns> 
        public static IncomingPhoneNumberReader Reader(string ownerAccountSid) {
            return new IncomingPhoneNumberReader(ownerAccountSid);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberReader to execute read.
        /// </summary>
        ///
        /// <returns> IncomingPhoneNumberReader capable of executing the read </returns> 
        public static IncomingPhoneNumberReader Reader() {
            return new IncomingPhoneNumberReader();
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="phoneNumber"> The phone number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(string ownerAccountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new IncomingPhoneNumberCreator(ownerAccountSid, phoneNumber);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberCreator to execute create.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(Twilio.Types.PhoneNumber phoneNumber) {
            return new IncomingPhoneNumberCreator(phoneNumber);
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="areaCode"> The desired area code for the new number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(string ownerAccountSid, string areaCode) {
            return new IncomingPhoneNumberCreator(ownerAccountSid, areaCode);
        }
    
        /// <summary>
        /// Create a IncomingPhoneNumberCreator to execute create.
        /// </summary>
        ///
        /// <param name="areaCode"> The desired area code for the new number </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(string areaCode) {
            return new IncomingPhoneNumberCreator(areaCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a IncomingPhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IncomingPhoneNumberResource object represented by the provided JSON </returns> 
        public static IncomingPhoneNumberResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<IncomingPhoneNumberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly IncomingPhoneNumberResource.AddressRequirement addressRequirements;
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
        [JsonProperty("trunk_sid")]
        private readonly string trunkSid;
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
    
        public IncomingPhoneNumberResource() {
        
        }
    
        private IncomingPhoneNumberResource([JsonProperty("account_sid")]
                                            string accountSid, 
                                            [JsonProperty("address_requirements")]
                                            IncomingPhoneNumberResource.AddressRequirement addressRequirements, 
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> Indicates if the customer requires an address </returns> 
        public IncomingPhoneNumberResource.AddressRequirement GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /// <returns> The Twilio REST API version to use </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> Indicates if the phone number is a beta number </returns> 
        public bool? GetBeta() {
            return this.beta;
        }
    
        /// <returns> Indicate if a phone can receive calls or messages </returns> 
        public PhoneNumberCapabilities GetCapabilities() {
            return this.capabilities;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> A human readable description of this resouce </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The incoming phone number </returns> 
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /// <returns> A string that uniquely identifies this resource </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> Unique string that identifies the application </returns> 
        public string GetSmsApplicationSid() {
            return this.smsApplicationSid;
        }
    
        /// <returns> HTTP method used with sms fallback url </returns> 
        public Twilio.Http.HttpMethod GetSmsFallbackMethod() {
            return this.smsFallbackMethod;
        }
    
        /// <returns> URL Twilio will request if an error occurs in executing TwiML </returns> 
        public Uri GetSmsFallbackUrl() {
            return this.smsFallbackUrl;
        }
    
        /// <returns> HTTP method to use with sms url </returns> 
        public Twilio.Http.HttpMethod GetSmsMethod() {
            return this.smsMethod;
        }
    
        /// <returns> URL Twilio will request when receiving an SMS </returns> 
        public Uri GetSmsUrl() {
            return this.smsUrl;
        }
    
        /// <returns> URL Twilio will use to pass status parameters </returns> 
        public Uri GetStatusCallback() {
            return this.statusCallback;
        }
    
        /// <returns> HTTP method twilio will use with status callback </returns> 
        public Twilio.Http.HttpMethod GetStatusCallbackMethod() {
            return this.statusCallbackMethod;
        }
    
        /// <returns> Unique string to identify the trunk </returns> 
        public string GetTrunkSid() {
            return this.trunkSid;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    
        /// <returns> The unique sid of the application to handle this number </returns> 
        public string GetVoiceApplicationSid() {
            return this.voiceApplicationSid;
        }
    
        /// <returns> Look up the caller's caller-ID </returns> 
        public bool? GetVoiceCallerIdLookup() {
            return this.voiceCallerIdLookup;
        }
    
        /// <returns> HTTP method used with fallback_url </returns> 
        public Twilio.Http.HttpMethod GetVoiceFallbackMethod() {
            return this.voiceFallbackMethod;
        }
    
        /// <returns> URL Twilio will request when an error occurs in TwiML </returns> 
        public Uri GetVoiceFallbackUrl() {
            return this.voiceFallbackUrl;
        }
    
        /// <returns> HTTP method used with the voice url </returns> 
        public Twilio.Http.HttpMethod GetVoiceMethod() {
            return this.voiceMethod;
        }
    
        /// <returns> URL Twilio will request when receiving a call </returns> 
        public Uri GetVoiceUrl() {
            return this.voiceUrl;
        }
    }
}