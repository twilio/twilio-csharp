using System.Collections.Generic;

using Twilio.Converters;

namespace Twilio.UnitTests.Converters
{
    
    public class PrefixedCollapsibleMapTest : TwilioTest {

        [Fact]
        public void TestNullSerialize()
        {
            var result = PrefixedCollapsibleMap.Serialize(null, "really");
            Assert.Equal(new Dictionary<string, string>(), result);
        }

        [Fact]
        public void TestEmptySerialize()
        {
            var result = PrefixedCollapsibleMap.Serialize(new Dictionary<string, object>(), "really");
            Assert.Equal(new Dictionary<string, string>(), result);
        }

        [Fact]
        public void TestNormalSerialize() {

            var inputDict = new Dictionary<string, object>
            {
                {"foo", "bar"},
                {"super", new Dictionary<string, object> {{"cool", "people"}, {"fun", "times"}}}
            };

            var result = PrefixedCollapsibleMap.Serialize(
                inputDict, 
                "really"
            );

            var expected = new Dictionary<string, string>
            {
                {"really.foo", "bar"},
                {"really.super.cool", "people"},
                {"really.super.fun", "times"}
            };

            Assert.Equal(expected, result);
        }
    }
}