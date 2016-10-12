using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Messaging {

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
        [JsonProperty("outbound_sms_prices")]
        private readonly List<OutboundSmsPrice> outboundSmsPrices;
        [JsonProperty("inbound_sms_prices")]
        private readonly List<InboundSmsPrice> inboundSmsPrices;
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
                                [JsonProperty("outbound_sms_prices")]
                                List<OutboundSmsPrice> outboundSmsPrices, 
                                [JsonProperty("inbound_sms_prices")]
                                List<InboundSmsPrice> inboundSmsPrices, 
                                [JsonProperty("price_unit")]
                                string priceUnit, 
                                [JsonProperty("url")]
                                Uri url) {
            this.country = country;
            this.isoCountry = isoCountry;
            this.outboundSmsPrices = outboundSmsPrices;
            this.inboundSmsPrices = inboundSmsPrices;
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
    
        /// <returns> The outbound_sms_prices </returns> 
        public List<OutboundSmsPrice> GetOutboundSmsPrices() {
            return this.outboundSmsPrices;
        }
    
        /// <returns> The inbound_sms_prices </returns> 
        public List<InboundSmsPrice> GetInboundSmsPrices() {
            return this.inboundSmsPrices;
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