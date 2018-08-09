using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
    /// <summary>
    /// POCO for outbound prefix prices with origins
    /// </summary>
    public class OutboundPrefixPriceWithOrigin
    {
        /// <summary>
        /// Destination Prefix list
        /// </summary>
        [JsonProperty("destination_prefixes")]
        public List<string> DestinationPrefixes { get; }

        /// <summary>
        /// Destination Prefix list
        /// </summary>
        [JsonProperty("origination_prefixes")]
        public List<string> OriginationPrefixes { get; }

        /// <summary>
        /// Prefix friendly name
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; }

        /// <summary>
        /// Base price for prefix
        /// </summary>
        [JsonProperty("base_price")]
        public double? BasePrice { get; }

        /// <summary>
        /// Current price of prefix
        /// </summary>
        [JsonProperty("current_price")]
        public double? CurrentPrice { get; }

        /// <summary>
        /// Create a new OutboundPrefixPrice
        /// </summary>
        /// <param name="destinationPrefixes">List of destination prefixes</param>
        /// <param name="originationPrefixes">List of origination prefixes</param>
        /// <param name="friendlyName">Prefix friendly name</param>
        /// <param name="basePrice">Base price of prefix</param>
        /// <param name="currentPrice">Current price of prefix</param>
        public OutboundPrefixPriceWithOrigin (
            List<string> destinationPrefixes,
            List<string> originationPrefixes,
            string friendlyName,
            double basePrice,
            double currentPrice
        )
        {
            DestinationPrefixes = destinationPrefixes;
            OriginationPrefixes = originationPrefixes;
            FriendlyName = friendlyName;
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
        }
    }
}

