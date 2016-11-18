using Newtonsoft.Json;
using Twilio.Converters;

namespace Twilio.Types
{
	public class InboundCallPrice
	{
        public sealed class TypeEnum : StringEnum {
            private TypeEnum(string value) : base(value) {}
            public TypeEnum() {}

            public static readonly TypeEnum Local = new TypeEnum("local");
            public static readonly TypeEnum Mobile = new TypeEnum("mobile");
            public static readonly TypeEnum National = new TypeEnum("national");
            public static readonly TypeEnum TollFree = new TypeEnum("toll free");
        }

		[JsonProperty("base_price")]
		public double? BasePrice { get; }
		[JsonProperty("current_price")]
		public double? CurrentPrice { get; }
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public TypeEnum Type { get; }

		public InboundCallPrice() {}

	    private InboundCallPrice(
            [JsonProperty("base_price")]
            double? basePrice,
            [JsonProperty("current_priece")]
            double? currentPrice,
            [JsonProperty("type")]
            TypeEnum type
	    )
	    {
	        BasePrice = basePrice;
	        CurrentPrice = currentPrice;
	        Type = type;
	    }
	}
}

