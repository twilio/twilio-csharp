using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class InboundSmsPrice
	{
		public sealed class Type {
			public const string LOCAL="local";
			public const string MOBILE="mobile";
			public const string NATIONAL="national";
			public const string TOLL_FREE="toll free";

			private readonly string value;

			public Type(string value) {
				this.value = value;
			}

			public override string ToString() {
				return value;
			}

			public static implicit operator Type(string value) {
				return new Type(value);
			}

			public static implicit operator string(Type value) {
				return value.ToString();
			}
		}

		[JsonProperty("base_price")]
		private readonly double? basePrice;
		[JsonProperty("current_price")]
		private readonly double? currentPrice;
		[JsonProperty("type")]
		private readonly Type type;

		public InboundSmsPrice ()
		{
		}

		private double? GetBasePrice() {
			return basePrice;
		}

		private double? GetCurrentPrice() {
			return currentPrice;
		}

		private new Type GetType() {
			return type;
		}
	}
}

