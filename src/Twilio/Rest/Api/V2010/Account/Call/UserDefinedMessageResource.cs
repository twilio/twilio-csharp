/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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



namespace Twilio.Rest.Api.V2010.Account.Call
{
    public class UserDefinedMessageResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateUserDefinedMessageOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/UserDefinedMessages.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new User Defined Message for the given Call SID. </summary>
        /// <param name="options"> Create UserDefinedMessage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessage </returns>
        public static UserDefinedMessageResource Create(CreateUserDefinedMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new User Defined Message for the given Call SID. </summary>
        /// <param name="options"> Create UserDefinedMessage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessage </returns>
        public static async System.Threading.Tasks.Task<UserDefinedMessageResource> CreateAsync(CreateUserDefinedMessageOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new User Defined Message for the given Call SID. </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the User Defined Message is associated with. </param>
        /// <param name="content"> The User Defined Message in the form of URL-encoded JSON string. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created User Defined Message. </param>
        /// <param name="idempotencyKey"> A unique string value to identify API call. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserDefinedMessage </returns>
        public static UserDefinedMessageResource Create(
                                          string pathCallSid,
                                          string content,
                                          string pathAccountSid = null,
                                          string idempotencyKey = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateUserDefinedMessageOptions(pathCallSid, content){  PathAccountSid = pathAccountSid, IdempotencyKey = idempotencyKey };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new User Defined Message for the given Call SID. </summary>
        /// <param name="pathCallSid"> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the User Defined Message is associated with. </param>
        /// <param name="content"> The User Defined Message in the form of URL-encoded JSON string. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created User Defined Message. </param>
        /// <param name="idempotencyKey"> A unique string value to identify API call. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserDefinedMessage </returns>
        public static async System.Threading.Tasks.Task<UserDefinedMessageResource> CreateAsync(
                                                                                  string pathCallSid,
                                                                                  string content,
                                                                                  string pathAccountSid = null,
                                                                                  string idempotencyKey = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateUserDefinedMessageOptions(pathCallSid, content){  PathAccountSid = pathAccountSid, IdempotencyKey = idempotencyKey };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UserDefinedMessageResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserDefinedMessageResource object represented by the provided JSON </returns>
        public static UserDefinedMessageResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UserDefinedMessageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> Account SID. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Call SID. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> User Defined Message SID. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The date this User Defined Message was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }



        private UserDefinedMessageResource() {

        }
    }
}

