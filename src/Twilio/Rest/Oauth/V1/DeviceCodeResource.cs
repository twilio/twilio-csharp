/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Oauth
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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Oauth.V1
{
    public class DeviceCodeResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateDeviceCodeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/device/code";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Oauth,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Issues a new Access token (optionally identity_token & refresh_token) in exchange of Oauth grant </summary>
        /// <param name="options"> Create DeviceCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeviceCode </returns>
        public static DeviceCodeResource Create(CreateDeviceCodeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Issues a new Access token (optionally identity_token & refresh_token) in exchange of Oauth grant </summary>
        /// <param name="options"> Create DeviceCode parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeviceCode </returns>
        public static async System.Threading.Tasks.Task<DeviceCodeResource> CreateAsync(CreateDeviceCodeOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Issues a new Access token (optionally identity_token & refresh_token) in exchange of Oauth grant </summary>
        /// <param name="clientSid"> A 34 character string that uniquely identifies this OAuth App. </param>
        /// <param name="scopes"> An Array of scopes for authorization request </param>
        /// <param name="audiences"> An array of intended audiences for token requests </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DeviceCode </returns>
        public static DeviceCodeResource Create(
                                          string clientSid,
                                          List<string> scopes,
                                          List<string> audiences = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateDeviceCodeOptions(clientSid, scopes){  Audiences = audiences };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Issues a new Access token (optionally identity_token & refresh_token) in exchange of Oauth grant </summary>
        /// <param name="clientSid"> A 34 character string that uniquely identifies this OAuth App. </param>
        /// <param name="scopes"> An Array of scopes for authorization request </param>
        /// <param name="audiences"> An array of intended audiences for token requests </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DeviceCode </returns>
        public static async System.Threading.Tasks.Task<DeviceCodeResource> CreateAsync(
                                                                                  string clientSid,
                                                                                  List<string> scopes,
                                                                                  List<string> audiences = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateDeviceCodeOptions(clientSid, scopes){  Audiences = audiences };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DeviceCodeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeviceCodeResource object represented by the provided JSON </returns>
        public static DeviceCodeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DeviceCodeResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The device verification code. </summary> 
        [JsonProperty("device_code")]
        public string DeviceCode { get; private set; }

        ///<summary> The verification code which end user uses to verify authorization request. </summary> 
        [JsonProperty("user_code")]
        public string UserCode { get; private set; }

        ///<summary> The URI that the end user visits to verify authorization request. </summary> 
        [JsonProperty("verification_uri")]
        public string VerificationUri { get; private set; }

        ///<summary> The URI with user_code that the end-user alternatively visits to verify authorization request. </summary> 
        [JsonProperty("verification_uri_complete")]
        public string VerificationUriComplete { get; private set; }

        ///<summary> The expiration time of the device_code and user_code in seconds. </summary> 
        [JsonProperty("expires_in")]
        public long? ExpiresIn { get; private set; }

        ///<summary> The minimum amount of time in seconds that the client should wait between polling requests to the token endpoint. </summary> 
        [JsonProperty("interval")]
        public int? Interval { get; private set; }



        private DeviceCodeResource() {

        }
    }
}

