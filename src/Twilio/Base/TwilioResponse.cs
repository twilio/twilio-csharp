using System.Net;

#if NET35
using Headers = System.Net.WebHeaderCollection;
#else
using Headers = System.Net.Http.Headers.HttpResponseHeaders;
#endif

namespace Twilio.Base
{
    /// <summary>
    /// Wrapper class that contains both the resource and HTTP response headers
    /// </summary>
    /// <typeparam name="T">The type of the resource</typeparam>
    public class TwilioResponse<T>
    {
        /// <summary>
        /// The resource data
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// HTTP response headers
        /// </summary>
        public Headers Headers { get; }

        /// <summary>
        /// HTTP status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Create a new TwilioResponse
        /// </summary>
        /// <param name="data">The resource data</param>
        /// <param name="headers">HTTP response headers</param>
        /// <param name="statusCode">HTTP status code</param>
        public TwilioResponse(T data, Headers headers, HttpStatusCode statusCode)
        {
            Data = data;
            Headers = headers;
            StatusCode = statusCode;
        }
    }
}
