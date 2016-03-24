using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace.Task;
using Twilio.Updaters;

namespace Twilio.Updaters.Taskrouter.V1.Workspace.Task {

    public class ReservationUpdater : Updater<ReservationResource> {
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
         * @return Updated ReservationResource
         */
        public override ReservationResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ReservationResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            return ReservationResource.fromJson(response.GetContent());
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