using Twilio.Types;

namespace Twilio.UnitTests.Types
{
    
    public class ClientTest
    {
        [Fact]
        public void TestToString()
        {
            Assert.Equal("client:me", new Client("me").ToString());
            Assert.Equal("client:YOU", new Client("YOU").ToString());
            Assert.Equal("CLIENT:HIM", new Client("CLIENT:HIM").ToString());
            Assert.Equal("cLiEnT:her", new Client("cLiEnT:her").ToString());
        }
    }
}
