using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Task;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace.Task;
using Twilio.Updaters.Taskrouter.V1.Workspace.Task;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task {

    public class Reservation : SidResource {
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
    
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @return ReservationReader capable of executing the read
         */
        public static ReservationReader Read(string workspaceSid, string taskSid) {
            return new ReservationReader(workspaceSid, taskSid);
        }
    
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         * @return ReservationFetcher capable of executing the fetch
         */
        public static ReservationFetcher Fetch(string workspaceSid, string taskSid, string sid) {
            return new ReservationFetcher(workspaceSid, taskSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         * @return ReservationUpdater capable of executing the update
         */
        public static ReservationUpdater Update(string workspaceSid, string taskSid, string sid) {
            return new ReservationUpdater(workspaceSid, taskSid, sid);
        }
    
        /**
         * Converts a JSON string into a Reservation object
         * 
         * @param json Raw JSON string
         * @return Reservation object represented by the provided JSON
         */
        public static Reservation FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Reservation>(json);
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
        private readonly Reservation.Status reservationStatus;
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
    
        public Reservation() {
        
        }
    
        private Reservation([JsonProperty("account_sid")]
                            string accountSid, 
                            [JsonProperty("date_created")]
                            string dateCreated, 
                            [JsonProperty("date_updated")]
                            string dateUpdated, 
                            [JsonProperty("reservation_status")]
                            Reservation.Status reservationStatus, 
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
         * @return The reservation_status
         */
        public Reservation.Status GetReservationStatus() {
            return this.reservationStatus;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_sid
         */
        public string GetTaskSid() {
            return this.taskSid;
        }
    
        /**
         * @return The worker_name
         */
        public string GetWorkerName() {
            return this.workerName;
        }
    
        /**
         * @return The worker_sid
         */
        public string GetWorkerSid() {
            return this.workerSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}