using System;
using Twilio.Annotations;

namespace Twilio.Http.BearerToken
{
    /// <summary>
    /// Base http client used to make Twilio requests
    /// </summary>
    [Deprecated]
    public abstract class TokenHttpClient
    {
        /// <summary>
        /// The last request made by this client
        /// </summary>
        public TokenRequest LastRequest { get; protected set; }

        /// <summary>
        /// The last response received by this client
        /// </summary>
        public Response LastResponse { get; protected set; }

        /// <summary>
        /// Make a request to Twilio, returns non-2XX responses as well
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <exception>throws exception on network or connection errors.</exception>
        /// <returns>response of the request</returns>
        public abstract Response MakeRequest(TokenRequest request);

#if !NET35
        /// <summary>
        /// Make an async request to Twilio, returns non-2XX responses as well
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <exception>throws exception on network or connection errors.</exception>
        /// <returns>response of the request</returns>
        public abstract System.Threading.Tasks.Task<Response> MakeRequestAsync(TokenRequest request);
#endif

    }
}
