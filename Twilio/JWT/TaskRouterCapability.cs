using System;
using System.Collections.Generic;
using System.Linq;
using JWT;

namespace Twilio.JWT
{
    /// <summary>
    /// Capability Token for TaskRouter resources.
    /// </summary>
    public class TaskRouterCapability
    {
        private const string TaskRouterUrlBase = "https://taskrouter.twilio.com";
        private const string TaskRouterVersion = "v1";
        private const string TaskRouterEventsUrlBase = "https://event-bridge.twilio.com/v1/wschannels";

        private readonly string _workspaceSid;
        private readonly string _channelId;
        private readonly string _baseUrl;
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly List<Policy> _policies;

        private string _resourceUrl;

        /// <summary>
        /// Creates a new TaskRouterCapability token generator for Twilio TaskRouter.
        /// </summary>
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="channelId">The websocket channel to listen on.</param>
        public TaskRouterCapability(string accountSid, string authToken, string workspaceSid, string channelId) {
            _accountSid = accountSid;
            _authToken = authToken;
            _workspaceSid = workspaceSid;
            _channelId = channelId;

            _policies = new List<Policy>();
            _baseUrl = TaskRouterUrlBase + "/" + TaskRouterVersion + "/Workspaces/" + workspaceSid;

            ValidateJwt();
            SetupResource();

            // add permissions to GET and POST to the event-bridge channel
            AllowWebsockets(channelId);

            // add permissions to fetch the instance resource
            AddPolicy(_resourceUrl, "GET");
        }

        private void SetupResource() {
            if (_channelId.Substring(0, 2).Equals("WS"))
            {
                _resourceUrl = _baseUrl;
            }
            else if (_channelId.Substring(0, 2).Equals("WK"))
            {
                _resourceUrl = _baseUrl + "/Workers/" + _channelId;
                var activityUrl = _baseUrl + "/Activities";
                var tasksUrl = _baseUrl + "/Tasks/**";
                var workerReservationsUrl = _resourceUrl + "/Reservations/**";

                // add permissions to fetch the list of activities, tasks, and worker reservations
                AddPolicy(activityUrl, "GET");
                AddPolicy(tasksUrl, "GET");
                AddPolicy(workerReservationsUrl, "GET");
            }
            else if (_channelId.Substring(0, 2).Equals("WQ"))
            {
                _resourceUrl = _baseUrl + "/TaskQueues/" + _channelId;
            }
        }

        private void AllowWebsockets(string channelId)
        {
            var wsUrl = TaskRouterEventsUrlBase + "/" + _accountSid + "/" + channelId;
            _policies.Add(new Policy(wsUrl, "GET"));
            _policies.Add(new Policy(wsUrl, "POST"));
        }

        private void ValidateJwt() {
            if (_accountSid == null || !_accountSid.Substring(0, 2).Equals("AC"))
            {
                throw new Exception("Invalid AccountSid provided: " + _accountSid);
            }

            if (_workspaceSid == null || !_workspaceSid.Substring(0, 2).Equals("WS"))
            {
                throw new Exception("Invalid WorkspaceSid provided: " + _workspaceSid);
            }

            if (_channelId == null)
            {
                throw new Exception("ChannelId not provided");
            }

            var prefix = _channelId.Substring(0, 2);
            if (!prefix.Equals("WS") && !prefix.Equals("WK") && !prefix.Equals("WQ"))
            {
                throw new Exception("Invalid ChannelId provided: " + _channelId);
            }
        }

        private string GenerateToken(int ttlSeconds, Dictionary<string, string> extraAttributes)
        {
            var ps = _policies.Select(p => p.ToDict()).ToArray();
            var payload = new Dictionary<string, object>
            {
                {"iss", _accountSid},
                {"exp", ConvertToUnixTimestamp(DateTime.UtcNow.AddSeconds(ttlSeconds))},
                {"version", TaskRouterVersion},
                {"friendly_name", _channelId},
                {"policies", ps}
            };

            foreach (var entry in extraAttributes) {
                payload.Add(entry.Key, entry.Value);
            }

            return JsonWebToken.Encode(payload, _authToken, JwtHashAlgorithm.HS256);
        }

        private static int ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }

        /// <summary>
        /// Add a policy to the Capability Token.
        /// </summary>
        ///
        /// <param name="url">url to expose</param>
        /// <param name="method">method to expose</param>
        /// <param name="allowed">allow requests for this token</param>
        /// <param name="queryFilter">allowed query parameters</param>
        /// <param name="postFilter">allowed post parameters</param>
        public void AddPolicy(
            string url,
            string method,
            bool allowed = true,
            Dictionary<string, Dictionary<string, bool>> queryFilter = null,
            Dictionary<string, Dictionary<string, bool>> postFilter = null
        )
        {
            _policies.Add(new Policy(url, method, queryFilter: queryFilter, postFilter: postFilter, allowed: allowed));
        }

        /// <summary>
        /// Allow fetching on the all subresources
        /// </summary>
        public void AllowFetchSubresources() {
            AddPolicy(_resourceUrl + "/**", "GET");
        }

        /// <summary>
        /// Allow updates on the current resource
        /// </summary>
        public void AllowUpdates() {
            AddPolicy(_resourceUrl, "POST");
        }

        /// <summary>
        /// Allow updates on all subresources
        /// </summary>
        public void AllowUpdatesSubresources() {
            AddPolicy(_resourceUrl + "/**", "POST");
        }

        /// <summary>
        /// Allow deletes on this resources
        /// </summary>
        public void AllowDelete() {
            AddPolicy(_resourceUrl, "DELETE");
        }

        /// <summary>
        /// All deletes all all subresources
        /// </summary>
        public void AllowDeleteSubresources()
        {
            AddPolicy(_resourceUrl + "/**", "DELETE");
        }

        /// <summary>
        /// Generate the token
        /// </summary>
        ///
        /// <param name="ttlSeconds">Time to live for the token - default: 3600 seconds</param>
        /// <returns>The generated JWT</returns>
        public string GenerateToken(int ttlSeconds = 3600)
        {
            var taskRouterAttributes = new Dictionary<string, string>
            {
                {"account_sid", _accountSid},
                {"workspace_sid", _workspaceSid},
                {"channel", _channelId}
            };

            var prefix = _channelId.Substring(0, 2);
            if (prefix.Equals("WK"))
            {
                taskRouterAttributes.Add("worker_sid", _channelId);
            }
            else if (prefix.Equals("WQ"))
            {
                taskRouterAttributes.Add("taskqueue_sid", _channelId);
            }

            return GenerateToken(ttlSeconds, taskRouterAttributes);
        }
    }

    public class TaskRouterWorkerCapability : TaskRouterCapability
    {
        /// <summary>
        /// Creates a new TaskRouterWorkerCapability token generator for Twilio TaskRouter.
        /// </summary>
        ///
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="workerSid">The worker to create a capability token for.</param>
        public TaskRouterWorkerCapability(
            string accountSid,
            string authToken,
            string workspaceSid,
            string workerSid
        ) : base(accountSid, authToken, workspaceSid, workerSid) {}
    }

    public class TaskRouterWorkspaceCapability : TaskRouterCapability
    {
        /// <summary>
        /// Creates a new TaskRouterWorkspaceCapability token generator for Twilio TaskRouter.
        /// </summary>
        ///
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        public TaskRouterWorkspaceCapability(
            string accountSid,
            string authToken,
            string workspaceSid
        ) : base(accountSid, authToken, workspaceSid, workspaceSid) {}
    }

    public class TaskRouterTaskQueueCapability : TaskRouterCapability
    {
        /// <summary>
        /// Creates a new TaskRouterTaskQueueCapability token generator for Twilio TaskRouter.
        /// </summary>
        ///
        /// <param name="accountSid">Your Twilio Account SID from your account dashboard</param>
        /// <param name="authToken">Your Twilio Auth Token from your account dashboard. Used to sign capability
        /// tokens and will not be included in token contents.</param>
        /// <param name="workspaceSid">The workspace to create a capability token for.</param>
        /// <param name="taskQueueSid">The taskqueue to create a capability token for.</param>
        public TaskRouterTaskQueueCapability(
            string accountSid,
            string authToken,
            string workspaceSid,
            string taskQueueSid
        ) : base(accountSid, authToken, workspaceSid, taskQueueSid) {}
    }
}
