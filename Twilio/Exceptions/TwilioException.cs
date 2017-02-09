using System;

namespace Twilio.Exceptions
{
	public class TwilioException : Exception
	{
		public TwilioException() {}

		public TwilioException (string message) : base(message) {}

		public TwilioException(string message, Exception exception) : base(message, exception) {}
	}

    public class ApiConnectionException : TwilioException
    {
        public ApiConnectionException(string message) : base(message) {}

        public ApiConnectionException(string message, Exception exception) : base(message, exception) {}
    }

    public class AuthenticationException : TwilioException
    {
        public AuthenticationException(string message) : base(message) {}
    }

    public class InvalidRequestException : TwilioException
    {
        public string Param { get; }

        public InvalidRequestException(string message, string param, Exception exception) : base(message, exception) 
		{
            Param = param;
        }
    }
}

