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

    public class IpAccessControlListResource : Resource 
    {
        private static Request BuildFetchRequest(FetchIpAccessControlListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/IpAccessControlLists/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static IpAccessControlListResource Fetch(FetchIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> FetchAsync(FetchIpAccessControlListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static IpAccessControlListResource Fetch(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListOptions(trunkSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> FetchAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListOptions(trunkSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteIpAccessControlListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/IpAccessControlLists/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIpAccessControlListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListOptions(trunkSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string trunkSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListOptions(trunkSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateIpAccessControlListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/IpAccessControlLists",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static IpAccessControlListResource Create(CreateIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> CreateAsync(CreateIpAccessControlListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static IpAccessControlListResource Create(string trunkSid, string ipAccessControlListSid, ITwilioRestClient client = null)
        {
            var options = new CreateIpAccessControlListOptions(trunkSid, ipAccessControlListSid);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> CreateAsync(string trunkSid, string ipAccessControlListSid, ITwilioRestClient client = null)
        {
            var options = new CreateIpAccessControlListOptions(trunkSid, ipAccessControlListSid);
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadIpAccessControlListOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                "/v1/Trunks/" + options.TrunkSid + "/IpAccessControlLists",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<IpAccessControlListResource> Read(ReadIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
            return new ResourceSet<IpAccessControlListResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListResource>> ReadAsync(ReadIpAccessControlListOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<IpAccessControlListResource> Read(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListOptions(trunkSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListResource>> ReadAsync(string trunkSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListOptions(trunkSid){PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<IpAccessControlListResource> NextPage(Page<IpAccessControlListResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Trunking,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListResource object represented by the provided JSON </returns> 
        public static IpAccessControlListResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListResource>(json);
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
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private IpAccessControlListResource()
        {
        
        }
    }

}