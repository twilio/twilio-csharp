using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskResource : Resource 
    {
        public sealed class TaskStatus : IStringEnum 
        {
            public const string Pending = "pending";
            public const string Reserved = "reserved";
            public const string Assigned = "assigned";
            public const string Canceled = "canceled";
            public const string Completed = "completed";
        
            private string _value;
            
            public TaskStatus() {}
            
            public TaskStatus(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator TaskStatus(string value)
            {
                return new TaskStatus(value);
            }
            
            public static implicit operator string(TaskStatus value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskFetcher capable of executing the fetch </returns> 
        public static TaskFetcher Fetcher(string workspaceSid, string sid)
        {
            return new TaskFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskUpdater capable of executing the update </returns> 
        public static TaskUpdater Updater(string workspaceSid, string sid)
        {
            return new TaskUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskDeleter capable of executing the delete </returns> 
        public static TaskDeleter Deleter(string workspaceSid, string sid)
        {
            return new TaskDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskReader capable of executing the read </returns> 
        public static TaskReader Reader(string workspaceSid)
        {
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
        public static TaskCreator Creator(string workspaceSid, string attributes, string workflowSid)
        {
            return new TaskCreator(workspaceSid, attributes, workflowSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskResource object represented by the provided JSON </returns> 
        public static TaskResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("age")]
        public int? age { get; set; }
        [JsonProperty("assignment_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TaskResource.TaskStatus assignmentStatus { get; set; }
        [JsonProperty("attributes")]
        public string attributes { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("priority")]
        public int? priority { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("task_queue_sid")]
        public string taskQueueSid { get; set; }
        [JsonProperty("task_channel_sid")]
        public string taskChannelSid { get; set; }
        [JsonProperty("task_channel_unique_name")]
        public string taskChannelUniqueName { get; set; }
        [JsonProperty("timeout")]
        public int? timeout { get; set; }
        [JsonProperty("workflow_sid")]
        public string workflowSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
    
        public TaskResource()
        {
        
        }
    
        private TaskResource([JsonProperty("account_sid")]
                             string accountSid, 
                             [JsonProperty("age")]
                             int? age, 
                             [JsonProperty("assignment_status")]
                             TaskResource.TaskStatus assignmentStatus, 
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
                             string workspaceSid, 
                             [JsonProperty("url")]
                             Uri url)
                             {
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
            this.url = url;
        }
    }
}