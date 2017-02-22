using System;
using System.Collections.Generic;

namespace Twilio.Jwt
{
    /// <summary>
    /// JWT for Twilio Client
    /// </summary>
    public class ClientCapability : BaseJwt
    {
        private readonly HashSet<IScope> _scopes;

        /// <summary>
        /// Create a new Client JWT
        /// </summary>
        /// <param name="accountSid">Twilio Account SID</param>
        /// <param name="authToken">Twilio auth token</param>
        /// <param name="expiration">JWT expiration</param>
        /// <param name="scopes">Scopes to give access to</param>
        public ClientCapability(
            string accountSid,
            string authToken,
            DateTime? expiration = null,
            HashSet<IScope> scopes = null
        ) : base (authToken, accountSid, expiration.HasValue ? expiration.Value : DateTime.UtcNow.AddSeconds(3600))
        {
            this._scopes = scopes;
        }

        /// <summary>
        /// JWT headers
        /// </summary>
        public override Dictionary<string, object> Headers
        {
            get
            {
                return new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Get the JWT claims in JSON format
        /// </summary>
        public override Dictionary<string, object> Claims
        {
            get
            {
                var claims = new Dictionary<string, object>();
                if (_scopes != null)
                {
                    var scopes = new List<string>();
                    foreach (var scope in _scopes)
                    {
                        scopes.Add(scope.Payload);
                    }

                    claims.Add("scope", String.Join(" ", scopes.ToArray()));
                }

                return claims;
            }
        }
    }
}
