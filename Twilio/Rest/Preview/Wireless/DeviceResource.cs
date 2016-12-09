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
        ///
        /// <param name="options"> Fetch Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Fetch(FetchDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(FetchDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(sid);
            return await FetchAsync(options, client);
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
        ///
        /// <param name="options"> Read Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static ResourceSet<DeviceResource> Read(ReadDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DeviceResource>.FromJson("devices", response.Content);
            return new ResourceSet<DeviceResource>(page, options, client);
        }
    
        #if NET40
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(ReadDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<DeviceResource>.FromJson("devices", response.Content);
            return new ResourceSet<DeviceResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="status"> The status </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static ResourceSet<DeviceResource> Read(string status = null, string simIdentifier = null, string ratePlan = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions{Status = status, SimIdentifier = simIdentifier, RatePlan = ratePlan, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="status"> The status </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(string status = null, string simIdentifier = null, string ratePlan = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions{Status = status, SimIdentifier = simIdentifier, RatePlan = ratePlan, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
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
        ///
        /// <param name="options"> Create Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Create(CreateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> CreateAsync(CreateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Create(string ratePlan, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateDeviceOptions(ratePlan){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return Create(options, client);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> CreateAsync(string ratePlan, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new CreateDeviceOptions(ratePlan){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return await CreateAsync(options, client);
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
        ///
        /// <param name="options"> Update Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Update(UpdateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(UpdateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns> 
        public static DeviceResource Update(string sid, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string ratePlan = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(sid){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return Update(options, client);
        }
    
        #if NET40
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="alias"> The alias </param>
        /// <param name="callbackMethod"> The callback_method </param>
        /// <param name="callbackUrl"> The callback_url </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="ratePlan"> The rate_plan </param>
        /// <param name="simIdentifier"> The sim_identifier </param>
        /// <param name="status"> The status </param>
        /// <param name="commandsCallbackMethod"> The commands_callback_method </param>
        /// <param name="commandsCallbackUrl"> The commands_callback_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns> 
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(string sid, string alias = null, string callbackMethod = null, Uri callbackUrl = null, string friendlyName = null, string ratePlan = null, string simIdentifier = null, string status = null, string commandsCallbackMethod = null, Uri commandsCallbackUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(sid){Alias = alias, CallbackMethod = callbackMethod, CallbackUrl = callbackUrl, FriendlyName = friendlyName, RatePlan = ratePlan, SimIdentifier = simIdentifier, Status = status, CommandsCallbackMethod = commandsCallbackMethod, CommandsCallbackUrl = commandsCallbackUrl};
            return await UpdateAsync(options, client);
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
    
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The alias
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The rate_plan_sid
        /// </summary>
        [JsonProperty("rate_plan_sid")]
        public string RatePlanSid { get; private set; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The sim_identifier
        /// </summary>
        [JsonProperty("sim_identifier")]
        public string SimIdentifier { get; private set; }
        /// <summary>
        /// The status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }
        /// <summary>
        /// The commands_callback_url
        /// </summary>
        [JsonProperty("commands_callback_url")]
        public Uri CommandsCallbackUrl { get; private set; }
        /// <summary>
        /// The commands_callback_method
        /// </summary>
        [JsonProperty("commands_callback_method")]
        public string CommandsCallbackMethod { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private DeviceResource()
        {
        
        }
    }

}