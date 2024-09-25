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





namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue
{
    public class TaskQueueRealTimeStatisticsResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchTaskQueueRealTimeStatisticsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Workspaces/{WorkspaceSid}/TaskQueues/{TaskQueueSid}/RealTimeStatistics";

            string PathWorkspaceSid = options.PathWorkspaceSid;
            path = path.Replace("{"+"WorkspaceSid"+"}", PathWorkspaceSid);
            string PathTaskQueueSid = options.PathTaskQueueSid;
            path = path.Replace("{"+"TaskQueueSid"+"}", PathTaskQueueSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch TaskQueueRealTimeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueueRealTimeStatistics </returns>
        public static TaskQueueRealTimeStatisticsResource Fetch(FetchTaskQueueRealTimeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch TaskQueueRealTimeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueueRealTimeStatistics </returns>
        public static async System.Threading.Tasks.Task<TaskQueueRealTimeStatisticsResource> FetchAsync(FetchTaskQueueRealTimeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the TaskQueue to fetch. </param>
        /// <param name="pathTaskQueueSid"> The SID of the TaskQueue for which to fetch statistics. </param>
        /// <param name="taskChannel"> The TaskChannel for which to fetch statistics. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueueRealTimeStatistics </returns>
        public static TaskQueueRealTimeStatisticsResource Fetch(
                                         string pathWorkspaceSid, 
                                         string pathTaskQueueSid, 
                                         string taskChannel = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueRealTimeStatisticsOptions(pathWorkspaceSid, pathTaskQueueSid){ TaskChannel = taskChannel };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the TaskQueue to fetch. </param>
        /// <param name="pathTaskQueueSid"> The SID of the TaskQueue for which to fetch statistics. </param>
        /// <param name="taskChannel"> The TaskChannel for which to fetch statistics. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueueRealTimeStatistics </returns>
        public static async System.Threading.Tasks.Task<TaskQueueRealTimeStatisticsResource> FetchAsync(string pathWorkspaceSid, string pathTaskQueueSid, string taskChannel = null, ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueRealTimeStatisticsOptions(pathWorkspaceSid, pathTaskQueueSid){ TaskChannel = taskChannel };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueRealTimeStatisticsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueRealTimeStatisticsResource object represented by the provided JSON </returns>
        public static TaskQueueRealTimeStatisticsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TaskQueueRealTimeStatisticsResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the TaskQueue resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The number of current Workers by Activity. </summary> 
        [JsonProperty("activity_statistics")]
        public List<object> ActivityStatistics { get; private set; }

        ///<summary> The age of the longest waiting Task. </summary> 
        [JsonProperty("longest_task_waiting_age")]
        public int? LongestTaskWaitingAge { get; private set; }

        ///<summary> The SID of the longest waiting Task. </summary> 
        [JsonProperty("longest_task_waiting_sid")]
        public string LongestTaskWaitingSid { get; private set; }

        ///<summary> The relative age in the TaskQueue for the longest waiting Task. Calculation is based on the time when the Task entered the TaskQueue. </summary> 
        [JsonProperty("longest_relative_task_age_in_queue")]
        public int? LongestRelativeTaskAgeInQueue { get; private set; }

        ///<summary> The Task SID of the Task waiting in the TaskQueue the longest. Calculation is based on the time when the Task entered the TaskQueue. </summary> 
        [JsonProperty("longest_relative_task_sid_in_queue")]
        public string LongestRelativeTaskSidInQueue { get; private set; }

        ///<summary> The SID of the TaskQueue from which these statistics were calculated. </summary> 
        [JsonProperty("task_queue_sid")]
        public string TaskQueueSid { get; private set; }

        ///<summary> The number of Tasks by priority. For example: `{\"0\": \"10\", \"99\": \"5\"}` shows 10 Tasks at priority 0 and 5 at priority 99. </summary> 
        [JsonProperty("tasks_by_priority")]
        public object TasksByPriority { get; private set; }

        ///<summary> The number of Tasks by their current status. For example: `{\"pending\": \"1\", \"reserved\": \"3\", \"assigned\": \"2\", \"completed\": \"5\"}`. </summary> 
        [JsonProperty("tasks_by_status")]
        public object TasksByStatus { get; private set; }

        ///<summary> The total number of Workers in the TaskQueue with an `available` status. Workers with an `available` status may already have active interactions or may have none. </summary> 
        [JsonProperty("total_available_workers")]
        public int? TotalAvailableWorkers { get; private set; }

        ///<summary> The total number of Workers eligible for Tasks in the TaskQueue, independent of their Activity state. </summary> 
        [JsonProperty("total_eligible_workers")]
        public int? TotalEligibleWorkers { get; private set; }

        ///<summary> The total number of Tasks. </summary> 
        [JsonProperty("total_tasks")]
        public int? TotalTasks { get; private set; }

        ///<summary> The SID of the Workspace that contains the TaskQueue. </summary> 
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }

        ///<summary> The absolute URL of the TaskQueue statistics resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private TaskQueueRealTimeStatisticsResource() {

        }
    }
}

