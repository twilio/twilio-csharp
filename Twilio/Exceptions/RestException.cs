using System;
using Newtonsoft.Json;

namespace Twilio.Exceptions
{
	public class RestException : TwilioException
	{
		[JsonProperty("code")]
		public int Code { get; }

	    [JsonProperty("status")]
	    public int Status { get; }

	    [JsonProperty("message")]
	    public override string Message { get; }

	    [JsonProperty("moreInfo")]
		public string MoreInfo { get; }

	    public RestException() {}
		public RestException(string message) : base(message) {}
		public RestException(string message, Exception exception) : base(message, exception) {}
		public RestException(int status, string message, int code, string moreInfo) : base(message) {
			Status = status;
			Message = message;
			Code = code;
			MoreInfo = moreInfo;
		}

		public static RestException FromJson(string json) {
			return JsonConvert.DeserializeObject<RestException>(json);
		}
	}
}
