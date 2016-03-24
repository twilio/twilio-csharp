using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;
using Twilio.Updaters;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class TaskQueueUpdater : Updater<TaskQueueResource> {
        private string workspaceSid;
        private string sid;
        private string friendlyName;
        private string targetWorkers;
        private string reservationActivitySid;
        private string assignmentActivitySid;
        private int maxReservedWorkers;
    
        /**
         * Construct a new TaskQueueUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public TaskQueueUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TaskQueueUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The target_workers
         * 
         * @param targetWorkers The target_workers
         * @return this
         */
        public TaskQueueUpdater setTargetWorkers(string targetWorkers) {
            this.targetWorkers = targetWorkers;
            return this;
        }
    
        /**
         * The reservation_activity_sid
         * 
         * @param reservationActivitySid The reservation_activity_sid
         * @return this
         */
        public TaskQueueUpdater setReservationActivitySid(string reservationActivitySid) {
            this.reservationActivitySid = reservationActivitySid;
            return this;
        }
    
        /**
         * The assignment_activity_sid
         * 
         * @param assignmentActivitySid The assignment_activity_sid
         * @return this
         */
        public TaskQueueUpdater setAssignmentActivitySid(string assignmentActivitySid) {
            this.assignmentActivitySid = assignmentActivitySid;
            return this;
        }
    
        /**
         * The max_reserved_workers
         * 
         * @param maxReservedWorkers The max_reserved_workers
         * @return this
         */
        public TaskQueueUpdater setMaxReservedWorkers(int maxReservedWorkers) {
            this.maxReservedWorkers = maxReservedWorkers;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated TaskQueueResource
         */
        public override TaskQueueResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueueResource update failed: Unable to connect to server");
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
            
            return TaskQueueResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkers != null) {
                request.addPostParam("TargetWorkers", targetWorkers);
            }
            
            if (reservationActivitySid != null) {
                request.addPostParam("ReservationActivitySid", reservationActivitySid);
            }
            
            if (assignmentActivitySid != null) {
                request.addPostParam("AssignmentActivitySid", assignmentActivitySid);
            }
            
            if (maxReservedWorkers != null) {
                request.addPostParam("MaxReservedWorkers", maxReservedWorkers.ToString());
            }
        }
    }
}