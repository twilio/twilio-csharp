using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class SyncListItemResource : Resource 
    {
        public sealed class QueryResultOrderEnum : StringEnum 
        {
            private QueryResultOrderEnum(string value) : base(value) {}
            public QueryResultOrderEnum() {}
        
            public static readonly QueryResultOrderEnum Asc = new QueryResultOrderEnum("asc");
            public static readonly QueryResultOrderEnum Desc = new QueryResultOrderEnum("desc");
        }
    
        public sealed class QueryFromBoundTypeEnum : StringEnum 
        {
            private QueryFromBoundTypeEnum(string value) : base(value) {}
            public QueryFromBoundTypeEnum() {}
        
            public static readonly QueryFromBoundTypeEnum Inclusive = new QueryFromBoundTypeEnum("inclusive");
            public static readonly QueryFromBoundTypeEnum Exclusive = new QueryFromBoundTypeEnum("exclusive");
        }
    
        private static Request BuildFetchRequest(FetchSyncListItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Items/" + options.Index + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SyncListItemResource Fetch(FetchSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> FetchAsync(FetchSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SyncListItemResource Fetch(string serviceSid, string listSid, int? index, ITwilioRestClient client = null)
        {
            var options = new FetchSyncListItemOptions(serviceSid, listSid, index);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> FetchAsync(string serviceSid, string listSid, int? index, ITwilioRestClient client = null)
        {
            var options = new FetchSyncListItemOptions(serviceSid, listSid, index);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteSyncListItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Items/" + options.Index + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string listSid, int? index, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListItemOptions(serviceSid, listSid, index);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string listSid, int? index, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListItemOptions(serviceSid, listSid, index);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateSyncListItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Items",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static SyncListItemResource Create(CreateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> CreateAsync(CreateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static SyncListItemResource Create(string serviceSid, string listSid, object data, ITwilioRestClient client = null)
        {
            var options = new CreateSyncListItemOptions(serviceSid, listSid, data);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> CreateAsync(string serviceSid, string listSid, object data, ITwilioRestClient client = null)
        {
            var options = new CreateSyncListItemOptions(serviceSid, listSid, data);
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadSyncListItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Items",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<SyncListItemResource> Read(ReadSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<SyncListItemResource>.FromJson("items", response.Content);
            return new ResourceSet<SyncListItemResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListItemResource>> ReadAsync(ReadSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<SyncListItemResource>.FromJson("items", response.Content);
            return new ResourceSet<SyncListItemResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<SyncListItemResource> Read(string serviceSid, string listSid, SyncListItemResource.QueryResultOrderEnum order = null, string from = null, SyncListItemResource.QueryFromBoundTypeEnum bounds = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncListItemOptions(serviceSid, listSid){Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListItemResource>> ReadAsync(string serviceSid, string listSid, SyncListItemResource.QueryResultOrderEnum order = null, string from = null, SyncListItemResource.QueryFromBoundTypeEnum bounds = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncListItemOptions(serviceSid, listSid){Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<SyncListItemResource> NextPage(Page<SyncListItemResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<SyncListItemResource>.FromJson("items", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateSyncListItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Items/" + options.Index + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static SyncListItemResource Update(UpdateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> UpdateAsync(UpdateSyncListItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static SyncListItemResource Update(string serviceSid, string listSid, int? index, object data, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListItemOptions(serviceSid, listSid, index, data);
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncListItemResource> UpdateAsync(string serviceSid, string listSid, int? index, object data, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListItemOptions(serviceSid, listSid, index, data);
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncListItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListItemResource object represented by the provided JSON </returns> 
        public static SyncListItemResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncListItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("index")]
        public int? Index { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("list_sid")]
        public string ListSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("revision")]
        public string Revision { get; private set; }
        [JsonProperty("data")]
        public object Data { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }
    
        private SyncListItemResource()
        {
        
        }
    }

}