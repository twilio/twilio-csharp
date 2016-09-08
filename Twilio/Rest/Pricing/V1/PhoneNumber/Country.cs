using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Pricing.V1.PhoneNumber;
using Twilio.Http;
using Twilio.Readers.Pricing.V1.PhoneNumber;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.PhoneNumber {

    public class Country : SidResource {
        /**
         * read
         * 
         * @return CountryReader capable of executing the read
         */
        public static CountryReader Read() {
            return new CountryReader();
        }
    
        /**
         * fetch
         * 
         * @param isoCountry The iso_country
         * @return CountryFetcher capable of executing the fetch
         */
        public static CountryFetcher Fetch(string isoCountry) {
            return new CountryFetcher(isoCountry);
        }
    
        /**
         * Converts a JSON string into a Country object
         * 
         * @param json Raw JSON string
         * @return Country object represented by the provided JSON
         */
        public static Country FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Country>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        private readonly string country;
        [JsonProperty("iso_country")]
        private readonly string isoCountry;
        [JsonProperty("phone_number_prices")]
        private readonly List<PhoneNumberPrice> phoneNumberPrices;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("uri")]
        private readonly Uri uri;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public Country() {
        
        }
    
        private Country([JsonProperty("country")]
                        string country, 
                        [JsonProperty("iso_country")]
                        string isoCountry, 
                        [JsonProperty("phone_number_prices")]
                        List<PhoneNumberPrice> phoneNumberPrices, 
                        [JsonProperty("price_unit")]
                        string priceUnit, 
                        [JsonProperty("uri")]
                        Uri uri, 
                        [JsonProperty("url")]
                        Uri url) {
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
        public override string GetSid() {
            return this.GetIsoCountry();
        }
    
        /**
         * @return The country
         */
        public string GetCountry() {
            return this.country;
        }
    
        /**
         * @return The iso_country
         */
        public string GetIsoCountry() {
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
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The uri
         */
        public Uri GetUri() {
            return this.uri;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}