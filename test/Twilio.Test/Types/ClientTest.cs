using System;
using NUnit.Framework;
using Twilio.Types;

namespace Twilio.Tests.Types
{
    [TestFixture]
    public class ClientTest
    {
        [Test]
        public void TestToString()
        {
            Assert.AreEqual("client:me", new Client("me").ToString());
            Assert.AreEqual("client:YOU", new Client("YOU").ToString());
            Assert.AreEqual("CLIENT:HIM", new Client("CLIENT:HIM").ToString());
            Assert.AreEqual("cLiEnT:her", new Client("cLiEnT:her").ToString());
        }
    }
}
