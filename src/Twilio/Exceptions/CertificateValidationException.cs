using System;
using Twilio.Http;

namespace Twilio.Exceptions
{
    /// <summary>
    /// Error thrown specifically when validating SSL connection
    /// </summary>
    public class CertificateValidationException : TwilioException
    {
        /// <summary>
        /// Request object that triggered the exception
        /// </summary>
        public Request Request { get; }

        /// <summary>
        /// Response object that triggered the exception, if available
        /// </summary>
        public Response Response { get; }

        /// <summary>
        /// Construct a CertificateValidationException
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="request">The Request that triggered the exception</param>
        /// <param name="response">The Response (if available) that triggered the exception</param>
        public CertificateValidationException(string message, Request request, Response response)
            : base(message)
        {
            Request = request;
            Response = response;
        }

        /// <summary>
        /// Construct a CertificateValidationException
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="exception">The parent exception</param>
        /// <param name="request">The Request that triggered the exception</param>
        public CertificateValidationException(string message, Exception exception, Request request)
            : base(message, exception)
        {
            Request = request;
        }
    }
}
