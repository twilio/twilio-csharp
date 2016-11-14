using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AvailablePhoneNumberCountryResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> AvailablePhoneNumberCountryReader capable of executing the read </returns> 
        public static AvailablePhoneNumberCountryReader Reader()
        {
            return new AvailablePhoneNumberCountryReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <returns> AvailablePhoneNumberCountryFetcher capable of executing the fetch </returns> 
        public static AvailablePhoneNumberCountryFetcher Fetcher(string countryCode)
        {
            return new AvailablePhoneNumberCountryFetcher(countryCode);
        }
    
        /// <summary>
        /// Converts a JSON string into a AvailablePhoneNumberCountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AvailablePhoneNumberCountryResource object represented by the provided JSON </returns> 
        public static AvailablePhoneNumberCountryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AvailablePhoneNumberCountryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("uri")]
        public Uri Uri { get; set; }
        [JsonProperty("beta")]
        public bool? Beta { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
    
        public AvailablePhoneNumberCountryResource()
        {
        
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
                                                    Dictionary<string, string> subresourceUris)
                                                    {
            CountryCode = countryCode;
            Country = country;
            Uri = uri;
            Beta = beta;
            SubresourceUris = subresourceUris;
        }
    }
}