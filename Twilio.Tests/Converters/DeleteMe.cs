using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
	public static class DeleteMe
	{
		public static string ToDebugString<TKey, TValue> (this IDictionary<TKey, TValue> dictionary)
		{
			return "{" + string.Join(",", dictionary.Select(kv => kv.Key.ToString() + "=" + kv.Value.ToString()).ToArray()) + "}";
		}
	}
}

