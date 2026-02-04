using System.Collections;
using System.Collections.Generic;
using System.Net;

#if NET35
using Headers = System.Net.WebHeaderCollection;
#else
using Headers = System.Net.Http.Headers.HttpResponseHeaders;
#endif

namespace Twilio.Base
{
    /// <summary>
    /// Wrapper class that contains both the resource set and HTTP response headers.
    /// Implements IEnumerable to allow direct iteration over records.
    /// </summary>
    /// <typeparam name="T">The type of the resource</typeparam>
    public class ResourceSetResponse<T> : IEnumerable<T> where T : Resource
    {
        /// <summary>
        /// The resource set containing the records
        /// </summary>
        public ResourceSet<T> Records { get; }

        /// <summary>
        /// HTTP response headers from the initial request
        /// </summary>
        public Headers Headers { get; }

        /// <summary>
        /// HTTP status code from the initial request
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Create a new ResourceSetResponse
        /// </summary>
        /// <param name="records">The resource set containing records</param>
        /// <param name="headers">HTTP response headers</param>
        /// <param name="statusCode">HTTP status code</param>
        public ResourceSetResponse(ResourceSet<T> records, Headers headers, HttpStatusCode statusCode)
        {
            Records = records;
            Headers = headers;
            StatusCode = statusCode;
        }

        /// <summary>
        /// Get enumerator for iterating over resources
        /// </summary>
        /// <returns>IEnumerator of resources</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Records.GetEnumerator();
        }

        /// <summary>
        /// Get enumerator for iterating over resources
        /// </summary>
        /// <returns>IEnumerator of resources</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
