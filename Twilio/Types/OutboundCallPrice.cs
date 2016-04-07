using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class OutboundCallPrice
	{
		[JsonProperty("base_price")]
		private double basePrice;
		[JsonProperty("current_price")]
		private double currentPrice;

		public OutboundCallPrice (double basePrice, double currentPrice) {
			this.basePrice = basePrice;
			this.currentPrice = currentPrice;
		}

		public double GetBasePrice() {
			return basePrice;
		}

		public double GetCurrentPrice() {
			return currentPrice;
		}
	}
}

