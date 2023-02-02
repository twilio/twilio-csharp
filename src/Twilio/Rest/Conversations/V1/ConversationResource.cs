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


namespace Twilio.Rest.Conversations.V1
{
    public class ConversationResource : Resource
    {
    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StateEnum : StringEnum
        {
            private StateEnum(string value) : base(value) {}
            public StateEnum() {}
            public static implicit operator StateEnum(string value)
            {
                return new StateEnum(value);
            }
            public static readonly StateEnum Inactive = new StateEnum("inactive");
            public static readonly StateEnum Active = new StateEnum("active");
            public static readonly StateEnum Closed = new StateEnum("closed");

        }
        public sealed class WebhookEnabledTypeEnum : StringEnum
        {
            private WebhookEnabledTypeEnum(string value) : base(value) {}
            public WebhookEnabledTypeEnum() {}
            public static implicit operator WebhookEnabledTypeEnum(string value)
            {
                return new WebhookEnabledTypeEnum(value);
            }
            public static readonly WebhookEnabledTypeEnum True = new WebhookEnabledTypeEnum("true");
            public static readonly WebhookEnabledTypeEnum False = new WebhookEnabledTypeEnum("false");

        }

        
        private static Request BuildCreateRequest(CreateConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> Create a new conversation in your account's default service </summary>
        /// <param name="options"> Create Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Create(CreateConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new conversation in your account's default service </summary>
        /// <param name="options"> Create Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ConversationResource> CreateAsync(CreateConversationOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new conversation in your account's default service </summary>
        /// <param name="friendlyName"> The human-readable name of this conversation, limited to 256 characters. Optional. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </param>
        /// <param name="dateCreated"> The date that this resource was created. </param>
        /// <param name="dateUpdated"> The date that this resource was last updated. </param>
        /// <param name="messagingServiceSid"> The unique ID of the [Messaging Service](https://www.twilio.com/docs/sms/services/api) this conversation belongs to. </param>
        /// <param name="attributes"> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </param>
        /// <param name="state">  </param>
        /// <param name="timersInactive"> ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="timersClosed"> ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Create(
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          DateTime? dateCreated = null,
                                          DateTime? dateUpdated = null,
                                          string messagingServiceSid = null,
                                          string attributes = null,
                                          ConversationResource.StateEnum state = null,
                                          string timersInactive = null,
                                          string timersClosed = null,
                                          ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateConversationOptions(){  FriendlyName = friendlyName, UniqueName = uniqueName, DateCreated = dateCreated, DateUpdated = dateUpdated, MessagingServiceSid = messagingServiceSid, Attributes = attributes, State = state, TimersInactive = timersInactive, TimersClosed = timersClosed, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new conversation in your account's default service </summary>
        /// <param name="friendlyName"> The human-readable name of this conversation, limited to 256 characters. Optional. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </param>
        /// <param name="dateCreated"> The date that this resource was created. </param>
        /// <param name="dateUpdated"> The date that this resource was last updated. </param>
        /// <param name="messagingServiceSid"> The unique ID of the [Messaging Service](https://www.twilio.com/docs/sms/services/api) this conversation belongs to. </param>
        /// <param name="attributes"> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </param>
        /// <param name="state">  </param>
        /// <param name="timersInactive"> ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="timersClosed"> ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ConversationResource> CreateAsync(
                                                                                  string friendlyName = null,
                                                                                  string uniqueName = null,
                                                                                  DateTime? dateCreated = null,
                                                                                  DateTime? dateUpdated = null,
                                                                                  string messagingServiceSid = null,
                                                                                  string attributes = null,
                                                                                  ConversationResource.StateEnum state = null,
                                                                                  string timersInactive = null,
                                                                                  string timersClosed = null,
                                                                                  ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateConversationOptions(){  FriendlyName = friendlyName, UniqueName = uniqueName, DateCreated = dateCreated, DateUpdated = dateUpdated, MessagingServiceSid = messagingServiceSid, Attributes = attributes, State = state, TimersInactive = timersInactive, TimersClosed = timersClosed, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Remove a conversation from your account's default service </summary>
        /// <param name="options"> Delete Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        private static Request BuildDeleteRequest(DeleteConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> Remove a conversation from your account's default service </summary>
        /// <param name="options"> Delete Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static bool Delete(DeleteConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove a conversation from your account's default service </summary>
        /// <param name="options"> Delete Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteConversationOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove a conversation from your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static bool Delete(string pathSid, ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null, ITwilioRestClient client = null)
        {
            var options = new DeleteConversationOptions(pathSid)      { XTwilioWebhookEnabled = xTwilioWebhookEnabled }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove a conversation from your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null, ITwilioRestClient client = null)
        {
            var options = new DeleteConversationOptions(pathSid)  { XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations/{Sid}";

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

        /// <summary> Fetch a conversation from your account's default service </summary>
        /// <param name="options"> Fetch Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Fetch(FetchConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a conversation from your account's default service </summary>
        /// <param name="options"> Fetch Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ConversationResource> FetchAsync(FetchConversationOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a conversation from your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchConversationOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a conversation from your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ConversationResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchConversationOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of conversations in your account's default service </summary>
        /// <param name="options"> Read Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ResourceSet<ConversationResource> Read(ReadConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ConversationResource>.FromJson("conversations", response.Content);
            return new ResourceSet<ConversationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of conversations in your account's default service </summary>
        /// <param name="options"> Read Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConversationResource>> ReadAsync(ReadConversationOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ConversationResource>.FromJson("conversations", response.Content);
            return new ResourceSet<ConversationResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of conversations in your account's default service </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ResourceSet<ConversationResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadConversationOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of conversations in your account's default service </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConversationResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadConversationOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ConversationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ConversationResource>.FromJson("conversations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ConversationResource> NextPage(Page<ConversationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConversationResource>.FromJson("conversations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ConversationResource> PreviousPage(Page<ConversationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConversationResource>.FromJson("conversations", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Conversations/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> Update an existing conversation in your account's default service </summary>
        /// <param name="options"> Update Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Update(UpdateConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update an existing conversation in your account's default service </summary>
        /// <param name="options"> Update Conversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ConversationResource> UpdateAsync(UpdateConversationOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update an existing conversation in your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="friendlyName"> The human-readable name of this conversation, limited to 256 characters. Optional. </param>
        /// <param name="dateCreated"> The date that this resource was created. </param>
        /// <param name="dateUpdated"> The date that this resource was last updated. </param>
        /// <param name="attributes"> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </param>
        /// <param name="messagingServiceSid"> The unique ID of the [Messaging Service](https://www.twilio.com/docs/sms/services/api) this conversation belongs to. </param>
        /// <param name="state">  </param>
        /// <param name="timersInactive"> ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="timersClosed"> ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Conversation </returns>
        public static ConversationResource Update(
                                          string pathSid,
                                          string friendlyName = null,
                                          DateTime? dateCreated = null,
                                          DateTime? dateUpdated = null,
                                          string attributes = null,
                                          string messagingServiceSid = null,
                                          ConversationResource.StateEnum state = null,
                                          string timersInactive = null,
                                          string timersClosed = null,
                                          string uniqueName = null,
                                          ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateConversationOptions(pathSid){ FriendlyName = friendlyName, DateCreated = dateCreated, DateUpdated = dateUpdated, Attributes = attributes, MessagingServiceSid = messagingServiceSid, State = state, TimersInactive = timersInactive, TimersClosed = timersClosed, UniqueName = uniqueName, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update an existing conversation in your account's default service </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. Can also be the `unique_name` of the Conversation. </param>
        /// <param name="friendlyName"> The human-readable name of this conversation, limited to 256 characters. Optional. </param>
        /// <param name="dateCreated"> The date that this resource was created. </param>
        /// <param name="dateUpdated"> The date that this resource was last updated. </param>
        /// <param name="attributes"> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \\\"{}\\\" will be returned. </param>
        /// <param name="messagingServiceSid"> The unique ID of the [Messaging Service](https://www.twilio.com/docs/sms/services/api) this conversation belongs to. </param>
        /// <param name="state">  </param>
        /// <param name="timersInactive"> ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="timersClosed"> ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Conversation </returns>
        public static async System.Threading.Tasks.Task<ConversationResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              DateTime? dateCreated = null,
                                                                              DateTime? dateUpdated = null,
                                                                              string attributes = null,
                                                                              string messagingServiceSid = null,
                                                                              ConversationResource.StateEnum state = null,
                                                                              string timersInactive = null,
                                                                              string timersClosed = null,
                                                                              string uniqueName = null,
                                                                              ConversationResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateConversationOptions(pathSid){ FriendlyName = friendlyName, DateCreated = dateCreated, DateUpdated = dateUpdated, Attributes = attributes, MessagingServiceSid = messagingServiceSid, State = state, TimersInactive = timersInactive, TimersClosed = timersClosed, UniqueName = uniqueName, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ConversationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConversationResource object represented by the provided JSON </returns>
        public static ConversationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConversationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this conversation. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </summary> 
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }

        ///<summary> The unique ID of the [Messaging Service](https://www.twilio.com/docs/sms/services/api) this conversation belongs to. </summary> 
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The human-readable name of this conversation, limited to 256 characters. Optional. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \"{}\" will be returned. </summary> 
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }

        
        [JsonProperty("state")]
        public ConversationResource.StateEnum State { get; private set; }

        ///<summary> The date that this resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> Timer date values representing state update for this conversation. </summary> 
        [JsonProperty("timers")]
        public object Timers { get; private set; }

        ///<summary> An absolute API resource URL for this conversation. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains absolute URLs to access the [participants](https://www.twilio.com/docs/conversations/api/conversation-participant-resource), [messages](https://www.twilio.com/docs/conversations/api/conversation-message-resource) and [webhooks](https://www.twilio.com/docs/conversations/api/conversation-scoped-webhook-resource) of this conversation. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The bindings </summary> 
        [JsonProperty("bindings")]
        public object Bindings { get; private set; }



        private ConversationResource() {

        }
    }
}

