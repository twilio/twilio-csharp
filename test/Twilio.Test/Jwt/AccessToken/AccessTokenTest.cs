using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Jwt.AccessToken;
using Newtonsoft.Json;

namespace Twilio.Tests.Jwt.AccessToken
{
    class TestToken : Token
    {
        public TestToken(
            string accountSid,
            string signingKeySid,
            string secret,
            string identity = null,
            DateTime? expiration = null,
            DateTime? nbf = null,
            HashSet<IGrant> grants = null,
            string region = null
        ) : base(accountSid, signingKeySid, secret, identity, expiration, nbf, grants, region) {}
    }

    [TestFixture]
    public class AccessTokenTests
    {
        private static readonly string Secret = "superdupersecretsecret";

        private Dictionary<string, object> ToDict(object o)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(o.ToString());
        }

        [Test]
        public void TestBuildToken()
        {
            var jwt = new TestToken("AC456", "SK123", Secret).ToJwt();

            var decoded = new DecodedJwt(jwt, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);

            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
            Assert.AreEqual("{}", payload["grants"].ToString());
        }

        [Test]
        public void TestHaveRegion()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret, region: "foo").ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var header = decoded.Header;
            Assert.IsNotNull(header);
            Assert.AreEqual("twilio-fpa;v=1", header["cty"]);
            Assert.AreEqual("foo", header["twr"]);
        }

        [Test]
        public void TestEmptyRegion()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var header = decoded.Header;
            Assert.IsNotNull(header);
            Assert.AreEqual("twilio-fpa;v=1", header["cty"]);
            
            try {
                var twr = header["twr"];
                Assert.Fail();
            } catch (KeyNotFoundException) {
                // Pass
            }
        }

        [Test]
        public void TestHaveNbf()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret, nbf: now).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.AreEqual(BaseJwt.ConvertToUnixTimestamp(now), Convert.ToInt64(payload["nbf"]));
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            Assert.AreEqual("{}", payload["grants"].ToString());
        }

        [Test]
        public void TestAddGrant()
        {
            var grants = new HashSet<IGrant>
            {
                { new ConversationsGrant() }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);
            Assert.IsNotNull(decodedGrants["rtc"]);
        }

        [Test]
        public void TestAddGrants()
        {
            var grants = new HashSet<IGrant>
            {
                { new ConversationsGrant() },
                { new IpMessagingGrant() }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(2, decodedGrants.Count);
            Assert.IsNotNull(decodedGrants["rtc"]);
            Assert.IsNotNull(decodedGrants["ip_messaging"]);
        }

        [Test]
        public void TestCreateVoiceGrant()
        {
            var grants = new HashSet<IGrant>
            {
                {
                    new VoiceGrant
                    {
                        IncomingAllow = true,
                        OutgoingApplicationSid = "AP123",
                        OutgoingApplicationParams = new Dictionary<string, string> { { "foo", "bar" } }
                    }
                }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedPvg = decodedGrants["voice"];
            var incoming = ToDict(decodedPvg.ToString())["incoming"];
            Assert.AreEqual(true, ToDict(incoming)["allow"]);

            var outgoing = ToDict(decodedPvg.ToString())["outgoing"];
            Assert.AreEqual("AP123", ToDict(outgoing)["application_sid"]);

            var decodedParams = ToDict(outgoing)["params"];
            Assert.AreEqual("bar", ToDict(decodedParams)["foo"]);
        }

        [Test]
        public void TestTaskRouterProperties()
        {
            var taskRouterGrant = new TaskRouterGrant();
            taskRouterGrant.WorkspaceSid = "WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            Assert.AreEqual("WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", taskRouterGrant.WorkspaceSid);
        }
        
        [Test]
        public void TestCheckTaskRouter()
        {
            var taskRouterGrant = new TaskRouterGrant
            {
                WorkspaceSid = "WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                WorkerSid = "WKxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                Role = "worker"
            };
    
            Assert.IsNotNull(taskRouterGrant);
            Assert.AreEqual("task_router", taskRouterGrant.Key);
            var taskRouterPayload = (Dictionary<string, string>)(taskRouterGrant.Payload);
            Assert.AreEqual(3, taskRouterPayload.Count);
            Assert.AreEqual("WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", taskRouterPayload["workspace_sid"]);
            Assert.AreEqual("WKxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", taskRouterPayload["worker_sid"]);
            Assert.AreEqual("worker", taskRouterPayload["role"]);
        }
        
        [Test]
        public void TestCreateTaskRouterGrant()
        {
            var grants = new HashSet<IGrant>
            {
                {
                    new TaskRouterGrant
                    {
                        WorkspaceSid = "WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                        WorkerSid = "WKxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                        Role = "worker"
                    }
                }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedCg = ToDict(decodedGrants["task_router"]);
            Assert.AreEqual("WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", decodedCg["workspace_sid"]);
            Assert.AreEqual("WKxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", decodedCg["worker_sid"]);
            Assert.AreEqual("worker", decodedCg["role"]);
        }

        [Test]
        public void TestCreateChatGrant()
        {
            var grants = new HashSet<IGrant>
            {
                {
                    new ChatGrant
                    {
                        ServiceSid = "IS123",
                        EndpointId = "foobar"
                    }
                }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedCg = ToDict(decodedGrants["chat"]);
            Assert.AreEqual("IS123", decodedCg["service_sid"]);
            Assert.AreEqual("foobar", decodedCg["endpoint_id"]);
        }

        [Test]
        public void TestCreateSyncGrant()
        {
            var grants = new HashSet<IGrant>
            {
                {
                    new SyncGrant
                    {
                        ServiceSid = "IS123",
                        EndpointId = "foobar"
                    }
                }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedSg = ToDict(decodedGrants["data_sync"]);
            Assert.AreEqual("IS123", decodedSg["service_sid"]);
            Assert.AreEqual("foobar", decodedSg["endpoint_id"]);

        }

        [Test]
        public void TestCreateVideoGrant()
        {
            var grants = new HashSet<IGrant>
            {
                { new VideoGrant { Room = "RM123" } }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedVg = ToDict(decodedGrants["video"]);
            Assert.AreEqual("RM123", decodedVg["room"]);
        }

        [Test]
        public void TestCreatePlaybackGrant()
        {
            var grants = new HashSet<IGrant>
            {
                {
                    new PlaybackGrant {
                        Grant =  new Dictionary<string, object> {
                            { "requestCredentials", null },
                            { "playbackUrl", "https://000.us-east-1.playback.live-video.net/api/video/v1/us-east-000.channel.000?token=xxxxx" },
                            { "playerStreamerSid", "VJXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" },
                        }
                    }
                }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.IsNotNull(token);
            Assert.IsNotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.Greater(Convert.ToInt64(payload["exp"]), BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.AreEqual(1, decodedGrants.Count);

            var decodedVg = ToDict(decodedGrants["player"]);
            Assert.AreEqual(null, decodedVg["requestCredentials"]);
            Assert.AreEqual("https://000.us-east-1.playback.live-video.net/api/video/v1/us-east-000.channel.000?token=xxxxx", decodedVg["playbackUrl"]);
            Assert.AreEqual("VJXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", decodedVg["playerStreamerSid"]);
        }

    }
}
