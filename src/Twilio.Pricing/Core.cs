using System;

namespace Twilio.Pricing
{
    /// <summary>
    /// Twilio Pricing API wrapper.
    /// </summary>
    public partial class PricingClient : TwilioClient
    {

        /// <summary>
        /// Initializes a Pricing API client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with.</param>
        /// <param name="authToken">The AuthToken to authenticate with.</param>
        public PricingClient(string accountSid, string authToken) : base(accountSid, authToken, accountSid, "v1", "https://pricing.twilio.com/") { }
    }
}

