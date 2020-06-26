using System.Net;
using System.Net.Http.Headers;

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
        public HttpResponseHeaders Headers { get; }

        /// <summary>
        /// Create a new Response
        /// </summary>
        /// <param name="statusCode">HTTP status code</param>
        /// <param name="content">Content string</param>
        /// <param name="headers">Headers</param>
        public Response(HttpStatusCode statusCode, string content, HttpResponseHeaders headers = null)
        {
            StatusCode = statusCode;
            Content = content;
            Headers = headers;
        }
    }
}
