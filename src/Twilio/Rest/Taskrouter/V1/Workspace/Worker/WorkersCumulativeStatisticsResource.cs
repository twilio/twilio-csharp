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
    public class WorkersCumulativeStatisticsResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchWorkersCumulativeStatisticsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Workspaces/{WorkspaceSid}/Workers/CumulativeStatistics";

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
        /// <param name="options"> Fetch WorkersCumulativeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersCumulativeStatistics </returns>
        public static WorkersCumulativeStatisticsResource Fetch(FetchWorkersCumulativeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WorkersCumulativeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersCumulativeStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkersCumulativeStatisticsResource> FetchAsync(FetchWorkersCumulativeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the resource to fetch. </param>
        /// <param name="endDate"> Only calculate statistics from this date and time and earlier, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="taskChannel"> Only calculate cumulative statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkersCumulativeStatistics </returns>
        public static WorkersCumulativeStatisticsResource Fetch(
                                         string pathWorkspaceSid, 
                                         DateTime? endDate = null, 
                                         int? minutes = null, 
                                         DateTime? startDate = null, 
                                         string taskChannel = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchWorkersCumulativeStatisticsOptions(pathWorkspaceSid){ EndDate = endDate,Minutes = minutes,StartDate = startDate,TaskChannel = taskChannel };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the resource to fetch. </param>
        /// <param name="endDate"> Only calculate statistics from this date and time and earlier, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="taskChannel"> Only calculate cumulative statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkersCumulativeStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkersCumulativeStatisticsResource> FetchAsync(string pathWorkspaceSid, DateTime? endDate = null, int? minutes = null, DateTime? startDate = null, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersCumulativeStatisticsOptions(pathWorkspaceSid){ EndDate = endDate,Minutes = minutes,StartDate = startDate,TaskChannel = taskChannel };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkersCumulativeStatisticsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkersCumulativeStatisticsResource object represented by the provided JSON </returns>
        public static WorkersCumulativeStatisticsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<WorkersCumulativeStatisticsResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Worker resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The beginning of the interval during which these statistics were calculated, in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }

        ///<summary> The end of the interval during which these statistics were calculated, in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }

        ///<summary> The minimum, average, maximum, and total time (in seconds) that Workers spent in each Activity. </summary> 
        [JsonProperty("activity_durations")]
        public List<object> ActivityDurations { get; private set; }

        ///<summary> The total number of Reservations that were created. </summary> 
        [JsonProperty("reservations_created")]
        public int? ReservationsCreated { get; private set; }

        ///<summary> The total number of Reservations that were accepted. </summary> 
        [JsonProperty("reservations_accepted")]
        public int? ReservationsAccepted { get; private set; }

        ///<summary> The total number of Reservations that were rejected. </summary> 
        [JsonProperty("reservations_rejected")]
        public int? ReservationsRejected { get; private set; }

        ///<summary> The total number of Reservations that were timed out. </summary> 
        [JsonProperty("reservations_timed_out")]
        public int? ReservationsTimedOut { get; private set; }

        ///<summary> The total number of Reservations that were canceled. </summary> 
        [JsonProperty("reservations_canceled")]
        public int? ReservationsCanceled { get; private set; }

        ///<summary> The total number of Reservations that were rescinded. </summary> 
        [JsonProperty("reservations_rescinded")]
        public int? ReservationsRescinded { get; private set; }

        ///<summary> The SID of the Workspace that contains the Workers. </summary> 
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }

        ///<summary> The absolute URL of the Workers statistics resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private WorkersCumulativeStatisticsResource() {

        }
    }
}

