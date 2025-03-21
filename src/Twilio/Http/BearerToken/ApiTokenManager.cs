using Twilio.Rest.PreviewIam.V1;
using Twilio.Exceptions;
using System;
using Twilio.Annotations;


namespace Twilio.Http.BearerToken{

    /// <summary>
    /// Implementation of a Token Manager
    /// </summary>
    [Beta]
    public class ApiTokenManager : TokenManager
    {

        public string GrantType { get; }
        public string ClientId { get; }
        public string ClientSecret { get; set; }
        public string Code { get; set; }
        public string RedirectUri { get; set; }
        public string Audience { get; set; }
        public string RefreshToken { get; set; }
        public string Scope { get; set; }

        /// Constructor for a ApiTokenManager
        public ApiTokenManager(
            string clientId,
            string clientSecret,
            string code = null,
            string redirectUri = null,
            string audience = null,
            string refreshToken = null,
            string scope = null
        ){
            GrantType = "client_credentials";
            ClientId = clientId;
            ClientSecret = clientSecret;
            Code = code;
            RedirectUri = redirectUri;
            Audience = audience;
            RefreshToken = refreshToken;
            Scope = scope;
        }

        public string fetchAccessToken(){
           CreateTokenOptions createTokenOptions = new CreateTokenOptions(GrantType, ClientId);
           if(ClientSecret != null){ createTokenOptions.ClientSecret = ClientSecret;}
           if(Code != null){ createTokenOptions.Code = Code; }
           if(RedirectUri != null){ createTokenOptions.RedirectUri = RedirectUri; }
           if(Audience != null){ createTokenOptions.Audience = Audience; }
           if(RefreshToken != null){ createTokenOptions.RefreshToken = RefreshToken; }
           if(Scope != null){ createTokenOptions.Scope = Scope; }

           TokenResource token;
           try{
                token = TokenResource.Create(createTokenOptions);
                if(token == null || token.AccessToken == null){
                    throw new ApiException("Token creation failed");
                }
           }catch(Exception e){
               throw new ApiException("Token creation failed" + e);
           }

           return token.AccessToken;
        }
    }
}