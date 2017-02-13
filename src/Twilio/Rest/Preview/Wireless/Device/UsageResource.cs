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
        ///
        /// <param name="options"> Fetch Usage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Usage </returns> 
        public static UsageResource Fetch(FetchUsageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Usage parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Usage </returns> 
        public static async System.Threading.Tasks.Task<UsageResource> FetchAsync(FetchUsageOptions options, ITwilioRestClient client = null)
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
        /// <param name="deviceSid"> The device_sid </param>
        /// <param name="end"> The end </param>
        /// <param name="start"> The start </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Usage </returns> 
        public static UsageResource Fetch(string deviceSid, string end = null, string start = null, ITwilioRestClient client = null)
        {
            var options = new FetchUsageOptions(deviceSid){End = end, Start = start};
            return Fetch(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="deviceSid"> The device_sid </param>
        /// <param name="end"> The end </param>
        /// <param name="start"> The start </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Usage </returns> 
        public static async System.Threading.Tasks.Task<UsageResource> FetchAsync(string deviceSid, string end = null, string start = null, ITwilioRestClient client = null)
        {
            var options = new FetchUsageOptions(deviceSid){End = end, Start = start};
            return await FetchAsync(options, client);
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
    
        /// <summary>
        /// The device_sid
        /// </summary>
        [JsonProperty("device_sid")]
        public string DeviceSid { get; private set; }
        /// <summary>
        /// The device_alias
        /// </summary>
        [JsonProperty("device_alias")]
        public string DeviceAlias { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The period
        /// </summary>
        [JsonProperty("period")]
        public object Period { get; private set; }
        /// <summary>
        /// The commands_usage
        /// </summary>
        [JsonProperty("commands_usage")]
        public object CommandsUsage { get; private set; }
        /// <summary>
        /// The commands_costs
        /// </summary>
        [JsonProperty("commands_costs")]
        public object CommandsCosts { get; private set; }
        /// <summary>
        /// The data_usage
        /// </summary>
        [JsonProperty("data_usage")]
        public object DataUsage { get; private set; }
        /// <summary>
        /// The data_costs
        /// </summary>
        [JsonProperty("data_costs")]
        public object DataCosts { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private UsageResource()
        {
        
        }
    }

}