using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Lookups.V1 
{

    public class PhoneNumberResource : Resource 
    {
        public sealed class TypeEnum : IStringEnum 
        {
            public const string Landline = "landline";
            public const string Mobile = "mobile";
            public const string Voip = "voip";
        
            private string _value;
            
            public TypeEnum() {}
            
            public TypeEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator TypeEnum(string value)
            {
                return new TypeEnum(value);
            }
            
            public static implicit operator string(TypeEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> PhoneNumberFetcher capable of executing the fetch </returns> 
        public static PhoneNumberFetcher Fetcher(Twilio.Types.PhoneNumber phoneNumber)
        {
            return new PhoneNumberFetcher(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a PhoneNumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PhoneNumberResource object represented by the provided JSON </returns> 
        public static PhoneNumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("caller_name")]
        public Dictionary<string, string> CallerName { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber PhoneNumber { get; set; }
        [JsonProperty("national_format")]
        public string NationalFormat { get; set; }
        [JsonProperty("carrier")]
        public Dictionary<string, string> Carrier { get; set; }
        [JsonProperty("add_ons")]
        public Object AddOns { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public PhoneNumberResource()
        {
        
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
                                    Uri url)
                                    {
            CallerName = callerName;
            CountryCode = countryCode;
            PhoneNumber = phoneNumber;
            NationalFormat = nationalFormat;
            Carrier = carrier;
            AddOns = addOns;
            Url = url;
        }
    }
}