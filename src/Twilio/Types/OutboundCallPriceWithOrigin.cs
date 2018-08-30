using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
    /// <summary>
    /// POCO for outbound call price with origin
    /// </summary>
    public class OutboundCallPriceWithOrigin {

        /// <summary>
        /// Base price of outbound call
        /// </summary>
        [JsonProperty("base_price")]
        public double? BasePrice { get; }

        /// <summary>
        /// Current price of outbound call
        /// </summary>
        /// <returns></returns>
        [JsonProperty("current_price")]
        public double? CurrentPrice { get; }

        /// <summary>
        /// List of origination prefixes of outbound call
        /// </summary>
        /// <returns></returns>
        [JsonProperty("origination_prefixes")]
        public List<string> OriginationPrefixes { get; }

        /// <summary>
        /// Create a new OutboundCallPriceWithOrigin
        /// </summary>
        /// <param name="basePrice">Base price of call</param>
        /// <param name="currentPrice">Current price of call</param>
        /// <param name="originationPrefixes">List of origination prefixes of call</param>
        public OutboundCallPriceWithOrigin (double basePrice, double currentPrice, List<string> originationPrefixes) {
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
            OriginationPrefixes = originationPrefixes;
        }
    }
}