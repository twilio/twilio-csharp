using System;
using System.Collections.Generic;

namespace Twilio.Jwt.Taskrouter
{
    /// <summary>
    /// JWT for TaskRouter use
    /// </summary>
    public class TaskRouterCapability : BaseJwt
    {
        private readonly string _accountSid;
        private readonly string _workspaceSid;
        private readonly string _friendlyName;
        private readonly string _channelId;
        private readonly List<Policy> _policies;

        /// <summary>
        /// Create a new TaskRouter JWT
        /// </summary>
        /// <param name="accountSid">Twilio account SID</param>
        /// <param name="authToken">Twilio auth token</param>
        /// <param name="workspaceSid">TaskRouter workspace SID</param>
        /// <param name="channelId">TaskRouter channel ID</param>
        /// <param name="friendlyName">Friendly name for this JWT</param>
        /// <param name="expiration">JWT expiration</param>
        /// <param name="policies">JWT policies</param>
        public TaskRouterCapability(
            string accountSid,
            string authToken,
            string workspaceSid,
            string channelId,
            string friendlyName = null,
            DateTime? expiration = null,
            List<Policy> policies = null
        ) : base(authToken, accountSid, expiration.HasValue ? expiration.Value : DateTime.UtcNow.AddSeconds(3600))
        {
            this._accountSid = accountSid;
            this._workspaceSid = workspaceSid;
            this._channelId = channelId;
            this._friendlyName = friendlyName;
            this._policies = policies;
        }

        /// <summary>
        /// Get the JWT headers
        /// </summary>
        public override Dictionary<string, object> Headers
        {
            get
            {
                return new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Generate JWT payload
        /// </summary>
        public override Dictionary<string, object> Claims
        {
            get
            {
                var payload = new Dictionary<string, object>
                {
                    { "version", "v1" },
                    { "account_sid", _accountSid },
                    { "friendly_name", _friendlyName },
                    { "workspace_sid", _workspaceSid },
                    { "channel", _channelId }
                };

                if (_channelId.StartsWith("WK"))
                {
                    payload.Add("worker_sid", _channelId);
                }
                else if (_channelId.StartsWith("WQ"))
                {
                    payload.Add("taskqueue_sid", _channelId);
                }

                var payloadPolicies = new List<object>();
                foreach (var policy in PolicyUtils.DefaultEventBridgePolicies(_accountSid, _channelId))
                {
                    payloadPolicies.Add(policy.ToDict());
                }

                if (_policies != null)
                {
                    foreach (var policy in _policies)
                    {
                        payloadPolicies.Add(policy.ToDict());
                    }
                }

                payload.Add("policies", payloadPolicies);
                return payload;
            }
        }
    }
}
