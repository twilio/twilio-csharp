using System;
using Newtonsoft.Json;

namespace Twilio.Converters
{
    public class DateTimeConverter : JsonConverter
    {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value != null)
                {
                    writer.WriteValue(Serializers.DateTimeIso8601((DateTime)value));
                }
                else
                {
                    writer.WriteNull();
                }
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var dateTime = reader.Value;
                return dateTime;
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(DateTime);
            }
    }
}