using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkflowResource : SidResource {
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
        /// <returns> WorkflowUpdater capable of executing the update </returns> 
        public static WorkflowUpdater Updater(string workspaceSid, string sid) {
            return new WorkflowUpdater(workspaceSid, sid);
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
        /// <returns> WorkflowReader capable of executing the read </returns> 
        public static WorkflowReader Reader(string workspaceSid) {
            return new WorkflowReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="configuration"> The configuration </param>
        /// <returns> WorkflowCreator capable of executing the create </returns> 
        public static WorkflowCreator Creator(string workspaceSid, string friendlyName, string configuration) {
            return new WorkflowCreator(workspaceSid, friendlyName, configuration);
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
        private readonly string accountSid;
        [JsonProperty("assignment_callback_url")]
        private readonly Uri assignmentCallbackUrl;
        [JsonProperty("configuration")]
        private readonly string configuration;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("document_content_type")]
        private readonly string documentContentType;
        [JsonProperty("fallback_assignment_callback_url")]
        private readonly Uri fallbackAssignmentCallbackUrl;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("task_reservation_timeout")]
        private readonly int? taskReservationTimeout;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
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
                                 string workspaceSid) {
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
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The assignment_callback_url </returns> 
        public Uri GetAssignmentCallbackUrl() {
            return this.assignmentCallbackUrl;
        }
    
        /// <returns> The configuration </returns> 
        public string GetConfiguration() {
            return this.configuration;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The document_content_type </returns> 
        public string GetDocumentContentType() {
            return this.documentContentType;
        }
    
        /// <returns> The fallback_assignment_callback_url </returns> 
        public Uri GetFallbackAssignmentCallbackUrl() {
            return this.fallbackAssignmentCallbackUrl;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The task_reservation_timeout </returns> 
        public int? GetTaskReservationTimeout() {
            return this.taskReservationTimeout;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}