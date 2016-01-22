using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JWT;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class CapabilityTests
    {

        [Test]
        public void ShouldAllowWorkspaceDefaults()
        {
            TaskRouterCapability cap = new TaskRouterCapability("AC123", "foobar", "WS456", "WS456");
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            Assert.AreEqual("AC123", payload["iss"]);
            Assert.AreEqual("AC123", payload["account_sid"]);
            Assert.AreEqual("WS456", payload["workspace_sid"]);
            Assert.AreEqual("WS456", payload["channel"]);
            Assert.AreEqual("v1", payload["version"]);
            Assert.AreEqual("WS456", payload["friendly_name"]);

            var policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(3, policies.Count);
            var url = "https://event-bridge.twilio.com/v1/wschannels/AC123/WS456";

            var getPolicy = policies[0] as IDictionary<string, object>;
            Assert.AreEqual(url, getPolicy["url"]);
            Assert.AreEqual("GET", getPolicy["method"]);
            Assert.IsTrue((bool) getPolicy["allow"]);
            var queryFilter = getPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = getPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var postPolicy = policies[1] as IDictionary<string, object>;
            Assert.AreEqual(url, postPolicy["url"]);
            Assert.AreEqual("POST", postPolicy["method"]);
            Assert.IsTrue((bool)postPolicy["allow"]);
            queryFilter = postPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = postPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var workspaceFetchPolicy = policies[2] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456", workspaceFetchPolicy["url"]);
            Assert.AreEqual("GET", workspaceFetchPolicy["method"]);
            Assert.IsTrue((bool)workspaceFetchPolicy["allow"]);
            queryFilter = workspaceFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = workspaceFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }

        [Test]
        public void ShouldAllowTaskQueueDefaults()
        {
            TaskRouterCapability cap = new TaskRouterCapability("AC123", "foobar", "WS456", "WQ789");
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            Assert.AreEqual("AC123", payload["iss"]);
            Assert.AreEqual("AC123", payload["account_sid"]);
            Assert.AreEqual("WS456", payload["workspace_sid"]);
            Assert.AreEqual("WQ789", payload["taskqueue_sid"]);
            Assert.AreEqual("WQ789", payload["channel"]);
            Assert.AreEqual("v1", payload["version"]);
            Assert.AreEqual("WQ789", payload["friendly_name"]);

            var policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(3, policies.Count);
            var url = "https://event-bridge.twilio.com/v1/wschannels/AC123/WQ789";

            var getPolicy = policies[0] as IDictionary<string, object>;
            Assert.AreEqual(url, getPolicy["url"]);
            Assert.AreEqual("GET", getPolicy["method"]);
            Assert.IsTrue((bool) getPolicy["allow"]);
            var queryFilter = getPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = getPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var postPolicy = policies[1] as IDictionary<string, object>;
            Assert.AreEqual(url, postPolicy["url"]);
            Assert.AreEqual("POST", postPolicy["method"]);
            Assert.IsTrue((bool)postPolicy["allow"]);
            queryFilter = postPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = postPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var taskQueueFetchPolicy = policies[2] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/TaskQueues/WQ789", taskQueueFetchPolicy["url"]);
            Assert.AreEqual("GET", taskQueueFetchPolicy["method"]);
            Assert.IsTrue((bool)taskQueueFetchPolicy["allow"]);
            queryFilter = taskQueueFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = taskQueueFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }

        [Test]
        public void ShouldAllowWorkerDefaults()
        {
            TaskRouterCapability cap = new TaskRouterCapability("AC123", "foobar", "WS456", "WK789");
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            Assert.AreEqual("AC123", payload["iss"]);
            Assert.AreEqual("AC123", payload["account_sid"]);
            Assert.AreEqual("WS456", payload["workspace_sid"]);
            Assert.AreEqual("WK789", payload["worker_sid"]);
            Assert.AreEqual("WK789", payload["channel"]);
            Assert.AreEqual("v1", payload["version"]);
            Assert.AreEqual("WK789", payload["friendly_name"]);

            var policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(6, policies.Count);
            var url = "https://event-bridge.twilio.com/v1/wschannels/AC123/WK789";

            var activitesFetchPolicy = policies[0] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Activities", activitesFetchPolicy["url"]);
            Assert.AreEqual("GET", activitesFetchPolicy["method"]);
            Assert.IsTrue((bool)activitesFetchPolicy["allow"]);
            var queryFilter = activitesFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = activitesFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var tasksFetchPolicy = policies[1] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Tasks/**", tasksFetchPolicy["url"]);
            Assert.AreEqual("GET", tasksFetchPolicy["method"]);
            Assert.IsTrue((bool)tasksFetchPolicy["allow"]);
            queryFilter = tasksFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = tasksFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var reservationsFetchPolicy = policies[2] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789/Reservations/**", reservationsFetchPolicy["url"]);
            Assert.AreEqual("GET", reservationsFetchPolicy["method"]);
            Assert.IsTrue((bool)reservationsFetchPolicy["allow"]);
            queryFilter = reservationsFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = reservationsFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var getPolicy = policies[3] as IDictionary<string, object>;
            Assert.AreEqual(url, getPolicy["url"]);
            Assert.AreEqual("GET", getPolicy["method"]);
            Assert.IsTrue((bool) getPolicy["allow"]);
            queryFilter = getPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = getPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var postPolicy = policies[4] as IDictionary<string, object>;
            Assert.AreEqual(url, postPolicy["url"]);
            Assert.AreEqual("POST", postPolicy["method"]);
            Assert.IsTrue((bool)postPolicy["allow"]);
            queryFilter = postPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = postPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var workerFetchPolicy = policies[5] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789", workerFetchPolicy["url"]);
            Assert.AreEqual("GET", workerFetchPolicy["method"]);
            Assert.IsTrue((bool)workerFetchPolicy["allow"]);
            queryFilter = workerFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = workerFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }

        [Test]
        public void ShouldAllowDeprecatedWorker()
        {
            TaskRouterCapability cap = new TaskRouterCapability("AC123", "foobar", "WS456", "WK789");
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            Assert.AreEqual("AC123", payload["iss"]);
            Assert.AreEqual("AC123", payload["account_sid"]);
            Assert.AreEqual("WS456", payload["workspace_sid"]);
            Assert.AreEqual("WK789", payload["worker_sid"]);
            Assert.AreEqual("WK789", payload["channel"]);
            Assert.AreEqual("v1", payload["version"]);
            Assert.AreEqual("WK789", payload["friendly_name"]);

            var policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(6, policies.Count);
            var url = "https://event-bridge.twilio.com/v1/wschannels/AC123/WK789";

            var activitesFetchPolicy = policies[0] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Activities", activitesFetchPolicy["url"]);
            Assert.AreEqual("GET", activitesFetchPolicy["method"]);
            Assert.IsTrue((bool)activitesFetchPolicy["allow"]);
            var queryFilter = activitesFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = activitesFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var tasksFetchPolicy = policies[1] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Tasks/**", tasksFetchPolicy["url"]);
            Assert.AreEqual("GET", tasksFetchPolicy["method"]);
            Assert.IsTrue((bool)tasksFetchPolicy["allow"]);
            queryFilter = tasksFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = tasksFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var reservationsFetchPolicy = policies[2] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789/Reservations/**", reservationsFetchPolicy["url"]);
            Assert.AreEqual("GET", reservationsFetchPolicy["method"]);
            Assert.IsTrue((bool)reservationsFetchPolicy["allow"]);
            queryFilter = reservationsFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = reservationsFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var getPolicy = policies[3] as IDictionary<string, object>;
            Assert.AreEqual(url, getPolicy["url"]);
            Assert.AreEqual("GET", getPolicy["method"]);
            Assert.IsTrue((bool) getPolicy["allow"]);
            queryFilter = getPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = getPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var postPolicy = policies[4] as IDictionary<string, object>;
            Assert.AreEqual(url, postPolicy["url"]);
            Assert.AreEqual("POST", postPolicy["method"]);
            Assert.IsTrue((bool)postPolicy["allow"]);
            queryFilter = postPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = postPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var workerFetchPolicy = policies[5] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789", workerFetchPolicy["url"]);
            Assert.AreEqual("GET", workerFetchPolicy["method"]);
            Assert.IsTrue((bool)workerFetchPolicy["allow"]);
            queryFilter = workerFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = workerFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }

    }
}
