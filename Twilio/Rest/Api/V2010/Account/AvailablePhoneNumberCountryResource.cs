using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class AvailablePhoneNumberCountryResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> AvailablePhoneNumberCountryReader capable of executing the read </returns> 
        public static AvailablePhoneNumberCountryReader Reader(string accountSid) {
            return new AvailablePhoneNumberCountryReader(accountSid);
        }
    
        /// <summary>
        /// Create a AvailablePhoneNumberCountryReader to execute read.
        /// </summary>
        ///
        /// <returns> AvailablePhoneNumberCountryReader capable of executing the read </returns> 
        public static AvailablePhoneNumberCountryReader Reader() {
            return new AvailablePhoneNumberCountryReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="countryCode"> The country_code </param>
        /// <returns> AvailablePhoneNumberCountryFetcher capable of executing the fetch </returns> 
        public static AvailablePhoneNumberCountryFetcher Fetcher(string accountSid, string countryCode) {
            return new AvailablePhoneNumberCountryFetcher(accountSid, countryCode);
        }
    
        /// <summary>
        /// Create a AvailablePhoneNumberCountryFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> AvailablePhoneNumberCountryFetcher capable of executing the fetch </returns> 
        public static AvailablePhoneNumberCountryFetcher Fetcher(string countryCode) {
            return new AvailablePhoneNumberCountryFetcher(countryCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a AvailablePhoneNumberCountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AvailablePhoneNumberCountryResource object represented by the provided JSON </returns> 
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
    
        public AvailablePhoneNumberCountryResource() {
        
        }
    
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
    
        /// <returns> The country_code </returns> 
        public override string GetSid() {
            return this.GetCountryCode();
        }
    
        /// <returns> The country_code </returns> 
        public string GetCountryCode() {
            return this.countryCode;
        }
    
        /// <returns> The country </returns> 
        public string GetCountry() {
            return this.country;
        }
    
        /// <returns> The uri </returns> 
        public Uri GetUri() {
            return this.uri;
        }
    
        /// <returns> The beta </returns> 
        public bool? GetBeta() {
            return this.beta;
        }
    
        /// <returns> The subresource_uris </returns> 
        public Dictionary<string, string> GetSubresourceUris() {
            return this.subresourceUris;
        }
    }
}