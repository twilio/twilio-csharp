using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWT;

namespace Twilio.TaskRouter
{
    public class TaskRouterCapability {
        const string taskRouterUrlBase = "https://taskrouter.twilio.com";
        const string taskRouterVersion = "v1";
        const string taskRouterEventsUrlBase = "https://event-bridge.twilio.com/v1/wschannels";

        protected string workspaceSid;
        protected string channelId;
        protected string resourceUrl;
        protected string baseUrl;

        protected string accountSid;
        protected string authToken;
        protected List<Policy> policies;

        /// <summary>
        /// Creates a new TaskRouterCapability token generator for Twilio TaskRouter.
        /// </summary>
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="channelId">The websocket channel to listen on.</param>
        public TaskRouterCapability(string accountSid, string authToken, string workspaceSid, string channelId) {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.policies = new List<Policy>();

            this.workspaceSid = workspaceSid;
            this.channelId = channelId;

            this.baseUrl = taskRouterUrlBase + "/" + taskRouterVersion + "/Workspaces/" + workspaceSid;

            this.ValidateJWT();

            this.SetupResource();

            // add permissions to GET and POST to the event-bridge channel
            this.AllowWebsockets(channelId);

            // add permissions to fetch the instance resource
            this.AddPolicy(resourceUrl, "GET", true);
        }

        protected virtual void SetupResource() {
            if (channelId.Substring (0, 2).Equals("WS")) {
                this.resourceUrl = this.baseUrl;
            } else if (channelId.Substring (0, 2).Equals("WK")) {
                this.resourceUrl = this.baseUrl + "/Workers/" + channelId;
                string activityUrl = this.baseUrl + "/Activities";
                string tasksUrl = this.baseUrl + "/Tasks/**";
                string workerReservationsUrl = this.resourceUrl + "/Reservations/**";

                // add permissions to fetch the list of activities, tasks, and worker reservations
                this.Allow(activityUrl, "GET");
                this.Allow(tasksUrl, "GET");
                this.Allow(workerReservationsUrl, "GET");

            } else if (channelId.Substring (0, 2).Equals("WQ")) {
                this.resourceUrl = this.baseUrl + "/TaskQueues/" + channelId;
            }
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

        public void AddPolicy(string url, string method, bool allowed,
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {
            if (queryFilter == null) {
                queryFilter = new Dictionary<string, Dictionary<string, bool>>();
            }
            if (postFilter == null) {
                postFilter = new Dictionary<string, Dictionary<string, bool>> ();
            }

            var policy = new Policy (url, method, queryFilter, postFilter, allowed);
            policies.Add(policy);
        }

        public void Allow(string url, string method, 
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {

            this.AddPolicy(url, method, true, queryFilter, postFilter);
        }

        public void Deny(string url, string method, 
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null) {

            this.AddPolicy(url, method, false, queryFilter, postFilter);
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

        [Obsolete("Please use TaskRouterWorkerCapability.allowActivityUpdates instead.")]
        public void AllowWorkerActivityUpdates()
        {
            if (channelId.Substring (0, 2).Equals ("WK")) {
                var policy = new Policy (this.resourceUrl, "POST", true);
                policy.postFilter.Add ("ActivitySid", Policy.required);
                policies.Add (policy);
            } else {
                throw new Exception ("Deprecated function not applicable to non Worker");
            }
        }

        [Obsolete("Please use TaskRouterWorkerCapability instead; added automatically in constructor")]
        public void AllowWorkerFetchAttributes()
        {
            if (channelId.Substring (0, 2).Equals ("WK")) {
                policies.Add(new Policy(this.resourceUrl, "GET", true));
            } else {
                throw new Exception ("Deprecated function not applicable to non Worker");
            }
        }

        [Obsolete("Please use TaskRouterWorkerCapability.allowReservationUpdates instead.")]
        public void AllowTaskReservationUpdates()
        {
            if (channelId.Substring (0, 2).Equals ("WK")) {
                var policy = new Policy(this.baseUrl + "/Tasks/**", "POST", true);
                policy.postFilter.Add("ReservationStatus", Policy.required);
                policies.Add(policy);
            } else {
                throw new Exception ("Deprecated function not applicable to non Worker");
            }
        }

        public string GenerateToken()
        {
            return GenerateToken(3600);
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

            return GenerateToken(ttlSeconds, taskRouterAttributes);
        }

        private string GenerateToken(int ttlSeconds, 
            Dictionary<string, string> extraAttributes = null) {
            var ps = policies.Select(p => p.ToDict()).ToArray();
            var payload = new Dictionary<string, object> ();
            payload.Add("iss", accountSid);
            payload.Add("exp", ConvertToUnixTimestamp (DateTime.UtcNow.AddSeconds (ttlSeconds)));
            payload.Add("version", taskRouterVersion);
            payload.Add("friendly_name", this.channelId);
            payload.Add("policies", ps);
            foreach (KeyValuePair<string, string> entry in extraAttributes) {
                payload.Add(entry.Key, entry.Value);
            }

            return JsonWebToken.Encode(payload, authToken, JwtHashAlgorithm.HS256);
        }

        static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }

    public class TaskRouterWorkerCapability : TaskRouterCapability
    {
        private string tasksUrl;
        private string workerReservationsUrl;
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
            this.tasksUrl = this.baseUrl + "/Tasks/**";
            this.activityUrl = this.baseUrl + "/Activities";
            this.workerReservationsUrl = this.resourceUrl + "/Reservations/**";

            // add permissions to fetch the list of activities, tasks and worker reservations
            this.Allow(activityUrl, "GET");
            this.Allow(tasksUrl, "GET");
            this.Allow(workerReservationsUrl, "GET");
        }

        override
        protected void SetupResource() {
            this.resourceUrl = this.baseUrl + "/Workers/" + this.channelId;
        }

        public void AllowActivityUpdates()
        {
            var policy = new Policy(this.resourceUrl, "POST", true);
            policy.postFilter.Add("ActivitySid", Policy.required);
            policies.Add(policy);
        }

        public void AllowReservationUpdates()
        {
            this.Allow(this.tasksUrl, "POST");
            this.Allow(this.workerReservationsUrl, "POST");
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

        override
        protected void SetupResource() {
            this.resourceUrl = this.baseUrl;
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
        base(accountSid, authToken, workspaceSid, taskQueueSid)
        {
        }

        override
        protected void SetupResource() {
            this.resourceUrl = this.baseUrl + "/TaskQueues/" + this.channelId;
        }
    }
}
