using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Pricing.V1.Voice;
using Twilio.Http;
using Twilio.Resources;
using Twilio.Types;

namespace Twilio.Resources.Pricing.V1.Voice {

    public class NumberResource : SidResource {
        /**
         * fetch
         * 
         * @param number The number
         * @return NumberFetcher capable of executing the fetch
         */
        public static NumberFetcher Fetch(Twilio.Types.PhoneNumber number) {
            return new NumberFetcher(number);
        }
    
        /**
         * Converts a JSON string into a NumberResource object
         * 
         * @param json Raw JSON string
         * @return NumberResource object represented by the provided JSON
         */
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
        private readonly decimal? priceUnit;
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
                               decimal? priceUnit, 
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
    
        /**
         * @return The number
         */
        public override string GetSid() {
            return this.GetNumber().ToString();
        }
    
        /**
         * @return The number
         */
        public Twilio.Types.PhoneNumber GetNumber() {
            return this.number;
        }
    
        /**
         * @return The country
         */
        public string GetCountry() {
            return this.country;
        }
    
        /**
         * @return The iso_country
         */
        public string GetIsoCountry() {
            return this.isoCountry;
        }
    
        /**
         * @return The outbound_call_price
         */
        public OutboundCallPrice GetOutboundCallPrice() {
            return this.outboundCallPrice;
        }
    
        /**
         * @return The inbound_call_price
         */
        public InboundCallPrice GetInboundCallPrice() {
            return this.inboundCallPrice;
        }
    
        /**
         * @return The price_unit
         */
        public decimal? GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}