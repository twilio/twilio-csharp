/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Organization Public API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.PreviewIam.V1
{
    public class TokenResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateTokenOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/token";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.PreviewIam,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create Token parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Token </returns>
        public static TokenResource Create(CreateTokenOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetNoAuthRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create Token parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Token </returns>
        public static async System.Threading.Tasks.Task<TokenResource> CreateAsync(CreateTokenOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetNoAuthRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="grantType"> Grant type is a credential representing resource owner's authorization which can be used by client to obtain access token. </param>
        /// <param name="clientId"> A 34 character string that uniquely identifies this OAuth App. </param>
        /// <param name="clientSecret"> The credential for confidential OAuth App. </param>
        /// <param name="code"> JWT token related to the authorization code grant type. </param>
        /// <param name="redirectUri"> The redirect uri </param>
        /// <param name="audience"> The targeted audience uri </param>
        /// <param name="refreshToken"> JWT token related to refresh access token. </param>
        /// <param name="scope"> The scope of token </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Token </returns>
        public static TokenResource Create(
                                          string grantType,
                                          string clientId,
                                          string clientSecret = null,
                                          string code = null,
                                          string redirectUri = null,
                                          string audience = null,
                                          string refreshToken = null,
                                          string scope = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateTokenOptions(grantType, clientId){  ClientSecret = clientSecret, Code = code, RedirectUri = redirectUri, Audience = audience, RefreshToken = refreshToken, Scope = scope };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="grantType"> Grant type is a credential representing resource owner's authorization which can be used by client to obtain access token. </param>
        /// <param name="clientId"> A 34 character string that uniquely identifies this OAuth App. </param>
        /// <param name="clientSecret"> The credential for confidential OAuth App. </param>
        /// <param name="code"> JWT token related to the authorization code grant type. </param>
        /// <param name="redirectUri"> The redirect uri </param>
        /// <param name="audience"> The targeted audience uri </param>
        /// <param name="refreshToken"> JWT token related to refresh access token. </param>
        /// <param name="scope"> The scope of token </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Token </returns>
        public static async System.Threading.Tasks.Task<TokenResource> CreateAsync(
                                                                                  string grantType,
                                                                                  string clientId,
                                                                                  string clientSecret = null,
                                                                                  string code = null,
                                                                                  string redirectUri = null,
                                                                                  string audience = null,
                                                                                  string refreshToken = null,
                                                                                  string scope = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateTokenOptions(grantType, clientId){  ClientSecret = clientSecret, Code = code, RedirectUri = redirectUri, Audience = audience, RefreshToken = refreshToken, Scope = scope };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TokenResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TokenResource object represented by the provided JSON </returns>
        public static TokenResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TokenResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> Token which carries the necessary information to access a Twilio resource directly. </summary> 
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        ///<summary> Token which carries the information necessary to get a new access token. </summary> 
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        ///<summary> Token which carries the information necessary of user profile. </summary> 
        [JsonProperty("id_token")]
        public string IdToken { get; private set; }

        ///<summary> Token type </summary> 
        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        ///<summary> The expires_in </summary> 
        [JsonProperty("expires_in")]
        public long? ExpiresIn { get; private set; }



        private TokenResource() {

        }
    }
}

