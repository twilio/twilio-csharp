using Newtonsoft.Json;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.Constant
{
    public class EnumConstants
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ContentTypeEnum : StringEnum
        {
            private ContentTypeEnum(string value) : base(value) {}
            public static readonly ContentTypeEnum JSON = new ContentTypeEnum("application/json");
            public static readonly ContentTypeEnum SCIM = new ContentTypeEnum("application/scim");
            public static readonly ContentTypeEnum FORM_URLENCODED = new ContentTypeEnum("application/x-www-form-urlencoded");
        }
    }
}
