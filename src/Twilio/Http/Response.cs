using System.Net;

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
        /// Create a new Response 
        /// </summary>
        /// <param name="statusCode">HTTP status code</param>
        /// <param name="content">Content string</param>
        public Response (HttpStatusCode statusCode, string content)
        {
            StatusCode = statusCode;
            Content = content;
        }
    }
}
