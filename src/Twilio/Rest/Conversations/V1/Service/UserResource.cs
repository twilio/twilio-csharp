/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// UserResource
/// </summary>

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

    public class UserResource : Resource
    {
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

        private static Request BuildCreateRequest(CreateUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                "/v1/Services/" + options.PathChatServiceSid + "/Users",
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary>
        /// Add a new conversation user to your service
        /// </summary>
        /// <param name="options"> Create User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Create(CreateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Add a new conversation user to your service
        /// </summary>
        /// <param name="options"> Create User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(CreateUserOptions options,
                                                                                  ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Add a new conversation user to your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with </param>
        /// <param name="identity"> The string that identifies the resource's User </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The JSON Object string that stores application-specific data </param>
        /// <param name="roleSid"> The SID of a service-level Role to assign to the user </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Create(string pathChatServiceSid,
                                          string identity,
                                          string friendlyName = null,
                                          string attributes = null,
                                          string roleSid = null,
                                          UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(pathChatServiceSid, identity){FriendlyName = friendlyName, Attributes = attributes, RoleSid = roleSid, XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// Add a new conversation user to your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with </param>
        /// <param name="identity"> The string that identifies the resource's User </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The JSON Object string that stores application-specific data </param>
        /// <param name="roleSid"> The SID of a service-level Role to assign to the user </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(string pathChatServiceSid,
                                                                                  string identity,
                                                                                  string friendlyName = null,
                                                                                  string attributes = null,
                                                                                  string roleSid = null,
                                                                                  UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                  ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(pathChatServiceSid, identity){FriendlyName = friendlyName, Attributes = attributes, RoleSid = roleSid, XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                "/v1/Services/" + options.PathChatServiceSid + "/Users/" + options.PathSid + "",
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary>
        /// Update an existing conversation user in your service
        /// </summary>
        /// <param name="options"> Update User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Update(UpdateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Update an existing conversation user in your service
        /// </summary>
        /// <param name="options"> Update User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(UpdateUserOptions options,
                                                                                  ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Update an existing conversation user in your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with </param>
        /// <param name="pathSid"> The SID of the User resource to update </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The JSON Object string that stores application-specific data </param>
        /// <param name="roleSid"> The SID of a service-level Role to assign to the user </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Update(string pathChatServiceSid,
                                          string pathSid,
                                          string friendlyName = null,
                                          string attributes = null,
                                          string roleSid = null,
                                          UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(pathChatServiceSid, pathSid){FriendlyName = friendlyName, Attributes = attributes, RoleSid = roleSid, XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// Update an existing conversation user in your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service that the resource is associated with </param>
        /// <param name="pathSid"> The SID of the User resource to update </param>
        /// <param name="friendlyName"> The string that you assigned to describe the resource </param>
        /// <param name="attributes"> The JSON Object string that stores application-specific data </param>
        /// <param name="roleSid"> The SID of a service-level Role to assign to the user </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(string pathChatServiceSid,
                                                                                  string pathSid,
                                                                                  string friendlyName = null,
                                                                                  string attributes = null,
                                                                                  string roleSid = null,
                                                                                  UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                  ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(pathChatServiceSid, pathSid){FriendlyName = friendlyName, Attributes = attributes, RoleSid = roleSid, XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Conversations,
                "/v1/Services/" + options.PathChatServiceSid + "/Users/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary>
        /// Remove a conversation user from your service
        /// </summary>
        /// <param name="options"> Delete User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static bool Delete(DeleteUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// Remove a conversation user from your service
        /// </summary>
        /// <param name="options"> Delete User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary>
        /// Remove a conversation user from your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to delete the resource from </param>
        /// <param name="pathSid"> The SID of  the User resource to delete </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static bool Delete(string pathChatServiceSid,
                                  string pathSid,
                                  UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                  ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathChatServiceSid, pathSid){XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// Remove a conversation user from your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to delete the resource from </param>
        /// <param name="pathSid"> The SID of  the User resource to delete </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathChatServiceSid,
                                                                          string pathSid,
                                                                          UserResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathChatServiceSid, pathSid){XTwilioWebhookEnabled = xTwilioWebhookEnabled};
            return await DeleteAsync(options, client);
        }
        #endif

        private static Request BuildFetchRequest(FetchUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                "/v1/Services/" + options.PathChatServiceSid + "/Users/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Fetch a conversation user from your service
        /// </summary>
        /// <param name="options"> Fetch User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Fetch(FetchUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// Fetch a conversation user from your service
        /// </summary>
        /// <param name="options"> Fetch User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(FetchUserOptions options,
                                                                                 ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// Fetch a conversation user from your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to fetch the resource from </param>
        /// <param name="pathSid"> The SID of the User resource to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Fetch(string pathChatServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathChatServiceSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// Fetch a conversation user from your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to fetch the resource from </param>
        /// <param name="pathSid"> The SID of the User resource to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(string pathChatServiceSid,
                                                                                 string pathSid,
                                                                                 ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathChatServiceSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                "/v1/Services/" + options.PathChatServiceSid + "/Users",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// Retrieve a list of all conversation users in your service
        /// </summary>
        /// <param name="options"> Read User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static ResourceSet<UserResource> Read(ReadUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<UserResource>.FromJson("users", response.Content);
            return new ResourceSet<UserResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all conversation users in your service
        /// </summary>
        /// <param name="options"> Read User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(ReadUserOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<UserResource>.FromJson("users", response.Content);
            return new ResourceSet<UserResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// Retrieve a list of all conversation users in your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to read the User resources from </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static ResourceSet<UserResource> Read(string pathChatServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathChatServiceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// Retrieve a list of all conversation users in your service
        /// </summary>
        /// <param name="pathChatServiceSid"> The SID of the Conversation Service to read the User resources from </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(string pathChatServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathChatServiceSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<UserResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<UserResource> NextPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Conversations)
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<UserResource> PreviousPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Conversations)
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserResource object represented by the provided JSON </returns>
        public static UserResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UserResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique string that identifies the resource
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The SID of the Conversation Service that the resource is associated with
        /// </summary>
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }
        /// <summary>
        /// The SID of a service-level Role assigned to the user
        /// </summary>
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }
        /// <summary>
        /// The string that identifies the resource's User
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        /// <summary>
        /// The string that you assigned to describe the resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The JSON Object string that stores application-specific data
        /// </summary>
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }
        /// <summary>
        /// Whether the User is actively connected to this Conversations Service and online
        /// </summary>
        [JsonProperty("is_online")]
        public bool? IsOnline { get; private set; }
        /// <summary>
        /// Whether the User has a potentially valid Push Notification registration for this Conversations Service
        /// </summary>
        [JsonProperty("is_notifiable")]
        public bool? IsNotifiable { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The ISO 8601 date and time in GMT when the resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// An absolute URL for this user.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private UserResource()
        {

        }
    }

}