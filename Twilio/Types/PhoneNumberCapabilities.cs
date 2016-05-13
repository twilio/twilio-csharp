using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class PhoneNumberCapabilities
	{
		[JsonProperty("mms")]
		private bool mms;
		[JsonProperty("sms")]
		private bool sms;
		[JsonProperty("voice")]
		private bool voice;

		public PhoneNumberCapabilities (bool mms, bool sms, bool voice) {
			this.mms = mms;
			this.sms = sms;
			this.voice = voice;
		}

		public bool GetMms() {
			return mms;
		}

		public bool GetSms() {
			return sms;
		}

		public bool GetVoice() {
			return voice;
		}
	}
}

