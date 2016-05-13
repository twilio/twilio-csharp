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

		public int getCode() {
			return code;
		}

		public string getMoreInfo() {
			return moreInfo;
		}

		public int getStatusCode() {
			return status;
		}
	}
}

