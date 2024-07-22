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


using Twilio.Clients.NoAuth;
using Twilio.Http.NoAuth;


namespace Twilio.Rest.PreviewIam.Organizations
{
    public class AuthorizeResource : Resource
    {
    

    

        
        private static NoAuthRequest BuildFetchRequest(FetchAuthorizeOptions options, TwilioNoAuthRestClient client)
        {
            
            string path = "/v1/authorize";


            return new NoAuthRequest(
                HttpMethod.Get,
                Rest.Domain.PreviewIam,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Authorize parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Authorize </returns>
        public static AuthorizeResource Fetch(FetchAuthorizeOptions options, TwilioNoAuthRestClient client = null)
        {
            client = client ?? TwilioNoAuthClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Authorize parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Authorize </returns>
        public static async System.Threading.Tasks.Task<AuthorizeResource> FetchAsync(FetchAuthorizeOptions options, TwilioNoAuthRestClient client = null)
        {
            client = client ?? TwilioNoAuthClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="responseType"> Response Type </param>
        /// <param name="clientId"> The Client Identifier </param>
        /// <param name="redirectUri"> The url to which response will be redirected to </param>
        /// <param name="scope"> The scope of the access request </param>
        /// <param name="state"> An opaque value which can be used to maintain state between the request and callback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Authorize </returns>
        public static AuthorizeResource Fetch(
                                         string responseType = null, 
                                         string clientId = null, 
                                         string redirectUri = null, 
                                         string scope = null, 
                                         string state = null, 
                                        TwilioNoAuthRestClient client = null)
        {
            var options = new FetchAuthorizeOptions(){ ResponseType = responseType,ClientId = clientId,RedirectUri = redirectUri,Scope = scope,State = state };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="responseType"> Response Type </param>
        /// <param name="clientId"> The Client Identifier </param>
        /// <param name="redirectUri"> The url to which response will be redirected to </param>
        /// <param name="scope"> The scope of the access request </param>
        /// <param name="state"> An opaque value which can be used to maintain state between the request and callback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Authorize </returns>
        public static async System.Threading.Tasks.Task<AuthorizeResource> FetchAsync(string responseType = null, string clientId = null, string redirectUri = null, string scope = null, string state = null, TwilioNoAuthRestClient client = null)
        {
            var options = new FetchAuthorizeOptions(){ ResponseType = responseType,ClientId = clientId,RedirectUri = redirectUri,Scope = scope,State = state };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AuthorizeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AuthorizeResource object represented by the provided JSON </returns>
        public static AuthorizeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AuthorizeResource>(json);
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

    
        ///<summary> The callback URL </summary> 
        [JsonProperty("redirect_to")]
        public Uri RedirectTo { get; private set; }



        private AuthorizeResource() {

        }
    }
}

