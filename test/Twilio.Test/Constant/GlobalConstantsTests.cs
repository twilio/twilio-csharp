using NUnit.Framework;
using Twilio.Constant;
using System.Collections.Generic;

namespace Twilio.Tests
{
    [TestFixture]
    public class GlobalConstantsTests
    {
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = false)]
        [TestCase("edge", null, ExpectedResult = true)]
        [TestCase(null, "region", ExpectedResult = true)]
        [TestCase("edge", "", ExpectedResult = true)]
        [TestCase("", "region", ExpectedResult = true)]
        [TestCase("edge", "region", ExpectedResult = false)]
        public bool IsOnlyOneSet_ReturnsExpected(string edge, string region)
        {
            return GlobalConstants.IsOnlyOneSet(edge, region);
        }
    }

    [TestFixture]
        public class GlobalConstantsMapTests
        {
            [Test]
            public void RegionToEdgeMap_ContainsExpectedEntries()
            {
                // Example: adjust key-value pairs to match your actual map
                Assert.IsTrue(GlobalConstants.RegionToEdgeMap.ContainsKey("us1"));
                Assert.AreEqual("ashburn", GlobalConstants.RegionToEdgeMap["us1"]);

                Assert.IsTrue(GlobalConstants.RegionToEdgeMap.ContainsKey("ie1"));
                Assert.AreEqual("dublin", GlobalConstants.RegionToEdgeMap["ie1"]);
            }

            [Test]
            public void RegionToEdgeMap_DoesNotContainUnexpectedKey()
            {
                Assert.IsFalse(GlobalConstants.RegionToEdgeMap.ContainsKey("unexpected"));
            }
        }

}
