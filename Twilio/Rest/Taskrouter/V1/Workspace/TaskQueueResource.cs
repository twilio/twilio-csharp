using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskQueueResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueFetcher capable of executing the fetch </returns> 
        public static TaskQueueFetcher Fetcher(string workspaceSid, string sid)
        {
            return new TaskQueueFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueUpdater capable of executing the update </returns> 
        public static TaskQueueUpdater Updater(string workspaceSid, string sid)
        {
            return new TaskQueueUpdater(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskQueueReader capable of executing the read </returns> 
        public static TaskQueueReader Reader(string workspaceSid)
        {
            return new TaskQueueReader(workspaceSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="reservationActivitySid"> The reservation_activity_sid </param>
        /// <param name="assignmentActivitySid"> The assignment_activity_sid </param>
        /// <returns> TaskQueueCreator capable of executing the create </returns> 
        public static TaskQueueCreator Creator(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid)
        {
            return new TaskQueueCreator(workspaceSid, friendlyName, reservationActivitySid, assignmentActivitySid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> TaskQueueDeleter capable of executing the delete </returns> 
        public static TaskQueueDeleter Deleter(string workspaceSid, string sid)
        {
            return new TaskQueueDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueResource object represented by the provided JSON </returns> 
        public static TaskQueueResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskQueueResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("assignment_activity_sid")]
        public string AssignmentActivitySid { get; set; }
        [JsonProperty("assignment_activity_name")]
        public string AssignmentActivityName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("max_reserved_workers")]
        public int? MaxReservedWorkers { get; set; }
        [JsonProperty("reservation_activity_sid")]
        public string ReservationActivitySid { get; set; }
        [JsonProperty("reservation_activity_name")]
        public string ReservationActivityName { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("target_workers")]
        public string TargetWorkers { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
        public TaskQueueResource()
        {
        
        }
    
        private TaskQueueResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("assignment_activity_sid")]
                                  string assignmentActivitySid, 
                                  [JsonProperty("assignment_activity_name")]
                                  string assignmentActivityName, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("friendly_name")]
                                  string friendlyName, 
                                  [JsonProperty("max_reserved_workers")]
                                  int? maxReservedWorkers, 
                                  [JsonProperty("reservation_activity_sid")]
                                  string reservationActivitySid, 
                                  [JsonProperty("reservation_activity_name")]
                                  string reservationActivityName, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("target_workers")]
                                  string targetWorkers, 
                                  [JsonProperty("url")]
                                  Uri url, 
                                  [JsonProperty("workspace_sid")]
                                  string workspaceSid, 
                                  [JsonProperty("links")]
                                  Dictionary<string, string> links)
                                  {
            AccountSid = accountSid;
            AssignmentActivitySid = assignmentActivitySid;
            AssignmentActivityName = assignmentActivityName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            MaxReservedWorkers = maxReservedWorkers;
            ReservationActivitySid = reservationActivitySid;
            ReservationActivityName = reservationActivityName;
            Sid = sid;
            TargetWorkers = targetWorkers;
            Url = url;
            WorkspaceSid = workspaceSid;
            Links = links;
        }
    }
}