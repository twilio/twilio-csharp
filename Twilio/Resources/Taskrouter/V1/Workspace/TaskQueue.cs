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
using java.net.URI;
using org.joda.time.DateTime;

namespace Twilio.Resources.Taskrouter.V1.Workspace {

    public class TaskQueue : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueFetcher capable of executing the fetch
         */
        public static TaskQueueFetcher fetch(String workspaceSid, String sid) {
            return new TaskQueueFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueUpdater capable of executing the update
         */
        public static TaskQueueUpdater update(String workspaceSid, String sid) {
            return new TaskQueueUpdater(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskQueueReader capable of executing the read
         */
        public static TaskQueueReader read(String workspaceSid) {
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
        public static TaskQueueCreator create(String workspaceSid, String friendlyName, String reservationActivitySid, String assignmentActivitySid) {
            return new TaskQueueCreator(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskQueueDeleter capable of executing the delete
         */
        public static TaskQueueDeleter delete(String workspaceSid, String sid) {
            return new TaskQueueDeleter(workspaceSid, sid);
        }
    
        /**
         * Converts a JSON string into a TaskQueue object
         * 
         * @param json Raw JSON string
         * @return TaskQueue object represented by the provided JSON
         */
        public static TaskQueue fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskQueue>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("assignment_activity_sid")]
        private readonly String assignmentActivitySid;
        [JsonProperty("assignment_activity_name")]
        private readonly String assignmentActivityName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("max_reserved_workers")]
        private readonly Integer maxReservedWorkers;
        [JsonProperty("reservation_activity_sid")]
        private readonly String reservationActivitySid;
        [JsonProperty("reservation_activity_name")]
        private readonly String reservationActivityName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("target_workers")]
        private readonly String targetWorkers;
        [JsonProperty("url")]
        private readonly URI url;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private TaskQueue([JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("assignment_activity_sid")]
                          String assignmentActivitySid, 
                          [JsonProperty("assignment_activity_name")]
                          String assignmentActivityName, 
                          [JsonProperty("date_created")]
                          String dateCreated, 
                          [JsonProperty("date_updated")]
                          String dateUpdated, 
                          [JsonProperty("friendly_name")]
                          String friendlyName, 
                          [JsonProperty("max_reserved_workers")]
                          Integer maxReservedWorkers, 
                          [JsonProperty("reservation_activity_sid")]
                          String reservationActivitySid, 
                          [JsonProperty("reservation_activity_name")]
                          String reservationActivityName, 
                          [JsonProperty("sid")]
                          String sid, 
                          [JsonProperty("target_workers")]
                          String targetWorkers, 
                          [JsonProperty("url")]
                          URI url, 
                          [JsonProperty("workspace_sid")]
                          String workspaceSid) {
            this.accountSid = accountSid;
            this.assignmentActivitySid = assignmentActivitySid;
            this.assignmentActivityName = assignmentActivityName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The assignment_activity_sid
         */
        public String GetAssignmentActivitySid() {
            return this.assignmentActivitySid;
        }
    
        /**
         * @return The assignment_activity_name
         */
        public String GetAssignmentActivityName() {
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
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The max_reserved_workers
         */
        public Integer GetMaxReservedWorkers() {
            return this.maxReservedWorkers;
        }
    
        /**
         * @return The reservation_activity_sid
         */
        public String GetReservationActivitySid() {
            return this.reservationActivitySid;
        }
    
        /**
         * @return The reservation_activity_name
         */
        public String GetReservationActivityName() {
            return this.reservationActivityName;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The target_workers
         */
        public String GetTargetWorkers() {
            return this.targetWorkers;
        }
    
        /**
         * @return The url
         */
        public URI GetUrl() {
            return this.url;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}