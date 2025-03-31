using System;
using System.Collections.Generic;

using Twilio.Converters;

namespace Twilio.UnitTests.Converters
{
    
    public class SerializersTest : TwilioTest {

        [Fact]
        public void TestJsonObjectSerializesDictionary()
        {
            var inputDict = new Dictionary<string, string> {{"twilio", "rocks"}};
            var result = Serializers.JsonObject(inputDict);
            Assert.Equal("{\"twilio\":\"rocks\"}", result);
        }

        [Fact]
        public void TestJsonObjectSerializesList()
        {
            var inputDict = new List<object>{
                "twilio",
                new Dictionary<string, string> {{"join", "us"}}
            };
            var result = Serializers.JsonObject(inputDict);
            Assert.Equal("[\"twilio\",{\"join\":\"us\"}]", result);
        }

        [Fact]
        public void TestJsonObjectSerializesArray()
        {
            string[] inputDict = new string[2] {"twilio", "rocks"};
            var result = Serializers.JsonObject(inputDict);
            Assert.Equal("[\"twilio\",\"rocks\"]", result);
        }

        [Fact]
        public void TestJsonObjectPassesThroughString()
        {
            var input = "{\"twilio\":\"is dope\"}";
            var result = Serializers.JsonObject(input);
            Assert.Equal(input, result);
        }

        [Fact]
        public void TestDateTimeIso8601WithDateTime()
        {
            var expect = "2017-06-19T12:13:14Z";
            var input = new DateTime(2017, 06, 19, 12, 13, 14);
            var result = Serializers.DateTimeIso8601(input);
            Assert.Equal(expect, result);
        }

        [Fact]
        public void TestDateTimeIso8601WithNull()
        {
            var result = Serializers.DateTimeIso8601(null);
            Assert.Null(result);
        }
    }
}
