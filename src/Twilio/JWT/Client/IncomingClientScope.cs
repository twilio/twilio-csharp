using System;

namespace Twilio.Jwt.Client
{
    /// <summary>
    /// Incoming client scope for client capabilites
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
                var query = "clientName=" + _clientName;
                return Scope + "?" + query;
            }
        }
    }
}
