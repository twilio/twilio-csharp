using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Wireless.Device 
{

    public class UsageResource : Resource 
    {
        private static Request BuildFetchRequest(FetchUsageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/wireless/Devices/" + options.DeviceSid + "/Usage",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static UsageResource Fetch(FetchUsageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UsageResource> FetchAsync(FetchUsageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static UsageResource Fetch(string deviceSid, string end = null, string start = null, ITwilioRestClient client = null)
        {
            var options = new FetchUsageOptions(deviceSid){End = end, Start = start};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<UsageResource> FetchAsync(string deviceSid, string end = null, string start = null, ITwilioRestClient client = null)
        {
            var options = new FetchUsageOptions(deviceSid){End = end, Start = start};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UsageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UsageResource object represented by the provided JSON </returns> 
        public static UsageResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<UsageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("device_sid")]
        public string DeviceSid { get; private set; }
        [JsonProperty("device_alias")]
        public string DeviceAlias { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("period")]
        public Object Period { get; private set; }
        [JsonProperty("commands_usage")]
        public Object CommandsUsage { get; private set; }
        [JsonProperty("commands_costs")]
        public Object CommandsCosts { get; private set; }
        [JsonProperty("data_usage")]
        public Object DataUsage { get; private set; }
        [JsonProperty("data_costs")]
        public Object DataCosts { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private UsageResource()
        {
        
        }
    }

}