using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.IpMessaging.V1.Service.Channel 
{

    public class InviteResource : Resource 
    {
        private static Request BuildFetchRequest(FetchInviteOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Invites/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static InviteResource Fetch(FetchInviteOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<InviteResource> FetchAsync(FetchInviteOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static InviteResource Fetch(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchInviteOptions(serviceSid, channelSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<InviteResource> FetchAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchInviteOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateInviteOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Invites",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static InviteResource Create(CreateInviteOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<InviteResource> CreateAsync(CreateInviteOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static InviteResource Create(string serviceSid, string channelSid, string identity, string roleSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateInviteOptions(serviceSid, channelSid, identity){RoleSid = roleSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<InviteResource> CreateAsync(string serviceSid, string channelSid, string identity, string roleSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateInviteOptions(serviceSid, channelSid, identity){RoleSid = roleSid};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadInviteOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Invites",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<InviteResource> Read(ReadInviteOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<InviteResource>.FromJson("invites", response.Content);
            return new ResourceSet<InviteResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<InviteResource>> ReadAsync(ReadInviteOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<InviteResource> Read(string serviceSid, string channelSid, List<string> identity = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInviteOptions(serviceSid, channelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<InviteResource>> ReadAsync(string serviceSid, string channelSid, List<string> identity = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadInviteOptions(serviceSid, channelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<InviteResource> NextPage(Page<InviteResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.IpMessaging,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<InviteResource>.FromJson("invites", response.Content);
        }
    
        private static Request BuildDeleteRequest(DeleteInviteOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.IpMessaging,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Invites/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteInviteOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteInviteOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteInviteOptions(serviceSid, channelSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteInviteOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a InviteResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> InviteResource object represented by the provided JSON </returns> 
        public static InviteResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<InviteResource>(json);
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
        [JsonProperty("channel_sid")]
        public string ChannelSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private InviteResource()
        {
        
        }
    }

}