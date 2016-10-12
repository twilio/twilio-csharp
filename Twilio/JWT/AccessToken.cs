using System;
using System.Collections.Generic;
using JWT;

namespace Twilio.JWT
{
    /// <summary>
    /// Access Token for Twilio resources
    /// </summary>
    public class AccessToken
    {
        private const int DefaultTtl = 3600;

        private readonly string _signingKeySid;
        private readonly string _accountSid;
        private readonly string _secret;
        public string Identity { get; set; }
        public int Ttl { get; set; }
        public int? Nbf { get; set; }
        public List<IGrant> Grants { get; set; }

        /// <summary>
        /// Create a new access token
        /// </summary>
        ///
        /// <param name="accountSid">account sid for the token</param>
        /// <param name="signingKeySid">signing key sid to use</param>
        /// <param name="secret">signing key secret</param>
        /// <param name="ttl">ttl for the token</param>
        public AccessToken(string accountSid, string signingKeySid, string secret, int ttl=DefaultTtl)
        {
            _accountSid = accountSid;
            _signingKeySid = signingKeySid;
            _secret = secret;
            Ttl = ttl;
            Grants = new List<IGrant>();
        }

        /// <summary>
        /// Add a Grant to this AccessToken.
        /// </summary>
        /// <param name="grant">The grant to add</param>
        /// <returns>AccessToken</returns>
        public AccessToken AddGrant(IGrant grant)
        {
            Grants.Add(grant);
            return this;
        }

        /// <summary>
        /// Generate a JWT with the provided information and sign it with the given secret.
        /// </summary>
        /// <param name="algorithm">The encryption type - default:HS256</param>
        /// <returns>Signed JWT authorizing the grants configured on this object</returns>
        public string ToJwt(JwtHashAlgorithm algorithm=JwtHashAlgorithm.HS256)
        {
            var headers = new Dictionary<string, object> {{"cty", "twilio-fpa;v=1"}};
            var now = ConvertToUnixTimestamp(DateTime.UtcNow);

            var grantPayload = new Dictionary<string, object>();
            if (Identity != null)
            {
                grantPayload.Add("identity", Identity);
            }

            foreach (var grant in Grants)
            {
                grantPayload.Add(grant.GetGrantKey(), grant.GetPayload());
            }

            var payload = new Dictionary<string, object>
            {
                {"jti", $"{_signingKeySid}-{now}"},
                {"iss", _signingKeySid},
                {"sub", _accountSid},
                {"exp", now + Ttl},
                {"grants", grantPayload}
            };

            if (Nbf != null)
            {
                payload.Add("nbf", Nbf);
            }

            return JsonWebToken.Encode(headers, payload, _secret, algorithm);
        }

        public override string ToString()
        {
            return ToJwt();
        }

        public static int ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}
