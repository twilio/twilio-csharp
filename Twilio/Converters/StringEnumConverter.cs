using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Converters
{
	public class StringEnumConverter : JsonConverter
	{
		public StringEnumConverter () {
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			JToken t = JToken.FromObject(value.ToString());
			t.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var instance = (IStringEnum) Activator.CreateInstance(objectType);
			instance.FromString(reader.Value as string);

			return instance;
		}

		public override bool CanConvert(Type objectType) {
			return objectType == typeof(Enum);
		}
	}
}

