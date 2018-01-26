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
    /// Scope capability
    /// </summary>
    public class OutgoingClientScope : IScope
    {
        private static readonly string Scope = "scope:client:outgoing";

        private readonly string _applicationSid;
        private readonly string _clientName;
        private readonly Dictionary<string, string> _parameters;

        /// <summary>
        /// Create a new OutgoingClientScope
        /// </summary>
        /// <param name="applicationSid">Twilio Application SID</param>
        /// <param name="clientName">Name of client</param>
        /// <param name="parameters">Parameters to pass</param>
        public OutgoingClientScope(
            string applicationSid,
            string clientName = null,
            Dictionary<string, string> parameters = null
        )
        {
            this._applicationSid = applicationSid;
            this._clientName = clientName;
            this._parameters = parameters;
        }

        /// <summary>
        /// Generate scope payload
        /// </summary>
        public string Payload
        {
            get
            {
                var queryArgs = new List<string>();
                queryArgs.Add(BuildParameter("appSid", _applicationSid));

                if (_clientName != null)
                {
                    queryArgs.Add(BuildParameter("clientName", _clientName));
                }

                if (_parameters != null)
                {
                    queryArgs.Add(BuildParameter("appParams", GetAppParams()));
                }

                var queryString = String.Join("&", queryArgs.ToArray());
                return Scope + "?" + queryString;
            }
        }

        private string GetAppParams()
        {
            var queryParams = new List<string>();
            foreach (var entry in _parameters)
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
