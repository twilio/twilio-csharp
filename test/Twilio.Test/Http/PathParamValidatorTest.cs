using NUnit.Framework;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Tests.Http
{
    [TestFixture]
    public class PathParamValidatorTest
    {
        [TestCase("FW00000000000000000000000000000000")]
        [TestCase("+15551234567")]
        [TestCase("my name.txt")]
        public void TestValidValueReturnedUnchanged(string value)
        {
            Assert.AreEqual(value, PathParamValidator.Validate(value));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(".")]
        [TestCase("..")]
        [TestCase("a/b")]
        [TestCase("a?b")]
        [TestCase("a#b")]
        [TestCase("../x")]
        public void TestInvalidValueThrows(string value)
        {
            Assert.Throws<ApiException>(() => PathParamValidator.Validate(value));
        }
    }
}
