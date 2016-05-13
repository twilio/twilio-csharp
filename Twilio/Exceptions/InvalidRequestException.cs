using System;

namespace Twilio.Exceptions
{
	public class InvalidRequestException : TwilioException
	{
		private string param;

		public InvalidRequestException(string message, string param, Exception exception) : base(message, exception) {
			this.param = param;
		}

		public string getParam() {
			return param;
		}
	}
}

