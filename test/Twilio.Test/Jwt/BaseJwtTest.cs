using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Jwt;
using Twilio.Tests.Jwt;

namespace Twilio.Tests.Jwt
{
    class TestJwt : BaseJwt
    {
        public static string SECRET = "superduperduperdupersecret";
        
        private DateTime? _nbf;

        public TestJwt(DateTime exp, DateTime? nbf = null) : base(TestJwt.SECRET, "issuer", exp)
        {
            this._nbf = nbf;
        }

        public override Dictionary<string, object> Headers => new Dictionary<string, object>();
        public override Dictionary<string, object> Claims => new Dictionary<string, object>();
        public override DateTime? Nbf { get => this._nbf; }
    }
        
    }
    public class BaseJwtTest
    {
        [Test]
        public void TestSetUtcExp()
        {
            var exp = new DateTime(1993, 9, 7, 9, 0, 0, DateTimeKind.Utc);

            var encoded = new TestJwt(exp).ToJwt();
            var decoded = new DecodedJwt(encoded, TestJwt.SECRET);

            // 9/7/1993 9:00am (utc) in unix timestamp form
            Assert.AreEqual(747392400, decoded.Payload["exp"]);
        }
        
        [Test]
        public void TestSetLocalTimeExp()
        {
            var exp = new DateTime(1993, 9, 7, 9, 0, 0, DateTimeKind.Local);

            var encoded = new TestJwt(exp).ToJwt();
            var decoded = new DecodedJwt(encoded, TestJwt.SECRET);

            // 9/7/1993 4:00pm (utc) in unix timestamp form
            Assert.AreEqual(747417600, decoded.Payload["exp"]);
        }
        
        [Test]
        public void TestSetUtcNbf()
        {
            var nbf = new DateTime(1993, 9, 7, 9, 0, 0, DateTimeKind.Utc);

            var encoded = new TestJwt(DateTime.UtcNow, nbf).ToJwt();
            var decoded = new DecodedJwt(encoded, TestJwt.SECRET);

            // 9/7/1993 9:00am (utc) in unix timestamp form
            Assert.AreEqual(747392400, decoded.Payload["nbf"]);
        }
        
        [Test]
        public void TestSetLocalTimeNbf()
        {
            var nbf = new DateTime(1993, 9, 7, 9, 0, 0, DateTimeKind.Local);

            var encoded = new TestJwt(DateTime.UtcNow, nbf).ToJwt();
            var decoded = new DecodedJwt(encoded, TestJwt.SECRET);

            // 9/7/1993 4:00pm (utc) in unix timestamp form
            Assert.AreEqual(747417600, decoded.Payload["nbf"]);
        }
    }