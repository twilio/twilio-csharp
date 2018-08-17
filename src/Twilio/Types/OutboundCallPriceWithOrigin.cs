using Newtonsoft.Json

namespace Twilio.Types
{
    public class OutboundCallPriceWithOrigin {

        [JsonProperty("base_price")]
        public double? BasePrice { get; }

        [JsonProperty("base_price")]
        public double? CurrentPrice { get; }

        [JsonProperty("origination_prefixes")]
        public List<string> OriginationPrefixes

        public OutboundCallPriceWithOrigin (double basePrice, double currentPrice, List<string> originationPrefixes) {
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
            OriginationPrefixes = originationPrefixes;
        }
    }
}