using Newtonsoft.Json;

namespace Twilio.Exceptions
{
    /// <summary>
    /// Exception from Twilio API
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class RestException : TwilioException
    {
        /// <summary>
        /// Twilio error code
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; private set; }

        /// <summary>
        /// HTTP status code
        /// </summary>
        [JsonProperty("status")]
        public int Status { get; private set; }

        /// <summary>
        /// Error message
        /// </summary>
        public override string Message {
            get
            {
                return _message;
            }        
        }

        [JsonProperty("message")]
        private string _message
        {
            get; set;
        }

        /// <summary>
        /// More info if provided
        /// </summary>
        [JsonProperty("more_info")]
        public string MoreInfo { get; private set; }
        
        /// <summary>
        /// Create an empty RestException
        /// </summary>
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
            _message = message;
            MoreInfo = moreInfo;
        }

        /// <summary>
        /// Create a RestException from a JSON payload
        /// </summary>
        /// <param name="json">JSON string to parse</param>
        public static RestException FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RestException>(json);
        }
    }
}
