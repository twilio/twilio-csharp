using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskQueueUpdater : Updater<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string TargetWorkers { get; set; }
        public string ReservationActivitySid { get; set; }
        public string AssignmentActivitySid { get; set; }
        public int? MaxReservedWorkers { get; set; }
    
        /// <summary>
        /// Construct a new TaskQueueUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public TaskQueueUpdater(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskQueueResource </returns> 
        public override async System.Threading.Tasks.Task<TaskQueueResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues/" + Sid + ""
            );
            AddPostParams(request);
            
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
        public override TaskQueueResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues/" + Sid + ""
            );
            AddPostParams(request);
            
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
        private void AddPostParams(Request request)
        {
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
            
            if (TargetWorkers != null)
            {
                request.AddPostParam("TargetWorkers", TargetWorkers);
            }
            
            if (ReservationActivitySid != null)
            {
                request.AddPostParam("ReservationActivitySid", ReservationActivitySid);
            }
            
            if (AssignmentActivitySid != null)
            {
                request.AddPostParam("AssignmentActivitySid", AssignmentActivitySid);
            }
            
            if (MaxReservedWorkers != null)
            {
                request.AddPostParam("MaxReservedWorkers", MaxReservedWorkers.ToString());
            }
        }
    }
}