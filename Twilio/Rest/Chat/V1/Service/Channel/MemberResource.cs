using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class MemberResource : Resource 
    {
        private static Request BuildFetchRequest(FetchMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Members/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static MemberResource Fetch(FetchMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(FetchMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static MemberResource Fetch(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(serviceSid, channelSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Members",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static MemberResource Create(CreateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> CreateAsync(CreateMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static MemberResource Create(string serviceSid, string channelSid, string identity, string roleSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateMemberOptions(serviceSid, channelSid, identity){RoleSid = roleSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> CreateAsync(string serviceSid, string channelSid, string identity, string roleSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateMemberOptions(serviceSid, channelSid, identity){RoleSid = roleSid};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Members",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<MemberResource> Read(ReadMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<MemberResource>.FromJson("members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(ReadMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<MemberResource> Read(string serviceSid, string channelSid, List<string> identity = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(serviceSid, channelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(string serviceSid, string channelSid, List<string> identity = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(serviceSid, channelSid){Identity = identity, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<MemberResource> NextPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Chat,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<MemberResource>.FromJson("members", response.Content);
        }
    
        private static Request BuildDeleteRequest(DeleteMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Members/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteMemberOptions options, ITwilioRestClient client)
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
            var options = new DeleteMemberOptions(serviceSid, channelSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteMemberOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Members/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static MemberResource Update(UpdateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(UpdateMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static MemberResource Update(string serviceSid, string channelSid, string sid, string roleSid = null, int? lastConsumedMessageIndex = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(serviceSid, channelSid, sid){RoleSid = roleSid, LastConsumedMessageIndex = lastConsumedMessageIndex};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(string serviceSid, string channelSid, string sid, string roleSid = null, int? lastConsumedMessageIndex = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(serviceSid, channelSid, sid){RoleSid = roleSid, LastConsumedMessageIndex = lastConsumedMessageIndex};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
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
        [JsonProperty("last_consumed_message_index")]
        public int? LastConsumedMessageIndex { get; private set; }
        [JsonProperty("last_consumption_timestamp")]
        public DateTime? LastConsumptionTimestamp { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("role_sid")]
        public string RoleSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private MemberResource()
        {
        
        }
    }

}