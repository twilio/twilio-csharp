using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using NUnit.Framework;
using JWT;
using Twilio.JWT;

namespace Twilio.Tests.JWT
{
    [TestFixture]
    public class AccessTokenTests
    {
        [Test]
        public void ShouldBuildToken()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)Math.Floor(delta.TotalSeconds);
            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>)serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string)payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>)payload["grants"];
            Assert.AreEqual(0, grants.Count);
        }

        [Test]
        public void ShouldHaveNbf()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var now = DateTime.UtcNow;
            token.Nbf = AccessToken.ConvertToUnixTimestamp(now);

            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)Math.Floor(delta.TotalSeconds);
            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>)serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            Assert.AreEqual(AccessToken.ConvertToUnixTimestamp(now), payload["nbf"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string)payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>)payload["grants"];
            Assert.AreEqual(0, grants.Count);    
        }

        [Test]
        public void ShouldAddGrant()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)Math.Floor(delta.TotalSeconds);
            
            token.AddGrant(new ConversationsGrant());

            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>)serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string)payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>)payload["grants"];
            Assert.AreEqual(1, grants.Count);
            Assert.IsNotNull(grants["rtc"]);
        }

        [Test]
        public void ShouldAddGrants()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)Math.Floor(delta.TotalSeconds);

            token.AddGrant(new ConversationsGrant());
            token.AddGrant(new IpMessagingGrant());

            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>)serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string)payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>)payload["grants"];
            Assert.AreEqual(2, grants.Count);
            Assert.IsNotNull(grants["rtc"]);
            Assert.IsNotNull(grants["ip_messaging"]);
        }

        [Test]
        public void ShouldCreateVoiceGrant()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int)Math.Floor(delta.TotalSeconds);

            var pvg = new VoiceGrant {OutgoingApplicationSid = "AP123"};

            var param = new Dictionary<string, string> {{"foo", "bar"}};
            pvg.OutgoingApplicationParams = param;

            token.AddGrant(pvg);

            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
                Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>)serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string)payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>)payload["grants"];
            Assert.AreEqual(1, grants.Count);
         
            var decodedPvg = (Dictionary<string, object>)grants["voice"];
            var outgoing = (Dictionary<string, object>)decodedPvg["outgoing"];
            Assert.AreEqual("AP123", outgoing["application_sid"]);

            var decodedParams = (Dictionary<string, object>)outgoing["params"];
            Assert.AreEqual("bar", decodedParams["foo"]);
        }

        [Test]
        public void ShouldCreateSyncGrant()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int) Math.Floor(delta.TotalSeconds);

            var sg = new SyncGrant
            {
                ServiceSid = "IS123",
                EndpointId = "foobar"
            };

            token.AddGrant(sg);

            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>) serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string) payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>) payload["grants"];
            Assert.AreEqual(1, grants.Count);

            var decodedSg = (Dictionary<string, object>) grants["data_sync"];
            Assert.AreEqual("IS123", decodedSg["service_sid"]);
            Assert.AreEqual("foobar", decodedSg["endpoint_id"]);

        }

        [Test]
        public void ShouldCreateVideoGrant()
        {
            var token = new AccessToken("AC456", "SK123", "foobar");
            var delta = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var timestamp = (int) Math.Floor(delta.TotalSeconds);

            var vg = new VideoGrant {ConfigurationProfileSid = "CP123"};

            token.AddGrant(vg);

            var encoded = token.ToJwt();
            Assert.IsNotNull(encoded);
            Assert.IsNotEmpty(encoded);

            var decoded = JsonWebToken.Decode(encoded, "foobar");
            Assert.IsNotEmpty(decoded);
            var serializer = new JavaScriptSerializer();
            var payload = (Dictionary<string, object>) serializer.DeserializeObject(decoded);
            Assert.IsNotNull(payload);

            Assert.AreEqual("SK123", payload["iss"]);
            Assert.AreEqual("AC456", payload["sub"]);
            var exp = Convert.ToInt64(payload["exp"]);
            Assert.AreEqual(timestamp + 3600, exp);
            var jti = (string) payload["jti"];
            Assert.AreEqual("SK123-" + timestamp.ToString(), jti);

            var grants = (Dictionary<string, object>) payload["grants"];
            Assert.AreEqual(1, grants.Count);

            var decodedVg = (Dictionary<string, object>) grants["video"];
            Assert.AreEqual("CP123", decodedVg["configuration_profile_sid"]);
        }
    }
}
