using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Pricing.V1.Voice;
using Twilio.Http;
using Twilio.Readers.Pricing.V1.Voice;
using Twilio.Resources;
using com.twilio.types.InboundCallPrice;
using com.twilio.types.OutboundPrefixPrice;
using java.net.URI;
using java.util.Currency;
using java.util.List;

namespace Twilio.Resources.Pricing.V1.Voice {

    public class Country : SidResource {
        /**
         * read
         * 
         * @return CountryReader capable of executing the read
         */
        public static CountryReader read() {
            return new CountryReader();
        }
    
        /**
         * fetch
         * 
         * @param isoCountry The iso_country
         * @return CountryFetcher capable of executing the fetch
         */
        public static CountryFetcher fetch(String isoCountry) {
            return new CountryFetcher(isoCountry);
        }
    
        /**
         * Converts a JSON string into a Country object
         * 
         * @param json Raw JSON string
         * @return Country object represented by the provided JSON
         */
        public static Country fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Country>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        private readonly String country;
        [JsonProperty("iso_country")]
        private readonly String isoCountry;
        [JsonProperty("outbound_prefix_prices")]
        private readonly List<OutboundPrefixPrice> outboundPrefixPrices;
        [JsonProperty("inbound_call_prices")]
        private readonly List<InboundCallPrice> inboundCallPrices;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("url")]
        private readonly URI url;
    
        private Country([JsonProperty("country")]
                        String country, 
                        [JsonProperty("iso_country")]
                        String isoCountry, 
                        [JsonProperty("outbound_prefix_prices")]
                        List<OutboundPrefixPrice> outboundPrefixPrices, 
                        [JsonProperty("inbound_call_prices")]
                        List<InboundCallPrice> inboundCallPrices, 
                        [JsonProperty("price_unit")]
                        [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                        Currency priceUnit, 
                        [JsonProperty("url")]
                        URI url) {
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundPrefixPrices = outboundPrefixPrices;
            this.inboundCallPrices = inboundCallPrices;
            this.priceUnit = priceUnit;
            this.url = url;
        }
    
        /**
         * @return The iso_country
         */
        public String getSid() {
            return this.getIsoCountry();
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
         * @return The outbound_prefix_prices
         */
        public List<OutboundPrefixPrice> GetOutboundPrefixPrices() {
            return this.outboundPrefixPrices;
        }
    
        /**
         * @return The inbound_call_prices
         */
        public List<InboundCallPrice> GetInboundCallPrices() {
            return this.inboundCallPrices;
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