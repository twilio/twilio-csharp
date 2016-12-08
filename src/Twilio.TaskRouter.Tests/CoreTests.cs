using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.TaskRouter.Tests
{
    [TestFixture]
    public class CoreTests
    {

        [Test]
        public void ShouldAllowDictToJson()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string> ();
            dictionary.Add ("foo", "bar");
            dictionary.Add ("fuzz", "bazz");
            var json = TaskRouterClient.FromDictionaryToJson (dictionary);
            Assert.AreEqual ("{\"foo\":\"bar\",\"fuzz\":\"bazz\"}", json);
        }

        [Test]
        public void ShouldAllowJsonToDict()
        {
            Dictionary<string, string> expected = new Dictionary<string, string> ();
            expected.Add ("foo", "bar");
            expected.Add ("fuzz", "bazz");
            Dictionary<string, string> dictionary = TaskRouterClient.FromJsonToDictionary ("{\"foo\":\"bar\",\"fuzz\":\"bazz\"}");
            Assert.AreEqual (expected, dictionary);
        }
    }
}
