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

    public class Worker : SidResource {
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkerReader capable of executing the read
         */
        public static WorkerReader read(String workspaceSid) {
            return new WorkerReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @return WorkerCreator capable of executing the create
         */
        public static WorkerCreator create(String workspaceSid, String friendlyName) {
            return new WorkerCreator(workspaceSid, friendlyName);
        }
    
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerFetcher capable of executing the fetch
         */
        public static WorkerFetcher fetch(String workspaceSid, String sid) {
            return new WorkerFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerUpdater capable of executing the update
         */
        public static WorkerUpdater update(String workspaceSid, String sid) {
            return new WorkerUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerDeleter capable of executing the delete
         */
        public static WorkerDeleter delete(String workspaceSid, String sid) {
            return new WorkerDeleter(workspaceSid, sid);
        }
    
        /**
         * Converts a JSON string into a Worker object
         * 
         * @param json Raw JSON string
         * @return Worker object represented by the provided JSON
         */
        public static Worker fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Worker>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("activity_name")]
        private readonly String activityName;
        [JsonProperty("activity_sid")]
        private readonly String activitySid;
        [JsonProperty("attributes")]
        private readonly String attributes;
        [JsonProperty("available")]
        private readonly Boolean available;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_status_changed")]
        private readonly DateTime dateStatusChanged;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private Worker([JsonProperty("account_sid")]
                       String accountSid, 
                       [JsonProperty("activity_name")]
                       String activityName, 
                       [JsonProperty("activity_sid")]
                       String activitySid, 
                       [JsonProperty("attributes")]
                       String attributes, 
                       [JsonProperty("available")]
                       Boolean available, 
                       [JsonProperty("date_created")]
                       String dateCreated, 
                       [JsonProperty("date_status_changed")]
                       String dateStatusChanged, 
                       [JsonProperty("date_updated")]
                       String dateUpdated, 
                       [JsonProperty("friendly_name")]
                       String friendlyName, 
                       [JsonProperty("sid")]
                       String sid, 
                       [JsonProperty("workspace_sid")]
                       String workspaceSid) {
            this.accountSid = accountSid;
            this.activityName = activityName;
            this.activitySid = activitySid;
            this.attributes = attributes;
            this.available = available;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateStatusChanged = MarshalConverter.dateTimeFromString(dateStatusChanged);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The activity_name
         */
        public String GetActivityName() {
            return this.activityName;
        }
    
        /**
         * @return The activity_sid
         */
        public String GetActivitySid() {
            return this.activitySid;
        }
    
        /**
         * @return The attributes
         */
        public String GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The available
         */
        public Boolean GetAvailable() {
            return this.available;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_status_changed
         */
        public DateTime GetDateStatusChanged() {
            return this.dateStatusChanged;
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
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}