using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskChannelResource : SidResource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskChannelFetcher capable of executing the fetch </returns> 
        public static TaskChannelFetcher Fetcher(string workspaceSid, string sid) {
            return new TaskChannelFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskChannelReader capable of executing the read </returns> 
        public static TaskChannelReader Reader(string workspaceSid) {
            return new TaskChannelReader(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskChannelResource object represented by the provided JSON </returns> 
        public static TaskChannelResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TaskChannelResource>(json);
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
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("unique_name")]
        private readonly string uniqueName;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public TaskChannelResource() {
        
        }
    
        private TaskChannelResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("friendly_name")]
                                    string friendlyName, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("unique_name")]
                                    string uniqueName, 
                                    [JsonProperty("workspace_sid")]
                                    string workspaceSid, 
                                    [JsonProperty("url")]
                                    Uri url) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.uniqueName = uniqueName;
            this.workspaceSid = workspaceSid;
            this.url = url;
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
    
        /// <returns> The friendly_name </returns> 
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The unique_name </returns> 
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}