using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWT;

namespace Twilio.TaskRouter
{
	public class TaskRouterCapability : CapabilityAPI {
		const string taskRouterUrlBase = "https://taskrouter.twilio.com";
		const string taskRouterVersion = "v1";
		const string taskRouterEventsUrlBase = "https://event-bridge.twilio.com/v1/wschannels";

		protected string workspaceSid;
		protected string channelId;
		protected string resourceUrl;
		protected string baseUrl;

		/// <summary>
		/// Creates a new TaskRouterCapability token generator for Twilio TaskRouter.
		/// </summary>
		/// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
		/// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
		/// tokens and will not be included in token contents.</param>
		/// <param name="workspaceSid">The workspace to create a capability token for.</param>
		/// <param name="channelId">The websocket channel to listen on.</param>
		public TaskRouterCapability(string accountSid, string authToken, string workspaceSid, string channelId, string resourceUrl = null) : 
		base(accountSid, authToken, taskRouterVersion, channelId) {
			this.workspaceSid = workspaceSid;
			this.channelId = channelId;

			this.baseUrl = taskRouterUrlBase + "/" + taskRouterVersion + "/Workspaces/" + workspaceSid;

			if (resourceUrl == null) {
				if (channelId.Substring (0, 2).Equals("WS")) {
					resourceUrl = this.baseUrl;
				} else if (channelId.Substring (0, 2).Equals("WK")) {
					resourceUrl = this.baseUrl + "/Workers/" + channelId;
				} else if (channelId.Substring (0, 2).Equals("WQ")) {
					resourceUrl = this.baseUrl + "/TaskQueues/" + channelId;
				}
			}

			this.resourceUrl = resourceUrl;

			// add permissions to GET and POST to the event-bridge channel
			this.AllowWebsockets(channelId);

			// add permissions to fetch the instance resource
			this.AddPolicy(resourceUrl, "GET", true);

			this.ValidateJWT();
		}

		private void AllowWebsockets(string channelId)
		{
			var wsUrl = taskRouterEventsUrlBase + "/" + accountSid + "/" + channelId;
			this.policies.Add(new Policy(wsUrl, "GET", true));
			this.policies.Add(new Policy(wsUrl, "POST", true));
		}

		private void ValidateJWT() {
			if(accountSid == null || !accountSid.Substring(0,2).Equals("AC")) {
				throw new Exception("Invalid AccountSid provided: "+accountSid);
			}
			if(workspaceSid == null || !workspaceSid.Substring(0,2).Equals("WS")) {
				throw new Exception("Invalid WorkspaceSid provided: "+workspaceSid);
			}
			if(channelId == null) {
				throw new Exception("ChannelId not provided");
			}
			var prefix = channelId.Substring(0,2);
			if(!prefix.Equals("WS") && !prefix.Equals("WK") && !prefix.Equals("WQ")) {
				throw new Exception("Invalid ChannelId provided: "+channelId);
			}
		}

		public void AllowFetchSubresources() {
			this.Allow(this.resourceUrl+"/**", "GET");
		}

		public void AllowUpdates() {
			this.Allow(this.resourceUrl, "POST");
		}

		public void AllowUpdatesSubresources() {
			this.Allow(this.resourceUrl+"/**", "POST");
		}

		public void AllowDelete() {
			this.Allow(this.resourceUrl, "DELETE");
		}

		public void AllowDeleteSubresources() {
			this.Allow(this.resourceUrl+"/**", "DELETE");
		}

		public string GetResourceUrl() {
			return this.resourceUrl;
		}
			
		public string GenerateToken(int ttlSeconds = 3600) {
			Dictionary<string, string> taskRouterAttributes = new Dictionary<string, string>();
			taskRouterAttributes.Add("account_sid", this.accountSid);
			taskRouterAttributes.Add("workspace_sid", this.workspaceSid);
			taskRouterAttributes.Add("channel", this.channelId);

			if(channelId.Substring(0,2).Equals("WK")) {
				taskRouterAttributes.Add("worker_sid", this.channelId);
			}else if(channelId.Substring(0,2).Equals("WQ")) {
				taskRouterAttributes.Add("taskqueue_sid", this.channelId);
			}

			return base.GenerateToken(ttlSeconds, taskRouterAttributes);
		}
	}

	public class TaskRouterWorkerCapability : TaskRouterCapability
    {
		private string reservationsUrl;
		private string activityUrl;

        /// <summary>
        /// Creates a new TaskRouterWorkerCapability token generator for Twilio TaskRouter.
        /// </summary>
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="workerSid">The worker to create a capability token for.</param>
		public TaskRouterWorkerCapability(string accountSid, string authToken, string workspaceSid, string workerSid) :
			base(accountSid, authToken, workspaceSid, workerSid)
        {
			this.reservationsUrl = this.baseUrl + "/Tasks/**";
			this.activityUrl = this.baseUrl + "/Activities";

			// add permissions to fetch the list of activities and list of worker reservations
			this.Allow(activityUrl, "GET");
			this.Allow(reservationsUrl, "GET");
        }

        public void AllowActivityUpdates()
        {
			var policy = new Policy(this.resourceUrl, "POST", true);
            policy.postFilter.Add("ActivitySid", Policy.required);
            policies.Add(policy);
        }

        public void AllowReservationUpdates()
        {
			var policy = new Policy(this.reservationsUrl, "POST", true);
            policies.Add(policy);
        }
    }

	public class TaskRouterWorkspaceCapability : TaskRouterCapability
	{
		/// <summary>
		/// Creates a new TaskRouterWorkspaceCapability token generator for Twilio TaskRouter.
		/// </summary>
		/// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
		/// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
		/// tokens and will not be included in token contents.</param>
		/// <param name="workspaceSid">The workspace to create a capability token for.</param>
		public TaskRouterWorkspaceCapability(string accountSid, string authToken, string workspaceSid) :
		base(accountSid, authToken, workspaceSid, workspaceSid)
		{
		}
	}

	public class TaskRouterTaskQueueCapability : TaskRouterCapability
	{
		/// <summary>
		/// Creates a new TaskRouterTaskQueueCapability token generator for Twilio TaskRouter.
		/// </summary>
		/// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
		/// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
		/// tokens and will not be included in token contents.</param>
		/// <param name="workspaceSid">The workspace to create a capability token for.</param>
		/// <param name="taskQueueSid">The taskqueue to create a capability token for.</param>
		public TaskRouterTaskQueueCapability(string accountSid, string authToken, string workspaceSid, string taskQueueSid) :
		base(accountSid, authToken, workspaceSid, workspaceSid, taskQueueSid)
		{
		}
	}
}
