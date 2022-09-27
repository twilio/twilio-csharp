using NUnit.Framework;
using Twilio.Converters;

namespace Twilio.Tests.Converters
{
    [TestFixture]
    public class MarshalConverterTest : TwilioTest 
    {
        [Test]
        public void TestDifferentDateTimeParsing()
        {
            var dtIso = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            var dtRfc = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.AreEqual(dtIso,dtRfc);
        }

    }
}