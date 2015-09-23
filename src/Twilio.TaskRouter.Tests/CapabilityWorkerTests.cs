using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JWT;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class CapabilityWorkerTests
    {
        private TaskRouterWorkerCapability cap;

        [SetUp]
        public void Setup()
        {
            cap = new TaskRouterWorkerCapability("AC123", "foobar", "WS456", "WK789");
        }

        [Test]
        public void ShouldGenerateToken()
        {
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
        }

        [Test]
        public void ShouldGenerateTokenWithDefaultTtl()
        {
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            var expiration = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + 3600;

            Assert.AreEqual(expiration, payload["exp"]);
        }

        [Test]
        public void ShouldGenerateTokenWithSpecifiedTtl()
        {
            var token = cap.GenerateToken(10000);
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            var expiration = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + 10000;

            Assert.AreEqual(expiration, payload["exp"]);
        }

        [Test]
        public void ShouldAllowDefaults()
        {
            var token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;

            var policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(5, policies.Count);
            var url = "https://event-bridge.twilio.com/v1/wschannels/AC123/WK789";

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

            var workerFetchPolicy = policies[2] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789", workerFetchPolicy["url"]);
            Assert.AreEqual("GET", workerFetchPolicy["method"]);
            Assert.IsTrue((bool)workerFetchPolicy["allow"]);
            queryFilter = workerFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = workerFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var activitiesPolicy = policies[3] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Activities", activitiesPolicy["url"]);
            Assert.AreEqual("GET", activitiesPolicy["method"]);
            Assert.IsTrue((bool)activitiesPolicy["allow"]);
            queryFilter = activitiesPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = activitiesPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);

            var reservationsFetchPolicy = policies[4] as IDictionary<string, object>;
            Assert.AreEqual("https://taskrouter.twilio.com/v1/Workspaces/WS456/Tasks/**", reservationsFetchPolicy["url"]);
            Assert.AreEqual("GET", reservationsFetchPolicy["method"]);
            Assert.IsTrue((bool)reservationsFetchPolicy["allow"]);
            queryFilter = reservationsFetchPolicy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            postFilter = reservationsFetchPolicy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }

        [Test]
        public void ShouldAllowActivityUpdates()
        {
            var token = cap.GenerateToken();
            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            var policies = payload["policies"] as System.Collections.IList;
            var defaultPoliciesCount = policies.Count;

            cap.AllowActivityUpdates();
            token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;

            policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(defaultPoliciesCount+1, policies.Count);

            var url = "https://taskrouter.twilio.com/v1/Workspaces/WS456/Workers/WK789";
            var policy = policies[policies.Count-1] as IDictionary<string, object>;

            Assert.AreEqual(url, policy["url"]);
            Assert.AreEqual("POST", policy["method"]);
            Assert.IsTrue((bool)policy["allow"]);
            var queryFilter = policy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = policy["post_filter"] as IDictionary<string, object>;
            Assert.IsNotEmpty(postFilter);
            var required = postFilter["ActivitySid"] as IDictionary<string, object>;
            Assert.IsTrue((bool)required["required"]);
        }

        [Test]
        public void ShouldAllowReservationUpdates()
        {
            var token = cap.GenerateToken();
            var payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;
            var policies = payload["policies"] as System.Collections.IList;
            var defaultPoliciesCount = policies.Count;

            cap.AllowReservationUpdates();
            token = cap.GenerateToken();
            Assert.IsNotNullOrEmpty(token);

            payload = JsonWebToken.DecodeToObject(token, "foobar") as IDictionary<string, object>;

            policies = payload["policies"] as System.Collections.IList;
            Assert.AreEqual(defaultPoliciesCount+1, policies.Count);

            var url = "https://taskrouter.twilio.com/v1/Workspaces/WS456/Tasks/**";
            var policy = policies[policies.Count-1] as IDictionary<string, object>;

            Assert.AreEqual(url, policy["url"]);
            Assert.AreEqual("POST", policy["method"]);
            Assert.IsTrue((bool)policy["allow"]);
            var queryFilter = policy["query_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(queryFilter);
            var postFilter = policy["post_filter"] as IDictionary<string, object>;
            Assert.IsEmpty(postFilter);
        }
    }
}
