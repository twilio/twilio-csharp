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
        public void TestNullSerialize() {

			Dictionary<string, string> expected = new Dictionary<string, string>();

            Dictionary<string, string> result = PrefixedCollapsibleMap.Serialize(
                null, 
                "really"
            );         

            CollectionAssert.AreEquivalent(expected, result);
        }

        [Test]
        public void TestEmptySerialize() {

            Dictionary<string, string> expected = new Dictionary<string, string>();

            Dictionary<string, string> result = PrefixedCollapsibleMap.Serialize(
                new Dictionary<string, object>(), 
                "really"
            );

            CollectionAssert.AreEquivalent(expected, result);
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

            CollectionAssert.AreEquivalent(expected, result);
        }
    }
}