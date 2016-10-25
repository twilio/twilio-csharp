using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class IncomingPhoneNumberResource : Resource 
    {
        public sealed class AddressRequirement : IStringEnum 
        {
            public const string None = "none";
            public const string Any = "any";
            public const string Local = "local";
            public const string Foreign = "foreign";
        
            private string _value;
            
            public AddressRequirement() {}
            
            public AddressRequirement(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator AddressRequirement(string value)
            {
                return new AddressRequirement(value);
            }
            
            public static implicit operator string(AddressRequirement value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Update an incoming-phone-number instance
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="accountSid"> The new owner of the phone number </param>
        /// <param name="apiVersion"> The Twilio REST API version to use </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="smsApplicationSid"> Unique string that identifies the application </param>
        /// <param name="smsFallbackMethod"> HTTP method used with sms fallback url </param>
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="smsMethod"> HTTP method to use with sms url </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="statusCallback"> URL Twilio will use to pass status parameters </param>
        /// <param name="statusCallbackMethod"> HTTP method twilio will use with status callback </param>
        /// <param name="trunkSid"> Unique string to identify the trunk </param>
        /// <param name="voiceApplicationSid"> The unique sid of the application to handle this number </param>
        /// <param name="voiceCallerIdLookup"> Look up the caller's caller-ID </param>
        /// <param name="voiceFallbackMethod"> HTTP method used with fallback_url </param>
        /// <param name="voiceFallbackUrl"> URL Twilio will request when an error occurs in TwiML </param>
        /// <param name="voiceMethod"> HTTP method used with the voice url </param>
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> IncomingPhoneNumberUpdater capable of executing the update </returns> 
        public static IncomingPhoneNumberUpdater Updater(string sid, string ownerAccountSid=null, string accountSid=null, string apiVersion=null, string friendlyName=null, string smsApplicationSid=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsUrl=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string trunkSid=null, string voiceApplicationSid=null, bool? voiceCallerIdLookup=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceUrl=null)
        {
            return new IncomingPhoneNumberUpdater(sid, ownerAccountSid:ownerAccountSid, accountSid:accountSid, apiVersion:apiVersion, friendlyName:friendlyName, smsApplicationSid:smsApplicationSid, smsFallbackMethod:smsFallbackMethod, smsFallbackUrl:smsFallbackUrl, smsMethod:smsMethod, smsUrl:smsUrl, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, trunkSid:trunkSid, voiceApplicationSid:voiceApplicationSid, voiceCallerIdLookup:voiceCallerIdLookup, voiceFallbackMethod:voiceFallbackMethod, voiceFallbackUrl:voiceFallbackUrl, voiceMethod:voiceMethod, voiceUrl:voiceUrl);
        }
    
        /// <summary>
        /// Fetch an incoming-phone-number belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique incoming-phone-number Sid </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <returns> IncomingPhoneNumberFetcher capable of executing the fetch </returns> 
        public static IncomingPhoneNumberFetcher Fetcher(string sid, string ownerAccountSid=null)
        {
            return new IncomingPhoneNumberFetcher(sid, ownerAccountSid:ownerAccountSid);
        }
    
        /// <summary>
        /// Delete a phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique phone-number Sid </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <returns> IncomingPhoneNumberDeleter capable of executing the delete </returns> 
        public static IncomingPhoneNumberDeleter Deleter(string sid, string ownerAccountSid=null)
        {
            return new IncomingPhoneNumberDeleter(sid, ownerAccountSid:ownerAccountSid);
        }
    
        /// <summary>
        /// Retrieve a list of incoming-phone-numbers belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="beta"> Include new phone numbers </param>
        /// <param name="friendlyName"> Filter by friendly name </param>
        /// <param name="phoneNumber"> Filter by incoming phone number </param>
        /// <returns> IncomingPhoneNumberReader capable of executing the read </returns> 
        public static IncomingPhoneNumberReader Reader(string ownerAccountSid=null, bool? beta=null, string friendlyName=null, Twilio.Types.PhoneNumber phoneNumber=null)
        {
            return new IncomingPhoneNumberReader(ownerAccountSid:ownerAccountSid, beta:beta, friendlyName:friendlyName, phoneNumber:phoneNumber);
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone number </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="areaCode"> The desired area code for the new number </param>
        /// <param name="apiVersion"> The Twilio Rest API version to use </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="smsApplicationSid"> Unique string that identifies the application </param>
        /// <param name="smsFallbackMethod"> HTTP method used with sms fallback url </param>
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="smsMethod"> HTTP method to use with sms url </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="statusCallback"> URL Twilio will use to pass status parameters </param>
        /// <param name="statusCallbackMethod"> HTTP method twilio will use with status callback </param>
        /// <param name="trunkSid"> Unique string to identify the trunk </param>
        /// <param name="voiceApplicationSid"> The unique sid of the application to handle this number </param>
        /// <param name="voiceCallerIdLookup"> Look up the caller's caller-ID </param>
        /// <param name="voiceFallbackMethod"> HTTP method used with fallback_url </param>
        /// <param name="voiceFallbackUrl"> URL Twilio will request when an error occurs in TwiML </param>
        /// <param name="voiceMethod"> HTTP method used with the voice url </param>
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(Twilio.Types.PhoneNumber phoneNumber, string ownerAccountSid=null, string areaCode=null, string apiVersion=null, string friendlyName=null, string smsApplicationSid=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsUrl=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string trunkSid=null, string voiceApplicationSid=null, bool? voiceCallerIdLookup=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceUrl=null)
        {
            return new IncomingPhoneNumberCreator(phoneNumber, ownerAccountSid:ownerAccountSid, areaCode:areaCode, apiVersion:apiVersion, friendlyName:friendlyName, smsApplicationSid:smsApplicationSid, smsFallbackMethod:smsFallbackMethod, smsFallbackUrl:smsFallbackUrl, smsMethod:smsMethod, smsUrl:smsUrl, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, trunkSid:trunkSid, voiceApplicationSid:voiceApplicationSid, voiceCallerIdLookup:voiceCallerIdLookup, voiceFallbackMethod:voiceFallbackMethod, voiceFallbackUrl:voiceFallbackUrl, voiceMethod:voiceMethod, voiceUrl:voiceUrl);
        }
    
        /// <summary>
        /// Purchase a phone-number for the account
        /// </summary>
        ///
        /// <param name="areaCode"> The desired area code for the new number </param>
        /// <param name="ownerAccountSid"> The owner_account_sid </param>
        /// <param name="phoneNumber"> The phone number </param>
        /// <param name="apiVersion"> The Twilio Rest API version to use </param>
        /// <param name="friendlyName"> A human readable description of this resource </param>
        /// <param name="smsApplicationSid"> Unique string that identifies the application </param>
        /// <param name="smsFallbackMethod"> HTTP method used with sms fallback url </param>
        /// <param name="smsFallbackUrl"> URL Twilio will request if an error occurs in executing TwiML </param>
        /// <param name="smsMethod"> HTTP method to use with sms url </param>
        /// <param name="smsUrl"> URL Twilio will request when receiving an SMS </param>
        /// <param name="statusCallback"> URL Twilio will use to pass status parameters </param>
        /// <param name="statusCallbackMethod"> HTTP method twilio will use with status callback </param>
        /// <param name="trunkSid"> Unique string to identify the trunk </param>
        /// <param name="voiceApplicationSid"> The unique sid of the application to handle this number </param>
        /// <param name="voiceCallerIdLookup"> Look up the caller's caller-ID </param>
        /// <param name="voiceFallbackMethod"> HTTP method used with fallback_url </param>
        /// <param name="voiceFallbackUrl"> URL Twilio will request when an error occurs in TwiML </param>
        /// <param name="voiceMethod"> HTTP method used with the voice url </param>
        /// <param name="voiceUrl"> URL Twilio will request when receiving a call </param>
        /// <returns> IncomingPhoneNumberCreator capable of executing the create </returns> 
        public static IncomingPhoneNumberCreator Creator(string areaCode, string ownerAccountSid=null, Twilio.Types.PhoneNumber phoneNumber=null, string apiVersion=null, string friendlyName=null, string smsApplicationSid=null, Twilio.Http.HttpMethod smsFallbackMethod=null, Uri smsFallbackUrl=null, Twilio.Http.HttpMethod smsMethod=null, Uri smsUrl=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null, string trunkSid=null, string voiceApplicationSid=null, bool? voiceCallerIdLookup=null, Twilio.Http.HttpMethod voiceFallbackMethod=null, Uri voiceFallbackUrl=null, Twilio.Http.HttpMethod voiceMethod=null, Uri voiceUrl=null)
        {
            return new IncomingPhoneNumberCreator(areaCode, ownerAccountSid:ownerAccountSid, phoneNumber:phoneNumber, apiVersion:apiVersion, friendlyName:friendlyName, smsApplicationSid:smsApplicationSid, smsFallbackMethod:smsFallbackMethod, smsFallbackUrl:smsFallbackUrl, smsMethod:smsMethod, smsUrl:smsUrl, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod, trunkSid:trunkSid, voiceApplicationSid:voiceApplicationSid, voiceCallerIdLookup:voiceCallerIdLookup, voiceFallbackMethod:voiceFallbackMethod, voiceFallbackUrl:voiceFallbackUrl, voiceMethod:voiceMethod, voiceUrl:voiceUrl);
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
        public string accountSid { get; }
        [JsonProperty("address_requirements")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IncomingPhoneNumberResource.AddressRequirement addressRequirements { get; }
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
    
        public IncomingPhoneNumberResource()
        {
        
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