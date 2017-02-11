using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class OutboundSmsPrice
	{
		[JsonProperty("mcc")]
		public string Mcc { get; }
		[JsonProperty("mnc")]
		public string Mnc { get; }
		[JsonProperty("carrier")]
		public string Carrier { get; }
		[JsonProperty("prices")]
		public List<InboundSmsPrice> Prices { get; }

		public OutboundSmsPrice (
		    string mcc,
		    string mnc,
		    string carrier,
		    List<InboundSmsPrice> prices
		)
		{
		    Mcc = mcc;
		    Mnc = mnc;
		    Carrier = carrier;
		    Prices = prices;
		}
	}
}

