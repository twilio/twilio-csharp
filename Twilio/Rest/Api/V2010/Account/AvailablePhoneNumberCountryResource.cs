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
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> AvailablePhoneNumberCountryReader capable of executing the read </returns> 
        public static AvailablePhoneNumberCountryReader Reader(string accountSid=null)
        {
            return new AvailablePhoneNumberCountryReader(accountSid:accountSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> AvailablePhoneNumberCountryFetcher capable of executing the fetch </returns> 
        public static AvailablePhoneNumberCountryFetcher Fetcher(string countryCode, string accountSid=null)
        {
            return new AvailablePhoneNumberCountryFetcher(countryCode, accountSid:accountSid);
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
        public string countryCode { get; }
        [JsonProperty("country")]
        public string country { get; }
        [JsonProperty("uri")]
        public Uri uri { get; }
        [JsonProperty("beta")]
        public bool? beta { get; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> subresourceUris { get; }
    
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
            this.countryCode = countryCode;
            this.country = country;
            this.uri = uri;
            this.beta = beta;
            this.subresourceUris = subresourceUris;
        }
    }
}