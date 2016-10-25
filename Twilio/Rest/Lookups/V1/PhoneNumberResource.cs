using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Lookups.V1 {

    public class PhoneNumberResource : Resource {
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
        /// <param name="countryCode"> The country_code </param>
        /// <param name="type"> The type </param>
        /// <param name="addOns"> The add_ons </param>
        /// <param name="addOnsData"> The add_ons_data </param>
        /// <returns> PhoneNumberFetcher capable of executing the fetch </returns> 
        public static PhoneNumberFetcher Fetcher(Twilio.Types.PhoneNumber phoneNumber, string countryCode=null, List<string> type=null, List<string> addOns=null, Dictionary<string, object> addOnsData=null) {
            return new PhoneNumberFetcher(phoneNumber, countryCode:countryCode, type:type, addOns:addOns, addOnsData:addOnsData);
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
        public Dictionary<string, string> callerName { get; }
        [JsonProperty("country_code")]
        public string countryCode { get; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        [JsonProperty("national_format")]
        public string nationalFormat { get; }
        [JsonProperty("carrier")]
        public Dictionary<string, string> carrier { get; }
        [JsonProperty("add_ons")]
        public Object addOns { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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
                                    Object addOns, 
                                    [JsonProperty("url")]
                                    Uri url) {
            this.callerName = callerName;
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.nationalFormat = nationalFormat;
            this.carrier = carrier;
            this.addOns = addOns;
            this.url = url;
        }
    }
}