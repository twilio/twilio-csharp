/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Conversations
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
using Twilio.Types;


namespace Twilio.Rest.Conversations.V1.Service
{
    public class BindingResource : Resource
    {
    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class BindingTypeEnum : StringEnum
        {
            private BindingTypeEnum(string value) : base(value) {}
            public BindingTypeEnum() {}
            public static implicit operator BindingTypeEnum(string value)
            {
                return new BindingTypeEnum(value);
            }
            public static readonly BindingTypeEnum Apn = new BindingTypeEnum("apn");
            public static readonly BindingTypeEnum Gcm = new BindingTypeEnum("gcm");
            public static readonly BindingTypeEnum Fcm = new BindingTypeEnum("fcm");

        }

        
        /// <summary> Remove a push notification binding from the conversation service </summary>
        /// <param name="options"> Delete Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        private static Request BuildDeleteRequest(DeleteBindingOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Bindings/{Sid}";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Remove a push notification binding from the conversation service </summary>
        /// <param name="options"> Delete Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        public static bool Delete(DeleteBindingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove a push notification binding from the conversation service </summary>
        /// <param name="options"> Delete Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteBindingOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove a push notification binding from the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) to delete the Binding resource from. </param>
        /// <param name="pathSid"> The SID of the Binding resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        public static bool Delete(string pathChatServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteBindingOptions(pathChatServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove a push notification binding from the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) to delete the Binding resource from. </param>
        /// <param name="pathSid"> The SID of the Binding resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathChatServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteBindingOptions(pathChatServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchBindingOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Bindings/{Sid}";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a push notification binding from the conversation service </summary>
        /// <param name="options"> Fetch Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        public static BindingResource Fetch(FetchBindingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a push notification binding from the conversation service </summary>
        /// <param name="options"> Fetch Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<BindingResource> FetchAsync(FetchBindingOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a push notification binding from the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Binding resource is associated with. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        public static BindingResource Fetch(
                                         string pathChatServiceSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchBindingOptions(pathChatServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a push notification binding from the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Binding resource is associated with. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<BindingResource> FetchAsync(string pathChatServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchBindingOptions(pathChatServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadBindingOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Bindings";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all push notification bindings in the conversation service </summary>
        /// <param name="options"> Read Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Binding </returns>
        public static ResourceSet<BindingResource> Read(ReadBindingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<BindingResource>.FromJson("bindings", response.Content);
            return new ResourceSet<BindingResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all push notification bindings in the conversation service </summary>
        /// <param name="options"> Read Binding parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BindingResource>> ReadAsync(ReadBindingOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<BindingResource>.FromJson("bindings", response.Content);
            return new ResourceSet<BindingResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all push notification bindings in the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Binding resource is associated with. </param>
        /// <param name="bindingType"> The push technology used by the Binding resources to read.  Can be: `apn`, `gcm`, or `fcm`.  See [push notification configuration](https://www.twilio.com/docs/chat/push-notification-configuration) for more info. </param>
        /// <param name="identity"> The identity of a [Conversation User](https://www.twilio.com/docs/conversations/api/user-resource) this binding belongs to. See [access tokens](https://www.twilio.com/docs/conversations/create-tokens) for more details. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of Binding </returns>
        public static ResourceSet<BindingResource> Read(
                                                     string pathChatServiceSid,
                                                     List<BindingResource.BindingTypeEnum> bindingType = null,
                                                     List<string> identity = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadBindingOptions(pathChatServiceSid){ BindingType = bindingType, Identity = identity, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all push notification bindings in the conversation service </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Binding resource is associated with. </param>
        /// <param name="bindingType"> The push technology used by the Binding resources to read.  Can be: `apn`, `gcm`, or `fcm`.  See [push notification configuration](https://www.twilio.com/docs/chat/push-notification-configuration) for more info. </param>
        /// <param name="identity"> The identity of a [Conversation User](https://www.twilio.com/docs/conversations/api/user-resource) this binding belongs to. See [access tokens](https://www.twilio.com/docs/conversations/create-tokens) for more details. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of Binding </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BindingResource>> ReadAsync(
                                                                                             string pathChatServiceSid,
                                                                                             List<BindingResource.BindingTypeEnum> bindingType = null,
                                                                                             List<string> identity = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadBindingOptions(pathChatServiceSid){ BindingType = bindingType, Identity = identity, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<BindingResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<BindingResource>.FromJson("bindings", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<BindingResource> NextPage(Page<BindingResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<BindingResource>.FromJson("bindings", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<BindingResource> PreviousPage(Page<BindingResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<BindingResource>.FromJson("bindings", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a BindingResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BindingResource object represented by the provided JSON </returns>
        public static BindingResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BindingResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this binding. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Binding resource is associated with. </summary> 
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }

        ///<summary> The SID of the [Credential](https://www.twilio.com/docs/conversations/api/credential-resource) for the binding. See [push notification configuration](https://www.twilio.com/docs/chat/push-notification-configuration) for more info. </summary> 
        [JsonProperty("credential_sid")]
        public string CredentialSid { get; private set; }

        ///<summary> The date that this resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The unique endpoint identifier for the Binding. The format of this value depends on the `binding_type`. </summary> 
        [JsonProperty("endpoint")]
        public string Endpoint { get; private set; }

        ///<summary> The application-defined string that uniquely identifies the [Conversation User](https://www.twilio.com/docs/conversations/api/user-resource) within the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource). See [access tokens](https://www.twilio.com/docs/conversations/create-tokens) for more info. </summary> 
        [JsonProperty("identity")]
        public string Identity { get; private set; }

        
        [JsonProperty("binding_type")]
        public BindingResource.BindingTypeEnum BindingType { get; private set; }

        ///<summary> The [Conversation message types](https://www.twilio.com/docs/chat/push-notification-configuration#push-types) the binding is subscribed to. </summary> 
        [JsonProperty("message_types")]
        public List<string> MessageTypes { get; private set; }

        ///<summary> An absolute API resource URL for this binding. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private BindingResource() {

        }
    }
}

