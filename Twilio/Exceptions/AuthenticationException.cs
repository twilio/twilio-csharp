using System;

namespace Twilio.Exceptions
{
	public class AuthenticationException : TwilioException
	{
		public AuthenticationException(string message) : base(message) {
		}
	}
}

