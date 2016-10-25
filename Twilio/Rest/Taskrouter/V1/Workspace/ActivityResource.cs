using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class ActivityResource : Resource {
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
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="available"> The available </param>
        /// <returns> ActivityReader capable of executing the read </returns> 
        public static ActivityReader Reader(string workspaceSid, string friendlyName=null, string available=null) {
            return new ActivityReader(workspaceSid, friendlyName:friendlyName, available:available);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="available"> The available </param>
        /// <returns> ActivityCreator capable of executing the create </returns> 
        public static ActivityCreator Creator(string workspaceSid, string friendlyName, bool? available=null) {
            return new ActivityCreator(workspaceSid, friendlyName, available:available);
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
        public string accountSid { get; }
        [JsonProperty("available")]
        public bool? available { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
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
                                 string workspaceSid, 
                                 [JsonProperty("url")]
                                 Uri url) {
            this.accountSid = accountSid;
            this.available = available;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.workspaceSid = workspaceSid;
            this.url = url;
        }
    }
}