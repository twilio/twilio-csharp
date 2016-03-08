using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.AvailablePhoneNumberCountry;
using Twilio.Resources;
using com.twilio.types.PhoneNumberCapabilities;
using java.math.BigDecimal;

namespace Twilio.Resources.Api.V2010.Account.Availablephonenumbercountry {

    public class Local : Resource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         * @return LocalReader capable of executing the read
         */
        public static LocalReader read(String accountSid, String countryCode) {
            return new LocalReader(accountSid, countryCode);
        }
    
        /**
         * Converts a JSON string into a Local object
         * 
         * @param json Raw JSON string
         * @return Local object represented by the provided JSON
         */
        public static Local fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Local>(json);
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
        [JsonProperty("beta")]
        private readonly Boolean beta;
        [JsonProperty("capabilities")]
        private readonly PhoneNumberCapabilities capabilities;
    
        private Local([JsonProperty("friendly_name")]
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
                      [JsonProperty("beta")]
                      Boolean beta, 
                      [JsonProperty("capabilities")]
                      PhoneNumberCapabilities capabilities) {
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
            this.beta = beta;
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
    }
}