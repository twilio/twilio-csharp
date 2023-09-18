using NUnit.Framework;
using Twilio.Constant;

namespace Twilio.Tests.Constant
{
    [TestFixture]
    public class EnumConstantsTest
    {
        [Test]
        public void EnumConstantComparison()
        {
            var jsonContentType = EnumConstants.ContentTypeEnum.JSON;
            var formUrlEncodedType = EnumConstants.ContentTypeEnum.FORM_URLENCODED;
          
            Assert.AreEqual("application/json", jsonContentType.ToString());
            Assert.AreEqual("application/x-www-form-urlencoded", formUrlEncodedType.ToString());
        }
    }
}