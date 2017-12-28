using System;
using System.Collections.Generic;
using Twilio.Http;

namespace Twilio.Jwt.Taskrouter
{
    /// <summary>
    /// Utility class for generating Policies
    /// </summary>
    public class PolicyUtils
    {
        private static readonly string TaskRouterEventUrl = "https://event-bridge.twilio.com/v1/wschannels";

        private PolicyUtils() {}

        /// <summary>
        /// Generate default event bridge policies
        /// </summary>
        /// <param name="accountSid">Twilio account SID</param>
        /// <param name="channelId">TaskRouter channel ID</param>
        /// <returns>Default event bridge policies</returns>
        public static List<Policy> DefaultEventBridgePolicies(string accountSid, string channelId)
        {
            var url = TaskRouterEventUrl + "/" + accountSid + "/" + channelId;
            return new List<Policy>
            {
                { new Policy(url, HttpMethod.Get) },
                { new Policy(url, HttpMethod.Post) }
            };
        }
    }
}
