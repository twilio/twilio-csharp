using System;
using System.Collections.Generic;

namespace Twilio.Jwt.AccessToken
{
    /// <summary>
    /// Access Token for Twilio resources
    /// </summary>
    public class Token : BaseJwt
    {
        private readonly string _id;
        private readonly string _accountSid;
        private readonly string _identity;
        private readonly DateTime? _nbf;
        private readonly HashSet<IGrant> _grants;

        /// <summary>
        /// Create a new Access Token
        /// </summary>
        /// <param name="accountSid">Account SID</param>
        /// <param name="signingKeySid">Signing key SID</param>
        /// <param name="secret">Secret to encode with</param>
        /// <param name="identity">Token identity</param>
        /// <param name="expiration">Token expiration</param>
        /// <param name="nbf">Token nbf</param>
        /// <param name="grants">Token grants</param>
        public Token(
            string accountSid,
            string signingKeySid,
            string secret,
            string identity = null,
            DateTime? expiration = null,
            DateTime? nbf = null,
            HashSet<IGrant> grants = null
        ) : base(secret, signingKeySid, expiration.HasValue ? expiration.Value : DateTime.UtcNow.AddSeconds(3600))
        {
            var now = BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow);
            this._id = signingKeySid + "-" + now;
            this._accountSid = accountSid;
            this._identity = identity;
            this._nbf = nbf;
            this._grants = grants;
        }

        /// <summary>
        /// Token ID
        /// </summary>
        public override string Id
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// Access token subject
        /// </summary>
        public override string Subject
        {
            get
            {
                return _accountSid;
            }
        }

        /// <summary>
        /// Token not before time
        /// </summary>
        public override DateTime? Nbf
        {
            get
            {
                return _nbf;
            }
        }

        /// <summary>
        /// Headers for an Access Token
        /// </summary>
        public override Dictionary<string, object> Headers
        {
            get
            {
                return new Dictionary<string, object> { { "cty", "twilio-fpa;v=1" } };
            }
        }

        /// <summary>
        /// Populate claims for the Access Token
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> Claims
        {
            get
            {
                var grants = new Dictionary<string, object>();
                if (_identity != null)
                {
                    grants.Add("identity", _identity);
                }

                if (_grants != null)
                {
                    foreach (var grant in _grants)
                    {
                        grants.Add(grant.Key, grant.Payload);
                    }
                }

                return new Dictionary<string, object> { { "grants", grants } };
            }
        }

    }
}
