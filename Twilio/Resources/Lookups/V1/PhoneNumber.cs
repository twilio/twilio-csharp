using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
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
        public static PhoneNumberFetcher fetch(com.twilio.types.PhoneNumber phoneNumber) {
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
        private readonly String countryCode;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("national_format")]
        private readonly String nationalFormat;
        [JsonProperty("carrier")]
        private readonly Map<String, String> carrier;
    
        private PhoneNumber([JsonProperty("country_code")]
                            String countryCode, 
                            [JsonProperty("phone_number")]
                            com.twilio.types.PhoneNumber phoneNumber, 
                            [JsonProperty("national_format")]
                            String nationalFormat, 
                            [JsonProperty("carrier")]
                            Map<String, String> carrier) {
            this.countryCode = countryCode;
            this.phoneNumber = phoneNumber;
            this.nationalFormat = nationalFormat;
            this.carrier = carrier;
        }
    
        /**
         * @return The phone_number
         */
        public String getSid() {
            return this.getPhoneNumber().toString();
        }
    
        /**
         * @return The country_code
         */
        public String GetCountryCode() {
            return this.countryCode;
        }
    
        /**
         * @return The phone_number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The national_format
         */
        public String GetNationalFormat() {
            return this.nationalFormat;
        }
    
        /**
         * @return The carrier
         */
        public Map<String, String> GetCarrier() {
            return this.carrier;
        }
    }
}