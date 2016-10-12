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
		            return Http.HttpMethod.GET;

		        case "post":
		            return Http.HttpMethod.POST;

		        case "put":
		            return Http.HttpMethod.PUT;

		        case "delete":
		            return Http.HttpMethod.DELETE;

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

