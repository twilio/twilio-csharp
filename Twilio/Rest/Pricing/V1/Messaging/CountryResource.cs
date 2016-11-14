using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Messaging 
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
        public string Country { get; set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; set; }
        [JsonProperty("outbound_sms_prices")]
        public List<OutboundSmsPrice> OutboundSmsPrices { get; set; }
        [JsonProperty("inbound_sms_prices")]
        public List<InboundSmsPrice> InboundSmsPrices { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public CountryResource()
        {
        
        }
    
        private CountryResource([JsonProperty("country")]
                                string country, 
                                [JsonProperty("iso_country")]
                                string isoCountry, 
                                [JsonProperty("outbound_sms_prices")]
                                List<OutboundSmsPrice> outboundSmsPrices, 
                                [JsonProperty("inbound_sms_prices")]
                                List<InboundSmsPrice> inboundSmsPrices, 
                                [JsonProperty("price_unit")]
                                string priceUnit, 
                                [JsonProperty("url")]
                                Uri url)
                                {
            Country = country;
            IsoCountry = isoCountry;
            OutboundSmsPrices = outboundSmsPrices;
            InboundSmsPrices = inboundSmsPrices;
            PriceUnit = priceUnit;
            Url = url;
        }
    }
}