using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Pricing.V1.PhoneNumber;
using Twilio.Http;
using Twilio.Readers.Pricing.V1.PhoneNumber;
using Twilio.Resources;
using com.twilio.types.PhoneNumberPrice;
using java.net.URI;
using java.util.Currency;
using java.util.List;

namespace Twilio.Resources.Pricing.V1.Phonenumber {

    public class Country : SidResource {
        /**
         * read
         * 
         * @return CountryReader capable of executing the read
         */
        public static CountryReader read() {
            return new CountryReader();
        }
    
        /**
         * fetch
         * 
         * @param isoCountry The iso_country
         * @return CountryFetcher capable of executing the fetch
         */
        public static CountryFetcher fetch(String isoCountry) {
            return new CountryFetcher(isoCountry);
        }
    
        /**
         * Converts a JSON string into a Country object
         * 
         * @param json Raw JSON string
         * @return Country object represented by the provided JSON
         */
        public static Country fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Country>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        private readonly String country;
        [JsonProperty("iso_country")]
        private readonly String isoCountry;
        [JsonProperty("phone_number_prices")]
        private readonly List<PhoneNumberPrice> phoneNumberPrices;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("uri")]
        private readonly URI uri;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Country([JsonProperty("country")]
                        String country, 
                        [JsonProperty("iso_country")]
                        String isoCountry, 
                        [JsonProperty("phone_number_prices")]
                        List<PhoneNumberPrice> phoneNumberPrices, 
                        [JsonProperty("price_unit")]
                        [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                        Currency priceUnit, 
                        [JsonProperty("uri")]
                        URI uri, 
                        [JsonProperty("url")]
                        URI url) {
            this.country = country;
            this.isoCountry = isoCountry;
            this.phoneNumberPrices = phoneNumberPrices;
            this.priceUnit = priceUnit;
            this.uri = uri;
            this.url = url;
        }
    
        /**
         * @return The iso_country
         */
        public String getSid() {
            return this.getIsoCountry();
        }
    
        /**
         * @return The country
         */
        public String GetCountry() {
            return this.country;
        }
    
        /**
         * @return The iso_country
         */
        public String GetIsoCountry() {
            return this.isoCountry;
        }
    
        /**
         * @return The phone_number_prices
         */
        public List<PhoneNumberPrice> GetPhoneNumberPrices() {
            return this.phoneNumberPrices;
        }
    
        /**
         * @return The price_unit
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The uri
         */
        public URI GetUri() {
            return this.uri;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}