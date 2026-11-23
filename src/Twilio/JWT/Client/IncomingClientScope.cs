using System;

#if !NET35
using System.Net;
#else
using System.Web;
#endif

namespace Twilio.Jwt.Client
{
    /// <summary>
    /// Incoming client scope for client capabilities
    /// </summary>
    public class IncomingClientScope : IScope
    {
        private static readonly string Scope = "scope:client:incoming";

        private readonly string _clientName;

        /// <summary>
        /// Create a new IncomingClientScope
        /// </summary>
        /// <param name="clientName">Client name</param>
        public IncomingClientScope(string clientName)
        {
            this._clientName = clientName;
        }

        /// <summary>
        /// Generate scope payload
        /// </summary>
        public string Payload
        {
            get
            {
#if !NET35
                var encodedName = WebUtility.UrlEncode(_clientName);
#else
                var encodedName = HttpUtility.UrlEncode(_clientName);
#endif
                var query = "clientName=" + encodedName;
                return Scope + "?" + query;
            }
        }
    }
}
