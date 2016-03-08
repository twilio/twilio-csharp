using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Task;
using Twilio.Http;
using Twilio.Readers.Taskrouter.V1.Workspace.Task;
using Twilio.Resources;
using Twilio.Updaters.Taskrouter.V1.Workspace.Task;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Task {

    public class Reservation : SidResource {
        /**
         * read
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @return ReservationReader capable of executing the read
         */
        public static ReservationReader read(String workspaceSid, String taskSid) {
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
        public static ReservationFetcher fetch(String workspaceSid, String taskSid, String sid) {
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
        public static ReservationUpdater update(String workspaceSid, String taskSid, String sid, String reservationStatus) {
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
        private readonly String accountSid;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("reservation_status")]
        private readonly String reservationStatus;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("task_sid")]
        private readonly String taskSid;
        [JsonProperty("worker_name")]
        private readonly String workerName;
        [JsonProperty("worker_sid")]
        private readonly String workerSid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private Reservation([JsonProperty("account_sid")]
                            String accountSid, 
                            [JsonProperty("date_created")]
                            String dateCreated, 
                            [JsonProperty("date_updated")]
                            String dateUpdated, 
                            [JsonProperty("reservation_status")]
                            String reservationStatus, 
                            [JsonProperty("sid")]
                            String sid, 
                            [JsonProperty("task_sid")]
                            String taskSid, 
                            [JsonProperty("worker_name")]
                            String workerName, 
                            [JsonProperty("worker_sid")]
                            String workerSid, 
                            [JsonProperty("workspace_sid")]
                            String workspaceSid) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
        public String GetAccountSid() {
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
        public String GetReservationStatus() {
            return this.reservationStatus;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The task_sid
         */
        public String GetTaskSid() {
            return this.taskSid;
        }
    
        /**
         * @return The worker_name
         */
        public String GetWorkerName() {
            return this.workerName;
        }
    
        /**
         * @return The worker_sid
         */
        public String GetWorkerSid() {
            return this.workerSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}