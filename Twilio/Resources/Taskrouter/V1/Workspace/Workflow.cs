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

    public class Workflow : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowFetcher capable of executing the fetch
         */
        public static WorkflowFetcher fetch(String workspaceSid, String sid) {
            return new WorkflowFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowUpdater capable of executing the update
         */
        public static WorkflowUpdater update(String workspaceSid, String sid) {
            return new WorkflowUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkflowDeleter capable of executing the delete
         */
        public static WorkflowDeleter delete(String workspaceSid, String sid) {
            return new WorkflowDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkflowReader capable of executing the read
         */
        public static WorkflowReader read(String workspaceSid) {
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
        public static WorkflowCreator create(String workspaceSid, String friendlyName, String configuration, String assignmentCallbackUrl) {
            return new WorkflowCreator(workspaceSid, friendlyName, configuration, assignmentCallbackUrl);
        }
    
        /**
         * Converts a JSON string into a Workflow object
         * 
         * @param json Raw JSON string
         * @return Workflow object represented by the provided JSON
         */
        public static Workflow fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Workflow>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("assignment_callback_url")]
        private readonly String assignmentCallbackUrl;
        [JsonProperty("configuration")]
        private readonly String configuration;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("document_content_type")]
        private readonly String documentContentType;
        [JsonProperty("fallback_assignment_callback_url")]
        private readonly String fallbackAssignmentCallbackUrl;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("task_reservation_timeout")]
        private readonly Integer taskReservationTimeout;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private Workflow([JsonProperty("account_sid")]
                         String accountSid, 
                         [JsonProperty("assignment_callback_url")]
                         String assignmentCallbackUrl, 
                         [JsonProperty("configuration")]
                         String configuration, 
                         [JsonProperty("date_created")]
                         String dateCreated, 
                         [JsonProperty("date_updated")]
                         String dateUpdated, 
                         [JsonProperty("document_content_type")]
                         String documentContentType, 
                         [JsonProperty("fallback_assignment_callback_url")]
                         String fallbackAssignmentCallbackUrl, 
                         [JsonProperty("friendly_name")]
                         String friendlyName, 
                         [JsonProperty("sid")]
                         String sid, 
                         [JsonProperty("task_reservation_timeout")]
                         Integer taskReservationTimeout, 
                         [JsonProperty("workspace_sid")]
                         String workspaceSid) {
            this.accountSid = accountSid;
            this.assignmentCallbackUrl = assignmentCallbackUrl;
            this.configuration = configuration;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The assignment_callback_url
         */
        public String GetAssignmentCallbackUrl() {
            return this.assignmentCallbackUrl;
        }
    
        /**
         * @return The configuration
         */
        public String GetConfiguration() {
            return this.configuration;
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
         * @return The document_content_type
         */
        public String GetDocumentContentType() {
            return this.documentContentType;
        }
    
        /**
         * @return The fallback_assignment_callback_url
         */
        public String GetFallbackAssignmentCallbackUrl() {
            return this.fallbackAssignmentCallbackUrl;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_reservation_timeout
         */
        public Integer GetTaskReservationTimeout() {
            return this.taskReservationTimeout;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}