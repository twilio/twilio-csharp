using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Lookups.V1;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Lookups.V1 {

    public class PhoneNumber : SidResource {
        public enum Type {
            LANDLINE="landline",
            MOBILE="mobile",
            VOIP="voip"
        };
    
        /**
         * fetch
         * 
         * @param phoneNumber The phone_number
         * @return PhoneNumberFetcher capable of executing the fetch
         */
        public static PhoneNumberFetcher fetch(Twilio.Types.PhoneNumber phoneNumber) {
            return new PhoneNumberFetcher(phoneNumber);
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
    
        [JsonProperty("country_code")]
        private readonly string countryCode;
        [JsonProperty("phone_number")]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("national_format")]
        private readonly string nationalFormat;
        [JsonProperty("carrier")]
        private readonly Dictionary<string, string> carrier;
    
        private PhoneNumber([JsonProperty("country_code")]
                            string countryCode, 
                            [JsonProperty("phone_number")]
                            Twilio.Types.PhoneNumber phoneNumber, 
                            [JsonProperty("national_format")]
                            string nationalFormat, 
                            [JsonProperty("carrier")]
                            Dictionary<string, string> carrier) {
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.nationalFormat = nationalFormat;
            this.carrier = carrier;
        }
    
        /**
         * @return The phone_number
         */
        public string getSid() {
            return this.getPhoneNumber().ToString();
        }
    
        /**
         * @return The country_code
         */
        public string GetCountryCode() {
            return this.countryCode;
        }
    
        /**
         * @return The phone_number
         */
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The national_format
         */
        public string GetNationalFormat() {
            return this.nationalFormat;
        }
    
        /**
         * @return The carrier
         */
        public Dictionary<string, string> GetCarrier() {
            return this.carrier;
        }
    }
}