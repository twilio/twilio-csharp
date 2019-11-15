using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twilio.Converters
{
    /// <summary>
    /// Convert between strings and a Twiml
    /// </summary>
    public class TwimlConverter : JsonConverter
    {
        /// <summary>
        /// Write value to JsonWriter
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="value">Value to write</param>
        /// <param name="serializer">unused</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value.ToString());
            t.WriteTo(writer);
        }

        /// <summary>
        /// Convert a string to a Twiml
        /// </summary>
        /// <param name="reader">JsonReader to read from</param>
        /// <param name="objectType">unused</param>
        /// <param name="existingValue">unused</param>
        /// <param name="serializer">unused</param>
        /// <returns>Converted Twiml</returns>
        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            return new Types.Twiml(reader.Value as string);
        }

        /// <summary>
        /// Determines if an object converted to a Twiml
        /// </summary>
        /// <param name="objectType">Type of object</param>
        /// <returns>true if an object can be converted; false otherwise</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Enum);
        }
    }
}
