using System;
using System.Collections.Generic;

namespace Twilio.Exceptions
{
    /// <summary>
    /// RFC 9457 compliant API Exception for HTTP APIs
    /// </summary>
    public class ApiStandardException : TwilioException
    {
        /// <summary>
        /// Twilio error code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// A URI reference identifying the problem type (RFC 9457)
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// A short, human-readable summary of the problem type (RFC 9457)
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem (RFC 9457)
        /// </summary>
        public string Instance { get; }

        /// <summary>
        /// Validation errors for this occurrence (RFC 9457 extension)
        /// </summary>
        public List<ErrorDetail> Errors { get; }

        /// <summary>
        /// Create an ApiStandardException with message
        /// </summary>
        /// <param name="message">Exception message</param>
        public ApiStandardException(string message) : base(message) { }

        /// <summary>
        /// Create an ApiStandardException from another Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="exception">Exception to copy details from</param>
        public ApiStandardException(string message, Exception exception) : base(message, exception) { }

        /// <summary>
        /// Create an ApiStandardException with RFC 9457 fields
        /// </summary>
        /// <param name="code">Twilio error code</param>
        /// <param name="status">HTTP status code</param>
        /// <param name="message">Error message (detail)</param>
        /// <param name="type">URI reference identifying the problem type (RFC 9457)</param>
        /// <param name="title">Short summary of the problem type (RFC 9457)</param>
        /// <param name="instance">URI identifying this specific occurrence (RFC 9457)</param>
        /// <param name="errors">Validation errors (RFC 9457)</param>
        /// <param name="exception">Original exception</param>
        public ApiStandardException(
            int code,
            int status,
            string message,
            string type,
            string title,
            string instance,
            List<ErrorDetail> errors,
            Exception exception = null
        ) : base(message, exception)
        {
            Code = code;
            Status = status;
            Type = type;
            Title = title;
            Instance = instance;
            Errors = errors;
        }
    }
}
