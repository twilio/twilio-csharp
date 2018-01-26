using System;
using System.Collections.Generic;

#if !NET35
using System.Net;
#else
using System.Web;
#endif

namespace Twilio.Jwt.Client
{
    /// <summary>
    /// Event stream scope for client capabilites
    /// </summary>
    public class EventStreamScope : IScope
    {
        private static readonly string Scope = "scope:stream:subscribe";

        private readonly Dictionary<string, string> _filters;

        /// <summary>
        /// Create a new EventStreamScope
        /// </summary>
        /// <param name="filters">filters to use</param>
        public EventStreamScope(Dictionary<string, string> filters = null)
        {
            this._filters = filters;
        }

        /// <summary>
        /// Generate scope payload
        /// </summary>
        public string Payload
        {
            get
            {
                var queryArgs = new List<string>();
                queryArgs.Add("path=/2010-04-01/Events");

                if (_filters != null)
                {
                    queryArgs.Add(BuildParameter("appParams", GetFilterParams()));
                }

                var queryString = String.Join("&", queryArgs.ToArray());
                return Scope + "?" + queryString;
            }
        }

        private string GetFilterParams()
        {
            var queryParams = new List<string>();
            foreach (var entry in _filters)
            {
                queryParams.Add(BuildParameter(entry.Key, entry.Value));
            }

            return String.Join("&", queryParams.ToArray());
        }

        private string BuildParameter(string k, string v)
        {
#if !NET35
            return WebUtility.UrlEncode(k) + "=" + WebUtility.UrlEncode(v);
#else
            return HttpUtility.UrlEncode(k) + "=" + HttpUtility.UrlEncode(v);
#endif
        }
    }
}
