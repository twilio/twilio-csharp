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

        // DateTimeFromString returns a local-kind DateTime, so the components below are
        // compared against the UTC-normalised value. Asserting on local components makes
        // these tests dependent on the machine's time zone: an offset that is not a whole
        // number of hours (e.g. +05:30) shifts the minute field, and an offset large
        // enough to cross midnight shifts the date.
        [Test]
        public void TestIsoCorrectness()
        {
            var dtIso = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z").ToUniversalTime();
            Assert.AreEqual(2016, dtIso.Year);
            Assert.AreEqual(6, dtIso.Month);
            Assert.AreEqual(7, dtIso.Day);
            Assert.AreEqual(16, dtIso.Hour);
            Assert.AreEqual(31, dtIso.Minute);
            Assert.AreEqual(31, dtIso.Second);
        }

        [Test]
        public void TestRfcCorrectness()
        {
            var dtRfc = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000").ToUniversalTime();
            Assert.AreEqual(2016, dtRfc.Year);
            Assert.AreEqual(6, dtRfc.Month);
            Assert.AreEqual(7, dtRfc.Day);
            Assert.AreEqual(16, dtRfc.Hour);
            Assert.AreEqual(31, dtRfc.Minute);
            Assert.AreEqual(31, dtRfc.Second);
        }
    }
}