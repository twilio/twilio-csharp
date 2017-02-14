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
            this._id = $"{signingKeySid}-{now}";
            this._accountSid = accountSid;
            this._identity = identity;
            this._nbf = nbf;
            this._grants = grants;
        }

        public override string Id
        {
            get
            {
                return _id;
            }
        }
        public override string Subject
        {
            get
            {
                return _accountSid;
            }
        }
        public override DateTime? Nbf
        {
            get
            {
                return _nbf;
            }
        }

        public override Dictionary<string, object> Headers
        {
            get
            {
                return new Dictionary<string, object> { { "cty", "twilio-fpa;v=1" } };
            }
        }

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
