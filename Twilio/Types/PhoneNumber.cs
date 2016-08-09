using System;

namespace Twilio.Types
{
	public class PhoneNumber : Endpoint
	{
		private string number;

		public PhoneNumber(string number) {
			this.number = number;
		}

		public override string ToString() {
			return this.number;
		}
	}
}

