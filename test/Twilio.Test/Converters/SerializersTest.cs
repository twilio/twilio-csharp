using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Converters;

namespace Twilio.Tests.Converters
{
    [TestFixture]
    public class SerializersTest : TwilioTest {

        [Test]
        public void TestJsonObjectSerializesDictionary()
        {
            var inputDict = new Dictionary<string, string> {{"twilio", "rocks"}};
            var result = Serializers.JsonObject(inputDict);
            Assert.AreEqual("{\"twilio\":\"rocks\"}", result);
        }

        [Test]
        public void TestJsonObjectSerializesList()
        {
            var inputDict = new List<object>{
                "twilio",
                new Dictionary<string, string> {{"join", "us"}}
            };
            var result = Serializers.JsonObject(inputDict);
            Assert.AreEqual("[\"twilio\",{\"join\":\"us\"}]", result);
        }

        [Test]
        public void TestJsonObjectSerializesArray()
        {
            string[] inputDict = new string[2] {"twilio", "rocks"};
            var result = Serializers.JsonObject(inputDict);
            Assert.AreEqual("[\"twilio\",\"rocks\"]", result);
        }

        [Test]
        public void TestJsonObjectPassesThroughString()
        {
            var input = "{\"twilio\":\"is dope\"}";
            var result = Serializers.JsonObject(input);
            Assert.AreEqual(input, result);
        }

        [Test]
        public void TestDateTimeIso8601WithDateTime()
        {
            var expect = "2017-06-19T12:13:14Z";
            var input = new DateTime(2017, 06, 19, 12, 13, 14);
            var result = Serializers.DateTimeIso8601(input);
            Assert.AreEqual(expect, result);
        }

        [Test]
        public void TestDateTimeIso8601WithNull()
        {
            var result = Serializers.DateTimeIso8601(null);
            Assert.AreEqual(null, result);
        }
    }
}
