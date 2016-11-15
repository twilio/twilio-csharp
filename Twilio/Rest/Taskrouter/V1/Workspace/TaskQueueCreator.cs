using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskQueueCreator : Creator<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string FriendlyName { get; }
        public string ReservationActivitySid { get; }
        public string AssignmentActivitySid { get; }
        public string TargetWorkers { get; set; }
        public int? MaxReservedWorkers { get; set; }
    
        /// <summary>
        /// Construct a new TaskQueueCreator
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="reservationActivitySid"> The reservation_activity_sid </param>
        /// <param name="assignmentActivitySid"> The assignment_activity_sid </param>
        public TaskQueueCreator(string workspaceSid, string friendlyName, string reservationActivitySid, string assignmentActivitySid)
        {
            WorkspaceSid = workspaceSid;
            FriendlyName = friendlyName;
            ReservationActivitySid = reservationActivitySid;
            AssignmentActivitySid = assignmentActivitySid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskQueueResource </returns> 
        public override async System.Threading.Tasks.Task<TaskQueueResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskQueueResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskQueueResource </returns> 
        public override TaskQueueResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
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
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (ReservationActivitySid != null)
            {
                request.AddPostParam("ReservationActivitySid", ReservationActivitySid);
            }
            
            if (AssignmentActivitySid != null)
            {
                request.AddPostParam("AssignmentActivitySid", AssignmentActivitySid);
            }
            
            if (TargetWorkers != null)
            {
                request.AddPostParam("TargetWorkers", TargetWorkers);
            }
            
            if (MaxReservedWorkers != null)
            {
                request.AddPostParam("MaxReservedWorkers", MaxReservedWorkers.ToString());
            }
        }
    }
}