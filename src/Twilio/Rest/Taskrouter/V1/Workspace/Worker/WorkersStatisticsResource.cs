/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Taskrouter
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;





namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker
{
    public class WorkersStatisticsResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchWorkersStatisticsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Workspaces/{WorkspaceSid}/Workers/Statistics";

            string PathWorkspaceSid = options.PathWorkspaceSid;
            path = path.Replace("{"+"WorkspaceSid"+"}", PathWorkspaceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WorkersStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersStatistics </returns>
        public static WorkersStatisticsResource Fetch(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WorkersStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Worker to fetch. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="endDate"> Only calculate statistics from this date and time and earlier, specified in GMT as an [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date-time. </param>
        /// <param name="taskQueueSid"> The SID of the TaskQueue for which to fetch Worker statistics. </param>
        /// <param name="taskQueueName"> The `friendly_name` of the TaskQueue for which to fetch Worker statistics. </param>
        /// <param name="friendlyName"> Only include Workers with `friendly_name` values that match this parameter. </param>
        /// <param name="taskChannel"> Only calculate statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersStatistics </returns>
        public static WorkersStatisticsResource Fetch(
                                         string pathWorkspaceSid, 
                                         int? minutes = null, 
                                         DateTime? startDate = null, 
                                         DateTime? endDate = null, 
                                         string taskQueueSid = null, 
                                         string taskQueueName = null, 
                                         string friendlyName = null, 
                                         string taskChannel = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(pathWorkspaceSid){ Minutes = minutes,StartDate = startDate,EndDate = endDate,TaskQueueSid = taskQueueSid,TaskQueueName = taskQueueName,FriendlyName = friendlyName,TaskChannel = taskChannel };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the Worker to fetch. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="endDate"> Only calculate statistics from this date and time and earlier, specified in GMT as an [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date-time. </param>
        /// <param name="taskQueueSid"> The SID of the TaskQueue for which to fetch Worker statistics. </param>
        /// <param name="taskQueueName"> The `friendly_name` of the TaskQueue for which to fetch Worker statistics. </param>
        /// <param name="friendlyName"> Only include Workers with `friendly_name` values that match this parameter. </param>
        /// <param name="taskChannel"> Only calculate statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(string pathWorkspaceSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, string taskQueueSid = null, string taskQueueName = null, string friendlyName = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(pathWorkspaceSid){ Minutes = minutes,StartDate = startDate,EndDate = endDate,TaskQueueSid = taskQueueSid,TaskQueueName = taskQueueName,FriendlyName = friendlyName,TaskChannel = taskChannel };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkersStatisticsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkersStatisticsResource object represented by the provided JSON </returns>
        public static WorkersStatisticsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<WorkersStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> An object that contains the real-time statistics for the Worker. </summary> 
        [JsonProperty("realtime")]
        public object Realtime { get; private set; }

        ///<summary> An object that contains the cumulative statistics for the Worker. </summary> 
        [JsonProperty("cumulative")]
        public object Cumulative { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Worker resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the Workspace that contains the Worker. </summary> 
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }

        ///<summary> The absolute URL of the Worker statistics resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private WorkersStatisticsResource() {

        }
    }
}

