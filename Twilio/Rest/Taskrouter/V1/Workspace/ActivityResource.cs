using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class ActivityResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ActivityFetcher capable of executing the fetch </returns> 
        public static ActivityFetcher Fetcher(string workspaceSid, string sid) {
            return new ActivityFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> ActivityUpdater capable of executing the update </returns> 
        public static ActivityUpdater Updater(string workspaceSid, string sid, string friendlyName) {
            return new ActivityUpdater(workspaceSid, sid, friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ActivityDeleter capable of executing the delete </returns> 
        public static ActivityDeleter Deleter(string workspaceSid, string sid) {
            return new ActivityDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> ActivityReader capable of executing the read </returns> 
        public static ActivityReader Reader(string workspaceSid) {
            return new ActivityReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> ActivityCreator capable of executing the create </returns> 
        public static ActivityCreator Creator(string workspaceSid, string friendlyName) {
            return new ActivityCreator(workspaceSid, friendlyName);
        }
    
        /// <summary>
        /// Converts a JSON string into a ActivityResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ActivityResource object represented by the provided JSON </returns> 
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
        private readonly bool? available;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public ActivityResource() {
        
        }
    
        private ActivityResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("available")]
                                 bool? available, 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The available </returns> 
        public bool? GetAvailable() {
            return this.available;
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