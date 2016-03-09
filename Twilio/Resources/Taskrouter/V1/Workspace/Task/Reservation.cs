using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Task;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace.Task;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1.Workspace.Task;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Task {

    public class Reservation : SidResource {
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @return ReservationReader capable of executing the read
         */
        public static ReservationReader read(string workspaceSid, string taskSid) {
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
        public static ReservationFetcher fetch(string workspaceSid, string taskSid, string sid) {
            return new ReservationFetcher(workspaceSid, taskSid, sid);
        }
    
        /**
         * update
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         * @param reservationStatus The reservation_status
         * @return ReservationUpdater capable of executing the update
         */
        public static ReservationUpdater update(string workspaceSid, string taskSid, string sid, string reservationStatus) {
            return new ReservationUpdater(workspaceSid, taskSid, sid, reservationStatus);
        }
    
        /**
         * Converts a JSON string into a Reservation object
         * 
         * @param json Raw JSON string
         * @return Reservation object represented by the provided JSON
         */
        public static Reservation fromJson(string json) {
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
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("reservation_status")]
        private readonly string reservationStatus;
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
    
        private Reservation([JsonProperty("account_sid")]
                            string accountSid, 
                            [JsonProperty("date_created")]
                            string dateCreated, 
                            [JsonProperty("date_updated")]
                            string dateUpdated, 
                            [JsonProperty("reservation_status")]
                            string reservationStatus, 
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
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The reservation_status
         */
        public string GetReservationStatus() {
            return this.reservationStatus;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
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