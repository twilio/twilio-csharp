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

    public class RatePlanResource : Resource 
    {
        private static Request BuildReadRequest(ReadRatePlanOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/RatePlans",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RatePlanResource> Read(ReadRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<RatePlanResource>.FromJson("rate_plans", response.Content);
            return new ResourceSet<RatePlanResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RatePlanResource>> ReadAsync(ReadRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<RatePlanResource>.FromJson("rate_plans", response.Content);
            return new ResourceSet<RatePlanResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<RatePlanResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRatePlanOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RatePlanResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRatePlanOptions{PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<RatePlanResource> NextPage(Page<RatePlanResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<RatePlanResource>.FromJson("rate_plans", response.Content);
        }
    
        private static Request BuildFetchRequest(FetchRatePlanOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/RatePlans/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static RatePlanResource Fetch(FetchRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> FetchAsync(FetchRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static RatePlanResource Fetch(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchRatePlanOptions(sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> FetchAsync(string sid, ITwilioRestClient client = null)
        {
            var options = new FetchRatePlanOptions(sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateRatePlanOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/RatePlans",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static RatePlanResource Create(CreateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> CreateAsync(CreateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static RatePlanResource Create(string alias = null, string friendlyName = null, List<string> roaming = null, int? dataLimit = null, string dataMetering = null, bool? commandsEnabled = null, int? renewalPeriod = null, string renewalUnits = null, ITwilioRestClient client = null)
        {
            var options = new CreateRatePlanOptions{Alias = alias, FriendlyName = friendlyName, Roaming = roaming, DataLimit = dataLimit, DataMetering = dataMetering, CommandsEnabled = commandsEnabled, RenewalPeriod = renewalPeriod, RenewalUnits = renewalUnits};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> CreateAsync(string alias = null, string friendlyName = null, List<string> roaming = null, int? dataLimit = null, string dataMetering = null, bool? commandsEnabled = null, int? renewalPeriod = null, string renewalUnits = null, ITwilioRestClient client = null)
        {
            var options = new CreateRatePlanOptions{Alias = alias, FriendlyName = friendlyName, Roaming = roaming, DataLimit = dataLimit, DataMetering = dataMetering, CommandsEnabled = commandsEnabled, RenewalPeriod = renewalPeriod, RenewalUnits = renewalUnits};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateRatePlanOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/wireless/RatePlans/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static RatePlanResource Update(UpdateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> UpdateAsync(UpdateRatePlanOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static RatePlanResource Update(string sid, string alias = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateRatePlanOptions(sid){Alias = alias, FriendlyName = friendlyName};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RatePlanResource> UpdateAsync(string sid, string alias = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new UpdateRatePlanOptions(sid){Alias = alias, FriendlyName = friendlyName};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a RatePlanResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RatePlanResource object represented by the provided JSON </returns> 
        public static RatePlanResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RatePlanResource>(json);
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
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("roaming")]
        public List<string> Roaming { get; private set; }
        [JsonProperty("data")]
        public Object Data { get; private set; }
        [JsonProperty("commands")]
        public Object Commands { get; private set; }
        [JsonProperty("renewal")]
        public Object Renewal { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private RatePlanResource()
        {
        
        }
    }

}