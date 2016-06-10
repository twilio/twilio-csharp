using NSubstitute;
using NUnit.Framework;
using Twilio.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Twilio.Tests
{
    [TestFixture]
    public class PrefixedCollapsibleMapTest : TwilioTest {

        [Test]
        public void TestEmptyNullSerialize() {

            Dictionary<string, string> result = PrefixedCollapsibleMap.Serialize(
                null, 
                "really"
            );

            Dictionary<string, string> expected = new Dictionary<string, string>();

            Assert.IsTrue(expected.SequenceEqual(result));

            result = PrefixedCollapsibleMap.Serialize(
                new Dictionary<string, object>(), 
                "really"
            );

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [Test]
        public void TestNormalSerialize() {

            Dictionary<string, object> inputDict = new Dictionary<string, object>();
            Dictionary<string, object> subDict = new Dictionary<string, object>();

            subDict.Add("cool", "people");
            subDict.Add("fun", "times");

            inputDict.Add("foo", "bar");
            inputDict.Add("super", subDict); 

            Dictionary<string, string> result = PrefixedCollapsibleMap.Serialize(
                inputDict, 
                "really"
            );

            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected.Add("really.foo","bar");
            expected.Add("really.super.cool","people");
            expected.Add("really.super.fun","times");

            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}