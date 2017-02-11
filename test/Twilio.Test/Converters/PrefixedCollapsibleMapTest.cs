using System.Collections.Generic;
using NUnit.Framework;
using Twilio.Converters;

namespace Twilio.Tests.Converters
{
    [TestFixture]
    public class PrefixedCollapsibleMapTest : TwilioTest {

        [Test]
        public void TestNullSerialize()
        {
            var result = PrefixedCollapsibleMap.Serialize(null, "really");
            CollectionAssert.AreEquivalent(new Dictionary<string, string>(), result);
        }

        [Test]
        public void TestEmptySerialize()
        {
            var result = PrefixedCollapsibleMap.Serialize(new Dictionary<string, object>(), "really");
            CollectionAssert.AreEquivalent(new Dictionary<string, string>(), result);
        }

        [Test]
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

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}