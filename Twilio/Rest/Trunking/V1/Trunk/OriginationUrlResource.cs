using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class OriginationUrlResource : Resource 
    {
        private static Request BuildFetchRequest(FetchOriginationUrlOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/OriginationUrls/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static OriginationUrlResource Fetch(FetchOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> FetchAsync(FetchOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static OriginationUrlResource Fetch(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchOriginationUrlOptions(trunkSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> FetchAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchOriginationUrlOptions(trunkSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteOriginationUrlOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/OriginationUrls/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteOriginationUrlOptions(trunkSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteOriginationUrlOptions(trunkSid, sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateOriginationUrlOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/OriginationUrls",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static OriginationUrlResource Create(CreateOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> CreateAsync(CreateOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static OriginationUrlResource Create(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl, ITwilioRestClient client = null)
        {
            var options = new CreateOriginationUrlOptions(trunkSid, weight, priority, enabled, friendlyName, sipUrl);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> CreateAsync(string trunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl, ITwilioRestClient client = null)
        {
            var options = new CreateOriginationUrlOptions(trunkSid, weight, priority, enabled, friendlyName, sipUrl);
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadOriginationUrlOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/OriginationUrls",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<OriginationUrlResource> Read(ReadOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<OriginationUrlResource>.FromJson("origination_urls", response.Content);
            return new ResourceSet<OriginationUrlResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<OriginationUrlResource>> ReadAsync(ReadOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<OriginationUrlResource>.FromJson("origination_urls", response.Content);
            return new ResourceSet<OriginationUrlResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<OriginationUrlResource> Read(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadOriginationUrlOptions(trunkSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<OriginationUrlResource>> ReadAsync(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadOriginationUrlOptions(trunkSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<OriginationUrlResource> NextPage(Page<OriginationUrlResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Trunking,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<OriginationUrlResource>.FromJson("origination_urls", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateOriginationUrlOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/OriginationUrls/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static OriginationUrlResource Update(UpdateOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> UpdateAsync(UpdateOriginationUrlOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static OriginationUrlResource Update(string trunkSid, string sid, int? weight = null, int? priority = null, bool? enabled = null, string friendlyName = null, Uri sipUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateOriginationUrlOptions(trunkSid, sid){Weight = weight, Priority = priority, Enabled = enabled, FriendlyName = friendlyName, SipUrl = sipUrl};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<OriginationUrlResource> UpdateAsync(string trunkSid, string sid, int? weight = null, int? priority = null, bool? enabled = null, string friendlyName = null, Uri sipUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateOriginationUrlOptions(trunkSid, sid){Weight = weight, Priority = priority, Enabled = enabled, FriendlyName = friendlyName, SipUrl = sipUrl};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a OriginationUrlResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OriginationUrlResource object represented by the provided JSON </returns> 
        public static OriginationUrlResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<OriginationUrlResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; private set; }
        [JsonProperty("weight")]
        public int? Weight { get; private set; }
        [JsonProperty("enabled")]
        public bool? Enabled { get; private set; }
        [JsonProperty("sip_url")]
        public Uri SipUrl { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("priority")]
        public int? Priority { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private OriginationUrlResource()
        {
        
        }
    }

}