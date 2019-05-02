using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.Tests.Converters
{
    [TestFixture]
    public class StringEnumConverterTest : TwilioTest
    {
        class StatusClass
        {
            [JsonProperty("status")]
            [JsonConverter(typeof(StringEnumConverter))]
            public StatusEnum Status { get; private set; }

            [JsonProperty("status_list")]
            [JsonConverter(typeof(StringEnumConverter))]
            public List<StatusEnum> StatusList { get; private set; }
        }

        class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) { }
            public StatusEnum() { }
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }

            public static readonly StatusEnum Awe = new StatusEnum("awe");
            public static readonly StatusEnum Some = new StatusEnum("some");
        }

        [Test]
        public void TestBasicDeserialize()
        {
            var input = "{\"status\":\"awe\",\"status_list\":[\"some\"]}";
            var result = JsonConvert.DeserializeObject<StatusClass>(input);
            Assert.AreEqual(StatusEnum.Awe, result.Status);
            Assert.AreEqual(new[] { StatusEnum.Some }, result.StatusList);
        }

        [Test]
        public void TestNullDeserialize()
        {
            var input = "{\"status\":null,\"status_list\":null}";
            var result = JsonConvert.DeserializeObject<StatusClass>(input);
            Assert.Null(result.Status);
            Assert.Null(result.StatusList);
        }
    }
}
