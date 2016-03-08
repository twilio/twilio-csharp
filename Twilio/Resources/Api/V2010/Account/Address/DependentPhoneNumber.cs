using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Address;
using Twilio.Resources;
using java.math.BigDecimal;

namespace Twilio.Resources.Api.V2010.Account.Address {

    public class DependentPhoneNumber : Resource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param addressSid The address_sid
         * @return DependentPhoneNumberReader capable of executing the read
         */
        public static DependentPhoneNumberReader read(String accountSid, String addressSid) {
            return new DependentPhoneNumberReader(accountSid, addressSid);
        }
    
        /**
         * Converts a JSON string into a DependentPhoneNumber object
         * 
         * @param json Raw JSON string
         * @return DependentPhoneNumber object represented by the provided JSON
         */
        public static DependentPhoneNumber fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<DependentPhoneNumber>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("friendly_name")]
        private readonly com.twilio.types.PhoneNumber friendlyName;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("lata")]
        private readonly String lata;
        [JsonProperty("rate_center")]
        private readonly String rateCenter;
        [JsonProperty("latitude")]
        private readonly BigDecimal latitude;
        [JsonProperty("longitude")]
        private readonly BigDecimal longitude;
        [JsonProperty("region")]
        private readonly String region;
        [JsonProperty("postal_code")]
        private readonly String postalCode;
        [JsonProperty("iso_country")]
        private readonly String isoCountry;
        [JsonProperty("address_requirements")]
        private readonly String addressRequirements;
        [JsonProperty("capabilities")]
        private readonly Map<String, String> capabilities;
    
        private DependentPhoneNumber([JsonProperty("friendly_name")]
                                     com.twilio.types.PhoneNumber friendlyName, 
                                     [JsonProperty("phone_number")]
                                     com.twilio.types.PhoneNumber phoneNumber, 
                                     [JsonProperty("lata")]
                                     String lata, 
                                     [JsonProperty("rate_center")]
                                     String rateCenter, 
                                     [JsonProperty("latitude")]
                                     BigDecimal latitude, 
                                     [JsonProperty("longitude")]
                                     BigDecimal longitude, 
                                     [JsonProperty("region")]
                                     String region, 
                                     [JsonProperty("postal_code")]
                                     String postalCode, 
                                     [JsonProperty("iso_country")]
                                     String isoCountry, 
                                     [JsonProperty("address_requirements")]
                                     String addressRequirements, 
                                     [JsonProperty("capabilities")]
                                     Map<String, String> capabilities) {
            this.friendlyName = friendlyName;
            this.phoneNumber = phoneNumber;
            this.lata = lata;
            this.rateCenter = rateCenter;
            this.latitude = latitude;
            this.longitude = longitude;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
            this.addressRequirements = addressRequirements;
            this.capabilities = capabilities;
        }
    
        /**
         * @return The friendly_name
         */
        public com.twilio.types.PhoneNumber GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The phone_number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The lata
         */
        public String GetLata() {
            return this.lata;
        }
    
        /**
         * @return The rate_center
         */
        public String GetRateCenter() {
            return this.rateCenter;
        }
    
        /**
         * @return The latitude
         */
        public BigDecimal GetLatitude() {
            return this.latitude;
        }
    
        /**
         * @return The longitude
         */
        public BigDecimal GetLongitude() {
            return this.longitude;
        }
    
        /**
         * @return The region
         */
        public String GetRegion() {
            return this.region;
        }
    
        /**
         * @return The postal_code
         */
        public String GetPostalCode() {
            return this.postalCode;
        }
    
        /**
         * @return The iso_country
         */
        public String GetIsoCountry() {
            return this.isoCountry;
        }
    
        /**
         * @return The address_requirements
         */
        public String GetAddressRequirements() {
            return this.addressRequirements;
        }
    
        /**
         * @return The capabilities
         */
        public Map<String, String> GetCapabilities() {
            return this.capabilities;
        }
    }
}