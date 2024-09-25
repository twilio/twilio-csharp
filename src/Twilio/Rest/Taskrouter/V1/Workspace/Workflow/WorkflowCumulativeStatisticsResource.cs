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





namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow
{
    public class WorkflowCumulativeStatisticsResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchWorkflowCumulativeStatisticsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Workspaces/{WorkspaceSid}/Workflows/{WorkflowSid}/CumulativeStatistics";

            string PathWorkspaceSid = options.PathWorkspaceSid;
            path = path.Replace("{"+"WorkspaceSid"+"}", PathWorkspaceSid);
            string PathWorkflowSid = options.PathWorkflowSid;
            path = path.Replace("{"+"WorkflowSid"+"}", PathWorkflowSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WorkflowCumulativeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkflowCumulativeStatistics </returns>
        public static WorkflowCumulativeStatisticsResource Fetch(FetchWorkflowCumulativeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WorkflowCumulativeStatistics parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkflowCumulativeStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkflowCumulativeStatisticsResource> FetchAsync(FetchWorkflowCumulativeStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the resource to fetch. </param>
        /// <param name="pathWorkflowSid"> Returns the list of Tasks that are being controlled by the Workflow with the specified Sid value. </param>
        /// <param name="endDate"> Only include usage that occurred on or before this date, specified in GMT as an [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date-time. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="taskChannel"> Only calculate cumulative statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="splitByWaitTime"> A comma separated list of values that describes the thresholds, in seconds, to calculate statistics on. For each threshold specified, the number of Tasks canceled and reservations accepted above and below the specified thresholds in seconds are computed. For example, `5,30` would show splits of Tasks that were canceled or accepted before and after 5 seconds and before and after 30 seconds. This can be used to show short abandoned Tasks or Tasks that failed to meet an SLA. TaskRouter will calculate statistics on up to 10,000 Tasks for any given threshold. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WorkflowCumulativeStatistics </returns>
        public static WorkflowCumulativeStatisticsResource Fetch(
                                         string pathWorkspaceSid, 
                                         string pathWorkflowSid, 
                                         DateTime? endDate = null, 
                                         int? minutes = null, 
                                         DateTime? startDate = null, 
                                         string taskChannel = null, 
                                         string splitByWaitTime = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowCumulativeStatisticsOptions(pathWorkspaceSid, pathWorkflowSid){ EndDate = endDate,Minutes = minutes,StartDate = startDate,TaskChannel = taskChannel,SplitByWaitTime = splitByWaitTime };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathWorkspaceSid"> The SID of the Workspace with the resource to fetch. </param>
        /// <param name="pathWorkflowSid"> Returns the list of Tasks that are being controlled by the Workflow with the specified Sid value. </param>
        /// <param name="endDate"> Only include usage that occurred on or before this date, specified in GMT as an [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date-time. </param>
        /// <param name="minutes"> Only calculate statistics since this many minutes in the past. The default 15 minutes. This is helpful for displaying statistics for the last 15 minutes, 240 minutes (4 hours), and 480 minutes (8 hours) to see trends. </param>
        /// <param name="startDate"> Only calculate statistics from this date and time and later, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </param>
        /// <param name="taskChannel"> Only calculate cumulative statistics on this TaskChannel. Can be the TaskChannel's SID or its `unique_name`, such as `voice`, `sms`, or `default`. </param>
        /// <param name="splitByWaitTime"> A comma separated list of values that describes the thresholds, in seconds, to calculate statistics on. For each threshold specified, the number of Tasks canceled and reservations accepted above and below the specified thresholds in seconds are computed. For example, `5,30` would show splits of Tasks that were canceled or accepted before and after 5 seconds and before and after 30 seconds. This can be used to show short abandoned Tasks or Tasks that failed to meet an SLA. TaskRouter will calculate statistics on up to 10,000 Tasks for any given threshold. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WorkflowCumulativeStatistics </returns>
        public static async System.Threading.Tasks.Task<WorkflowCumulativeStatisticsResource> FetchAsync(string pathWorkspaceSid, string pathWorkflowSid, DateTime? endDate = null, int? minutes = null, DateTime? startDate = null, string taskChannel = null, string splitByWaitTime = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowCumulativeStatisticsOptions(pathWorkspaceSid, pathWorkflowSid){ EndDate = endDate,Minutes = minutes,StartDate = startDate,TaskChannel = taskChannel,SplitByWaitTime = splitByWaitTime };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkflowCumulativeStatisticsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowCumulativeStatisticsResource object represented by the provided JSON </returns>
        public static WorkflowCumulativeStatisticsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<WorkflowCumulativeStatisticsResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Workflow resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The average time in seconds between Task creation and acceptance. </summary> 
        [JsonProperty("avg_task_acceptance_time")]
        public int? AvgTaskAcceptanceTime { get; private set; }

        ///<summary> The beginning of the interval during which these statistics were calculated, in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }

        ///<summary> The end of the interval during which these statistics were calculated, in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }

        ///<summary> The total number of Reservations that were created for Workers. </summary> 
        [JsonProperty("reservations_created")]
        public int? ReservationsCreated { get; private set; }

        ///<summary> The total number of Reservations accepted by Workers. </summary> 
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

        ///<summary> A list of objects that describe the number of Tasks canceled and reservations accepted above and below the thresholds specified in seconds. </summary> 
        [JsonProperty("split_by_wait_time")]
        public object SplitByWaitTime { get; private set; }

        ///<summary> The wait duration statistics (`avg`, `min`, `max`, `total`) for Tasks that were accepted. </summary> 
        [JsonProperty("wait_duration_until_accepted")]
        public object WaitDurationUntilAccepted { get; private set; }

        ///<summary> The wait duration statistics (`avg`, `min`, `max`, `total`) for Tasks that were canceled. </summary> 
        [JsonProperty("wait_duration_until_canceled")]
        public object WaitDurationUntilCanceled { get; private set; }

        ///<summary> The total number of Tasks that were canceled. </summary> 
        [JsonProperty("tasks_canceled")]
        public int? TasksCanceled { get; private set; }

        ///<summary> The total number of Tasks that were completed. </summary> 
        [JsonProperty("tasks_completed")]
        public int? TasksCompleted { get; private set; }

        ///<summary> The total number of Tasks that entered the Workflow. </summary> 
        [JsonProperty("tasks_entered")]
        public int? TasksEntered { get; private set; }

        ///<summary> The total number of Tasks that were deleted. </summary> 
        [JsonProperty("tasks_deleted")]
        public int? TasksDeleted { get; private set; }

        ///<summary> The total number of Tasks that were moved from one queue to another. </summary> 
        [JsonProperty("tasks_moved")]
        public int? TasksMoved { get; private set; }

        ///<summary> The total number of Tasks that were timed out of their Workflows (and deleted). </summary> 
        [JsonProperty("tasks_timed_out_in_workflow")]
        public int? TasksTimedOutInWorkflow { get; private set; }

        ///<summary> Returns the list of Tasks that are being controlled by the Workflow with the specified Sid value. </summary> 
        [JsonProperty("workflow_sid")]
        public string WorkflowSid { get; private set; }

        ///<summary> The SID of the Workspace that contains the Workflow. </summary> 
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }

        ///<summary> The absolute URL of the Workflow statistics resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private WorkflowCumulativeStatisticsResource() {

        }
    }
}

