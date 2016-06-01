using System;

namespace Twilio.Exceptions
{
	public class TwilioException : Exception
	{

		public TwilioException() {}

		public TwilioException (string message) : base(message) {
		}

		public TwilioException(string message, Exception exception) : base(message, exception) {
		}
	}
}

