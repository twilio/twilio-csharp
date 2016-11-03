using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1 
{

    public class WorkspaceResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceFetcher capable of executing the fetch </returns> 
        public static WorkspaceFetcher Fetcher(string sid)
        {
            return new WorkspaceFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceUpdater capable of executing the update </returns> 
        public static WorkspaceUpdater Updater(string sid)
        {
            return new WorkspaceUpdater(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> WorkspaceReader capable of executing the read </returns> 
        public static WorkspaceReader Reader()
        {
            return new WorkspaceReader();
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkspaceCreator capable of executing the create </returns> 
        public static WorkspaceCreator Creator(string friendlyName)
        {
            return new WorkspaceCreator(friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> WorkspaceDeleter capable of executing the delete </returns> 
        public static WorkspaceDeleter Deleter(string sid)
        {
            return new WorkspaceDeleter(sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkspaceResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkspaceResource object represented by the provided JSON </returns> 
        public static WorkspaceResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkspaceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("default_activity_name")]
        public string defaultActivityName { get; set; }
        [JsonProperty("default_activity_sid")]
        public string defaultActivitySid { get; set; }
        [JsonProperty("event_callback_url")]
        public Uri eventCallbackUrl { get; set; }
        [JsonProperty("events_filter")]
        public string eventsFilter { get; set; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; set; }
        [JsonProperty("multi_task_enabled")]
        public bool? multiTaskEnabled { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("timeout_activity_name")]
        public string timeoutActivityName { get; set; }
        [JsonProperty("timeout_activity_sid")]
        public string timeoutActivitySid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
    
        public WorkspaceResource()
        {
        
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
                                  string timeoutActivitySid, 
                                  [JsonProperty("url")]
                                  Uri url, 
                                  [JsonProperty("links")]
                                  Dictionary<string, string> links)
                                  {
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
            this.url = url;
            this.links = links;
        }
    }
}