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
        /// Produce a ISO 8601 compatible string from input if possible
        /// </summary>
        /// <param name="input">DateTime intance to serialize to string</param>
        /// <returns>A string</returns>
        public static string DateTimeIso8601(DateTime input)
        {
              return input.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public static string DateTimeIso8601(string input)
        {
            if (input == null) return null;

            CultureInfo enUS = new CultureInfo("en-US");
            DateTimeStyles utc = DateTimeStyles.AdjustToUniversal;
            DateTime parsedDateTime;

            if (DateTime.TryParse(input, enUS, utc, out parsedDateTime))
              return DateTimeIso8601(parsedDateTime);
            else
              return input;
        }
    }
}
