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
    }
}
