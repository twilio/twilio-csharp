using System;
using System.Threading;
using Twilio.Http.BearerToken;
using Twilio.Exceptions;

#if !NET35
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
#endif

#if NET35
using Twilio.Http.Net35;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
#endif

namespace Twilio.AuthStrategies
{
    public class TokenAuthStrategy : AuthStrategy
    {
        private string token;
        private TokenManager tokenManager;


        public TokenAuthStrategy(TokenManager tokenManager)
        {
            this.tokenManager = tokenManager ?? throw new ArgumentNullException(nameof(tokenManager));
        }

        public override string GetAuthString()
        {
            FetchToken();
            return $"Bearer {token}";
        }

        public override bool RequiresAuthentication()
        {
            return true;
        }

        // Token-specific refresh logic
        private void FetchToken()
        {
            if (string.IsNullOrEmpty(token) || tokenExpired(token))
            {
                lock (typeof(TokenAuthStrategy))
                {
                    if (string.IsNullOrEmpty(token) || tokenExpired(token))
                    {
                        token = tokenManager.fetchAccessToken();
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            var that = (TokenAuthStrategy)obj;
            return token == that.token && tokenManager.Equals(that.tokenManager);
        }

        public override int GetHashCode()
        {
           int hash = 17;
           hash = hash * 31 + (token != null ? token.GetHashCode() : 0);
           hash = hash * 31 + (tokenManager != null ? tokenManager.GetHashCode() : 0);
           return hash;
        }


        public bool tokenExpired(String accessToken){
            #if NET35
            return IsTokenExpired(accessToken);
            #else
            return isTokenExpired(accessToken);
            #endif
        }

#if NET35
    public static bool IsTokenExpired(string token)
        {
            try
            {
                // Split the token into its components
                var parts = token.Split('.');
                if (parts.Length != 3)
                    throw new ArgumentException("Malformed token received");

                // Decode the payload (the second part of the JWT)
                string payload = Base64UrlEncode.Decode(parts[1]);

                // Parse the payload JSON
                var serializer = new JavaScriptSerializer();
                var payloadData = serializer.Deserialize<Dictionary<string, object>>(payload);

                // Check the 'exp' claim
                if (payloadData.TryGetValue("exp", out object expObj))
                {
                    if (long.TryParse(expObj.ToString(), out long exp))
                    {
                        DateTime expirationDate = UnixTimeStampToDateTime(exp);
                        return DateTime.UtcNow > expirationDate;
                    }
                }

                // If 'exp' claim is missing or not a valid timestamp, consider the token expired
                throw new ApiConnectionException("token expired");
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., malformed token or invalid JSON)
                Console.WriteLine($"Error checking token expiration: {ex.Message}");
                throw new ApiConnectionException("token expired");
                return true; // Consider as expired if there's an error
            }
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTimeStamp);
        }
#endif

#if !NET35
        public bool isTokenExpired(string token){
            var handler = new JwtSecurityTokenHandler();
            try{
                var jwtToken = handler.ReadJwtToken(token);
                var exp = jwtToken.Payload.Exp;
                if (exp.HasValue)
                    {
                        var expirationDate = DateTimeOffset.FromUnixTimeSeconds(exp.Value).UtcDateTime;
                        return DateTime.UtcNow > expirationDate;
                    }
                else
                {
                    return true; // Assuming token is expired if exp claim is missing
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading token: {ex.Message}");

                return true; // Treat as expired if there is an error
            }
        }
#endif
    }
}
