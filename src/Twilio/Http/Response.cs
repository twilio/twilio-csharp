using System.Net;

#if NET35
using Headers = System.Net.WebHeaderCollection;
#else
using Headers = System.Net.Http.Headers.HttpResponseHeaders;
#endif

namespace Twilio.Http
{
    /// <summary>
    /// Twilio response
    /// </summary>
    public class Response
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Content string
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Headers
        /// </summary>
        public Headers Headers { get; }

        /// <summary>
        /// Create a new Response
        /// </summary>
        /// <param name="statusCode">HTTP status code</param>
        /// <param name="content">Content string</param>
        /// <param name="headers">Headers</param>
        public Response(HttpStatusCode statusCode, string content, Headers headers = null)
        {
            StatusCode = statusCode;
            Content = content;
            Headers = headers;
        }
    }
}
