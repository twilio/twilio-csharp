using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class AvailablePhoneNumberCountryResource : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AvailablePhoneNumberCountryReader capable of executing the read
         */
        public static AvailablePhoneNumberCountryReader read(string accountSid) {
            return new AvailablePhoneNumberCountryReader(accountSid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         * @return AvailablePhoneNumberCountryFetcher capable of executing the fetch
         */
        public static AvailablePhoneNumberCountryFetcher fetch(string accountSid, string countryCode) {
            return new AvailablePhoneNumberCountryFetcher(accountSid, countryCode);
        }
    
        /**
         * Converts a JSON string into a AvailablePhoneNumberCountryResource object
         * 
         * @param json Raw JSON string
         * @return AvailablePhoneNumberCountryResource object represented by the
         *         provided JSON
         */
        public static AvailablePhoneNumberCountryResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountryResource>(json);
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
    
        private AvailablePhoneNumberCountryResource([JsonProperty("country_code")]
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