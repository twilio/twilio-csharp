using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Pricing.V1.Voice;
using Twilio.Http;
using Twilio.Resources;
using com.twilio.types.InboundCallPrice;
using com.twilio.types.OutboundCallPrice;
using java.net.URI;
using java.util.Currency;

namespace Twilio.Resources.Pricing.V1.Voice {

    public class Number : SidResource {
        /**
         * fetch
         * 
         * @param number The number
         * @return NumberFetcher capable of executing the fetch
         */
        public static NumberFetcher fetch(com.twilio.types.PhoneNumber number) {
            return new NumberFetcher(number);
        }
    
        /**
         * Converts a JSON string into a Number object
         * 
         * @param json Raw JSON string
         * @return Number object represented by the provided JSON
         */
        public static Number fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Number>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("number")]
        private readonly com.twilio.types.PhoneNumber number;
        [JsonProperty("country")]
        private readonly String country;
        [JsonProperty("iso_country")]
        private readonly String isoCountry;
        [JsonProperty("outbound_call_price")]
        private readonly OutboundCallPrice outboundCallPrice;
        [JsonProperty("inbound_call_price")]
        private readonly InboundCallPrice inboundCallPrice;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Number([JsonProperty("number")]
                       com.twilio.types.PhoneNumber number, 
                       [JsonProperty("country")]
                       String country, 
                       [JsonProperty("iso_country")]
                       String isoCountry, 
                       [JsonProperty("outbound_call_price")]
                       OutboundCallPrice outboundCallPrice, 
                       [JsonProperty("inbound_call_price")]
                       InboundCallPrice inboundCallPrice, 
                       [JsonProperty("price_unit")]
                       [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                       Currency priceUnit, 
                       [JsonProperty("url")]
                       URI url) {
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
        public String getSid() {
            return this.getNumber().toString();
        }
    
        /**
         * @return The number
         */
        public com.twilio.types.PhoneNumber GetNumber() {
            return this.number;
        }
    
        /**
         * @return The country
         */
        public String GetCountry() {
            return this.country;
        }
    
        /**
         * @return The iso_country
         */
        public String GetIsoCountry() {
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
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    }
}