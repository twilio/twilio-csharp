using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1 {

    public class WorkspaceResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceFetcher capable of executing the fetch </returns> 
        public static WorkspaceFetcher Fetcher(string sid) {
            return new WorkspaceFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceUpdater capable of executing the update </returns> 
        public static WorkspaceUpdater Updater(string sid) {
            return new WorkspaceUpdater(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> WorkspaceReader capable of executing the read </returns> 
        public static WorkspaceReader Reader() {
            return new WorkspaceReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkspaceCreator capable of executing the create </returns> 
        public static WorkspaceCreator Creator(string friendlyName) {
            return new WorkspaceCreator(friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceDeleter capable of executing the delete </returns> 
        public static WorkspaceDeleter Deleter(string sid) {
            return new WorkspaceDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkspaceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkspaceResource object represented by the provided JSON </returns> 
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
        private readonly Uri eventCallbackUrl;
        [JsonProperty("events_filter")]
        private readonly string eventsFilter;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("multi_task_enabled")]
        private readonly bool? multiTaskEnabled;
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
                                  Uri eventCallbackUrl, 
                                  [JsonProperty("events_filter")]
                                  string eventsFilter, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("multi_task_enabled")]
                                  bool? multiTaskEnabled, 
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
            this.eventsFilter = eventsFilter;
            this.friendlyName = friendlyName;
            this.multiTaskEnabled = multiTaskEnabled;
            this.sid = sid;
            this.timeoutActivityName = timeoutActivityName;
            this.timeoutActivitySid = timeoutActivitySid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The default_activity_name </returns> 
        public string GetDefaultActivityName() {
            return this.defaultActivityName;
        }
    
        /// <returns> The default_activity_sid </returns> 
        public string GetDefaultActivitySid() {
            return this.defaultActivitySid;
        }
    
        /// <returns> The event_callback_url </returns> 
        public Uri GetEventCallbackUrl() {
            return this.eventCallbackUrl;
        }
    
        /// <returns> The events_filter </returns> 
        public string GetEventsFilter() {
            return this.eventsFilter;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The multi_task_enabled </returns> 
        public bool? GetMultiTaskEnabled() {
            return this.multiTaskEnabled;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The timeout_activity_name </returns> 
        public string GetTimeoutActivityName() {
            return this.timeoutActivityName;
        }
    
        /// <returns> The timeout_activity_sid </returns> 
        public string GetTimeoutActivitySid() {
            return this.timeoutActivitySid;
        }
    }
}