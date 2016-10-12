using System;

namespace Twilio.Http
{
    /// <summary>
    /// Base http client used to make Twilio requests
    /// </summary>
    public abstract class HttpClient
    {
        /// <summary>
        /// Make the request to Twilio
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>response of the request</returns>
        public abstract Response MakeRequest(Request request);

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
