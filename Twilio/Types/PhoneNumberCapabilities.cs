using Newtonsoft.Json;

namespace Twilio.Types
{
	public class PhoneNumberCapabilities
	{
		[JsonProperty("mms")]
		public bool Mms { get; }
		[JsonProperty("sms")]
		public bool Sms { get; }
		[JsonProperty("voice")]
		public bool Voice { get; }

		public PhoneNumberCapabilities (bool mms, bool sms, bool voice)
		{
			Mms = mms;
			Sms = sms;
			Voice = voice;
		}
	}
}

