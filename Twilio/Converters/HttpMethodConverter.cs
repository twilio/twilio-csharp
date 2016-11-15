using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Converters
{
	public class HttpMethodConverter : JsonConverter
	{

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var t = JToken.FromObject(value.ToString());
			t.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var token = reader.Value as string;
		    if (token == null)
		    {
		        return null;
		    }

		    switch (token.ToLower())
		    {
		        case "get":
		            return Http.HttpMethod.Get;

		        case "post":
		            return Http.HttpMethod.Post;

		        case "put":
		            return Http.HttpMethod.Put;

		        case "delete":
		            return Http.HttpMethod.Delete;

                default:
		            return null;
		    }
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Http.HttpMethod);
		}

	}
}

