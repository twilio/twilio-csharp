#if !NET35
using System.IdentityModel.Tokens.Jwt;
#else
using System.Collections.Generic;
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

        private readonly JwtSecurityToken token;

        public DecodedJwt(string jwt, string secret)
        {
            token = new JwtSecurityToken(jwt);
        }

#else
        public IDictionary<string, object> Payload
        {
            get
            {
                return JsonConvert.DeserializeObject<Dictionary<string, object>>(token);
            }
        }

        private readonly string token;

        public DecodedJwt(string jwt, string secret)
        {
            token = JWT.JsonWebToken.Decode(jwt, secret);
        }

#endif

    }
}
