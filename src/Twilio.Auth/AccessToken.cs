using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWT;

namespace Twilio.Auth
{
    public class AccessToken
    {
        static readonly int DEFAULT_TTL = 3600;

        string SigningKeySid { get; set; }
        string AccountSid { get; set; }
        string Secret { get; set; }
        string Identity { get; set; }
        int Ttl { get; set; }
        List<Grant> Grants { get; set; }

        public AccessToken(string accountSid, string signingKeySid, string secret) : this(accountSid, signingKeySid, secret, DEFAULT_TTL) { }

        public AccessToken(string accountSid, string signingKeySid, string secret, int ttl)
        {
            this.AccountSid = accountSid;
            this.SigningKeySid = signingKeySid;
            this.Secret = secret;
            this.Ttl = ttl;
            this.Grants = new List<Grant>();
        }

        /// <summary>
        /// Add a Grant to this AccessToken.
        /// </summary>
        /// <param name="grant">The grant to add</param>
        /// <returns>AccessToken</returns>
        public AccessToken AddGrant(Grant grant)
        {
            this.Grants.Add(grant);
            return this;
        }

        /// <summary>
        /// Generate a JWT with the provided information and sign it with the given secret.
        /// </summary>
        /// <param name="algorithm">The encryption type - default:HS256</param>
        /// <returns>Signed JWT authorizing the grants configured on this object</returns>
        public string ToJWT(JwtHashAlgorithm algorithm=JwtHashAlgorithm.HS256)
        {
            var headers = new Dictionary<string, object>();
            headers.Add("cty", "twilio-fpa;v=1");

            int now = ConvertToUnixTimestamp(DateTime.UtcNow);

            var grantPayload = new Dictionary<string, object>();
            if (this.Identity != null)
            {
                grantPayload.Add("identity", this.Identity);
            }

            foreach (Grant grant in this.Grants)
            {
                Console.Write(grant.GetGrantKey());
                grantPayload.Add(grant.GetGrantKey(), grant.GetPayload());
            }

            var payload = new
            {
                jti = String.Format("{0}-{1}", SigningKeySid, now),
                iss = SigningKeySid,
                sub = AccountSid,
                nbf = now,
                exp = now + Ttl,
                grants = grantPayload
            };

            return JsonWebToken.Encode(headers, payload, Secret, algorithm);
        }

        public override string ToString()
        {
            return ToJWT();
        }

        static int ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            return (int)Math.Floor(diff.TotalSeconds);
        }
    }
}
