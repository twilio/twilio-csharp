using Newtonsoft.Json;

namespace Twilio.Types
{
    public class OutboundCallPrice
    {
        [JsonProperty("base_price")]
        public double? BasePrice { get; }
        [JsonProperty("current_price")]
        public double? CurrentPrice { get; }

        public OutboundCallPrice (double basePrice, double currentPrice)
        {
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
        }
    }
}

