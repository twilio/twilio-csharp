using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Twilio.Exceptions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RestException : TwilioException
	{
		[JsonProperty("code")]
		public int Code { get; private set; }

	    [JsonProperty("status")]
	    public int Status { get; private set; }

	    [JsonProperty("message")]
	    public string Body { get; private set; }

	    [JsonProperty("more_info")]
		public string MoreInfo { get; private set; }

	    public RestException() {}
	    private RestException(
		    [JsonProperty("status")]
		    int status,
		    [JsonProperty("message")]
		    string message,
		    [JsonProperty("code")]
		    int code,
		    [JsonProperty("more_info")]
		    string moreInfo
		) {
			Status = status;
			Code = code;
		    Body = message;
			MoreInfo = moreInfo;
		}

		public static RestException FromJson(string json) {
			return JsonConvert.DeserializeObject<RestException>(json);
		}
	}
}
