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
    public class RoleResource : Resource
    {
    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class RoleTypeEnum : StringEnum
        {
            private RoleTypeEnum(string value) : base(value) {}
            public RoleTypeEnum() {}
            public static implicit operator RoleTypeEnum(string value)
            {
                return new RoleTypeEnum(value);
            }
            public static readonly RoleTypeEnum Conversation = new RoleTypeEnum("conversation");
            public static readonly RoleTypeEnum Service = new RoleTypeEnum("service");

        }

        
        private static Request BuildCreateRequest(CreateRoleOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Roles";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new user role in your account's default service </summary>
        /// <param name="options"> Create Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Create(CreateRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new user role in your account's default service </summary>
        /// <param name="options"> Create Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(CreateRoleOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new user role in your account's default service </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </param>
        /// <param name="type">  </param>
        /// <param name="permission"> A permission that you grant to the new role. Only one permission can be granted per parameter. To assign more than one permission, repeat this parameter for each permission value. The values for this parameter depend on the role's `type`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Create(
                                          string friendlyName,
                                          RoleResource.RoleTypeEnum type,
                                          List<string> permission,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateRoleOptions(friendlyName, type, permission){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new user role in your account's default service </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </param>
        /// <param name="type">  </param>
        /// <param name="permission"> A permission that you grant to the new role. Only one permission can be granted per parameter. To assign more than one permission, repeat this parameter for each permission value. The values for this parameter depend on the role's `type`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(
                                                                                  string friendlyName,
                                                                                  RoleResource.RoleTypeEnum type,
                                                                                  List<string> permission,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateRoleOptions(friendlyName, type, permission){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Remove a user role from your account's default service </summary>
        /// <param name="options"> Delete Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        private static Request BuildDeleteRequest(DeleteRoleOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Roles/{Sid}";

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

        /// <summary> Remove a user role from your account's default service </summary>
        /// <param name="options"> Delete Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static bool Delete(DeleteRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove a user role from your account's default service </summary>
        /// <param name="options"> Delete Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRoleOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove a user role from your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteRoleOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove a user role from your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteRoleOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchRoleOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Roles/{Sid}";

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

        /// <summary> Fetch a user role from your account's default service </summary>
        /// <param name="options"> Fetch Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Fetch(FetchRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a user role from your account's default service </summary>
        /// <param name="options"> Fetch Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(FetchRoleOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a user role from your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchRoleOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a user role from your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchRoleOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadRoleOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Roles";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all user roles in your account's default service </summary>
        /// <param name="options"> Read Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static ResourceSet<RoleResource> Read(ReadRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<RoleResource>.FromJson("roles", response.Content);
            return new ResourceSet<RoleResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all user roles in your account's default service </summary>
        /// <param name="options"> Read Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(ReadRoleOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<RoleResource>.FromJson("roles", response.Content);
            return new ResourceSet<RoleResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all user roles in your account's default service </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of Role </returns>
        public static ResourceSet<RoleResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadRoleOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all user roles in your account's default service </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadRoleOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<RoleResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<RoleResource>.FromJson("roles", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<RoleResource> NextPage(Page<RoleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RoleResource>.FromJson("roles", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<RoleResource> PreviousPage(Page<RoleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RoleResource>.FromJson("roles", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateRoleOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Roles/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update an existing user role in your account's default service </summary>
        /// <param name="options"> Update Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Update(UpdateRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update an existing user role in your account's default service </summary>
        /// <param name="options"> Update Role parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(UpdateRoleOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update an existing user role in your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to update. </param>
        /// <param name="permission"> A permission that you grant to the role. Only one permission can be granted per parameter. To assign more than one permission, repeat this parameter for each permission value. Note that the update action replaces all previously assigned permissions with those defined in the update action. To remove a permission, do not include it in the subsequent update action. The values for this parameter depend on the role's `type`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Role </returns>
        public static RoleResource Update(
                                          string pathSid,
                                          List<string> permission,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateRoleOptions(pathSid, permission){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update an existing user role in your account's default service </summary>
        /// <param name="pathSid"> The SID of the Role resource to update. </param>
        /// <param name="permission"> A permission that you grant to the role. Only one permission can be granted per parameter. To assign more than one permission, repeat this parameter for each permission value. Note that the update action replaces all previously assigned permissions with those defined in the update action. To remove a permission, do not include it in the subsequent update action. The values for this parameter depend on the role's `type`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Role </returns>
        public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(
                                                                              string pathSid,
                                                                              List<string> permission,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateRoleOptions(pathSid, permission){  };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a RoleResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RoleResource object represented by the provided JSON </returns>
        public static RoleResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RoleResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the Role resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Role resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) the Role resource is associated with. </summary> 
        [JsonProperty("chat_service_sid")]
        public string ChatServiceSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        
        [JsonProperty("type")]
        public RoleResource.RoleTypeEnum Type { get; private set; }

        ///<summary> An array of the permissions the role has been granted. </summary> 
        [JsonProperty("permissions")]
        public List<string> Permissions { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> An absolute API resource URL for this user role. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private RoleResource() {

        }
    }
}

