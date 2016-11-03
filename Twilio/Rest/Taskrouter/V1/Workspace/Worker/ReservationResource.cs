using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class ReservationResource : Resource 
    {
        public sealed class Status : IStringEnum 
        {
            public const string Pending = "pending";
            public const string Accepted = "accepted";
            public const string Rejected = "rejected";
            public const string Timeout = "timeout";
            public const string Canceled = "canceled";
            public const string Rescinded = "rescinded";
        
            private string _value;
            
            public Status() {}
            
            public Status(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator Status(string value)
            {
                return new Status(value);
            }
            
            public static implicit operator string(Status value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <returns> ReservationReader capable of executing the read </returns> 
        public static ReservationReader Reader(string workspaceSid, string workerSid)
        {
            return new ReservationReader(workspaceSid, workerSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ReservationFetcher capable of executing the fetch </returns> 
        public static ReservationFetcher Fetcher(string workspaceSid, string workerSid, string sid)
        {
            return new ReservationFetcher(workspaceSid, workerSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ReservationUpdater capable of executing the update </returns> 
        public static ReservationUpdater Updater(string workspaceSid, string workerSid, string sid)
        {
            return new ReservationUpdater(workspaceSid, workerSid, sid);
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
        public string accountSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReservationResource.Status reservationStatus { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("task_sid")]
        public string taskSid { get; set; }
        [JsonProperty("worker_name")]
        public string workerName { get; set; }
        [JsonProperty("worker_sid")]
        public string workerSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; set; }
        [JsonProperty("url")]
        public Uri url { get; set; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; set; }
    
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
                                    ReservationResource.Status reservationStatus, 
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
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.reservationStatus = reservationStatus;
            this.sid = sid;
            this.taskSid = taskSid;
            this.workerName = workerName;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
            this.url = url;
            this.links = links;
        }
    }
}