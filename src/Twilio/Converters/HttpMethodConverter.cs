using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Converters
{
    /// <summary>
    /// Convert between strings and HttpMethod
    /// </summary>
    public class HttpMethodConverter : JsonConverter
    {
        /// <summary>
        /// Write the HTTP method out to json
        /// </summary>
        ///
        /// <param name="writer">json writer</param>
        /// <param name="value">value to write serialize</param>
        /// <param name="serializer">json serialize</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value.ToString());
            t.WriteTo(writer);
        }

        /// <summary>
        /// Deserialize a string into a HttpMethod
        /// </summary>
        ///
        /// <param name="reader">json reader</param>
        /// <param name="objectType">type of object</param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        ///
        /// <returns>Deserialized HttpMethod</returns>
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

        /// <summary>
        /// Determine if an object can be converted to HttpMethod
        /// </summary>
        ///
        /// <param name="objectType">object type</param>
        /// <returns>true if the type is an HttpMethod; false otherwise</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Http.HttpMethod);
        }
    }
}

