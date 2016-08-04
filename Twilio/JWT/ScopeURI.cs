using System;
using System.Collections.Generic;
using System.Collections.Specialized;
#if NET40
using System.Reflection;
using System.Net;
using System.Net.Http;
#else
using System.Web;
#endif

namespace Twilio.JWT
{
	public class ScopeURI
	{
		public string _service;
		public string _privilege;
		public Dictionary<string, object> _prms;

		public ScopeURI(string service, string privilege, object prms)
		{
			_service = service;
			_privilege = privilege;
			_prms = ObjectToUrlQuery(prms);
		}

		public ScopeURI(string service, string privilege, Dictionary<string, object> prms)
		{
			_service = service;
			_privilege = privilege;
			_prms = prms;
		}

		Dictionary<string, object> ObjectToUrlQuery(object obj)
		{
			if (obj == null) return new Dictionary<string, object>();

			var type = obj.GetType();
			var props = type.GetTypeInfo().DeclaredProperties;

			var coll = new Dictionary<string, object>();

			foreach (var prop in props)
			{
				var propType = prop.PropertyType;
				var value = prop.GetValue(obj, null);
				var name = prop.Name;

				if (value != null)
				{
					if (!propType.IsByRef || propType == typeof(string))
					{
						coll.Add(name, value);
					}
					else
					{
						coll.Add(name, ObjectToUrlQuery(value));
					}
				}
			}
			return coll;
		}

		public string ToString(string clientName)
		{
			if (!string.IsNullOrEmpty(clientName))
			{
				_prms.Add("clientName", clientName);
			}

			var uri = string.Format("scope:{0}:{1}", _service, _privilege);
			if (_prms.Count > 0)
			{
				var query = "";
				foreach (var item in _prms)
				{
					if (!string.IsNullOrEmpty(query))
					{
						query = query + "&";
					}

					var value = item.Value;
					if (item.Value is Dictionary<string, object>)
					{
						var nestedValue = "";
						foreach (var nestedItem in (Dictionary<string, object>)item.Value)
						{
							if (!string.IsNullOrEmpty(nestedValue))
							{
								nestedValue = nestedValue + "&";
							}
							nestedValue = string.Format("{0}{1}={2}", nestedValue, nestedItem.Key, nestedItem.Value);
						}

						#if NET40
						value = WebUtility.UrlEncode(nestedValue);
						#else
						value = HttpUtility.UrlEncode(nestedValue);
						#endif
					}

					query = string.Format("{0}{1}={2}", query, item.Key, value);
				}

				uri = uri + "?" + query;
			}
			return uri;
		}

		public static ScopeURI Parse(string uri)
		{
			if (!uri.StartsWith("scope:"))
			{
				throw new FormatException("Not a scope URI according to scheme");
			}

			var uriParts = uri.Split(new[] { '?' }, 2);

			#if NET40
			var parms = new HttpValueCollection();
			#else
			var parms = new NameValueCollection();
			#endif
			if (uriParts.Length > 1)
			{
				#if NET40
				parms = HttpUtility.ParseQueryString(uriParts[1]);
				#else
				parms = HttpUtility.ParseQueryString(uriParts[1]);
				#endif
			}

			var scopeParts = uriParts[0].Split(new[] { ':' }, 3);
			if (scopeParts.Length != 3)
			{
				throw new FormatException("Not enough parts for scope URI");
			}

			var service = scopeParts[1];
			var privilege = scopeParts[2];

			return new ScopeURI(service, privilege, parms);
		}

	}
}