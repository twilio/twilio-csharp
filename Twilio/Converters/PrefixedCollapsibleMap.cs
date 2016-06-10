using System;
using System.Collections.Generic;
using System.Linq;

namespace Twilio.Converters
{
    public class PrefixedCollapsibleMap
    {
        private static Dictionary<string, string> Flatten(
            Dictionary<string, object> dict, 
            Dictionary<string, string> result,
            List<string> previous
        ) {
            foreach (KeyValuePair<string, object> entry in dict) {
                List<string> next = new List<string>(previous);
                next.Add (entry.Key);

                if (entry.Value.GetType() == typeof(Dictionary<string, object>)) {
                    Flatten ((Dictionary<string, object>)entry.Value, result, next);
                } else {
                    result.Add(String.Join(".", next.ToArray()), entry.Value.ToString());
                }
            }

            return result;
        }

        public static Dictionary<string, string> Serialize(
            Dictionary<string, object> inputDict,
            String prefix
        ) {
            if (inputDict == null || inputDict.Count() == 0) {
                return new Dictionary<string, string>();
            }
                
            Dictionary<string, string> flattened = Flatten(
                inputDict, 
                new Dictionary<string, string>(), 
                new List<string>()
            );

            Dictionary<string, string> results = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> entry in flattened) {
                results.Add(prefix + "." + entry.Key, entry.Value);
            }

            return results;
        }
    }
}

