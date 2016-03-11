using System;

namespace Twilio.Monitor
{
    /// <summary>
    /// The Twilio Monitor API allows you to retrieve information about events.
    /// </summary>
    public partial class MonitorClient : TwilioClient
    {
        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public MonitorClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public MonitorClient(string accountSid, string authToken, string accountResourceSid)
            : base(accountSid, authToken, accountResourceSid, "v1", "https://monitor.twilio.com/")
        {
            DateFormat = null;
        }

        public MonitorClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) :
            base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl)
        {
            DateFormat = null;
        }
    }
}
