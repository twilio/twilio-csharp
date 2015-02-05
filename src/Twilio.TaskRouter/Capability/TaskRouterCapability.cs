using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWT;

namespace Twilio.TaskRouter
{
    public class TaskRouterCapability
    {
        const string taskRouterUrlBase = "https://taskrouter.twilio.com";
        const string taskRouterVersion = "v1";
        const string taskRouterEventsUrlBase = "https://event-bridge.twilio.com/v1/wschannels";

        private string accountSid;
        private string authToken;
        private string workspaceSid;
        private string workerSid;
        private List<Policy> policies;

        /// <summary>
        /// Creates a new TaskRouterCapability token generator for Twilio TaskRouter.
        /// </summary>
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="workerSid">The worker to create a capability token for.</param>
        public TaskRouterCapability(string accountSid, string authToken, string workspaceSid, string workerSid)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.workspaceSid = workspaceSid;
            this.workerSid = workerSid;
            this.policies = new List<Policy>();
            this.AllowWorkerWebsockets();
        }

        public void AllowWorkerActivityUpdates()
        {
            var url = GetWorkerUrl();
            var policy = new Policy(url, "POST", true);
            policy.postFilter.Add("ActivitySid", Policy.required);
            policies.Add(policy);
        }

        public void AllowWorkerFetchAttributes()
        {
            var url = GetWorkerUrl();
            policies.Add(new Policy(url, "GET", true));
        }

        public void AllowTaskReservationUpdates()
        {
            var url = GetWorkspaceUrl() + "/Tasks/**";
            var policy = new Policy(url, "POST", true);
            policy.postFilter.Add("ReservationStatus", Policy.required);
            policies.Add(policy);
        }

        private string GetWorkspaceUrl()
        {
            return taskRouterUrlBase + "/" + taskRouterVersion + "/Accounts/" + accountSid + "/Workspaces/" + workspaceSid;
        }

        private string GetWorkerUrl()
        {
            return GetWorkspaceUrl() + "/Workers/" + workerSid;
        }

        private void AllowWorkerWebsockets()
        {
            var wsUrl = taskRouterEventsUrlBase + "/" + accountSid + "/" + workerSid;
            this.policies.Add(new Policy(wsUrl, "GET", true));
            this.policies.Add(new Policy(wsUrl, "POST", true));
        }

        public string GenerateToken()
        {
            return GenerateToken(3600);
        }

        public string GenerateToken(int ttlSeconds)
        {
            var ps = policies.Select(p => p.ToDict()).ToArray();
            var payload = new
            {
                iss = accountSid,
                exp = ConvertToUnixTimestamp(DateTime.UtcNow.AddSeconds(ttlSeconds)),
                version = taskRouterVersion,
                friendly_name = workerSid,
                account_sid = accountSid,
                workspace_sid = workspaceSid,
                worker_sid = workerSid,
                channel = workerSid,
                policies = ps
            };

            return JsonWebToken.Encode(payload, authToken, JwtHashAlgorithm.HS256);
        }

        static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}
