using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskQueueCreator : Creator<TaskQueueResource> {
        private string workspaceSid;
        private string friendlyName;
        private string reservationActivitySid;
        private string assignmentActivitySid;
        private string targetWorkers;
        private int? maxReservedWorkers;
    
        /**
         * Construct a new TaskQueueCreator
         * 
         * @param workspaceSid The workspace_sid
         * @param friendlyName The friendly_name
         * @param reservationActivitySid The reservation_activity_sid
         * @param assignmentActivitySid The assignment_activity_sid
         */
        public TaskQueueCreator(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid) {
            this.workspaceSid = workspaceSid;
            this.friendlyName = friendlyName;
            this.reservationActivitySid = reservationActivitySid;
            this.assignmentActivitySid = assignmentActivitySid;
        }
    
        /**
         * The target_workers
         * 
         * @param targetWorkers The target_workers
         * @return this
         */
        public TaskQueueCreator setTargetWorkers(string targetWorkers) {
            this.targetWorkers = targetWorkers;
            return this;
        }
    
        /**
         * The max_reserved_workers
         * 
         * @param maxReservedWorkers The max_reserved_workers
         * @return this
         */
        public TaskQueueCreator setMaxReservedWorkers(int? maxReservedWorkers) {
            this.maxReservedWorkers = maxReservedWorkers;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created TaskQueueResource
         */
        public override async Task<TaskQueueResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return TaskQueueResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created TaskQueueResource
         */
        public override TaskQueueResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return TaskQueueResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (reservationActivitySid != null) {
                request.AddPostParam("ReservationActivitySid", reservationActivitySid);
            }
            
            if (assignmentActivitySid != null) {
                request.AddPostParam("AssignmentActivitySid", assignmentActivitySid);
            }
            
            if (targetWorkers != null) {
                request.AddPostParam("TargetWorkers", targetWorkers);
            }
            
            if (maxReservedWorkers != null) {
                request.AddPostParam("MaxReservedWorkers", maxReservedWorkers.ToString());
            }
        }
    }
}