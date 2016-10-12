using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkerResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkerReader capable of executing the read </returns> 
        public static WorkerReader Reader(string workspaceSid) {
            return new WorkerReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkerCreator capable of executing the create </returns> 
        public static WorkerCreator Creator(string workspaceSid, string friendlyName) {
            return new WorkerCreator(workspaceSid, friendlyName);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerFetcher capable of executing the fetch </returns> 
        public static WorkerFetcher Fetcher(string workspaceSid, string sid) {
            return new WorkerFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerUpdater capable of executing the update </returns> 
        public static WorkerUpdater Updater(string workspaceSid, string sid) {
            return new WorkerUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerDeleter capable of executing the delete </returns> 
        public static WorkerDeleter Deleter(string workspaceSid, string sid) {
            return new WorkerDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The activity_name </returns> 
        public string GetActivityName() {
            return this.activityName;
        }
    
        /// <returns> The activity_sid </returns> 
        public string GetActivitySid() {
            return this.activitySid;
        }
    
        /// <returns> The attributes </returns> 
        public string GetAttributes() {
            return this.attributes;
        }
    
        /// <returns> The available </returns> 
        public bool? GetAvailable() {
            return this.available;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_status_changed </returns> 
        public DateTime? GetDateStatusChanged() {
            return this.dateStatusChanged;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}