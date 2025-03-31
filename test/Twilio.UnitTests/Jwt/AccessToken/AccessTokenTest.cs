using System;
using System.Collections;
using System.Collections.Generic;

using Twilio.Jwt;
using Twilio.Jwt.AccessToken;
using Newtonsoft.Json;

namespace Twilio.UnitTests.Jwt.AccessToken
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

    
    public class AccessTokenTests
    {
        private static readonly string Secret = "superdupersecretsecretITHASTOBEEVENLONGERTHOGUH";

        private Dictionary<string, object> ToDict(object o)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(o.ToString());
        }

        [Fact]
        public void TestBuildToken()
        {
            var jwt = new TestToken("AC456", "SK123", Secret).ToJwt();

            var decoded = new DecodedJwt(jwt, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);

            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));
            Assert.Equal("{}", payload["grants"].ToString());
        }

        [Fact]
        public void TestHaveRegion()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret, region: "foo").ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var header = decoded.Header;
            Assert.NotNull(header);
            Assert.Equal("twilio-fpa;v=1", header["cty"]);
            Assert.Equal("foo", header["twr"]);
        }

        [Fact]
        public void TestEmptyRegion()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret).ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var header = decoded.Header;
            Assert.NotNull(header);
            Assert.Equal("twilio-fpa;v=1", header["cty"]);
            
            try {
                var twr = header["twr"];
                Assert.Fail();
            } catch (KeyNotFoundException) {
                // Pass
            }
        }

        [Fact]
        public void TestHaveNbf()
        {
            var now = DateTime.UtcNow;
            var token = new TestToken("AC456", "SK123", Secret, nbf: now).ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.Equal(BaseJwt.ConvertToUnixTimestamp(now), Convert.ToInt64(payload["nbf"]));
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            Assert.Equal("{}", payload["grants"].ToString());
        }

        [Fact]
        public void TestAddGrant()
        {
            var grants = new HashSet<IGrant>
            {
                { new ConversationsGrant() }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);
            Assert.NotNull(decodedGrants["rtc"]);
        }

        [Fact]
        public void TestAddGrants()
        {
            var grants = new HashSet<IGrant>
            {
                { new ConversationsGrant() },
                { new IpMessagingGrant() }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Equal(2, decodedGrants.Count);
            Assert.NotNull(decodedGrants["rtc"]);
            Assert.NotNull(decodedGrants["ip_messaging"]);
        }

        [Fact]
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
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedPvg = decodedGrants["voice"];
            var incoming = ToDict(decodedPvg.ToString())["incoming"];
            Assert.Equal(true, ToDict(incoming)["allow"]);

            var outgoing = ToDict(decodedPvg.ToString())["outgoing"];
            Assert.Equal("AP123", ToDict(outgoing)["application_sid"]);

            var decodedParams = ToDict(outgoing)["params"];
            Assert.Equal("bar", ToDict(decodedParams)["foo"]);
        }

        [Fact]
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
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedCg = ToDict(decodedGrants["chat"]);
            Assert.Equal("IS123", decodedCg["service_sid"]);
            Assert.Equal("foobar", decodedCg["endpoint_id"]);
        }

        [Fact]
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
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedSg = ToDict(decodedGrants["data_sync"]);
            Assert.Equal("IS123", decodedSg["service_sid"]);
            Assert.Equal("foobar", decodedSg["endpoint_id"]);

        }

        [Fact]
        public void TestCreateVideoGrant()
        {
            var grants = new HashSet<IGrant>
            {
                { new VideoGrant { Room = "RM123" } }
            };
            var token = new TestToken("AC456", "SK123", Secret, grants: grants).ToJwt();
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedVg = ToDict(decodedGrants["video"]);
            Assert.Equal("RM123", decodedVg["room"]);
        }

        [Fact]
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
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedVg = ToDict(decodedGrants["player"]);
            Assert.Null(decodedVg["requestCredentials"]);
            Assert.Equal("https://000.us-east-1.playback.live-video.net/api/video/v1/us-east-000.channel.000?token=xxxxx", decodedVg["playbackUrl"]);
            Assert.Equal("VJXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", decodedVg["playerStreamerSid"]);
        }
        
        [Fact]
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
            Assert.NotNull(token);
            Assert.NotEmpty(token);

            var decoded = new DecodedJwt(token, Secret);
            var payload = decoded.Payload;
            Assert.NotNull(payload);

            Assert.Equal("SK123", payload["iss"]);
            Assert.Equal("AC456", payload["sub"]);
            Assert.True(Convert.ToInt64(payload["exp"]) > BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow));

            var decodedGrants = ToDict(payload["grants"]);
            Assert.Single(decodedGrants);

            var decodedCg = ToDict(decodedGrants["task_router"]);
            Assert.Equal("WSxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", decodedCg["workspace_sid"]);
            Assert.Equal("WKxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", decodedCg["worker_sid"]);
            Assert.Equal("worker", decodedCg["role"]);
        }

    }
}
