using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Taskrouter.V1;
using Twilio.Deleters.Taskrouter.V1;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Taskrouter.V1 {

    public class Workspace : SidResource {
        /**
         * fetch
         * 
         * @param sid The sid
         * @return WorkspaceFetcher capable of executing the fetch
         */
        public static WorkspaceFetcher fetch(String sid) {
            return new WorkspaceFetcher(sid);
        }
    
        /**
         * update
         * 
         * @param sid The sid
         * @return WorkspaceUpdater capable of executing the update
         */
        public static WorkspaceUpdater update(String sid) {
            return new WorkspaceUpdater(sid);
        }
    
        /**
         * read
         * 
         * @return WorkspaceReader capable of executing the read
         */
        public static WorkspaceReader read() {
            return new WorkspaceReader();
        }
    
        /**
         * create
         * 
         * @param friendlyName The friendly_name
         * @return WorkspaceCreator capable of executing the create
         */
        public static WorkspaceCreator create(String friendlyName) {
            return new WorkspaceCreator(friendlyName);
        }
    
        /**
         * delete
         * 
         * @param sid The sid
         * @return WorkspaceDeleter capable of executing the delete
         */
        public static WorkspaceDeleter delete(String sid) {
            return new WorkspaceDeleter(sid);
        }
    
        /**
         * Converts a JSON string into a Workspace object
         * 
         * @param json Raw JSON string
         * @return Workspace object represented by the provided JSON
         */
        public static Workspace fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Workspace>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("default_activity_name")]
        private readonly String defaultActivityName;
        [JsonProperty("default_activity_sid")]
        private readonly String defaultActivitySid;
        [JsonProperty("event_callback_url")]
        private readonly String eventCallbackUrl;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("timeout_activity_name")]
        private readonly String timeoutActivityName;
        [JsonProperty("timeout_activity_sid")]
        private readonly String timeoutActivitySid;
    
        private Workspace([JsonProperty("account_sid")]
                          String accountSid, 
                          [JsonProperty("date_created")]
                          String dateCreated, 
                          [JsonProperty("date_updated")]
                          String dateUpdated, 
                          [JsonProperty("default_activity_name")]
                          String defaultActivityName, 
                          [JsonProperty("default_activity_sid")]
                          String defaultActivitySid, 
                          [JsonProperty("event_callback_url")]
                          String eventCallbackUrl, 
                          [JsonProperty("friendly_name")]
                          String friendlyName, 
                          [JsonProperty("sid")]
                          String sid, 
                          [JsonProperty("timeout_activity_name")]
                          String timeoutActivityName, 
                          [JsonProperty("timeout_activity_sid")]
                          String timeoutActivitySid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
            return this.accountSid;
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
         * @return The default_activity_name
         */
        public String GetDefaultActivityName() {
            return this.defaultActivityName;
        }
    
        /**
         * @return The default_activity_sid
         */
        public String GetDefaultActivitySid() {
            return this.defaultActivitySid;
        }
    
        /**
         * @return The event_callback_url
         */
        public String GetEventCallbackUrl() {
            return this.eventCallbackUrl;
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
         * @return The timeout_activity_name
         */
        public String GetTimeoutActivityName() {
            return this.timeoutActivityName;
        }
    
        /**
         * @return The timeout_activity_sid
         */
        public String GetTimeoutActivitySid() {
            return this.timeoutActivitySid;
        }
    }
}