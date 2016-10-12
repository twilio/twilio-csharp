using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskQueueResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueFetcher capable of executing the fetch </returns> 
        public static TaskQueueFetcher Fetcher(string workspaceSid, string sid) {
            return new TaskQueueFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueUpdater capable of executing the update </returns> 
        public static TaskQueueUpdater Updater(string workspaceSid, string sid) {
            return new TaskQueueUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskQueueReader capable of executing the read </returns> 
        public static TaskQueueReader Reader(string workspaceSid) {
            return new TaskQueueReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="reservationActivitySid"> The reservation_activity_sid </param>
        /// <param name="assignmentActivitySid"> The assignment_activity_sid </param>
        /// <returns> TaskQueueCreator capable of executing the create </returns> 
        public static TaskQueueCreator Creator(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid) {
            return new TaskQueueCreator(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueDeleter capable of executing the delete </returns> 
        public static TaskQueueDeleter Deleter(string workspaceSid, string sid) {
            return new TaskQueueDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueResource object represented by the provided JSON </returns> 
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
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("max_reserved_workers")]
        private readonly int? maxReservedWorkers;
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
    
        public TaskQueueResource() {
        
        }
    
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
                                  int? maxReservedWorkers, 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The assignment_activity_sid </returns> 
        public string GetAssignmentActivitySid() {
            return this.assignmentActivitySid;
        }
    
        /// <returns> The assignment_activity_name </returns> 
        public string GetAssignmentActivityName() {
            return this.assignmentActivityName;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The max_reserved_workers </returns> 
        public int? GetMaxReservedWorkers() {
            return this.maxReservedWorkers;
        }
    
        /// <returns> The reservation_activity_sid </returns> 
        public string GetReservationActivitySid() {
            return this.reservationActivitySid;
        }
    
        /// <returns> The reservation_activity_name </returns> 
        public string GetReservationActivityName() {
            return this.reservationActivityName;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The target_workers </returns> 
        public string GetTargetWorkers() {
            return this.targetWorkers;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}