using System;
using NUnit.Framework;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Tests.Types
{
    [TestFixture]
    public class AppTest
    {
        [Test]
        public void TestToString()
        {
            Assert.AreEqual("app:me", new App("me").ToString());
            Assert.AreEqual("app:YOU", new App("YOU").ToString());
            Assert.AreEqual("APP:HIM", new App("APP:HIM").ToString());
            Assert.AreEqual("aPp:her", new App("aPp:her").ToString());
            Assert.Throws<ArgumentException>(() => new App("").ToString());
            Assert.AreEqual("app:AP12345?mycustomparam1=foo&mycustomparam2=bar", new App("app:AP12345?mycustomparam1=foo&mycustomparam2=bar").ToString());
            Assert.AreEqual("app:AP12345?mycustomparam1=foo&mycustomparam2=bar", new App("AP12345?mycustomparam1=foo&mycustomparam2=bar").ToString());
        }
    }
}
