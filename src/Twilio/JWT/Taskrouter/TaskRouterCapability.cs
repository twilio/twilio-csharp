using System;
using System.Collections.Generic;

namespace Twilio.Jwt.Taskrouter
{
	public class TaskRouterCapability : BaseJwt
	{
		private readonly string _accountSid;
		private readonly string _workspaceSid;
		private readonly string _friendlyName;
		private readonly string _channelId;
		private readonly List<Policy> _policies;

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

		public override Dictionary<string, object> Headers
		{
			get
			{
				return new Dictionary<string, object>();
			}
		}

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
