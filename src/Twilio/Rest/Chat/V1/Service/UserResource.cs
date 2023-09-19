/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Chat
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



namespace Twilio.Rest.Chat.V1.Service
{
    public class UserResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateUserOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Users";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
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
        /// <summary> create </summary>
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

        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to create the resource under. </param>
        /// <param name="identity"> The `identity` value that uniquely identifies the new resource's [User](https://www.twilio.com/docs/api/chat/rest/v1/user) within the [Service](https://www.twilio.com/docs/api/chat/rest/v1/service). This value is often a username or email address. See the Identity documentation for more details. </param>
        /// <param name="roleSid"> The SID of the [Role](https://www.twilio.com/docs/api/chat/rest/roles) assigned to the new User. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. This value is often used for display purposes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Create(
                                          string pathServiceSid,
                                          string identity,
                                          string roleSid = null,
                                          string attributes = null,
                                          string friendlyName = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(pathServiceSid, identity){  RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to create the resource under. </param>
        /// <param name="identity"> The `identity` value that uniquely identifies the new resource's [User](https://www.twilio.com/docs/api/chat/rest/v1/user) within the [Service](https://www.twilio.com/docs/api/chat/rest/v1/service). This value is often a username or email address. See the Identity documentation for more details. </param>
        /// <param name="roleSid"> The SID of the [Role](https://www.twilio.com/docs/api/chat/rest/roles) assigned to the new User. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. This value is often used for display purposes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string identity,
                                                                                  string roleSid = null,
                                                                                  string attributes = null,
                                                                                  string friendlyName = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateUserOptions(pathServiceSid, identity){  RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        private static Request BuildDeleteRequest(DeleteUserOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Users/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
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
        /// <summary> delete </summary>
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

        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to delete the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to delete the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(pathServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchUserOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Users/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
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
        /// <summary> fetch </summary>
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
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to fetch the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to fetch the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadUserOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Users";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
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
        /// <summary> read </summary>
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
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static ResourceSet<UserResource> Read(
                                                     string pathServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
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

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<UserResource> NextPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<UserResource> PreviousPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateUserOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Users/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Update(UpdateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update User parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(UpdateUserOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to update the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to update. </param>
        /// <param name="roleSid"> The SID of the [Role](https://www.twilio.com/docs/api/chat/rest/roles) assigned to this user. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is often used for display purposes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of User </returns>
        public static UserResource Update(
                                          string pathServiceSid,
                                          string pathSid,
                                          string roleSid = null,
                                          string attributes = null,
                                          string friendlyName = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(pathServiceSid, pathSid){ RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to update the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the User resource to update. </param>
        /// <param name="roleSid"> The SID of the [Role](https://www.twilio.com/docs/api/chat/rest/roles) assigned to this user. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is often used for display purposes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of User </returns>
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathSid,
                                                                              string roleSid = null,
                                                                              string attributes = null,
                                                                              string friendlyName = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(pathServiceSid, pathSid){ RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserResource object represented by the provided JSON </returns>
        public static UserResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UserResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the User resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/api/rest/account) that created the User resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The JSON string that stores application-specific data. **Note** If this property has been assigned a value, it's only  displayed in a FETCH action that returns a single resource; otherwise, it's null. If the attributes have not been set, `{}` is returned. </summary> 
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The SID of the [Role](https://www.twilio.com/docs/api/chat/rest/roles) assigned to the user. </summary> 
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }

        ///<summary> The application-defined string that uniquely identifies the resource's User within the [Service](https://www.twilio.com/docs/api/chat/rest/services). This value is often a username or an email address. See [access tokens](https://www.twilio.com/docs/api/chat/guides/create-tokens) for more info. </summary> 
        [JsonProperty("identity")]
        public string Identity { get; private set; }

        ///<summary> Whether the User is actively connected to the Service instance and online. This value is only returned by Fetch actions that return a single resource and `null` is always returned by a Read action. This value is `null` if the Service's `reachability_enabled` is `false`, if the User has never been online for the Service instance, even if the Service's `reachability_enabled` is `true`. </summary> 
        [JsonProperty("is_online")]
        public bool? IsOnline { get; private set; }

        ///<summary> Whether the User has a potentially valid Push Notification registration (APN or GCM) for the Service instance. If at least one registration exists, `true`; otherwise `false`. This value is only returned by Fetch actions that return a single resource and `null` is always returned by a Read action. This value is `null` if the Service's `reachability_enabled` is `false`, and if the User has never had a notification registration, even if the Service's `reachability_enabled` is `true`. </summary> 
        [JsonProperty("is_notifiable")]
        public bool? IsNotifiable { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](http://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](http://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The number of Channels this User is a Member of. </summary> 
        [JsonProperty("joined_channels_count")]
        public int? JoinedChannelsCount { get; private set; }

        ///<summary> The absolute URLs of the [Channel](https://www.twilio.com/docs/chat/api/channels) and [Binding](https://www.twilio.com/docs/chat/rest/bindings-resource) resources related to the user. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The absolute URL of the User resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private UserResource() {

        }
    }
}

