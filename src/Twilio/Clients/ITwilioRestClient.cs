using Twilio.Http;

namespace Twilio.Clients
{
    /// <summary>
    /// Interface for a Twilio Client
    /// </summary>
    public interface ITwilioRestClient
    {
        /// <summary>
        /// Get the account sid all requests are made against
        /// </summary>
        string AccountSid { get; }

        /// <summary>
        /// Get the region requests are made against
        /// </summary>
        string Region { get; }

        /// <summary>
        /// Get the http client that makes requests
        /// </summary>
        HttpClient HttpClient { get; }

        /// <summary>
        /// Make a request to Twilio
        /// </summary>
        ///
        /// <param name="request">Request to make</param>
        /// <returns>response of the request</returns>
        Response Request(Request request);

#if !NET35
        /// <summary>
        /// Make a request to Twilio
        /// </summary>
        ///
        /// <param name="request">Request to make</param>
        /// <returns>response of the request</returns>
        System.Threading.Tasks.Task<Response> RequestAsync(Request request);
#endif
    }
}

