using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.IpMessaging
{
    /// <summary>
    /// Twilio Ip Messaging API wrapper.
    /// </summary>
    public partial class IpMessagingClient : TwilioClient
    {
        /// <summary>
        /// Initializes an Ip Messaging API client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with.</param>
        /// <param name="authToken">The AuthToken to authenticate with.</param>
        public IpMessagingClient(string accountSid, string authToken) : 
            base(accountSid, authToken, accountSid, "v1", "https://ip-messaging.twilio.com/") {

                DateFormat = null;
        }

        /// <summary>
        /// Initializes an Ip Messaging API client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with.</param>
        /// <param name="authToken">The AuthToken to authenticate with.</param>
        /// <param name="accountResourceSid">The AccountResourceSid to authenticate with.</param>
        /// <param name="apiVersion">The Version of API you are trying to access.</param>
        /// <param name="baseUrl">The BaseUrl of API you are trying to access.</param>
        public IpMessagingClient(string accountSid, string authToken, 
            string accountResourceSid, string apiVersion, string baseUrl) :
            base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl) {

                DateFormat = null;
        }
    }
}
