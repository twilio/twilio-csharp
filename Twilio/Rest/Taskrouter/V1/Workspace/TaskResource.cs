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
    
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskFetcher capable of executing the fetch
         */
        public static TaskFetcher Fetcher(string workspaceSid, string sid) {
            return new TaskFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskUpdater capable of executing the update
         */
        public static TaskUpdater Updater(string workspaceSid, string sid) {
            return new TaskUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskDeleter capable of executing the delete
         */
        public static TaskDeleter Deleter(string workspaceSid, string sid) {
            return new TaskDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskReader capable of executing the read
         */
        public static TaskReader Reader(string workspaceSid) {
            return new TaskReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param attributes The attributes
         * @param workflowSid The workflow_sid
         * @return TaskCreator capable of executing the create
         */
        public static TaskCreator Creator(string workspaceSid, string attributes, string workflowSid) {
            return new TaskCreator(workspaceSid, attributes, workflowSid);
        }
    
        /**
         * Converts a JSON string into a TaskResource object
         * 
         * @param json Raw JSON string
         * @return TaskResource object represented by the provided JSON
         */
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The age
         */
        public int? GetAge() {
            return this.age;
        }
    
        /**
         * @return The assignment_status
         */
        public TaskResource.Status GetAssignmentStatus() {
            return this.assignmentStatus;
        }
    
        /**
         * @return The attributes
         */
        public string GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The priority
         */
        public int? GetPriority() {
            return this.priority;
        }
    
        /**
         * @return The reason
         */
        public string GetReason() {
            return this.reason;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_queue_sid
         */
        public string GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /**
         * @return The task_channel_sid
         */
        public string GetTaskChannelSid() {
            return this.taskChannelSid;
        }
    
        /**
         * @return The task_channel_unique_name
         */
        public string GetTaskChannelUniqueName() {
            return this.taskChannelUniqueName;
        }
    
        /**
         * @return The timeout
         */
        public int? GetTimeout() {
            return this.timeout;
        }
    
        /**
         * @return The workflow_sid
         */
        public string GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}