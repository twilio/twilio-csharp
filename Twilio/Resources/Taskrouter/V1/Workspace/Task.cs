using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Taskrouter.V1.Workspace;
using Twilio.Deleters.Taskrouter.V1.Workspace;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1.Workspace;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Taskrouter.V1.Workspace {

    public class Task : SidResource {
        public enum Status {
            PENDING="pending",
            RESERVED="reserved",
            ASSIGNED="assigned",
            CANCELED="canceled"
        };
    
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskFetcher capable of executing the fetch
         */
        public static TaskFetcher fetch(String workspaceSid, String sid) {
            return new TaskFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskUpdater capable of executing the update
         */
        public static TaskUpdater update(String workspaceSid, String sid) {
            return new TaskUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskDeleter capable of executing the delete
         */
        public static TaskDeleter delete(String workspaceSid, String sid) {
            return new TaskDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskReader capable of executing the read
         */
        public static TaskReader read(String workspaceSid) {
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
        public static TaskCreator create(String workspaceSid, String attributes, String workflowSid) {
            return new TaskCreator(workspaceSid, attributes, workflowSid);
        }
    
        /**
         * Converts a JSON string into a Task object
         * 
         * @param json Raw JSON string
         * @return Task object represented by the provided JSON
         */
        public static Task fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Task>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("age")]
        private readonly Integer age;
        [JsonProperty("assignment_status")]
        private readonly Task.Status assignmentStatus;
        [JsonProperty("attributes")]
        private readonly String attributes;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("priority")]
        private readonly Integer priority;
        [JsonProperty("reason")]
        private readonly String reason;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("task_queue_sid")]
        private readonly String taskQueueSid;
        [JsonProperty("timeout")]
        private readonly Integer timeout;
        [JsonProperty("workflow_sid")]
        private readonly String workflowSid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private Task([JsonProperty("account_sid")]
                     String accountSid, 
                     [JsonProperty("age")]
                     Integer age, 
                     [JsonProperty("assignment_status")]
                     Task.Status assignmentStatus, 
                     [JsonProperty("attributes")]
                     String attributes, 
                     [JsonProperty("date_created")]
                     String dateCreated, 
                     [JsonProperty("date_updated")]
                     String dateUpdated, 
                     [JsonProperty("priority")]
                     Integer priority, 
                     [JsonProperty("reason")]
                     String reason, 
                     [JsonProperty("sid")]
                     String sid, 
                     [JsonProperty("task_queue_sid")]
                     String taskQueueSid, 
                     [JsonProperty("timeout")]
                     Integer timeout, 
                     [JsonProperty("workflow_sid")]
                     String workflowSid, 
                     [JsonProperty("workspace_sid")]
                     String workspaceSid) {
            this.accountSid = accountSid;
            this.age = age;
            this.assignmentStatus = assignmentStatus;
            this.attributes = attributes;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.priority = priority;
            this.reason = reason;
            this.sid = sid;
            this.taskQueueSid = taskQueueSid;
            this.timeout = timeout;
            this.workflowSid = workflowSid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The age
         */
        public Integer GetAge() {
            return this.age;
        }
    
        /**
         * @return The assignment_status
         */
        public Task.Status GetAssignmentStatus() {
            return this.assignmentStatus;
        }
    
        /**
         * @return The attributes
         */
        public String GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The priority
         */
        public Integer GetPriority() {
            return this.priority;
        }
    
        /**
         * @return The reason
         */
        public String GetReason() {
            return this.reason;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_queue_sid
         */
        public String GetTaskQueueSid() {
            return this.taskQueueSid;
        }
    
        /**
         * @return The timeout
         */
        public Integer GetTimeout() {
            return this.timeout;
        }
    
        /**
         * @return The workflow_sid
         */
        public String GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}