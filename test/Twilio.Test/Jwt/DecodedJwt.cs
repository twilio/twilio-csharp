#if !NET35
using System.IdentityModel.Tokens.Jwt;
#else
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
#endif

using System;
using Newtonsoft.Json;

namespace Twilio.Tests.Jwt
{
    class DecodedJwt
    {
#if !NET35

        public JwtPayload Payload
        {
            get
            {
                return token.Payload;
            }
        }

        public JwtHeader Header
        {
            get
            {
                return token.Header;
            }
        }

        private readonly JwtSecurityToken token;

        public DecodedJwt(string jwt, string secret)
        {
            token = new JwtSecurityToken(jwt);
        }

#else
        private static byte[] Base64UrlDecode(string input) => Convert.FromBase64String(UrlDecode(input));

        private static string UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            // Pad with trailing '='s
            switch (output.Length % 4)
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new Exception($"Illegal base-64 string: '{input}'.");
            }

            return output;
        }

        public IDictionary<string, object> Header
        {
            get
            {
                var parts = _jwt.Split('.');
                var header = parts[0];
                var headerBytes = Base64UrlDecode(header);
                var headerJson = Encoding.UTF8.GetString(headerBytes);
                var headerData = JsonConvert.DeserializeObject<Dictionary<string, object>>(headerJson);

                return headerData;
            }
        }

        public IDictionary<string, object> Payload
        {
            get
            {
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(token);
            }
        }

        private readonly string _jwt;
        private readonly string token;

        public DecodedJwt(string jwt, string secret)
        {
            _jwt = jwt;
            token = JWT.JsonWebToken.Decode(jwt, secret);
        }

#endif

    }
}
