using Newtonsoft.Json

namespace Twilio.Types
{
    public class OutboundCallPriceWithOrigin {          // TODO: why is this class public? What would making it private do?

        // members (private vs public?)
        [JsonProperty("base_price")]                    // TODO: not sure what this is doing? Or even what it is? Adding a property to a class? Type?
        public double? BasePrice { get; }               // TODO: what is '?' doing? ANSWER: It indicates it's a nullable type

        [JsonProperty("base_price")]
        public double? CurrentPrice { get; }

        [JsonProperty("origination_prefixes")]
        public List<string> OriginationPrefixes

        // constructor?
        public OutboundCallPriceWithOrigin (double basePrice, double currentPrice, List<string> originationPrefixes) {
            BasePrice = basePrice;
            CurrentPrice = currentPrice;
            OriginationPrefixes = originationPrefixes;
        }
    }
}