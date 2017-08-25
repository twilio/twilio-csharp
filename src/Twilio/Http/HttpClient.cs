using System;

namespace Twilio.Http
{
    /// <summary>
    /// Base http client used to make Twilio requests
    /// </summary>
    public abstract class HttpClient
    {
        /// <summary>
        /// The last request made by this client
        /// </summary>
        public Request LastRequest { get; protected set; }

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
        public abstract Response MakeRequest(Request request);

#if !NET35
        /// <summary>
        /// Make an async request to Twilio, returns non-2XX responses as well
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <exception>throws exception on network or connection errors.</exception>
        /// <returns>response of the request</returns>
        public abstract System.Threading.Tasks.Task<Response> MakeRequestAsync(Request request);
#endif

        /// <summary>
        /// Set the authentication string for the request
        /// </summary>
        ///
        /// <param name="username">username of the request</param>
        /// <param name="password">password of the request</param>
        /// <returns>authentication string</returns>
        public string Authentication(string username, string password)
        {
            var credentials = username + ":" + password;
            var encoded = System.Text.Encoding.UTF8.GetBytes(credentials);
            return Convert.ToBase64String(encoded);
        }
    }
}
