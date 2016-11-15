using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Types;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task 
{

    public class ReservationResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Pending = new StatusEnum("pending");
            public static readonly StatusEnum Accepted = new StatusEnum("accepted");
            public static readonly StatusEnum Rejected = new StatusEnum("rejected");
            public static readonly StatusEnum Timeout = new StatusEnum("timeout");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
            public static readonly StatusEnum Rescinded = new StatusEnum("rescinded");
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <returns> ReservationReader capable of executing the read </returns> 
        public static ReservationReader Reader(string workspaceSid, string taskSid)
        {
            return new ReservationReader(workspaceSid, taskSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ReservationFetcher capable of executing the fetch </returns> 
        public static ReservationFetcher Fetcher(string workspaceSid, string taskSid, string sid)
        {
            return new ReservationFetcher(workspaceSid, taskSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ReservationUpdater capable of executing the update </returns> 
        public static ReservationUpdater Updater(string workspaceSid, string taskSid, string sid)
        {
            return new ReservationUpdater(workspaceSid, taskSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ReservationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ReservationResource object represented by the provided JSON </returns> 
        public static ReservationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ReservationResource>(json);
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
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReservationResource.StatusEnum ReservationStatus { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("task_sid")]
        public string TaskSid { get; set; }
        [JsonProperty("worker_name")]
        public string WorkerName { get; set; }
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri Url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; set; }
    
        public ReservationResource()
        {
        
        }
    
        private ReservationResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("reservation_status")]
                                    ReservationResource.StatusEnum reservationStatus, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("task_sid")]
                                    string taskSid, 
                                    [JsonProperty("worker_name")]
                                    string workerName, 
                                    [JsonProperty("worker_sid")]
                                    string workerSid, 
                                    [JsonProperty("workspace_sid")]
                                    string workspaceSid, 
                                    [JsonProperty("url")]
                                    Uri url, 
                                    [JsonProperty("links")]
                                    Dictionary<string, string> links)
                                    {
            AccountSid = accountSid;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            ReservationStatus = reservationStatus;
            Sid = sid;
            TaskSid = taskSid;
            WorkerName = workerName;
            WorkerSid = workerSid;
            WorkspaceSid = workspaceSid;
            Url = url;
            Links = links;
        }
    }
}