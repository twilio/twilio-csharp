using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkflowResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkflowFetcher capable of executing the fetch </returns> 
        public static WorkflowFetcher Fetcher(string workspaceSid, string sid) {
            return new WorkflowFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="assignmentCallbackUrl"> The assignment_callback_url </param>
        /// <param name="fallbackAssignmentCallbackUrl"> The fallback_assignment_callback_url </param>
        /// <param name="configuration"> The configuration </param>
        /// <param name="taskReservationTimeout"> The task_reservation_timeout </param>
        /// <returns> WorkflowUpdater capable of executing the update </returns> 
        public static WorkflowUpdater Updater(string workspaceSid, string sid, string friendlyName=null, Uri assignmentCallbackUrl=null, Uri fallbackAssignmentCallbackUrl=null, string configuration=null, int? taskReservationTimeout=null) {
            return new WorkflowUpdater(workspaceSid, sid, friendlyName:friendlyName, assignmentCallbackUrl:assignmentCallbackUrl, fallbackAssignmentCallbackUrl:fallbackAssignmentCallbackUrl, configuration:configuration, taskReservationTimeout:taskReservationTimeout);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkflowDeleter capable of executing the delete </returns> 
        public static WorkflowDeleter Deleter(string workspaceSid, string sid) {
            return new WorkflowDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkflowReader capable of executing the read </returns> 
        public static WorkflowReader Reader(string workspaceSid, string friendlyName=null) {
            return new WorkflowReader(workspaceSid, friendlyName:friendlyName);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="configuration"> The configuration </param>
        /// <param name="assignmentCallbackUrl"> The assignment_callback_url </param>
        /// <param name="fallbackAssignmentCallbackUrl"> The fallback_assignment_callback_url </param>
        /// <param name="taskReservationTimeout"> The task_reservation_timeout </param>
        /// <returns> WorkflowCreator capable of executing the create </returns> 
        public static WorkflowCreator Creator(string workspaceSid, string friendlyName, string configuration, Uri assignmentCallbackUrl=null, Uri fallbackAssignmentCallbackUrl=null, int? taskReservationTimeout=null) {
            return new WorkflowCreator(workspaceSid, friendlyName, configuration, assignmentCallbackUrl:assignmentCallbackUrl, fallbackAssignmentCallbackUrl:fallbackAssignmentCallbackUrl, taskReservationTimeout:taskReservationTimeout);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkflowResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowResource object represented by the provided JSON </returns> 
        public static WorkflowResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkflowResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("assignment_callback_url")]
        public Uri assignmentCallbackUrl { get; }
        [JsonProperty("configuration")]
        public string configuration { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("document_content_type")]
        public string documentContentType { get; }
        [JsonProperty("fallback_assignment_callback_url")]
        public Uri fallbackAssignmentCallbackUrl { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("task_reservation_timeout")]
        public int? taskReservationTimeout { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
        public WorkflowResource() {
        
        }
    
        private WorkflowResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("assignment_callback_url")]
                                 Uri assignmentCallbackUrl, 
                                 [JsonProperty("configuration")]
                                 string configuration, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("document_content_type")]
                                 string documentContentType, 
                                 [JsonProperty("fallback_assignment_callback_url")]
                                 Uri fallbackAssignmentCallbackUrl, 
                                 [JsonProperty("friendly_name")]
                                 string friendlyName, 
                                 [JsonProperty("sid")]
                                 string sid, 
                                 [JsonProperty("task_reservation_timeout")]
                                 int? taskReservationTimeout, 
                                 [JsonProperty("workspace_sid")]
                                 string workspaceSid, 
                                 [JsonProperty("url")]
                                 Uri url) {
            this.accountSid = accountSid;
            this.assignmentCallbackUrl = assignmentCallbackUrl;
            this.configuration = configuration;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.documentContentType = documentContentType;
            this.fallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.taskReservationTimeout = taskReservationTimeout;
            this.workspaceSid = workspaceSid;
            this.url = url;
        }
    }
}