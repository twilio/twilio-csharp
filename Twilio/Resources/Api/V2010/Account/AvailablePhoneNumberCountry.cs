using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using java.net.URI;

namespace Twilio.Resources.Api.V2010.Account {

    public class AvailablePhoneNumberCountry : SidResource {
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AvailablePhoneNumberCountryReader capable of executing the read
         */
        public static AvailablePhoneNumberCountryReader read(String accountSid) {
            return new AvailablePhoneNumberCountryReader(accountSid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         * @return AvailablePhoneNumberCountryFetcher capable of executing the fetch
         */
        public static AvailablePhoneNumberCountryFetcher fetch(String accountSid, String countryCode) {
            return new AvailablePhoneNumberCountryFetcher(accountSid, countryCode);
        }
    
        /**
         * Converts a JSON string into a AvailablePhoneNumberCountry object
         * 
         * @param json Raw JSON string
         * @return AvailablePhoneNumberCountry object represented by the provided JSON
         */
        public static AvailablePhoneNumberCountry fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountry>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country_code")]
        private readonly String countryCode;
        [JsonProperty("country")]
        private readonly String country;
        [JsonProperty("uri")]
        private readonly URI uri;
        [JsonProperty("beta")]
        private readonly Boolean beta;
        [JsonProperty("subresource_uris")]
        private readonly Map<String, String> subresourceUris;
    
        private AvailablePhoneNumberCountry([JsonProperty("country_code")]
                                            String countryCode, 
                                            [JsonProperty("country")]
                                            String country, 
                                            [JsonProperty("uri")]
                                            URI uri, 
                                            [JsonProperty("beta")]
                                            Boolean beta, 
                                            [JsonProperty("subresource_uris")]
                                            Map<String, String> subresourceUris) {
            this.countryCode = countryCode;
            this.country = country;
            this.uri = uri;
            this.beta = beta;
            this.subresourceUris = subresourceUris;
        }
    
        /**
         * @return The country_code
         */
        public String getSid() {
            return this.getCountryCode();
        }
    
        /**
         * @return The country_code
         */
        public String GetCountryCode() {
            return this.countryCode;
        }
    
        /**
         * @return The country
         */
        public String GetCountry() {
            return this.country;
        }
    
        /**
         * @return The uri
         */
        public URI GetUri() {
            return this.uri;
        }
    
        /**
         * @return The beta
         */
        public Boolean GetBeta() {
            return this.beta;
        }
    
        /**
         * @return The subresource_uris
         */
        public Map<String, String> GetSubresourceUris() {
            return this.subresourceUris;
        }
    }
}