using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class NumberResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="number"> The number </param>
        /// <returns> NumberFetcher capable of executing the fetch </returns> 
        public static NumberFetcher Fetcher(Twilio.Types.PhoneNumber number)
        {
            return new NumberFetcher(number);
        }
    
        /// <summary>
        /// Converts a JSON string into a NumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NumberResource object represented by the provided JSON </returns> 
        public static NumberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NumberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber Number { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; set; }
        [JsonProperty("outbound_call_price")]
        public OutboundCallPrice OutboundCallPrice { get; set; }
        [JsonProperty("inbound_call_price")]
        public InboundCallPrice InboundCallPrice { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public NumberResource()
        {
        
        }
    
        private NumberResource([JsonProperty("number")]
                               Twilio.Types.PhoneNumber number, 
                               [JsonProperty("country")]
                               string country, 
                               [JsonProperty("iso_country")]
                               string isoCountry, 
                               [JsonProperty("outbound_call_price")]
                               OutboundCallPrice outboundCallPrice, 
                               [JsonProperty("inbound_call_price")]
                               InboundCallPrice inboundCallPrice, 
                               [JsonProperty("price_unit")]
                               string priceUnit, 
                               [JsonProperty("url")]
                               Uri url)
                               {
            Number = number;
            Country = country;
            IsoCountry = isoCountry;
            OutboundCallPrice = outboundCallPrice;
            InboundCallPrice = inboundCallPrice;
            PriceUnit = priceUnit;
            Url = url;
        }
    }
}