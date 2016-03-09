using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.task.Reservation;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Taskrouter.V1.Workspace.Task {

    public class ReservationUpdater : Updater<Reservation> {
        private string workspaceSid;
        private string taskSid;
        private string sid;
        private string reservationStatus;
        private string workerActivitySid;
    
        /**
         * Construct a new ReservationUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         * @param reservationStatus The reservation_status
         */
        public ReservationUpdater(string workspaceSid, string taskSid, string sid, string reservationStatus) {
            this.workspaceSid = workspaceSid;
            this.taskSid = taskSid;
            this.sid = sid;
            this.reservationStatus = reservationStatus;
        }
    
        /**
         * The worker_activity_sid
         * 
         * @param workerActivitySid The worker_activity_sid
         * @return this
         */
        public ReservationUpdater setWorkerActivitySid(string workerActivitySid) {
            this.workerActivitySid = workerActivitySid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Reservation
         */
        [Override]
        public Reservation execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Reservation update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Reservation.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (reservationStatus != null) {
                request.addPostParam("ReservationStatus", reservationStatus);
            }
            
            if (workerActivitySid != null) {
                request.addPostParam("WorkerActivitySid", workerActivitySid);
            }
        }
    }
}