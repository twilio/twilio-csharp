using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Lookups.V1 {

    public class PhoneNumberResource : SidResource {
        public sealed class Type : IStringEnum {
            public const string LANDLINE="landline";
            public const string MOBILE="mobile";
            public const string VOIP="voip";
        
            private string value;
            
            public Type() { }
            
            public Type(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Type(string value) {
                return new Type(value);
            }
            
            public static implicit operator string(Type value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> PhoneNumberFetcher capable of executing the fetch </returns> 
        public static PhoneNumberFetcher Fetcher(Twilio.Types.PhoneNumber phoneNumber) {
            return new PhoneNumberFetcher(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a PhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PhoneNumberResource object represented by the provided JSON </returns> 
        public static PhoneNumberResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("caller_name")]
        private readonly Dictionary<string, string> callerName;
        [JsonProperty("country_code")]
        private readonly string countryCode;
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("national_format")]
        private readonly string nationalFormat;
        [JsonProperty("carrier")]
        private readonly Dictionary<string, string> carrier;
        [JsonProperty("add_ons")]
        private readonly Object addOns;
    
        public PhoneNumberResource() {
        
        }
    
        private PhoneNumberResource([JsonProperty("caller_name")]
                                    Dictionary<string, string> callerName, 
                                    [JsonProperty("country_code")]
                                    string countryCode, 
                                    [JsonProperty("phone_number")]
                                    Twilio.Types.PhoneNumber phoneNumber, 
                                    [JsonProperty("national_format")]
                                    string nationalFormat, 
                                    [JsonProperty("carrier")]
                                    Dictionary<string, string> carrier, 
                                    [JsonProperty("add_ons")]
                                    Object addOns) {
            this.callerName = callerName;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.nationalFormat = nationalFormat;
            this.carrier = carrier;
            this.addOns = addOns;
        }
    
        /// <returns> The phone_number </returns> 
        public override string GetSid() {
            return this.GetPhoneNumber().ToString();
        }
    
        /// <returns> The caller_name </returns> 
        public Dictionary<string, string> GetCallerName() {
            return this.callerName;
        }
    
        /// <returns> The country_code </returns> 
        public string GetCountryCode() {
            return this.countryCode;
        }
    
        /// <returns> The phone_number </returns> 
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /// <returns> The national_format </returns> 
        public string GetNationalFormat() {
            return this.nationalFormat;
        }
    
        /// <returns> The carrier </returns> 
        public Dictionary<string, string> GetCarrier() {
            return this.carrier;
        }
    
        /// <returns> The add_ons </returns> 
        public Object GetAddOns() {
            return this.addOns;
        }
    }
}