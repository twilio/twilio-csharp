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
        private static Request BuildFetchRequest(FetchUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Users/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static UserResource Fetch(FetchUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(FetchUserOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static UserResource Fetch(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(serviceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> FetchAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchUserOptions(serviceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Users/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserOptions options, ITwilioRestClient client)
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
            var options = new DeleteUserOptions(serviceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserOptions(serviceSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Users",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static UserResource Create(CreateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(CreateUserOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static UserResource Create(string serviceSid, string identity, string roleSid = null, string attributes = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(serviceSid, identity){RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> CreateAsync(string serviceSid, string identity, string roleSid = null, string attributes = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateUserOptions(serviceSid, identity){RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Users",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<UserResource> Read(ReadUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<UserResource>.FromJson("users", response.Content);
            return new ResourceSet<UserResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(ReadUserOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<UserResource> Read(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(serviceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<UserResource>> ReadAsync(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadUserOptions(serviceSid){PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<UserResource> NextPage(Page<UserResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Chat,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<UserResource>.FromJson("users", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateUserOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Users/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static UserResource Update(UpdateUserOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(UpdateUserOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static UserResource Update(string serviceSid, string sid, string roleSid = null, string attributes = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(serviceSid, sid){RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UserResource> UpdateAsync(string serviceSid, string sid, string roleSid = null, string attributes = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateUserOptions(serviceSid, sid){RoleSid = roleSid, Attributes = attributes, FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UserResource object
        /// </summary>
        ///
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
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        [JsonProperty("is_online")]
        public bool? IsOnline { get; private set; }
        [JsonProperty("is_notifiable")]
        public bool? IsNotifiable { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private UserResource()
        {
        
        }
    }

}