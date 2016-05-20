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
            var json = TaskRouterClient.FromDictionaryToJson (dictionary);
            Assert.AreEqual ("{\"foo\":\"bar\"}", json);
        }

        [Test]
        public void ShouldAllowJsonToDict()
        {
            Dictionary<string, string> expected = new Dictionary<string, string> ();
            expected.Add ("foo", "bar");
            Dictionary<string, string> dictionary = TaskRouterClient.FromJsonToDictionary ("{\"foo\":\"bar\"}");
            Assert.AreEqual (expected, dictionary);
        }
    }
}
