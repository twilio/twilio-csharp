using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskQueueUpdater : Updater<TaskQueueResource> {
        private string workspaceSid;
        private string sid;
        private string friendlyName;
        private string targetWorkers;
        private string reservationActivitySid;
        private string assignmentActivitySid;
        private int? maxReservedWorkers;
    
        /// <summary>
        /// Construct a new TaskQueueUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public TaskQueueUpdater(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public TaskQueueUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The target_workers
        /// </summary>
        ///
        /// <param name="targetWorkers"> The target_workers </param>
        /// <returns> this </returns> 
        public TaskQueueUpdater setTargetWorkers(string targetWorkers) {
            this.targetWorkers = targetWorkers;
            return this;
        }
    
        /// <summary>
        /// The reservation_activity_sid
        /// </summary>
        ///
        /// <param name="reservationActivitySid"> The reservation_activity_sid </param>
        /// <returns> this </returns> 
        public TaskQueueUpdater setReservationActivitySid(string reservationActivitySid) {
            this.reservationActivitySid = reservationActivitySid;
            return this;
        }
    
        /// <summary>
        /// The assignment_activity_sid
        /// </summary>
        ///
        /// <param name="assignmentActivitySid"> The assignment_activity_sid </param>
        /// <returns> this </returns> 
        public TaskQueueUpdater setAssignmentActivitySid(string assignmentActivitySid) {
            this.assignmentActivitySid = assignmentActivitySid;
            return this;
        }
    
        /// <summary>
        /// The max_reserved_workers
        /// </summary>
        ///
        /// <param name="maxReservedWorkers"> The max_reserved_workers </param>
        /// <returns> this </returns> 
        public TaskQueueUpdater setMaxReservedWorkers(int? maxReservedWorkers) {
            this.maxReservedWorkers = maxReservedWorkers;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskQueueResource </returns> 
        public override async Task<TaskQueueResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskQueueResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskQueueResource </returns> 
        public override TaskQueueResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/TaskQueues/" + this.sid + ""
            );
            addPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskQueueResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkers != null) {
                request.AddPostParam("TargetWorkers", targetWorkers);
            }
            
            if (reservationActivitySid != null) {
                request.AddPostParam("ReservationActivitySid", reservationActivitySid);
            }
            
            if (assignmentActivitySid != null) {
                request.AddPostParam("AssignmentActivitySid", assignmentActivitySid);
            }
            
            if (maxReservedWorkers != null) {
                request.AddPostParam("MaxReservedWorkers", maxReservedWorkers.ToString());
            }
        }
    }
}