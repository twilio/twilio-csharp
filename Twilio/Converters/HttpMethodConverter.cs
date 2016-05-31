using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Converters
{
	public class HttpMethodConverter : JsonConverter
	{
		public HttpMethodConverter () {
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
			JToken t = JToken.FromObject(value.ToString());
			t.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			string token = reader.Value as string;

			if (token != null) {
				switch (token.ToLower ()) {
				case "get":
					return Twilio.Http.HttpMethod.GET;
				case "post":
					return Twilio.Http.HttpMethod.POST;
				case "put":
					return Twilio.Http.HttpMethod.PUT;
				case "delete":
					return Twilio.Http.HttpMethod.DELETE;
				}
			}

			return null;
		}

		public override bool CanConvert(Type objectType) {
			return objectType == typeof(Twilio.Http.HttpMethod);
		}
	}
}

