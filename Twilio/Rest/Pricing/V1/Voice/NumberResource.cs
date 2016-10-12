using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice {

    public class NumberResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="number"> The number </param>
        /// <returns> NumberFetcher capable of executing the fetch </returns> 
        public static NumberFetcher Fetcher(Twilio.Types.PhoneNumber number) {
            return new NumberFetcher(number);
        }
    
        /// <summary>
        /// Converts a JSON string into a NumberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NumberResource object represented by the provided JSON </returns> 
        public static NumberResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<NumberResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        private readonly Twilio.Types.PhoneNumber number;
        [JsonProperty("country")]
        private readonly string country;
        [JsonProperty("iso_country")]
        private readonly string isoCountry;
        [JsonProperty("outbound_call_price")]
        private readonly OutboundCallPrice outboundCallPrice;
        [JsonProperty("inbound_call_price")]
        private readonly InboundCallPrice inboundCallPrice;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public NumberResource() {
        
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
                               Uri url) {
            this.number = number;
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundCallPrice = outboundCallPrice;
            this.inboundCallPrice = inboundCallPrice;
            this.priceUnit = priceUnit;
            this.url = url;
        }
    
        /// <returns> The number </returns> 
        public override string GetSid() {
            return this.GetNumber().ToString();
        }
    
        /// <returns> The number </returns> 
        public Twilio.Types.PhoneNumber GetNumber() {
            return this.number;
        }
    
        /// <returns> The country </returns> 
        public string GetCountry() {
            return this.country;
        }
    
        /// <returns> The iso_country </returns> 
        public string GetIsoCountry() {
            return this.isoCountry;
        }
    
        /// <returns> The outbound_call_price </returns> 
        public OutboundCallPrice GetOutboundCallPrice() {
            return this.outboundCallPrice;
        }
    
        /// <returns> The inbound_call_price </returns> 
        public InboundCallPrice GetInboundCallPrice() {
            return this.inboundCallPrice;
        }
    
        /// <returns> The price_unit </returns> 
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}