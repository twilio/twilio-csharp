using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue {

    public class TaskQueueStatisticsResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <returns> TaskQueueStatisticsFetcher capable of executing the fetch </returns> 
        public static TaskQueueStatisticsFetcher Fetcher(string workspaceSid, string taskQueueSid) {
            return new TaskQueueStatisticsFetcher(workspaceSid, taskQueueSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueStatisticsResource object represented by the provided JSON </returns> 
        public static TaskQueueStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueueStatisticsResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("cumulative")]
        private readonly Dictionary<string, string> cumulative;
        [JsonProperty("realtime")]
        private readonly Object realtime;
        [JsonProperty("task_queue_sid")]
        private readonly string taskQueueSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public TaskQueueStatisticsResource() {
        
        }
    
        private TaskQueueStatisticsResource([JsonProperty("account_sid")]
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The cumulative </returns> 
        public Dictionary<string, string> GetCumulative() {
            return this.cumulative;
        }
    
        /// <returns> The realtime </returns> 
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /// <returns> The task_queue_sid </returns> 
        public string GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}