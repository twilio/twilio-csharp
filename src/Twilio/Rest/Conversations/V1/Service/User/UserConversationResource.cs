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
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Conversations.V1.Service.User
{
    public class UserConversationResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class NotificationLevelEnum : StringEnum
        {
            private NotificationLevelEnum(string value) : base(value) {}
            public NotificationLevelEnum() {}
            public static implicit operator NotificationLevelEnum(string value)
            {
                return new NotificationLevelEnum(value);
            }
            public static readonly NotificationLevelEnum Default = new NotificationLevelEnum("default");
            public static readonly NotificationLevelEnum Muted = new NotificationLevelEnum("muted");

        }
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

        
        /// <summary> Delete a specific User Conversation. </summary>
        /// <param name="options"> Delete UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        private static Request BuildDeleteRequest(DeleteUserConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Users/{UserSid}/Conversations/{ConversationSid}";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathConversationSid = options.PathConversationSid;
            path = path.Replace("{"+"ConversationSid"+"}", PathConversationSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific User Conversation. </summary>
        /// <param name="options"> Delete UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static bool Delete(DeleteUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific User Conversation. </summary>
        /// <param name="options"> Delete UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserConversationOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static bool Delete(string pathChatServiceSid, string pathUserSid, string pathConversationSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid)           ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathChatServiceSid, string pathUserSid, string pathConversationSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchUserConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Users/{UserSid}/Conversations/{ConversationSid}";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathConversationSid = options.PathConversationSid;
            path = path.Replace("{"+"ConversationSid"+"}", PathConversationSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific User Conversation. </summary>
        /// <param name="options"> Fetch UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static UserConversationResource Fetch(FetchUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific User Conversation. </summary>
        /// <param name="options"> Fetch UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<UserConversationResource> FetchAsync(FetchUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static UserConversationResource Fetch(
                                         string pathChatServiceSid, 
                                         string pathUserSid, 
                                         string pathConversationSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<UserConversationResource> FetchAsync(string pathChatServiceSid, string pathUserSid, string pathConversationSid, ITwilioRestClient client = null)
        {
            var options = new FetchUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadUserConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Users/{UserSid}/Conversations";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all User Conversations for the User. </summary>
        /// <param name="options"> Read UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static ResourceSet<UserConversationResource> Read(ReadUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<UserConversationResource>.FromJson("conversations", response.Content);
            return new ResourceSet<UserConversationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all User Conversations for the User. </summary>
        /// <param name="options"> Read UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserConversationResource>> ReadAsync(ReadUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<UserConversationResource>.FromJson("conversations", response.Content);
            return new ResourceSet<UserConversationResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all User Conversations for the User. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static ResourceSet<UserConversationResource> Read(
                                                     string pathChatServiceSid,
                                                     string pathUserSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadUserConversationOptions(pathChatServiceSid, pathUserSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all User Conversations for the User. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserConversationResource>> ReadAsync(
                                                                                             string pathChatServiceSid,
                                                                                             string pathUserSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadUserConversationOptions(pathChatServiceSid, pathUserSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<UserConversationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<UserConversationResource>.FromJson("conversations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<UserConversationResource> NextPage(Page<UserConversationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserConversationResource>.FromJson("conversations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<UserConversationResource> PreviousPage(Page<UserConversationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserConversationResource>.FromJson("conversations", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateUserConversationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ChatServiceSid}/Users/{UserSid}/Conversations/{ConversationSid}";

            string PathChatServiceSid = options.PathChatServiceSid;
            path = path.Replace("{"+"ChatServiceSid"+"}", PathChatServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathConversationSid = options.PathConversationSid;
            path = path.Replace("{"+"ConversationSid"+"}", PathConversationSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific User Conversation. </summary>
        /// <param name="options"> Update UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static UserConversationResource Update(UpdateUserConversationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific User Conversation. </summary>
        /// <param name="options"> Update UserConversation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<UserConversationResource> UpdateAsync(UpdateUserConversationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="notificationLevel">  </param>
        /// <param name="lastReadTimestamp"> The date of the last message read in conversation by the user, given in ISO 8601 format. </param>
        /// <param name="lastReadMessageIndex"> The index of the last Message in the Conversation that the Participant has read. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserConversation </returns>
        public static UserConversationResource Update(
                                          string pathChatServiceSid,
                                          string pathUserSid,
                                          string pathConversationSid,
                                          UserConversationResource.NotificationLevelEnum notificationLevel = null,
                                          DateTime? lastReadTimestamp = null,
                                          int? lastReadMessageIndex = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid){ NotificationLevel = notificationLevel, LastReadTimestamp = lastReadTimestamp, LastReadMessageIndex = lastReadMessageIndex };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific User Conversation. </summary>
        /// <param name="pathChatServiceSid"> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Conversation resource is associated with. </param>
        /// <param name="pathUserSid"> The unique SID identifier of the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). This value can be either the `sid` or the `identity` of the User resource. </param>
        /// <param name="pathConversationSid"> The unique SID identifier of the Conversation. This value can be either the `sid` or the `unique_name` of the [Conversation resource](https://www.twilio.com/docs/conversations/api/conversation-resource). </param>
        /// <param name="notificationLevel">  </param>
        /// <param name="lastReadTimestamp"> The date of the last message read in conversation by the user, given in ISO 8601 format. </param>
        /// <param name="lastReadMessageIndex"> The index of the last Message in the Conversation that the Participant has read. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserConversation </returns>
        public static async System.Threading.Tasks.Task<UserConversationResource> UpdateAsync(
                                                                              string pathChatServiceSid,
                                                                              string pathUserSid,
                                                                              string pathConversationSid,
                                                                              UserConversationResource.NotificationLevelEnum notificationLevel = null,
                                                                              DateTime? lastReadTimestamp = null,
                                                                              int? lastReadMessageIndex = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateUserConversationOptions(pathChatServiceSid, pathUserSid, pathConversationSid){ NotificationLevel = notificationLevel, LastReadTimestamp = lastReadTimestamp, LastReadMessageIndex = lastReadMessageIndex };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UserConversationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserConversationResource object represented by the provided JSON </returns>
        public static UserConversationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UserConversationResource>(json);
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

    
        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this conversation. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique ID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) this conversation belongs to. </summary> 
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }

        ///<summary> The unique ID of the [Conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) for this User Conversation. </summary> 
        [JsonProperty("conversation_sid")]
        public string ConversationSid { get; private set; }

        ///<summary> The number of unread Messages in the Conversation for the Participant. </summary> 
        [JsonProperty("unread_messages_count")]
        public int? UnreadMessagesCount { get; private set; }

        ///<summary> The index of the last Message in the Conversation that the Participant has read. </summary> 
        [JsonProperty("last_read_message_index")]
        public int? LastReadMessageIndex { get; private set; }

        ///<summary> The unique ID of the [participant](https://www.twilio.com/docs/conversations/api/conversation-participant-resource) the user conversation belongs to. </summary> 
        [JsonProperty("participant_sid")]
        public string ParticipantSid { get; private set; }

        ///<summary> The unique string that identifies the [User resource](https://www.twilio.com/docs/conversations/api/user-resource). </summary> 
        [JsonProperty("user_sid")]
        public string UserSid { get; private set; }

        ///<summary> The human-readable name of this conversation, limited to 256 characters. Optional. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        
        [JsonProperty("conversation_state")]
        public UserConversationResource.StateEnum ConversationState { get; private set; }

        ///<summary> Timer date values representing state update for this conversation. </summary> 
        [JsonProperty("timers")]
        public object Timers { get; private set; }

        ///<summary> An optional string metadata field you can use to store any data you wish. The string value must contain structurally valid JSON if specified.  **Note** that if the attributes are not set \"{}\" will be returned. </summary> 
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }

        ///<summary> The date that this conversation was created, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this conversation was last updated, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> Identity of the creator of this Conversation. </summary> 
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }

        
        [JsonProperty("notification_level")]
        public UserConversationResource.NotificationLevelEnum NotificationLevel { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the Conversation resource. It can be used to address the resource in place of the resource's `conversation_sid` in the URL. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains absolute URLs to access the [participant](https://www.twilio.com/docs/conversations/api/conversation-participant-resource) and [conversation](https://www.twilio.com/docs/conversations/api/conversation-resource) of this conversation. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private UserConversationResource() {

        }
    }
}

