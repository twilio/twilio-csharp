using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
    public class OutboundPrefixPrice
    {
        [JsonProperty("prefixes")]
        public List<string> Prefixes { get; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; }
        [JsonProperty("base_price")]
        public double? BasePrice { get; }
        [JsonProperty("current_price")]
        public double? CurrentPrice { get; }

        public OutboundPrefixPrice (
            List<string> prefixes,
            string friendlyName,
            double basePrice,
            double currentPrice
        )
        {
            Prefixes = prefixes;
            FriendlyName = friendlyName;
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
        }
    }
}

