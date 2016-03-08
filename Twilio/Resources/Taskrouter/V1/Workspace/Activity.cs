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

    public class Activity : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return ActivityFetcher capable of executing the fetch
         */
        public static ActivityFetcher fetch(String workspaceSid, String sid) {
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
        public static ActivityUpdater update(String workspaceSid, String sid, String friendlyName) {
            return new ActivityUpdater(workspaceSid, sid, friendlyName);
        }
    
        /**
         * delete
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return ActivityDeleter capable of executing the delete
         */
        public static ActivityDeleter delete(String workspaceSid, String sid) {
            return new ActivityDeleter(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return ActivityReader capable of executing the read
         */
        public static ActivityReader read(String workspaceSid) {
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
        public static ActivityCreator create(String workspaceSid, String friendlyName, Boolean available) {
            return new ActivityCreator(workspaceSid, friendlyName, available);
        }
    
        /**
         * Converts a JSON string into a Activity object
         * 
         * @param json Raw JSON string
         * @return Activity object represented by the provided JSON
         */
        public static Activity fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Activity>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("available")]
        private readonly Boolean available;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private Activity([JsonProperty("account_sid")]
                         String accountSid, 
                         [JsonProperty("available")]
                         Boolean available, 
                         [JsonProperty("date_created")]
                         String dateCreated, 
                         [JsonProperty("date_updated")]
                         String dateUpdated, 
                         [JsonProperty("friendly_name")]
                         String friendlyName, 
                         [JsonProperty("sid")]
                         String sid, 
                         [JsonProperty("workspace_sid")]
                         String workspaceSid) {
            this.accountSid = accountSid;
            this.available = available;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
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