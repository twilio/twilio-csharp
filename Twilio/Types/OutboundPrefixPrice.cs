using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class OutboundPrefixPrice
	{
		[JsonProperty("prefixes")]
		private readonly List<string> prefixes;
		[JsonProperty("friendly_name")]
		private readonly string friendlyName;
		[JsonProperty("base_price")]
		private readonly double basePrice;
		[JsonProperty("current_price")]
		private readonly double currentPrice;

		public OutboundPrefixPrice ()
		{
		}

		public List<string> GetPrefixes() {
			return prefixes;
		}

		public string GetFriendlyName() {
			return friendlyName;
		}

		public double GetBasePrice() {
			return basePrice;
		}

		public double GetCurrentPrice() {
			return currentPrice;
		}
	}
}

