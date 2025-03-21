/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Iam
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


namespace Twilio.Rest.Iam.V1
{
    public class NewApiKeyResource : Resource
    {
    

    
        public sealed class KeytypeEnum : StringEnum
        {
            private KeytypeEnum(string value) : base(value) {}
            public KeytypeEnum() {}
            public static implicit operator KeytypeEnum(string value)
            {
                return new KeytypeEnum(value);
            }
            public static readonly KeytypeEnum Restricted = new KeytypeEnum("restricted");

        }

        
        private static Request BuildCreateRequest(CreateNewApiKeyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Keys";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Iam,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Signing Key for the account making the request. </summary>
        /// <param name="options"> Create NewApiKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of NewApiKey </returns>
        public static NewApiKeyResource Create(CreateNewApiKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Signing Key for the account making the request. </summary>
        /// <param name="options"> Create NewApiKey parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of NewApiKey </returns>
        public static async System.Threading.Tasks.Task<NewApiKeyResource> CreateAsync(CreateNewApiKeyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Signing Key for the account making the request. </summary>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Payments resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="keyType">  </param>
        /// <param name="policy"> The \\\\`Policy\\\\` object is a collection that specifies the allowed Twilio permissions for the restricted key. For more information on the permissions available with restricted API keys, refer to the [Twilio documentation](https://www.twilio.com/docs/iam/api-keys/restricted-api-keys#permissions-available-with-restricted-api-keys). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of NewApiKey </returns>
        public static NewApiKeyResource Create(
                                          string accountSid,
                                          string friendlyName = null,
                                          NewApiKeyResource.KeytypeEnum keyType = null,
                                          object policy = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateNewApiKeyOptions(accountSid){  FriendlyName = friendlyName, KeyType = keyType, Policy = policy };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Signing Key for the account making the request. </summary>
        /// <param name="accountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Payments resource. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="keyType">  </param>
        /// <param name="policy"> The \\\\`Policy\\\\` object is a collection that specifies the allowed Twilio permissions for the restricted key. For more information on the permissions available with restricted API keys, refer to the [Twilio documentation](https://www.twilio.com/docs/iam/api-keys/restricted-api-keys#permissions-available-with-restricted-api-keys). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of NewApiKey </returns>
        public static async System.Threading.Tasks.Task<NewApiKeyResource> CreateAsync(
                                                                                  string accountSid,
                                                                                  string friendlyName = null,
                                                                                  NewApiKeyResource.KeytypeEnum keyType = null,
                                                                                  object policy = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateNewApiKeyOptions(accountSid){  FriendlyName = friendlyName, KeyType = keyType, Policy = policy };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a NewApiKeyResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NewApiKeyResource object represented by the provided JSON </returns>
        public static NewApiKeyResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<NewApiKeyResource>(json);
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

    
        ///<summary> The unique string that that we created to identify the NewKey resource. You will use this as the basic-auth `user` when authenticating to the API. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The date and time in GMT that the API Key was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the new API Key was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The secret your application uses to sign Access Tokens and to authenticate to the REST API (you will use this as the basic-auth `password`).  **Note that for security reasons, this field is ONLY returned when the API Key is first created.** </summary> 
        [JsonProperty("secret")]
        public string Secret { get; private set; }

        ///<summary> Collection of allow assertions. </summary> 
        [JsonProperty("policy")]
        public object Policy { get; private set; }



        private NewApiKeyResource() {

        }
    }
}

