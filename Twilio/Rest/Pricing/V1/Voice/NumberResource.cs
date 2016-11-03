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
        public Twilio.Types.PhoneNumber number { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("iso_country")]
        public string isoCountry { get; set; }
        [JsonProperty("outbound_call_price")]
        public OutboundCallPrice outboundCallPrice { get; set; }
        [JsonProperty("inbound_call_price")]
        public InboundCallPrice inboundCallPrice { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
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
            this.number = number;
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundCallPrice = outboundCallPrice;
            this.inboundCallPrice = inboundCallPrice;
            this.priceUnit = priceUnit;
            this.url = url;
        }
    }
}