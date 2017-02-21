using System;

namespace Twilio.Exceptions
{
    /// <summary>
    /// POCO to represent an API Exception
    /// </summary>
    public class ApiException : TwilioException
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
        /// More info if any was provided
        /// </summary>
        public string MoreInfo { get; }

        /// <summary>
        /// Create a ApiException with message
        /// </summary>
        /// <param name="message">Exception message</param>
        public ApiException(string message) : base(message) {}

        /// <summary>
        /// Create an ApiException from another Exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="exception">Exception to copy detatils from</param>
        public ApiException(string message, Exception exception) : base(message, exception) {}

        /// <summary>
        /// Create an ApiException
        /// </summary>
        /// <param name="code">Twilio error code</param>
        /// <param name="status">HTTP status code</param>
        /// <param name="message">Error message</param>
        /// <param name="moreInfo">More info if provided</param>
        /// <param name="exception">Original exception</param>
        public ApiException(
            int code,
            int status,
            string message,
            string moreInfo,
            Exception exception = null
        ) : base(message, exception)
        {
            Code = code;
            Status = status;
            MoreInfo = moreInfo;
        }
    }
}

