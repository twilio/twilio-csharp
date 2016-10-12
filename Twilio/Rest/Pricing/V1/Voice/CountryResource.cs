using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice {

    public class CountryResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> CountryReader capable of executing the read </returns> 
        public static CountryReader Reader() {
            return new CountryReader();
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> CountryFetcher capable of executing the fetch </returns> 
        public static CountryFetcher Fetcher(string isoCountry) {
            return new CountryFetcher(isoCountry);
        }
    
        /// <summary>
        /// Converts a JSON string into a CountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CountryResource object represented by the provided JSON </returns> 
        public static CountryResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<CountryResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        private readonly string country;
        [JsonProperty("iso_country")]
        private readonly string isoCountry;
        [JsonProperty("outbound_prefix_prices")]
        private readonly List<OutboundPrefixPrice> outboundPrefixPrices;
        [JsonProperty("inbound_call_prices")]
        private readonly List<InboundCallPrice> inboundCallPrices;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public CountryResource() {
        
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
                                Uri url) {
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundPrefixPrices = outboundPrefixPrices;
            this.inboundCallPrices = inboundCallPrices;
            this.priceUnit = priceUnit;
            this.url = url;
        }
    
        /// <returns> The iso_country </returns> 
        public override string GetSid() {
            return this.GetIsoCountry();
        }
    
        /// <returns> The country </returns> 
        public string GetCountry() {
            return this.country;
        }
    
        /// <returns> The iso_country </returns> 
        public string GetIsoCountry() {
            return this.isoCountry;
        }
    
        /// <returns> The outbound_prefix_prices </returns> 
        public List<OutboundPrefixPrice> GetOutboundPrefixPrices() {
            return this.outboundPrefixPrices;
        }
    
        /// <returns> The inbound_call_prices </returns> 
        public List<InboundCallPrice> GetInboundCallPrices() {
            return this.inboundCallPrices;
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