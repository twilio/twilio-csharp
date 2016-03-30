using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Taskrouter.V1.Workspace;
using Twilio.Deleters.Taskrouter.V1.Workspace;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1.Workspace;

namespace Twilio.Resources.Taskrouter.V1.Workspace {

    public class WorkflowResource : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowFetcher capable of executing the fetch
         */
        public static WorkflowFetcher fetch(string workspaceSid, string sid) {
            return new WorkflowFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowUpdater capable of executing the update
         */
        public static WorkflowUpdater update(string workspaceSid, string sid) {
            return new WorkflowUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowDeleter capable of executing the delete
         */
        public static WorkflowDeleter delete(string workspaceSid, string sid) {
            return new WorkflowDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkflowReader capable of executing the read
         */
        public static WorkflowReader read(string workspaceSid) {
            return new WorkflowReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param configuration The configuration
         * @param assignmentCallbackUrl The assignment_callback_url
         * @return WorkflowCreator capable of executing the create
         */
        public static WorkflowCreator create(string workspaceSid, string friendlyName, string configuration, string assignmentCallbackUrl) {
            return new WorkflowCreator(workspaceSid, friendlyName, configuration, assignmentCallbackUrl);
        }
    
        /**
         * Converts a JSON string into a WorkflowResource object
         * 
         * @param json Raw JSON string
         * @return WorkflowResource object represented by the provided JSON
         */
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
        private readonly string assignmentCallbackUrl;
        [JsonProperty("configuration")]
        private readonly string configuration;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("document_content_type")]
        private readonly string documentContentType;
        [JsonProperty("fallback_assignment_callback_url")]
        private readonly string fallbackAssignmentCallbackUrl;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("task_reservation_timeout")]
        private readonly int? taskReservationTimeout;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        private WorkflowResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("assignment_callback_url")]
                                 string assignmentCallbackUrl, 
                                 [JsonProperty("configuration")]
                                 string configuration, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("document_content_type")]
                                 string documentContentType, 
                                 [JsonProperty("fallback_assignment_callback_url")]
                                 string fallbackAssignmentCallbackUrl, 
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The assignment_callback_url
         */
        public string GetAssignmentCallbackUrl() {
            return this.assignmentCallbackUrl;
        }
    
        /**
         * @return The configuration
         */
        public string GetConfiguration() {
            return this.configuration;
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
         * @return The document_content_type
         */
        public string GetDocumentContentType() {
            return this.documentContentType;
        }
    
        /**
         * @return The fallback_assignment_callback_url
         */
        public string GetFallbackAssignmentCallbackUrl() {
            return this.fallbackAssignmentCallbackUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_reservation_timeout
         */
        public int? GetTaskReservationTimeout() {
            return this.taskReservationTimeout;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}