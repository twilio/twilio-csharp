using System;

namespace Twilio.Exceptions
{
	public class ApiException : TwilioException
	{

		private int code;
		private string moreInfo;
		private int status;

		public ApiException(string message) : base(message) {
		}

		public ApiException(string message, Exception exception) : base(message, exception) {
		}

		public ApiException(string message, int code, string moreInfo, int status, Exception exception) : base(message, exception) {
			this.code = code;
			this.moreInfo = moreInfo;
			this.status = status;
		}

		public int GetCode() {
			return code;
		}

		public string GetMoreInfo() {
			return moreInfo;
		}

		public int GetStatusCode() {
			return status;
		}
	}
}

