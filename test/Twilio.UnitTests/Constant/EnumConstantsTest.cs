using Twilio.Constant;

namespace Twilio.UnitTests.Constant
{
    
    public class EnumConstantsTest
    {
        [Fact]
        public void EnumConstantComparison()
        {
            var jsonContentType = EnumConstants.ContentTypeEnum.JSON;
            var formUrlEncodedType = EnumConstants.ContentTypeEnum.FORM_URLENCODED;
            Assert.Equal("application/json", jsonContentType.ToString());
            Assert.Equal("application/x-www-form-urlencoded", formUrlEncodedType.ToString());
        }
    }
}