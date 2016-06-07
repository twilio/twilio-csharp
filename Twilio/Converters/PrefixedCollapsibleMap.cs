using System;

using System.Collections.Generic;
using System.Linq;

namespace Twilio
{
	public class PrefixedCollapsibleMap
	{
		public static Dictionary<String, String> Flatten(
			Dictionary<String, Object> dict, 
			Dictionary<String, String> result,
			List<String> previous
		) {
			foreach (KeyValuePair<String, Object> entry in dict) {
				List<String> next = new List<String>(previous);
				next.Add (entry.Key);

				if (entry.Value.GetType() == typeof(Dictionary<String, Object>)) {
					Flatten ((Dictionary<String, Object>)entry.Value, result, next);
				} else {
					result.Add(String.Join(".", next), entry.Value.ToString());
				}
			}

			return result;
		}

		public static Dictionary<String, String> Serialize(
			Dictionary<String, Object> inputDict,
			String prefix
		) {
			if (inputDict == null || inputDict.Count() == 0) {
				return new Dictionary<String, String>();
			}
				
			Dictionary<String, String> flattened = Flatten(
				inputDict, 
				new Dictionary<String, String>(), 
				new List<String>()
			);

			Dictionary<String, String> results = new Dictionary<String, String>();

			foreach (KeyValuePair<String, String> entry in flattened) {
				results.Add(prefix + "." + entry.Key, entry.Value);
			}

			return results;
		}
	}
}

