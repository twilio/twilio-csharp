/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
 * This is the public Twilio REST API.
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
using Twilio.Types;


namespace Twilio.Rest.Verify.V2.Service
{
    public class AccessTokenResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class FactorTypesEnum : StringEnum
        {
            private FactorTypesEnum(string value) : base(value) {}
            public FactorTypesEnum() {}
            public static implicit operator FactorTypesEnum(string value)
            {
                return new FactorTypesEnum(value);
            }
            public static readonly FactorTypesEnum Push = new FactorTypesEnum("push");

        }

        
        private static Request BuildCreateRequest(CreateAccessTokenOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/AccessTokens";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new enrollment Access Token for the Entity </summary>
        /// <param name="options"> Create AccessToken parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AccessToken </returns>
        public static AccessTokenResource Create(CreateAccessTokenOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new enrollment Access Token for the Entity </summary>
        /// <param name="options"> Create AccessToken parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AccessToken </returns>
        public static async System.Threading.Tasks.Task<AccessTokenResource> CreateAsync(CreateAccessTokenOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new enrollment Access Token for the Entity </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="identity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, and generated by your external system, such as your user's UUID, GUID, or SID. </param>
        /// <param name="factorType">  </param>
        /// <param name="factorFriendlyName"> The friendly name of the factor that is going to be created with this access token </param>
        /// <param name="ttl"> How long, in seconds, the access token is valid. Can be an integer between 60 and 300. Default is 60. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AccessToken </returns>
        public static AccessTokenResource Create(
                                          string pathServiceSid,
                                          string identity,
                                          AccessTokenResource.FactorTypesEnum factorType,
                                          string factorFriendlyName = null,
                                          int? ttl = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateAccessTokenOptions(pathServiceSid, identity, factorType){  FactorFriendlyName = factorFriendlyName, Ttl = ttl };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new enrollment Access Token for the Entity </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="identity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, and generated by your external system, such as your user's UUID, GUID, or SID. </param>
        /// <param name="factorType">  </param>
        /// <param name="factorFriendlyName"> The friendly name of the factor that is going to be created with this access token </param>
        /// <param name="ttl"> How long, in seconds, the access token is valid. Can be an integer between 60 and 300. Default is 60. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AccessToken </returns>
        public static async System.Threading.Tasks.Task<AccessTokenResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string identity,
                                                                                  AccessTokenResource.FactorTypesEnum factorType,
                                                                                  string factorFriendlyName = null,
                                                                                  int? ttl = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateAccessTokenOptions(pathServiceSid, identity, factorType){  FactorFriendlyName = factorFriendlyName, Ttl = ttl };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchAccessTokenOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/AccessTokens/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch an Access Token for the Entity </summary>
        /// <param name="options"> Fetch AccessToken parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AccessToken </returns>
        public static AccessTokenResource Fetch(FetchAccessTokenOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an Access Token for the Entity </summary>
        /// <param name="options"> Fetch AccessToken parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AccessToken </returns>
        public static async System.Threading.Tasks.Task<AccessTokenResource> FetchAsync(FetchAccessTokenOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an Access Token for the Entity </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Access Token. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AccessToken </returns>
        public static AccessTokenResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchAccessTokenOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an Access Token for the Entity </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Access Token. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AccessToken </returns>
        public static async System.Threading.Tasks.Task<AccessTokenResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchAccessTokenOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AccessTokenResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccessTokenResource object represented by the provided JSON </returns>
        public static AccessTokenResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AccessTokenResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies this Access Token. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique SID identifier of the Verify Service. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The unique external identifier for the Entity of the Service. </summary> 
        [JsonProperty("entity_identity")]
        public string EntityIdentity { get; private set; }

        
        [JsonProperty("factor_type")]
        public AccessTokenResource.FactorTypesEnum FactorType { get; private set; }

        ///<summary> A human readable description of this factor, up to 64 characters. For a push factor, this can be the device's name. </summary> 
        [JsonProperty("factor_friendly_name")]
        public string FactorFriendlyName { get; private set; }

        ///<summary> The access token generated for enrollment, this is an encrypted json web token. </summary> 
        [JsonProperty("token")]
        public string Token { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> How long, in seconds, the access token is valid. Max: 5 minutes </summary> 
        [JsonProperty("ttl")]
        public int? Ttl { get; private set; }

        ///<summary> The date that this access token was created, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }



        private AccessTokenResource() {

        }
    }
}

