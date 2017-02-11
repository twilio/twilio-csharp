using System;
using System.Collections.Generic;
using System.Reflection;

#if !NET35
using System.Net;
#else
using System.Collections.Specialized;
using System.Web;
#endif

namespace Twilio.JWT
{
    public class ScopeUri
    {
        private readonly string _service;
        private readonly string _privilege;
        private readonly Dictionary<string, object> _prms;

        public ScopeUri(string service, string privilege, object prms) : this(service, privilege, ObjectToUrlQuery(prms)) { }

        public ScopeUri(string service, string privilege, Dictionary<string, object> prms)
        {
            _service = service;
            _privilege = privilege;
            _prms = prms;
        }

        private static IEnumerable<PropertyInfo> GetProps(Type type)
        {
#if !NET35
	        return type.GetTypeInfo().DeclaredProperties;
#else
            return type.GetProperties();
#endif
        }

        private static object GetPropValue(PropertyInfo prop, object obj)
        {
            var propType = prop.PropertyType;
            var value = prop.GetValue(obj, null);

#if !NET35
	        if (!propType.IsByRef || propType == typeof(string))
#else
            if (propType.IsPrimitive || propType == typeof(string))
#endif
            {
                return value;
            }

            return ObjectToUrlQuery(value);
        }

        private static string UrlEncode(string value)
        {
#if !NET35
	        return WebUtility.UrlEncode(value);
#else
            return HttpUtility.UrlEncode(value);
#endif
        }

        private static Dictionary<string, object> ObjectToUrlQuery(object obj)
        {
            if (obj == null)
            {
                return new Dictionary<string, object>();
            }

            var coll = new Dictionary<string, object>();
            foreach (var prop in GetProps(obj.GetType()))
            {
                var value = prop.GetValue(obj, null);
                if (value != null)
                {
                    coll.Add(prop.Name, GetPropValue(prop, obj));
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

            var uri = $"scope:{_service}:{_privilege}";
            if (_prms.Count <= 0)
            {
                return uri;
            }

            var query = "";
            foreach (var item in _prms)
            {
                if (!string.IsNullOrEmpty(query))
                {
                    query = query + "&";
                }

                var value = item.Value;
                var items = item.Value as Dictionary<string, object>;
                if (items != null)
                {
                    var nestedValue = "";
                    foreach (var nestedItem in items)
                    {
                        if (!string.IsNullOrEmpty(nestedValue))
                        {
                            nestedValue = nestedValue + "&";
                        }
                        nestedValue = $"{nestedValue}{nestedItem.Key}={nestedItem.Value}";
                    }
                    value = UrlEncode(nestedValue);
                }

                query = $"{query}{item.Key}={value}";
            }

            return uri + "?" + query;
        }

        public static ScopeUri Parse(string uri)
        {
            if (!uri.StartsWith("scope:"))
            {
                throw new FormatException("Not a scope URI according to scheme");
            }

#if !NET35
		    var parms = new HttpValueCollection();
#else
            var parms = new NameValueCollection();
#endif

            var uriParts = uri.Split(new[] { '?' }, 2);
            if (uriParts.Length > 1)
            {
                parms = HttpUtility.ParseQueryString(uriParts[1]);
            }

            var scopeParts = uriParts[0].Split(new[] { ':' }, 3);
            if (scopeParts.Length != 3)
            {
                throw new FormatException("Not enough parts for scope URI");
            }

            var service = scopeParts[1];
            var privilege = scopeParts[2];

            return new ScopeUri(service, privilege, parms);
        }

    }
}