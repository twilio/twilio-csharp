using Newtonsoft.Json;
using System.Collections.Generic;

namespace Twilio.Exceptions
{
    /// <summary>
    /// Represents a single validation error detail (RFC 9457)
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class ErrorDetail
    {
        /// <summary>
        /// A human-readable explanation of the validation error for this specific field.
        /// </summary>
        [JsonProperty("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// A JSON Pointer (RFC 6901) to the location in the request where the error occurred.
        /// </summary>
        [JsonProperty("pointer")]
        public string Pointer { get; set; }
    }

    /// <summary>
    /// RFC 9457 compliant REST API Standard Exception for HTTP APIs
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class RestApiStandardException : TwilioException
    {
        /// <summary>
        /// A URI reference identifying the problem type
        /// </summary>
        /// mandatory
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// A short, human-readable summary of the problem type
        /// </summary>
        /// mandatory
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// The numeric Twilio error code
        /// </summary>
        /// mandatory
        [JsonProperty("code")]
        public int Code { get; private set; }

        /// <summary>
        /// HTTP status code
        /// </summary>
        /// mandatory
        [JsonProperty("status")]
        public int Status { get; private set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem
        /// </summary>
        /// optional
        [JsonProperty("detail")]
        public string Detail { get; private set; }
        
        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem
        /// </summary>
        /// optional
        [JsonProperty("instance")]
        public string Instance { get; private set; }

        /// <summary>
        /// Validation errors for this occurrence (RFC 9457 extension)
        /// </summary>
        /// optional
        [JsonProperty("errors")]
        public List<ErrorDetail> Errors { get; private set; }

        /// <summary>
        /// Create an empty RestApiStandardException
        /// </summary>
        public RestApiStandardException() { }

        /// <summary>
        /// Create a RestApiStandardException from a JSON payload
        /// </summary>
        /// <param name="json">JSON string to parse</param>
        public static RestApiStandardException FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RestApiStandardException>(json);
        }
    }
}
