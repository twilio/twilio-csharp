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

    public class DeviceResource : Resource 
    {
        private static Request BuildFetchRequest(FetchDeviceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/Devices/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static DeviceResource Fetch(FetchDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(FetchDeviceOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static DeviceResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadDeviceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/Devices",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<DeviceResource> Read(ReadDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DeviceResource>.FromJson("devices", response.Content);
            return new ResourceSet<DeviceResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(ReadDeviceOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<DeviceResource> Read(string status = null, string simIdentifier = null, string ratePlan = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions{Status = status, SimIdentifier = simIdentifier, RatePlan = ratePlan, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(string status = null, string simIdentifier = null, string ratePlan = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions{Status = status, SimIdentifier = simIdentifier, RatePlan = ratePlan, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<DeviceResource> NextPage(Page<DeviceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<DeviceResource>.FromJson("devices", response.Content);
        }
    
        private static Request BuildCreateRequest(CreateDeviceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/Devices",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static DeviceResource Create(CreateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> CreateAsync(CreateDeviceOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static DeviceResource Create(string ratePlan, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateDeviceOptions(ratePlan){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> CreateAsync(string ratePlan, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateDeviceOptions(ratePlan){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateDeviceOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/Devices/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static DeviceResource Update(UpdateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(UpdateDeviceOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static DeviceResource Update(string sid, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string ratePlan = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(sid){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(string sid, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string ratePlan = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(sid){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DeviceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeviceResource object represented by the provided JSON </returns> 
        public static DeviceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DeviceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("alias")]
        public string Alias { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("rate_plan_sid")]
        public string RatePlanSid { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("sim_identifier")]
        public string SimIdentifier { get; private set; }
        [JsonProperty("status")]
        public string Status { get; private set; }
        [JsonProperty("commands_callback_url")]
        public Uri CommandsCallbackUrl { get; private set; }
        [JsonProperty("commands_callback_method")]
        public string CommandsCallbackMethod { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private DeviceResource()
        {
        
        }
    }

}