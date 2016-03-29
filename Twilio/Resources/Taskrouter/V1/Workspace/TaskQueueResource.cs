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

    public class TaskQueueResource : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueFetcher capable of executing the fetch
         */
        public static TaskQueueFetcher fetch(string workspaceSid, string sid) {
            return new TaskQueueFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueUpdater capable of executing the update
         */
        public static TaskQueueUpdater update(string workspaceSid, string sid) {
            return new TaskQueueUpdater(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskQueueReader capable of executing the read
         */
        public static TaskQueueReader read(string workspaceSid) {
            return new TaskQueueReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param reservationActivitySid The reservation_activity_sid
         * @param assignmentActivitySid The assignment_activity_sid
         * @return TaskQueueCreator capable of executing the create
         */
        public static TaskQueueCreator create(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid) {
            return new TaskQueueCreator(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueDeleter capable of executing the delete
         */
        public static TaskQueueDeleter delete(string workspaceSid, string sid) {
            return new TaskQueueDeleter(workspaceSid, sid);
        }
    
        /**
         * Converts a JSON string into a TaskQueueResource object
         * 
         * @param json Raw JSON string
         * @return TaskQueueResource object represented by the provided JSON
         */
        public static TaskQueueResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueueResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("assignment_activity_sid")]
        private readonly string assignmentActivitySid;
        [JsonProperty("assignment_activity_name")]
        private readonly string assignmentActivityName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("max_reserved_workers")]
        private readonly int maxReservedWorkers;
        [JsonProperty("reservation_activity_sid")]
        private readonly string reservationActivitySid;
        [JsonProperty("reservation_activity_name")]
        private readonly string reservationActivityName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("target_workers")]
        private readonly string targetWorkers;
        [JsonProperty("url")]
        private readonly Uri url;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        private TaskQueueResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("assignment_activity_sid")]
                                  string assignmentActivitySid, 
                                  [JsonProperty("assignment_activity_name")]
                                  string assignmentActivityName, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("max_reserved_workers")]
                                  int maxReservedWorkers, 
                                  [JsonProperty("reservation_activity_sid")]
                                  string reservationActivitySid, 
                                  [JsonProperty("reservation_activity_name")]
                                  string reservationActivityName, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("target_workers")]
                                  string targetWorkers, 
                                  [JsonProperty("url")]
                                  Uri url, 
                                  [JsonProperty("workspace_sid")]
                                  string workspaceSid) {
            this.accountSid = accountSid;
            this.assignmentActivitySid = assignmentActivitySid;
            this.assignmentActivityName = assignmentActivityName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.maxReservedWorkers = maxReservedWorkers;
            this.reservationActivitySid = reservationActivitySid;
            this.reservationActivityName = reservationActivityName;
            this.sid = sid;
            this.targetWorkers = targetWorkers;
            this.url = url;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The assignment_activity_sid
         */
        public string GetAssignmentActivitySid() {
            return this.assignmentActivitySid;
        }
    
        /**
         * @return The assignment_activity_name
         */
        public string GetAssignmentActivityName() {
            return this.assignmentActivityName;
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
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The max_reserved_workers
         */
        public int GetMaxReservedWorkers() {
            return this.maxReservedWorkers;
        }
    
        /**
         * @return The reservation_activity_sid
         */
        public string GetReservationActivitySid() {
            return this.reservationActivitySid;
        }
    
        /**
         * @return The reservation_activity_name
         */
        public string GetReservationActivityName() {
            return this.reservationActivityName;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The target_workers
         */
        public string GetTargetWorkers() {
            return this.targetWorkers;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}