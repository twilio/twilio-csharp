using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.workspace.TaskQueue;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Taskrouter.V1.Workspace {

    public class TaskQueueUpdater : Updater<TaskQueue> {
        private String workspaceSid;
        private String sid;
        private String friendlyName;
        private String targetWorkers;
        private String reservationActivitySid;
        private String assignmentActivitySid;
        private Integer maxReservedWorkers;
    
        /**
         * Construct a new TaskQueueUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public TaskQueueUpdater(String workspaceSid, String sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public TaskQueueUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The target_workers
         * 
         * @param targetWorkers The target_workers
         * @return this
         */
        public TaskQueueUpdater setTargetWorkers(String targetWorkers) {
            this.targetWorkers = targetWorkers;
            return this;
        }
    
        /**
         * The reservation_activity_sid
         * 
         * @param reservationActivitySid The reservation_activity_sid
         * @return this
         */
        public TaskQueueUpdater setReservationActivitySid(String reservationActivitySid) {
            this.reservationActivitySid = reservationActivitySid;
            return this;
        }
    
        /**
         * The assignment_activity_sid
         * 
         * @param assignmentActivitySid The assignment_activity_sid
         * @return this
         */
        public TaskQueueUpdater setAssignmentActivitySid(String assignmentActivitySid) {
            this.assignmentActivitySid = assignmentActivitySid;
            return this;
        }
    
        /**
         * The max_reserved_workers
         * 
         * @param maxReservedWorkers The max_reserved_workers
         * @return this
         */
        public TaskQueueUpdater setMaxReservedWorkers(Integer maxReservedWorkers) {
            this.maxReservedWorkers = maxReservedWorkers;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated TaskQueue
         */
        [Override]
        public TaskQueue execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.sid + "",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TaskQueue update failed: Unable to connect to server");
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
            
            return TaskQueue.fromJson(response.getStream(), client.getObjectMapper());
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
                request.addPostParam("MaxReservedWorkers", maxReservedWorkers.toString());
            }
        }
    }
}