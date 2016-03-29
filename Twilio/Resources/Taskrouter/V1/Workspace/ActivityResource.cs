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

    public class ActivityResource : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return ActivityFetcher capable of executing the fetch
         */
        public static ActivityFetcher fetch(string workspaceSid, string sid) {
            return new ActivityFetcher(workspaceSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @param friendlyName The friendly_name
         * @return ActivityUpdater capable of executing the update
         */
        public static ActivityUpdater update(string workspaceSid, string sid, string friendlyName) {
            return new ActivityUpdater(workspaceSid, sid, friendlyName);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return ActivityDeleter capable of executing the delete
         */
        public static ActivityDeleter delete(string workspaceSid, string sid) {
            return new ActivityDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return ActivityReader capable of executing the read
         */
        public static ActivityReader read(string workspaceSid) {
            return new ActivityReader(workspaceSid);
        }
    
        /**
         * create
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param available The available
         * @return ActivityCreator capable of executing the create
         */
        public static ActivityCreator create(string workspaceSid, string friendlyName, bool available) {
            return new ActivityCreator(workspaceSid, friendlyName, available);
        }
    
        /**
         * Converts a JSON string into a ActivityResource object
         * 
         * @param json Raw JSON string
         * @return ActivityResource object represented by the provided JSON
         */
        public static ActivityResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ActivityResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("available")]
        private readonly bool available;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        private ActivityResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("available")]
                                 bool available, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("friendly_name")]
                                 string friendlyName, 
                                 [JsonProperty("sid")]
                                 string sid, 
                                 [JsonProperty("workspace_sid")]
                                 string workspaceSid) {
            this.accountSid = accountSid;
            this.available = available;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
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
         * @return The available
         */
        public bool GetAvailable() {
            return this.available;
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