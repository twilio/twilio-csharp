using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkflowResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkflowFetcher capable of executing the fetch </returns> 
        public static WorkflowFetcher Fetcher(string workspaceSid, string sid)
        {
            return new WorkflowFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkflowUpdater capable of executing the update </returns> 
        public static WorkflowUpdater Updater(string workspaceSid, string sid)
        {
            return new WorkflowUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkflowDeleter capable of executing the delete </returns> 
        public static WorkflowDeleter Deleter(string workspaceSid, string sid)
        {
            return new WorkflowDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkflowReader capable of executing the read </returns> 
        public static WorkflowReader Reader(string workspaceSid)
        {
            return new WorkflowReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="configuration"> The configuration </param>
        /// <returns> WorkflowCreator capable of executing the create </returns> 
        public static WorkflowCreator Creator(string workspaceSid, string friendlyName, string configuration)
        {
            return new WorkflowCreator(workspaceSid, friendlyName, configuration);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkflowResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowResource object represented by the provided JSON </returns> 
        public static WorkflowResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkflowResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("assignment_callback_url")]
        public Uri AssignmentCallbackUrl { get; set; }
        [JsonProperty("configuration")]
        public string Configuration { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("document_content_type")]
        public string DocumentContentType { get; set; }
        [JsonProperty("fallback_assignment_callback_url")]
        public Uri FallbackAssignmentCallbackUrl { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("task_reservation_timeout")]
        public int? TaskReservationTimeout { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
    
        public WorkflowResource()
        {
        
        }
    
        private WorkflowResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("assignment_callback_url")]
                                 Uri assignmentCallbackUrl, 
                                 [JsonProperty("configuration")]
                                 string configuration, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("document_content_type")]
                                 string documentContentType, 
                                 [JsonProperty("fallback_assignment_callback_url")]
                                 Uri fallbackAssignmentCallbackUrl, 
                                 [JsonProperty("friendly_name")]
                                 string friendlyName, 
                                 [JsonProperty("sid")]
                                 string sid, 
                                 [JsonProperty("task_reservation_timeout")]
                                 int? taskReservationTimeout, 
                                 [JsonProperty("workspace_sid")]
                                 string workspaceSid, 
                                 [JsonProperty("url")]
                                 Uri url)
                                 {
            AccountSid = accountSid;
            AssignmentCallbackUrl = assignmentCallbackUrl;
            Configuration = configuration;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            DocumentContentType = documentContentType;
            FallbackAssignmentCallbackUrl = fallbackAssignmentCallbackUrl;
            FriendlyName = friendlyName;
            Sid = sid;
            TaskReservationTimeout = taskReservationTimeout;
            WorkspaceSid = workspaceSid;
            Url = url;
        }
    }
}