using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace.TaskQueue;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.TaskQueue {

    public class TaskQueuesStatisticsResource : Resource {
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskQueuesStatisticsReader capable of executing the read
         */
        public static TaskQueuesStatisticsReader Read(string workspaceSid) {
            return new TaskQueuesStatisticsReader(workspaceSid);
        }
    
        /**
         * Converts a JSON string into a TaskQueuesStatisticsResource object
         * 
         * @param json Raw JSON string
         * @return TaskQueuesStatisticsResource object represented by the provided JSON
         */
        public static TaskQueuesStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueuesStatisticsResource>(json);
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