using System;
using Twilio.Annotations;
using Twilio.AuthStrategies;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;
using System.Collections.Generic;

namespace Twilio.Credential
{
    [Beta]
    public class OrgsClientCredentialProvider : CredentialProvider
    {
        private string grantType;
        private string clientId;
        private string clientSecret;
        private AuthStrategy authStrategy;
        private TokenManager tokenManager;

        public OrgsClientCredentialProvider(string clientId, string clientSecret)
        {
            if (clientId == null || clientSecret == null)
            {
                throw new AuthenticationException("ClientId or ClientSecret cannot be null");
            }
            grantType = "client_credentials";
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            tokenManager = null;

        }

        public OrgsClientCredentialProvider(string clientId, string clientSecret, TokenManager tokenManager)
        {
            if (clientId == null || clientSecret == null || tokenManager == null)
            {
                throw new AuthenticationException("ClientId, ClientSecret, or TokenManager cannot be null");
            }
            grantType = "client_credentials";
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.tokenManager = tokenManager;
            this.authStrategy = new TokenAuthStrategy(tokenManager);
        }

        public override AuthStrategy ToAuthStrategy()
        {
            if (tokenManager == null)
            {
                tokenManager = new OrgsTokenManager(clientId, clientSecret);
            }
            authStrategy = new TokenAuthStrategy(tokenManager);
            return authStrategy;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj == null || GetType() != obj.GetType()) return false;

            var other = (OrgsClientCredentialProvider)obj;
            return clientId == other.clientId &&
                   clientSecret == other.clientSecret &&
                   EqualityComparer<TokenManager>.Default.Equals(tokenManager, other.tokenManager);
        }
    }
}
