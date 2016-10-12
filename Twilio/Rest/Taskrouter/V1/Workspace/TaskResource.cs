using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskResource : SidResource {
        public sealed class Status : IStringEnum {
            public const string PENDING="pending";
            public const string RESERVED="reserved";
            public const string ASSIGNED="assigned";
            public const string CANCELED="canceled";
            public const string COMPLETED="completed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskFetcher capable of executing the fetch </returns> 
        public static TaskFetcher Fetcher(string workspaceSid, string sid) {
            return new TaskFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskUpdater capable of executing the update </returns> 
        public static TaskUpdater Updater(string workspaceSid, string sid) {
            return new TaskUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskDeleter capable of executing the delete </returns> 
        public static TaskDeleter Deleter(string workspaceSid, string sid) {
            return new TaskDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskReader capable of executing the read </returns> 
        public static TaskReader Reader(string workspaceSid) {
            return new TaskReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> TaskCreator capable of executing the create </returns> 
        public static TaskCreator Creator(string workspaceSid, string attributes, string workflowSid) {
            return new TaskCreator(workspaceSid, attributes, workflowSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskResource object represented by the provided JSON </returns> 
        public static TaskResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("age")]
        private readonly int? age;
        [JsonProperty("assignment_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly TaskResource.Status assignmentStatus;
        [JsonProperty("attributes")]
        private readonly string attributes;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("priority")]
        private readonly int? priority;
        [JsonProperty("reason")]
        private readonly string reason;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("task_queue_sid")]
        private readonly string taskQueueSid;
        [JsonProperty("task_channel_sid")]
        private readonly string taskChannelSid;
        [JsonProperty("task_channel_unique_name")]
        private readonly string taskChannelUniqueName;
        [JsonProperty("timeout")]
        private readonly int? timeout;
        [JsonProperty("workflow_sid")]
        private readonly string workflowSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public TaskResource() {
        
        }
    
        private TaskResource([JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("age")]
                             int? age, 
                             [JsonProperty("assignment_status")]
                             TaskResource.Status assignmentStatus, 
                             [JsonProperty("attributes")]
                             string attributes, 
                             [JsonProperty("date_created")]
                             string dateCreated, 
                             [JsonProperty("date_updated")]
                             string dateUpdated, 
                             [JsonProperty("priority")]
                             int? priority, 
                             [JsonProperty("reason")]
                             string reason, 
                             [JsonProperty("sid")]
                             string sid, 
                             [JsonProperty("task_queue_sid")]
                             string taskQueueSid, 
                             [JsonProperty("task_channel_sid")]
                             string taskChannelSid, 
                             [JsonProperty("task_channel_unique_name")]
                             string taskChannelUniqueName, 
                             [JsonProperty("timeout")]
                             int? timeout, 
                             [JsonProperty("workflow_sid")]
                             string workflowSid, 
                             [JsonProperty("workspace_sid")]
                             string workspaceSid) {
            this.accountSid = accountSid;
            this.age = age;
            this.assignmentStatus = assignmentStatus;
            this.attributes = attributes;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.priority = priority;
            this.reason = reason;
            this.sid = sid;
            this.taskQueueSid = taskQueueSid;
            this.taskChannelSid = taskChannelSid;
            this.taskChannelUniqueName = taskChannelUniqueName;
            this.timeout = timeout;
            this.workflowSid = workflowSid;
            this.workspaceSid = workspaceSid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The age </returns> 
        public int? GetAge() {
            return this.age;
        }
    
        /// <returns> The assignment_status </returns> 
        public TaskResource.Status GetAssignmentStatus() {
            return this.assignmentStatus;
        }
    
        /// <returns> The attributes </returns> 
        public string GetAttributes() {
            return this.attributes;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The priority </returns> 
        public int? GetPriority() {
            return this.priority;
        }
    
        /// <returns> The reason </returns> 
        public string GetReason() {
            return this.reason;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The task_queue_sid </returns> 
        public string GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /// <returns> The task_channel_sid </returns> 
        public string GetTaskChannelSid() {
            return this.taskChannelSid;
        }
    
        /// <returns> The task_channel_unique_name </returns> 
        public string GetTaskChannelUniqueName() {
            return this.taskChannelUniqueName;
        }
    
        /// <returns> The timeout </returns> 
        public int? GetTimeout() {
            return this.timeout;
        }
    
        /// <returns> The workflow_sid </returns> 
        public string GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}