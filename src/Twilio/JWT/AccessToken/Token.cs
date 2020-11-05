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
        private readonly string _region;

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
        /// <param name="region">Token region</param>
        public Token(
            string accountSid,
            string signingKeySid,
            string secret,
            string identity = null,
            DateTime? expiration = null,
            DateTime? nbf = null,
            HashSet<IGrant> grants = null,
            string region = null
        ) : base(secret, signingKeySid, expiration.HasValue ? expiration.Value : DateTime.UtcNow.AddSeconds(3600))
        {
            var now = BaseJwt.ConvertToUnixTimestamp(DateTime.UtcNow);
            this._id = signingKeySid + "-" + now;
            this._accountSid = accountSid;
            this._identity = identity;
            this._nbf = nbf;
            this._grants = grants;
            this._region = region;
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
        /// The region associated with this account
        /// </summary>
        public string Region
        {
            get
            {
                return _region;
            }
        }

        /// <summary>
        /// Headers for an Access Token
        /// </summary>
        public override Dictionary<string, object> Headers
        {
            get
            {
                var headers = new Dictionary<string, object> { { "cty", "twilio-fpa;v=1" } };

                if (_region != null)
                {
                    headers.Add("twr", _region);
                }

                return headers;
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
