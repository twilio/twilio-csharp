using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task {

    public class ReservationResource : SidResource {
        public sealed class Status : IStringEnum {
            public const string PENDING="pending";
            public const string ACCEPTED="accepted";
            public const string REJECTED="rejected";
            public const string TIMEOUT="timeout";
            public const string CANCELED="canceled";
            public const string RESCINDED="rescinded";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <returns> ReservationReader capable of executing the read </returns> 
        public static ReservationReader Reader(string workspaceSid, string taskSid) {
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
        public static ReservationFetcher Fetcher(string workspaceSid, string taskSid, string sid) {
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
        public static ReservationUpdater Updater(string workspaceSid, string taskSid, string sid) {
            return new ReservationUpdater(workspaceSid, taskSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a ReservationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ReservationResource object represented by the provided JSON </returns> 
        public static ReservationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ReservationResource>(json);
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
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly ReservationResource.Status reservationStatus;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("task_sid")]
        private readonly string taskSid;
        [JsonProperty("worker_name")]
        private readonly string workerName;
        [JsonProperty("worker_sid")]
        private readonly string workerSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public ReservationResource() {
        
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
                                    string workspaceSid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.reservationStatus = reservationStatus;
            this.sid = sid;
            this.taskSid = taskSid;
            this.workerName = workerName;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
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
    
        /// <returns> The reservation_status </returns> 
        public ReservationResource.Status GetReservationStatus() {
            return this.reservationStatus;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The task_sid </returns> 
        public string GetTaskSid() {
            return this.taskSid;
        }
    
        /// <returns> The worker_name </returns> 
        public string GetWorkerName() {
            return this.workerName;
        }
    
        /// <returns> The worker_sid </returns> 
        public string GetWorkerSid() {
            return this.workerSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}