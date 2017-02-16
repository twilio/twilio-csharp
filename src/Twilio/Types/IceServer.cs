using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
    /// <summary>
    /// Ice Server POCO
    /// </summary>
    public class IceServer
    {
        /// <summary>
        /// Ice Server credential
        /// </summary>
        [JsonProperty("credential")]
        public string Credential { get; }

        /// <summary>
        /// Username for server
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; }

        /// <summary>
        /// Server URL
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; }

        /// <summary>
        /// Create a new IceServer
        /// </summary>
        /// <param name="credential">Ice Server credential</param>
        /// <param name="username">Server username</param>
        /// <param name="url">Server URL</param>
        public IceServer(string credential, string username, Uri url) {
            Credential = credential;
            Username = username;
            Url = url;
        }
    }
}

