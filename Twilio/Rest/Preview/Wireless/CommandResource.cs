using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless 
{

    public class CommandResource : Resource 
    {
        private static Request BuildFetchRequest(FetchCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/Commands/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static CommandResource Fetch(FetchCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CommandResource> FetchAsync(FetchCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static CommandResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchCommandOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CommandResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchCommandOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/Commands",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<CommandResource> Read(ReadCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<CommandResource>.FromJson("commands", response.Content);
            return new ResourceSet<CommandResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CommandResource>> ReadAsync(ReadCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<CommandResource>.FromJson("commands", response.Content);
            return new ResourceSet<CommandResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<CommandResource> Read(string device = null, string status = null, string direction = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCommandOptions{Device = device, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CommandResource>> ReadAsync(string device = null, string status = null, string direction = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCommandOptions{Device = device, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<CommandResource> NextPage(Page<CommandResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<CommandResource>.FromJson("commands", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateCommandOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/Commands",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static CommandResource Create(CreateCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CommandResource> CreateAsync(CreateCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static CommandResource Create(string device, string command, string callbackMethod = null, Uri callbackUrl = null, string commandMode = null, string includeSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCommandOptions(device, command){CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, CommandMode = commandMode, IncludeSid = includeSid};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CommandResource> CreateAsync(string device, string command, string callbackMethod = null, Uri callbackUrl = null, string commandMode = null, string includeSid = null, ITwilioRestClient client = null)
        {
            var options = new CreateCommandOptions(device, command){CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, CommandMode = commandMode, IncludeSid = includeSid};
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CommandResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CommandResource object represented by the provided JSON </returns> 
        public static CommandResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CommandResource>(json);
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
        [JsonProperty("device_sid")]
        public string DeviceSid { get; private set; }
        [JsonProperty("command")]
        public string Command { get; private set; }
        [JsonProperty("command_mode")]
        public string CommandMode { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("direction")]
        public string Direction { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private CommandResource()
        {
        
        }
    }

}