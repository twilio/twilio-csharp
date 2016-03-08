using System;

namespace Twilio.Exceptions
{
	public class ApiConnectionException : TwilioException
	{
		public ApiConnectionException(string message) : base(Message) {
		}

		public ApiConnectionException(string message, Exception exception) : base(message, exception) {
		}
	}
}

