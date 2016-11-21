using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskChannelResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskChannelFetcher capable of executing the fetch </returns> 
        public static TaskChannelFetcher Fetcher(string workspaceSid, string sid)
        {
            return new TaskChannelFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskChannelReader capable of executing the read </returns> 
        public static TaskChannelReader Reader(string workspaceSid)
        {
            return new TaskChannelReader(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskChannelResource object represented by the provided JSON </returns> 
        public static TaskChannelResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskChannelResource>(json);
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
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public TaskChannelResource()
        {
        
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
                                    Uri url)
                                    {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            Sid = sid;
            UniqueName = uniqueName;
            WorkspaceSid = workspaceSid;
            Url = url;
        }
    }
}