using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkerResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkerReader capable of executing the read </returns> 
        public static WorkerReader Reader(string workspaceSid)
        {
            return new WorkerReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkerCreator capable of executing the create </returns> 
        public static WorkerCreator Creator(string workspaceSid, string friendlyName)
        {
            return new WorkerCreator(workspaceSid, friendlyName);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerFetcher capable of executing the fetch </returns> 
        public static WorkerFetcher Fetcher(string workspaceSid, string sid)
        {
            return new WorkerFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerUpdater capable of executing the update </returns> 
        public static WorkerUpdater Updater(string workspaceSid, string sid)
        {
            return new WorkerUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerDeleter capable of executing the delete </returns> 
        public static WorkerDeleter Deleter(string workspaceSid, string sid)
        {
            return new WorkerDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerResource object represented by the provided JSON </returns> 
        public static WorkerResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkerResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("activity_name")]
        public string ActivityName { get; set; }
        [JsonProperty("activity_sid")]
        public string ActivitySid { get; set; }
        [JsonProperty("attributes")]
        public string Attributes { get; set; }
        [JsonProperty("available")]
        public bool? Available { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_status_changed")]
        public DateTime? DateStatusChanged { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
        public WorkerResource()
        {
        
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
                               string workspaceSid, 
                               [JsonProperty("url")]
                               Uri url, 
                               [JsonProperty("links")]
                               Dictionary<string, string> links)
                               {
            AccountSid = accountSid;
            ActivityName = activityName;
            ActivitySid = activitySid;
            Attributes = attributes;
            Available = available;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateStatusChanged = MarshalConverter.DateTimeFromString(dateStatusChanged);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            Sid = sid;
            WorkspaceSid = workspaceSid;
            Url = url;
            Links = links;
        }
    }
}