using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.PhoneNumber {

    public class CountryResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CountryReader capable of executing the read </returns> 
        public static CountryReader Reader() {
            return new CountryReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> CountryFetcher capable of executing the fetch </returns> 
        public static CountryFetcher Fetcher(string isoCountry) {
            return new CountryFetcher(isoCountry);
        }
    
        /// <summary>
        /// Converts a JSON string into a CountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CountryResource object represented by the provided JSON </returns> 
        public static CountryResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CountryResource>(json);
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
    
        public CountryResource() {
        
        }
    
        private CountryResource([JsonProperty("country")]
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
    
        /// <returns> The iso_country </returns> 
        public override string GetSid() {
            return this.GetIsoCountry();
        }
    
        /// <returns> The country </returns> 
        public string GetCountry() {
            return this.country;
        }
    
        /// <returns> The iso_country </returns> 
        public string GetIsoCountry() {
            return this.isoCountry;
        }
    
        /// <returns> The phone_number_prices </returns> 
        public List<PhoneNumberPrice> GetPhoneNumberPrices() {
            return this.phoneNumberPrices;
        }
    
        /// <returns> The price_unit </returns> 
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /// <returns> The uri </returns> 
        public Uri GetUri() {
            return this.uri;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}