using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class CountryResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CountryReader capable of executing the read </returns> 
        public static CountryReader Reader()
        {
            return new CountryReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> CountryFetcher capable of executing the fetch </returns> 
        public static CountryFetcher Fetcher(string isoCountry)
        {
            return new CountryFetcher(isoCountry);
        }
    
        /// <summary>
        /// Converts a JSON string into a CountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CountryResource object represented by the provided JSON </returns> 
        public static CountryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CountryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("iso_country")]
        public string isoCountry { get; set; }
        [JsonProperty("outbound_prefix_prices")]
        public List<OutboundPrefixPrice> outboundPrefixPrices { get; set; }
        [JsonProperty("inbound_call_prices")]
        public List<InboundCallPrice> inboundCallPrices { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public CountryResource()
        {
        
        }
    
        private CountryResource([JsonProperty("country")]
                                string country, 
                                [JsonProperty("iso_country")]
                                string isoCountry, 
                                [JsonProperty("outbound_prefix_prices")]
                                List<OutboundPrefixPrice> outboundPrefixPrices, 
                                [JsonProperty("inbound_call_prices")]
                                List<InboundCallPrice> inboundCallPrices, 
                                [JsonProperty("price_unit")]
                                string priceUnit, 
                                [JsonProperty("url")]
                                Uri url)
                                {
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundPrefixPrices = outboundPrefixPrices;
            this.inboundCallPrices = inboundCallPrices;
            this.priceUnit = priceUnit;
            this.url = url;
        }
    }
}