using NSubstitute;
using NUnit.Framework;
using System;
using Twilio.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Twilio.Tests
{
    [TestFixture]
    public class MarshalConverterTest : TwilioTest {
        
        [Test]
        public void TestDifferentDateTimeParsing() {
            DateTime dtISO = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            DateTime dtRFC = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.AreEqual(dtISO,dtRFC);
        }

        [Test]
        public void TestIsoCorrectness() {
            DateTime dtISO = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            Assert.AreEqual(dtISO.Day, 7);
            Assert.AreEqual(dtISO.Month, 6);
            Assert.AreEqual(dtISO.Year, 2016);
            Assert.AreEqual(dtISO.ToUniversalTime().Hour, 16);
            Assert.AreEqual(dtISO.Minute, 31);
            Assert.AreEqual(dtISO.Second, 31);
        }

        [Test]
        public void TestRfcCorrectness() {
            DateTime dtRFC = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.AreEqual(dtRFC.Day, 7);
            Assert.AreEqual(dtRFC.Month, 6);
            Assert.AreEqual(dtRFC.Year, 2016);
            Assert.AreEqual(dtRFC.ToUniversalTime().Hour, 16);
            Assert.AreEqual(dtRFC.Minute, 31);
            Assert.AreEqual(dtRFC.Second, 31);
        }
    }
}