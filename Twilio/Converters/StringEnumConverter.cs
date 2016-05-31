using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;

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
			if (reader.Value == null) {
				var listType = typeof(List<>);
				#if NET40
				var constructedListType = listType.MakeGenericType(objectType.GenericTypeArguments[0]);
				#else
				var constructedListType = listType.MakeGenericType(objectType.GetGenericArguments()[0]);
				#endif
				var results = (IList) Activator.CreateInstance(constructedListType);
				reader.Read();

				while (reader.Value != null) {
					#if NET40
					var e = (IStringEnum) Activator.CreateInstance(objectType.GenericTypeArguments[0]);
					#else
					var e = (IStringEnum) Activator.CreateInstance(objectType.GetGenericArguments()[0]);
					#endif
					e.FromString(reader.Value as string);
					results.Add(e);
					reader.Read();
				}

				return results;
			}

			var instance = (IStringEnum) Activator.CreateInstance(objectType);
			instance.FromString(reader.Value as string);

			return instance;
		}

		public override bool CanConvert(Type objectType) {
			return objectType == typeof(Enum);
		}
	}
}

