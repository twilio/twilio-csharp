using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections;
using Twilio.Types;

namespace Twilio.Converters
{
	public class StringEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var t = JToken.FromObject(value.ToString());
			t.WriteTo(writer);
		}

		public override object ReadJson(
		    JsonReader reader,
		    Type objectType,
		    object existingValue,
		    JsonSerializer serializer
		)
		{
			if (reader.Value == null)
			{
				#if !NET35
				if (objectType.GenericTypeArguments.Length == 0) 
				#else
				if (objectType.GetGenericArguments().Length == 0)
				#endif
				{
					return null;
				}
				var constructedListType = MakeGenericType(objectType);
				var results = (IList) Activator.CreateInstance(constructedListType);
				reader.Read();

				while (reader.Value != null)
				{
				    var e = CreateEnum(objectType);
					e.FromString(reader.Value as string);
					results.Add(e);
					reader.Read();
				}

				return results;
			}

			var instance = (StringEnum) Activator.CreateInstance(objectType);
			instance.FromString(reader.Value as string);

			return instance;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Enum);
		}

		private static Type MakeGenericType(Type objectType)
		{
			var listType = typeof(List<>);

			#if !NET35
			return listType.MakeGenericType(objectType.GenericTypeArguments[0]);
			#else
			return listType.MakeGenericType(objectType.GetGenericArguments()[0]);
			#endif
		}

		private static StringEnum CreateEnum(Type objectType)
		{
			#if !NET35
			return (StringEnum) Activator.CreateInstance(objectType.GenericTypeArguments[0]);
			#else
			return (StringEnum) Activator.CreateInstance(objectType.GetGenericArguments()[0]);
			#endif
		}
	}

}

