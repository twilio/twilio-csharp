using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;

namespace Twilio.Rest.Api.V2010.Account {

    public class AvailablePhoneNumberCountry : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AvailablePhoneNumberCountryReader capable of executing the read
         */
        public static AvailablePhoneNumberCountryReader Read(string accountSid) {
            return new AvailablePhoneNumberCountryReader(accountSid);
        }
    
        /**
         * Create a AvailablePhoneNumberCountryReader to execute read.
         * 
         * @return AvailablePhoneNumberCountryReader capable of executing the read
         */
        public static AvailablePhoneNumberCountryReader Read() {
            return new AvailablePhoneNumberCountryReader();
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         * @return AvailablePhoneNumberCountryFetcher capable of executing the fetch
         */
        public static AvailablePhoneNumberCountryFetcher Fetch(string accountSid, string countryCode) {
            return new AvailablePhoneNumberCountryFetcher(accountSid, countryCode);
        }
    
        /**
         * Create a AvailablePhoneNumberCountryFetcher to execute fetch.
         * 
         * @param countryCode The country_code
         * @return AvailablePhoneNumberCountryFetcher capable of executing the fetch
         */
        public static AvailablePhoneNumberCountryFetcher Fetch(string countryCode) {
            return new AvailablePhoneNumberCountryFetcher(countryCode);
        }
    
        /**
         * Converts a JSON string into a AvailablePhoneNumberCountry object
         * 
         * @param json Raw JSON string
         * @return AvailablePhoneNumberCountry object represented by the provided JSON
         */
        public static AvailablePhoneNumberCountry FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountry>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country_code")]
        private readonly string countryCode;
        [JsonProperty("country")]
        private readonly string country;
        [JsonProperty("uri")]
        private readonly Uri uri;
        [JsonProperty("beta")]
        private readonly bool? beta;
        [JsonProperty("subresource_uris")]
        private readonly Dictionary<string, string> subresourceUris;
    
        public AvailablePhoneNumberCountry() {
        
        }
    
        private AvailablePhoneNumberCountry([JsonProperty("country_code")]
                                            string countryCode, 
                                            [JsonProperty("country")]
                                            string country, 
                                            [JsonProperty("uri")]
                                            Uri uri, 
                                            [JsonProperty("beta")]
                                            bool? beta, 
                                            [JsonProperty("subresource_uris")]
                                            Dictionary<string, string> subresourceUris) {
            this.countryCode = countryCode;
            this.country = country;
            this.uri = uri;
            this.beta = beta;
            this.subresourceUris = subresourceUris;
        }
    
        /**
         * @return The country_code
         */
        public override string GetSid() {
            return this.GetCountryCode();
        }
    
        /**
         * @return The country_code
         */
        public string GetCountryCode() {
            return this.countryCode;
        }
    
        /**
         * @return The country
         */
        public string GetCountry() {
            return this.country;
        }
    
        /**
         * @return The uri
         */
        public Uri GetUri() {
            return this.uri;
        }
    
        /**
         * @return The beta
         */
        public bool? GetBeta() {
            return this.beta;
        }
    
        /**
         * @return The subresource_uris
         */
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    }
}