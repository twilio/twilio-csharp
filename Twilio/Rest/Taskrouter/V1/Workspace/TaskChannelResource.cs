using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskChannelResource : SidResource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         * @return TaskChannelFetcher capable of executing the fetch
         */
        public static TaskChannelFetcher Fetcher(string workspaceSid, string sid) {
            return new TaskChannelFetcher(workspaceSid, sid);
        }
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @return TaskChannelReader capable of executing the read
         */
        public static TaskChannelReader Reader(string workspaceSid) {
            return new TaskChannelReader(workspaceSid);
        }
    
        /**
         * Converts a JSON string into a TaskChannelResource object
         * 
         * @param json Raw JSON string
         * @return TaskChannelResource object represented by the provided JSON
         */
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
         * @return The unique_name
         */
        public string GetUniqueName() {
            return this.uniqueName;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    
        /**
         * @return The url
         */
        public Uri GetUrl() {
            return this.url;
        }
    }
}