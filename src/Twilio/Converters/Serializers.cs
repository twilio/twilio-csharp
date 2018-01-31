using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Twilio.Converters
{
    /// <summary>
    /// Serialization methods for various datatypes before making requests to the API
    /// </summary>
    public class Serializers
    {

        /// <summary>
        /// Produce a json string from input if possible
        /// </summary>
        /// <param name="input">Object to serialize to json</param>
        /// <returns>A json string</returns>
        public static string JsonObject(object input)
        {
            return (input is string) ? (string) input : JsonConvert.SerializeObject(input);
        }

        /// <summary>
        /// Produce a ISO 8601 UTC compatible string from input if possible
        /// </summary>
        /// <param name="input">DateTime instance to serialize to string</param>
        /// <returns>A string</returns>
        public static string DateTimeIso8601(DateTime? input)
        {
            if (input == null) return null;

            return input.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public static string Url(Uri input) 
        {
            if (input == null) 
            {
                return null;
            }

            string originalString = input.OriginalString;
            if (input is Types.EmptyUri && Types.EmptyUri.Uri.Equals(originalString))
            {
                return string.Empty;
            }

            return originalString;
        }
    }
}
