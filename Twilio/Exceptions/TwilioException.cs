using System;

namespace Twilio.Exceptions
{
	public abstract class TwilioException : Exception
	{
		public TwilioException (string message) : base(message) {
		}

		public TwilioException(string message, Exception exception) : base(message, exception) {
		}
	}
}

