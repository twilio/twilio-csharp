
using Twilio.Converters;

namespace Twilio.UnitTests.Converters
{
    
    public class MarshalConverterTest : TwilioTest 
    {
        [Fact]
        public void TestDifferentDateTimeParsing()
        {
            var dtIso = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            var dtRfc = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.Equal(dtIso,dtRfc);
        }

        [Fact]
        public void TestIsoCorrectness()
        {
            var dtIso = MarshalConverter.DateTimeFromString("2016-06-07T16:31:31Z");
            Assert.Equal(7, dtIso.Day);
            Assert.Equal(6, dtIso.Month);
            Assert.Equal(2016, dtIso.Year);
            Assert.Equal(16, dtIso.ToUniversalTime().Hour);
            Assert.Equal(31, dtIso.Minute);
            Assert.Equal(31, dtIso.Second);
        }

        [Fact]
        public void TestRfcCorrectness()
        {
            var dtRfc = MarshalConverter.DateTimeFromString("Tue, 07 Jun 2016 16:31:31 +0000");
            Assert.Equal(7, dtRfc.Day);
            Assert.Equal(6, dtRfc.Month);
            Assert.Equal(2016, dtRfc.Year);
            Assert.Equal(16, dtRfc.ToUniversalTime().Hour);
            Assert.Equal(31, dtRfc.Minute);
            Assert.Equal(31, dtRfc.Second);
        }
    }
}