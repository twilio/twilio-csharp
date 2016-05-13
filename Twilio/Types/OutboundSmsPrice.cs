using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class OutboundSmsPrice
	{
		[JsonProperty("mcc")]
		private readonly string mcc;
		[JsonProperty("mnc")]
		private readonly string mnc;
		[JsonProperty("carrier")]
		private readonly string carrier;
		[JsonProperty("prices")]
		private readonly List<InboundSmsPrice> prices;

		public OutboundSmsPrice ()
		{
		}

		public string GetMCC() {
			return mcc;
		}

		public string GetMNC() {
			return mnc;
		}

		public string GetCarrier() {
			return carrier;
		}

		public List<InboundSmsPrice> GetPrices() {
			return prices;
		}
	}
}

