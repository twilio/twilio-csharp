using System;
using Newtonsoft.Json;

namespace Twilio.Exceptions
{
	public class RestException : TwilioException
	{
		[JsonProperty("code")]
		private int code;
		[JsonProperty("message")]
		private string message;
		[JsonProperty("moreInfo")]
		private string moreInfo;
		[JsonProperty("status")]
		private int status;

		public RestException() {}

		public RestException(string message) : base(message) {
		}

		public RestException(string message, Exception exception) : base(message, exception) {
		}

		public RestException(int status, string message, int code, string moreInfo) : base(message) {
			this.status = status;
			this.message = message;
			this.code = code;
			this.moreInfo = moreInfo;
		}

		public static RestException FromJson(string json) {
			RestException result = JsonConvert.DeserializeObject<RestException>(json);

			return result;
		}

		public int GetStatus() {
			return this.status;
		}

		public string GetMessage() {
			return this.message;
		}

		public int GetCode() {
			return this.code;
		}

		public string GetMoreInfo() {
			return this.moreInfo;
		}
	}
}
