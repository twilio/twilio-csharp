using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

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
        public string AccountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("default_activity_name")]
        public string DefaultActivityName { get; set; }
        [JsonProperty("default_activity_sid")]
        public string DefaultActivitySid { get; set; }
        [JsonProperty("event_callback_url")]
        public Uri EventCallbackUrl { get; set; }
        [JsonProperty("events_filter")]
        public string EventsFilter { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("multi_task_enabled")]
        public bool? MultiTaskEnabled { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("timeout_activity_name")]
        public string TimeoutActivityName { get; set; }
        [JsonProperty("timeout_activity_sid")]
        public string TimeoutActivitySid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
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
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            DefaultActivityName = defaultActivityName;
            DefaultActivitySid = defaultActivitySid;
            EventCallbackUrl = eventCallbackUrl;
            EventsFilter = eventsFilter;
            FriendlyName = friendlyName;
            MultiTaskEnabled = multiTaskEnabled;
            Sid = sid;
            TimeoutActivityName = timeoutActivityName;
            TimeoutActivitySid = timeoutActivitySid;
            Url = url;
            Links = links;
        }
    }
}