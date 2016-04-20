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

    public class WorkerResource : SidResource {
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkerReader capable of executing the read
         */
        public static WorkerReader Read(string workspaceSid) {
            return new WorkerReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @return WorkerCreator capable of executing the create
         */
        public static WorkerCreator Create(string workspaceSid, string friendlyName) {
            return new WorkerCreator(workspaceSid, friendlyName);
        }
    
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerFetcher capable of executing the fetch
         */
        public static WorkerFetcher Fetch(string workspaceSid, string sid) {
            return new WorkerFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerUpdater capable of executing the update
         */
        public static WorkerUpdater Update(string workspaceSid, string sid) {
            return new WorkerUpdater(workspaceSid, sid);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return WorkerDeleter capable of executing the delete
         */
        public static WorkerDeleter Delete(string workspaceSid, string sid) {
            return new WorkerDeleter(workspaceSid, sid);
        }
    
        /**
         * Converts a JSON string into a WorkerResource object
         * 
         * @param json Raw JSON string
         * @return WorkerResource object represented by the provided JSON
         */
        public static WorkerResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("activity_name")]
        private readonly string activityName;
        [JsonProperty("activity_sid")]
        private readonly string activitySid;
        [JsonProperty("attributes")]
        private readonly string attributes;
        [JsonProperty("available")]
        private readonly bool? available;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_status_changed")]
        private readonly DateTime? dateStatusChanged;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public WorkerResource() {
        
        }
    
        private WorkerResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("activity_name")]
                               string activityName, 
                               [JsonProperty("activity_sid")]
                               string activitySid, 
                               [JsonProperty("attributes")]
                               string attributes, 
                               [JsonProperty("available")]
                               bool? available, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_status_changed")]
                               string dateStatusChanged, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("workspace_sid")]
                               string workspaceSid) {
            this.accountSid = accountSid;
            this.activityName = activityName;
            this.activitySid = activitySid;
            this.attributes = attributes;
            this.available = available;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateStatusChanged = MarshalConverter.DateTimeFromString(dateStatusChanged);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The activity_name
         */
        public string GetActivityName() {
            return this.activityName;
        }
    
        /**
         * @return The activity_sid
         */
        public string GetActivitySid() {
            return this.activitySid;
        }
    
        /**
         * @return The attributes
         */
        public string GetAttributes() {
            return this.attributes;
        }
    
        /**
         * @return The available
         */
        public bool? GetAvailable() {
            return this.available;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_status_changed
         */
        public DateTime? GetDateStatusChanged() {
            return this.dateStatusChanged;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
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
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}