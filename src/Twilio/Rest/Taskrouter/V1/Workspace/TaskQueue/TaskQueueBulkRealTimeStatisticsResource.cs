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
    public class TaskQueueBulkRealTimeStatisticsResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateTaskQueueBulkRealTimeStatisticsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Workspaces/{WorkspaceSid}/TaskQueues/RealTimeStatistics";

            string PathWorkspaceSid = options.PathWorkspaceSid;
            path = path.Replace("{"+"WorkspaceSid"+"}", PathWorkspaceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a Task Queue Real Time Statistics in bulk for the array of TaskQueue SIDs, support upto 50 in a request. </summary>
        /// <param name="options"> Create TaskQueueBulkRealTimeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueueBulkRealTimeStatistics </returns>
        public static TaskQueueBulkRealTimeStatisticsResource Create(CreateTaskQueueBulkRealTimeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a Task Queue Real Time Statistics in bulk for the array of TaskQueue SIDs, support upto 50 in a request. </summary>
        /// <param name="options"> Create TaskQueueBulkRealTimeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueueBulkRealTimeStatistics </returns>
        public static async System.Threading.Tasks.Task<TaskQueueBulkRealTimeStatisticsResource> CreateAsync(CreateTaskQueueBulkRealTimeStatisticsOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Fetch a Task Queue Real Time Statistics in bulk for the array of TaskQueue SIDs, support upto 50 in a request. </summary>
        /// <param name="pathWorkspaceSid"> The unique SID identifier of the Workspace. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TaskQueueBulkRealTimeStatistics </returns>
        public static TaskQueueBulkRealTimeStatisticsResource Create(
                                          string pathWorkspaceSid,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateTaskQueueBulkRealTimeStatisticsOptions(pathWorkspaceSid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Fetch a Task Queue Real Time Statistics in bulk for the array of TaskQueue SIDs, support upto 50 in a request. </summary>
        /// <param name="pathWorkspaceSid"> The unique SID identifier of the Workspace. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TaskQueueBulkRealTimeStatistics </returns>
        public static async System.Threading.Tasks.Task<TaskQueueBulkRealTimeStatisticsResource> CreateAsync(
                                                                                  string pathWorkspaceSid,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateTaskQueueBulkRealTimeStatisticsOptions(pathWorkspaceSid){  };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueBulkRealTimeStatisticsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueBulkRealTimeStatisticsResource object represented by the provided JSON </returns>
        public static TaskQueueBulkRealTimeStatisticsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TaskQueueBulkRealTimeStatisticsResource>(json);
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

        ///<summary> The SID of the Workspace that contains the TaskQueue. </summary> 
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }

        ///<summary> The real-time statistics for each requested TaskQueue SID. `task_queue_data` returns the following attributes:  `task_queue_sid`: The SID of the TaskQueue from which these statistics were calculated.  `total_available_workers`: The total number of Workers available for Tasks in the TaskQueue.  `total_eligible_workers`: The total number of Workers eligible for Tasks in the TaskQueue, regardless of their Activity state.  `total_tasks`: The total number of Tasks.  `longest_task_waiting_age`: The age of the longest waiting Task.  `longest_task_waiting_sid`: The SID of the longest waiting Task.  `tasks_by_status`: The number of Tasks grouped by their current status.  `tasks_by_priority`: The number of Tasks grouped by priority.  `activity_statistics`: The number of current Workers grouped by Activity.  </summary> 
        [JsonProperty("task_queue_data")]
        public List<object> TaskQueueData { get; private set; }

        ///<summary> The number of TaskQueue statistics received in task_queue_data. </summary> 
        [JsonProperty("task_queue_response_count")]
        public int? TaskQueueResponseCount { get; private set; }

        ///<summary> The absolute URL of the TaskQueue statistics resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private TaskQueueBulkRealTimeStatisticsResource() {

        }
    }
}
