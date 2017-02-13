using System;
using System.Collections.Generic;
using System.Text;

#if NET40
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
#else
using JWT;
#endif

namespace Twilio.Jwt
{
    public abstract class BaseJwt
    {
#if NET40
        private static readonly string Algorithm = "HS256";
#else
        private static readonly JwtHashAlgorithm Algorithm = JwtHashAlgorithm.HS256;
#endif

        public virtual string Id { get; }
        public virtual string Subject { get; }
        public virtual DateTime? Nbf { get; }

        public abstract Dictionary<string, object> Headers { get; }
        public abstract Dictionary<string, object> Claims { get; }

        private readonly string _secret;
        private readonly string _issuer;
        private readonly DateTime _expiration;

        protected BaseJwt(string secret, string issuer, DateTime expiration)
        {
            this._secret = secret;
            this._issuer = issuer;
            this._expiration = expiration;
        }

        public string ToJwt()
        {
            var headers = BuildHeaders();
            foreach (var entry in Headers)
            {
                headers.Add(entry.Key, entry.Value);
            }

            var payload = BuildPayload();
            if (Id != null)
            {
                payload.Add("jti", Id);
            }

            if (Subject != null)
            {
                payload.Add("sub", Subject);
            }

            if (Nbf.HasValue)
            {
                payload.Add("nbf", ConvertToUnixTimestamp(Nbf.Value));
            }

            foreach (var entry in Claims)
            {
                payload.Add(entry.Key, entry.Value);
            }

            return BuildToken(headers, payload);
        }

#if NET40
        private JwtHeader BuildHeaders()
        {
            return new JwtHeader(new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret)),
                Algorithm
            ));
        }

        private JwtPayload BuildPayload()
        {
            return new JwtPayload
            {
                {"iss", _issuer},
                {"exp", ConvertToUnixTimestamp(_expiration)}
            };
        }

        private string BuildToken(JwtHeader headers, JwtPayload payload)
        {
            var token = new JwtSecurityToken(headers, payload);
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }
#else
        private Dictionary<string, object> BuildHeaders()
        {
            return new Dictionary<string, object> { { "typ", "JWT" } };
        }

        private Dictionary<string, object> BuildPayload()
        {
            return new Dictionary<string, object>
            {
                {"iss", _issuer},
                {"exp", ConvertToUnixTimestamp(_expiration)}
            };
        }

        private string BuildToken(Dictionary<string, object> headers, Dictionary<string, object> payload)
        {
            return JsonWebToken.Encode(headers, payload, _secret, Algorithm);
        }
#endif

        public static long ConvertToUnixTimestamp(DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date - epoch).TotalSeconds);;
        }
    }
}
