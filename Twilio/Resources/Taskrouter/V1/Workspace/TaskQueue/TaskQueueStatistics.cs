using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.TaskQueue;
using Twilio.Http;
using Twilio.Resources;
using com.fasterxml.jackson.databind.JsonNode;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Taskqueue {

    public class TaskQueueStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param taskQueueSid The task_queue_sid
         * @return TaskQueueStatisticsFetcher capable of executing the fetch
         */
        public static TaskQueueStatisticsFetcher fetch(String workspaceSid, String taskQueueSid) {
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
        private readonly String accountSid;
        [JsonProperty("cumulative")]
        private readonly Map<String, String> cumulative;
        [JsonProperty("realtime")]
        private readonly JsonNode realtime;
        [JsonProperty("task_queue_sid")]
        private readonly String taskQueueSid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private TaskQueueStatistics([JsonProperty("account_sid")]
                                    String accountSid, 
                                    [JsonProperty("cumulative")]
                                    Map<String, String> cumulative, 
                                    [JsonProperty("realtime")]
                                    JsonNode realtime, 
                                    [JsonProperty("task_queue_sid")]
                                    String taskQueueSid, 
                                    [JsonProperty("workspace_sid")]
                                    String workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
            this.taskQueueSid = taskQueueSid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The cumulative
         */
        public Map<String, String> GetCumulative() {
            return this.cumulative;
        }
    
        /**
         * @return The realtime
         */
        public JsonNode GetRealtime() {
            return this.realtime;
        }
    
        /**
         * @return The task_queue_sid
         */
        public String GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}