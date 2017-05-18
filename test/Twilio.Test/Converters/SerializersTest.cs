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
    }
}
