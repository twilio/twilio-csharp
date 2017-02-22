using System.Collections.Generic;
using System.Linq;

namespace Twilio.Converters
{
    /// <summary>
    /// Flatten nested maps and give all entries a prefix
    /// </summary>
    public class PrefixedCollapsibleMap
    {
        private static Dictionary<string, string> Flatten(
            Dictionary<string, object> dict, 
            Dictionary<string, string> result,
            List<string> previous
        )
        {
            foreach (var entry in dict)
            {
                var next = new List<string>(previous) { entry.Key };

                if (entry.Value.GetType() == typeof(Dictionary<string, object>))
                {
                    Flatten((Dictionary<string, object>)entry.Value, result, next);
                }
                else
                {
                    result.Add(string.Join(".", next.ToArray()), entry.Value.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Flatten Dictionary separating nested keys with a .
        /// </summary>
        /// <param name="inputDict">Dictionary to flatten</param>
        /// <param name="prefix">Prefix to give all entries</param>
        /// <returns>Flattened Dictionary</returns>
        public static Dictionary<string, string> Serialize(
            Dictionary<string, object> inputDict,
            string prefix
        )
        {
            if (inputDict == null || !inputDict.Any())
            {
                return new Dictionary<string, string>();
            }
                
            var flattened = Flatten(inputDict, new Dictionary<string, string>(), new List<string>());
            return flattened.ToDictionary(entry => prefix + "." + entry.Key, entry => entry.Value);
        }
    }
}

