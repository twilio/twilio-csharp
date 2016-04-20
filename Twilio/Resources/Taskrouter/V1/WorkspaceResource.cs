using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Taskrouter.V1;
using Twilio.Deleters.Taskrouter.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1;

namespace Twilio.Resources.Taskrouter.V1 {

    public class WorkspaceResource : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return WorkspaceFetcher capable of executing the fetch
         */
        public static WorkspaceFetcher Fetch(string sid) {
            return new WorkspaceFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return WorkspaceUpdater capable of executing the update
         */
        public static WorkspaceUpdater Update(string sid) {
            return new WorkspaceUpdater(sid);
        }
    
        /**
         * read
         * 
         * @return WorkspaceReader capable of executing the read
         */
        public static WorkspaceReader Read() {
            return new WorkspaceReader();
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @return WorkspaceCreator capable of executing the create
         */
        public static WorkspaceCreator Create(string friendlyName) {
            return new WorkspaceCreator(friendlyName);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return WorkspaceDeleter capable of executing the delete
         */
        public static WorkspaceDeleter Delete(string sid) {
            return new WorkspaceDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a WorkspaceResource object
         * 
         * @param json Raw JSON string
         * @return WorkspaceResource object represented by the provided JSON
         */
        public static WorkspaceResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkspaceResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("default_activity_name")]
        private readonly string defaultActivityName;
        [JsonProperty("default_activity_sid")]
        private readonly string defaultActivitySid;
        [JsonProperty("event_callback_url")]
        private readonly string eventCallbackUrl;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("timeout_activity_name")]
        private readonly string timeoutActivityName;
        [JsonProperty("timeout_activity_sid")]
        private readonly string timeoutActivitySid;
    
        public WorkspaceResource() {
        
        }
    
        private WorkspaceResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("default_activity_name")]
                                  string defaultActivityName, 
                                  [JsonProperty("default_activity_sid")]
                                  string defaultActivitySid, 
                                  [JsonProperty("event_callback_url")]
                                  string eventCallbackUrl, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("timeout_activity_name")]
                                  string timeoutActivityName, 
                                  [JsonProperty("timeout_activity_sid")]
                                  string timeoutActivitySid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.defaultActivityName = defaultActivityName;
            this.defaultActivitySid = defaultActivitySid;
            this.eventCallbackUrl = eventCallbackUrl;
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.timeoutActivityName = timeoutActivityName;
            this.timeoutActivitySid = timeoutActivitySid;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
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
         * @return The default_activity_name
         */
        public string GetDefaultActivityName() {
            return this.defaultActivityName;
        }
    
        /**
         * @return The default_activity_sid
         */
        public string GetDefaultActivitySid() {
            return this.defaultActivitySid;
        }
    
        /**
         * @return The event_callback_url
         */
        public string GetEventCallbackUrl() {
            return this.eventCallbackUrl;
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
         * @return The timeout_activity_name
         */
        public string GetTimeoutActivityName() {
            return this.timeoutActivityName;
        }
    
        /**
         * @return The timeout_activity_sid
         */
        public string GetTimeoutActivitySid() {
            return this.timeoutActivitySid;
        }
    }
}