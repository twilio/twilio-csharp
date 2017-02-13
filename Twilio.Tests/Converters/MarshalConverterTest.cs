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

        [Test]
        public void TestIsoCorrectness()
        {
            var dtIso = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            Assert.AreEqual(dtIso.Day, 7);
            Assert.AreEqual(dtIso.Month, 6);
            Assert.AreEqual(dtIso.Year, 2016);
            Assert.AreEqual(dtIso.ToUniversalTime().Hour, 16);
            Assert.AreEqual(dtIso.Minute, 31);
            Assert.AreEqual(dtIso.Second, 31);
        }

        [Test]
        public void TestRfcCorrectness()
        {
            var dtRfc = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.AreEqual(dtRfc.Day, 7);
            Assert.AreEqual(dtRfc.Month, 6);
            Assert.AreEqual(dtRfc.Year, 2016);
            Assert.AreEqual(dtRfc.ToUniversalTime().Hour, 16);
            Assert.AreEqual(dtRfc.Minute, 31);
            Assert.AreEqual(dtRfc.Second, 31);
        }
    }
}