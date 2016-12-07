using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList 
{

    public class IpAddressResource : Resource 
    {
        private static Request BuildReadRequest(ReadIpAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/IpAccessControlLists/" + options.IpAccessControlListSid + "/IpAddresses.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<IpAddressResource> Read(ReadIpAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<IpAddressResource>.FromJson("ip_addresses", response.Content);
            return new ResourceSet<IpAddressResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IpAddressResource>> ReadAsync(ReadIpAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<IpAddressResource> Read(string ipAccessControlListSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIpAddressOptions(ipAccessControlListSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<IpAddressResource>> ReadAsync(string ipAccessControlListSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadIpAddressOptions(ipAccessControlListSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<IpAddressResource> NextPage(Page<IpAddressResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<IpAddressResource>.FromJson("ip_addresses", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateIpAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/IpAccessControlLists/" + options.IpAccessControlListSid + "/IpAddresses.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static IpAddressResource Create(CreateIpAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> CreateAsync(CreateIpAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static IpAddressResource Create(string ipAccessControlListSid, string friendlyName, string ipAddress, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateIpAddressOptions(ipAccessControlListSid, friendlyName, ipAddress){AccountSid = accountSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> CreateAsync(string ipAccessControlListSid, string friendlyName, string ipAddress, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateIpAddressOptions(ipAccessControlListSid, friendlyName, ipAddress){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchIpAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/IpAccessControlLists/" + options.IpAccessControlListSid + "/IpAddresses/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static IpAddressResource Fetch(FetchIpAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> FetchAsync(FetchIpAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static IpAddressResource Fetch(string ipAccessControlListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> FetchAsync(string ipAccessControlListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateIpAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/IpAccessControlLists/" + options.IpAccessControlListSid + "/IpAddresses/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static IpAddressResource Update(UpdateIpAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> UpdateAsync(UpdateIpAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static IpAddressResource Update(string ipAccessControlListSid, string sid, string accountSid = null, string ipAddress = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid, IpAddress = ipAddress, FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<IpAddressResource> UpdateAsync(string ipAccessControlListSid, string sid, string accountSid = null, string ipAddress = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid, IpAddress = ipAddress, FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteIpAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/SIP/IpAccessControlLists/" + options.IpAccessControlListSid + "/IpAddresses/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteIpAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIpAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string ipAccessControlListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string ipAccessControlListSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAddressOptions(ipAccessControlListSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a IpAddressResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAddressResource object represented by the provided JSON </returns> 
        public static IpAddressResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<IpAddressResource>(json);
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
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; private set; }
        [JsonProperty("ip_access_control_list_sid")]
        public string IpAccessControlListSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private IpAddressResource()
        {
        
        }
    }

}