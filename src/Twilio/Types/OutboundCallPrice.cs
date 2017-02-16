using Newtonsoft.Json;

namespace Twilio.Types
{
    /// <summary>
    /// POCO for outbound call prices
    /// </summary>
    public class OutboundCallPrice
    {
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
        /// Create a new OutboundCallPrice
        /// </summary>
        /// <param name="basePrice">Base price of call</param>
        /// <param name="currentPrice">Current price of call</param>
        public OutboundCallPrice (double basePrice, double currentPrice)
        {
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
        }
    }
}

