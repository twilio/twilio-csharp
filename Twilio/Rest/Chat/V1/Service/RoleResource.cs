using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Chat.V1.Service 
{

    public class RoleResource : Resource 
    {
        public sealed class RoleTypeEnum : StringEnum 
        {
            private RoleTypeEnum(string value) : base(value) {}
            public RoleTypeEnum() {}
        
            public static readonly RoleTypeEnum Channel = new RoleTypeEnum("channel");
            public static readonly RoleTypeEnum Deployment = new RoleTypeEnum("deployment");
        }
    
        private static Request BuildFetchRequest(FetchRoleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Roles/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static RoleResource Fetch(FetchRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(FetchRoleOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static RoleResource Fetch(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchRoleOptions(serviceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> FetchAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchRoleOptions(serviceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteRoleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Roles/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRoleOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteRoleOptions(serviceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteRoleOptions(serviceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateRoleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Roles",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static RoleResource Create(CreateRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(CreateRoleOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static RoleResource Create(string serviceSid, string friendlyName, RoleResource.RoleTypeEnum type, List<string> permission, ITwilioRestClient client = null)
        {
            var options = new CreateRoleOptions(serviceSid, friendlyName, type, permission);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> CreateAsync(string serviceSid, string friendlyName, RoleResource.RoleTypeEnum type, List<string> permission, ITwilioRestClient client = null)
        {
            var options = new CreateRoleOptions(serviceSid, friendlyName, type, permission);
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadRoleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Roles",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RoleResource> Read(ReadRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<RoleResource>.FromJson("roles", response.Content);
            return new ResourceSet<RoleResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(ReadRoleOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RoleResource> Read(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRoleOptions(serviceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RoleResource>> ReadAsync(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRoleOptions(serviceSid){PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<RoleResource> NextPage(Page<RoleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Chat,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<RoleResource>.FromJson("roles", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateRoleOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Roles/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static RoleResource Update(UpdateRoleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(UpdateRoleOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static RoleResource Update(string serviceSid, string sid, List<string> permission, ITwilioRestClient client = null)
        {
            var options = new UpdateRoleOptions(serviceSid, sid, permission);
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RoleResource> UpdateAsync(string serviceSid, string sid, List<string> permission, ITwilioRestClient client = null)
        {
            var options = new UpdateRoleOptions(serviceSid, sid, permission);
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a RoleResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RoleResource object represented by the provided JSON </returns> 
        public static RoleResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RoleResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RoleResource.RoleTypeEnum Type { get; private set; }
        [JsonProperty("permissions")]
        public List<string> Permissions { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private RoleResource()
        {
        
        }
    }

}