using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.TaskQueue;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Taskqueue {

    public class TaskQueueStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param taskQueueSid The task_queue_sid
         * @return TaskQueueStatisticsFetcher capable of executing the fetch
         */
        public static TaskQueueStatisticsFetcher fetch(string workspaceSid, string taskQueueSid) {
            return new TaskQueueStatisticsFetcher(workspaceSid, taskQueueSid);
        }
    
        /**
         * Converts a JSON string into a TaskQueueStatistics object
         * 
         * @param json Raw JSON string
         * @return TaskQueueStatistics object represented by the provided JSON
         */
        public static TaskQueueStatistics fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueueStatistics>(json);
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
    
        private TaskQueueStatistics([JsonProperty("account_sid")]
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The cumulative
         */
        public Dictionary<string, string> GetCumulative() {
            return this.cumulative;
        }
    
        /**
         * @return The realtime
         */
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /**
         * @return The task_queue_sid
         */
        public string GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}