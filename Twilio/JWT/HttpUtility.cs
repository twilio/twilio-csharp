using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Net;

namespace Twilio
{
	public sealed class HttpUtility
	{
		public static HttpValueCollection ParseQueryString(string query)
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}

			if ((query.Length > 0) && (query[0] == '?'))
			{
				query = query.Substring(1);
			}

			return new HttpValueCollection(query, true);
		}
	}

	public sealed class HttpValue
	{
		public HttpValue()
		{
		}

		public HttpValue(string key, string value)
		{
			this.Key = key;
			this.Value = value;
		}

		public string Key { get; set; }
		public string Value { get; set; }
	}

	public class HttpValueCollection : Collection<HttpValue>
	{
		#region Constructors

		public HttpValueCollection()
		{
		}

		public HttpValueCollection(string query)
			: this(query, true)
		{
		}

		public HttpValueCollection(string query, bool urlencoded)
		{
			if (!string.IsNullOrEmpty(query))
			{
				this.FillFromString(query, urlencoded);
			}
		} 

		#endregion

		#region Parameters

		public string this[string key]
		{
			get { return this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value; }
			set { this.First(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value = value; }
		}

		#endregion

		#region Public Methods

		public void Add(string key, string value)
		{
			this.Add(new HttpValue(key, value));
		}

		public bool ContainsKey(string key)
		{
			return this.Any(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
		}

		public string[] GetValues(string key)
		{
			return this.Where(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToArray();
		}

		public void Remove(string key)
		{
			var list = this.Where(x => string.Equals (x.Key, key, StringComparison.OrdinalIgnoreCase)).ToList();
			foreach (var x in list) {
				this.Remove(x);
			}
		}

		public override string ToString()
		{
			return this.ToString(true);
		}

		public virtual string ToString(bool urlencoded)
		{
			return this.ToString(urlencoded, null);
		}

		public virtual string ToString(bool urlencoded, IDictionary excludeKeys)
		{
			if (this.Count == 0)
			{
				return string.Empty;
			}

			StringBuilder stringBuilder = new StringBuilder();

			foreach (HttpValue item in this)
			{
				string key = item.Key;

				if ((excludeKeys == null) || !excludeKeys.Contains(key))
				{
					string value = item.Value;

					if (urlencoded)
					{
						// If .NET 4.5 and above (Thanks @Paya)
						key = WebUtility.UrlDecode(key);
						// If .NET 4.0 use this instead.
						// key = Uri.EscapeDataString(key);
					}

					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append('&');
					}

					stringBuilder.Append((key != null) ? (key + "=") : string.Empty);

					if ((value != null) && (value.Length > 0))
					{
						if (urlencoded)
						{
							value = Uri.EscapeDataString(value);
						}

						stringBuilder.Append(value);
					}
				}
			}

			return stringBuilder.ToString();
		} 

		#endregion

		#region Private Methods

		private void FillFromString(string query, bool urlencoded)
		{
			int num = (query != null) ? query.Length : 0;
			for (int i = 0; i < num; i++)
			{
				int startIndex = i;
				int num4 = -1;
				while (i < num)
				{
					char ch = query[i];
					if (ch == '=')
					{
						if (num4 < 0)
						{
							num4 = i;
						}
					}
					else if (ch == '&')
					{
						break;
					}
					i++;
				}
				string str = null;
				string str2 = null;
				if (num4 >= 0)
				{
					str = query.Substring(startIndex, num4 - startIndex);
					str2 = query.Substring(num4 + 1, (i - num4) - 1);
				}
				else
				{
					str2 = query.Substring(startIndex, i - startIndex);
				}

				if (urlencoded)
				{
					this.Add(Uri.UnescapeDataString(str), Uri.UnescapeDataString(str2));
				}
				else
				{
					this.Add(str, str2);
				}

				if ((i == (num - 1)) && (query[i] == '&'))
				{
					this.Add(null, string.Empty);
				}
			}
		} 

		#endregion
	}
}

