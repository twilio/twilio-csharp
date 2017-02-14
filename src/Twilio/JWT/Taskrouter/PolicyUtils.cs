using System;
using System.Collections.Generic;
using Twilio.Http;

namespace Twilio.Jwt.Taskrouter
{
    public class PolicyUtils
    {
        private static readonly string TaskRouterEventUrl = "https://event-bridge.twilio.com/v1/wschannels";

        private PolicyUtils() {}

        public static List<Policy> DefaultEventBridgePolicies(string accountSid, string channelId)
        {
            var url = $"{TaskRouterEventUrl}/{accountSid}/{channelId}";
            return new List<Policy>
            {
                { new Policy(url, HttpMethod.Get) },
                { new Policy(url, HttpMethod.Post) }
            };
        }
    }
}
