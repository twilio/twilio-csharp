using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class MediaResource : Resource 
    {
        private static Request BuildDeleteRequest(DeleteMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.MessageSid + "/Media/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete media from your account. Once delete, you will no longer be billed
        /// </summary>
        public static bool Delete(DeleteMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteMediaOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Delete media from your account. Once delete, you will no longer be billed
        /// </summary>
        public static bool Delete(string messageSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteMediaOptions(messageSid, sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string messageSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteMediaOptions(messageSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.MessageSid + "/Media/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a single media instance belonging to the account used to make the request
        /// </summary>
        public static MediaResource Fetch(FetchMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MediaResource> FetchAsync(FetchMediaOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch a single media instance belonging to the account used to make the request
        /// </summary>
        public static MediaResource Fetch(string messageSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMediaOptions(messageSid, sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MediaResource> FetchAsync(string messageSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMediaOptions(messageSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadMediaOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.MessageSid + "/Media.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of medias belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<MediaResource> Read(ReadMediaOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<MediaResource>.FromJson("media_list", response.Content);
            return new ResourceSet<MediaResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MediaResource>> ReadAsync(ReadMediaOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of medias belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<MediaResource> Read(string messageSid, string accountSid = null, string dateCreated = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMediaOptions(messageSid){AccountSid = accountSid, DateCreated = dateCreated, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MediaResource>> ReadAsync(string messageSid, string accountSid = null, string dateCreated = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMediaOptions(messageSid){AccountSid = accountSid, DateCreated = dateCreated, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<MediaResource> NextPage(Page<MediaResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<MediaResource>.FromJson("media_list", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a MediaResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MediaResource object represented by the provided JSON </returns> 
        public static MediaResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MediaResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("parent_sid")]
        public string ParentSid { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private MediaResource()
        {
        
        }
    }

}