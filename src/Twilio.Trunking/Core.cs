using System;

namespace Twilio.Trunking
{
    /// <summary>
    /// The Twilio SIP Trunking API allows you to control Elastic SIP Trunks.
    /// </summary>
    public partial class TrunkingClient : TwilioClient
    {
        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public TrunkingClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public TrunkingClient(string accountSid, string authToken, string accountResourceSid)
            : base(accountSid, authToken, accountResourceSid, "v1", "https://trunking.twilio.com/") { }

        public TrunkingClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) :
            base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl) { }
    }
}
