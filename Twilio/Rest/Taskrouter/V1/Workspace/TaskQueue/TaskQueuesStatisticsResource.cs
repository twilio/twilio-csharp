using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue {

    public class TaskQueuesStatisticsResource : Resource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <returns> TaskQueuesStatisticsReader capable of executing the read </returns> 
        public static TaskQueuesStatisticsReader Reader(string workspaceSid, DateTime? endDate=null, string friendlyName=null, int? minutes=null, DateTime? startDate=null) {
            return new TaskQueuesStatisticsReader(workspaceSid, endDate:endDate, friendlyName:friendlyName, minutes:minutes, startDate:startDate);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueuesStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueuesStatisticsResource object represented by the provided JSON </returns> 
        public static TaskQueuesStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueuesStatisticsResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("cumulative")]
        public Dictionary<string, string> cumulative { get; }
        [JsonProperty("realtime")]
        public Object realtime { get; }
        [JsonProperty("task_queue_sid")]
        public string taskQueueSid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
    
        public TaskQueuesStatisticsResource() {
        
        }
    
        private TaskQueuesStatisticsResource([JsonProperty("account_sid")]
                                             string accountSid, 
                                             [JsonProperty("cumulative")]
                                             Dictionary<string, string> cumulative, 
                                             [JsonProperty("realtime")]
                                             Object realtime, 
                                             [JsonProperty("task_queue_sid")]
                                             string taskQueueSid, 
                                             [JsonProperty("workspace_sid")]
                                             string workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
            this.taskQueueSid = taskQueueSid;
            this.workspaceSid = workspaceSid;
        }
    }
}