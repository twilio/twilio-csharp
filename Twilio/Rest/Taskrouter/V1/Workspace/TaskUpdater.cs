using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskUpdater : Updater<TaskResource> 
    {
        public string workspaceSid { get; }
        public string sid { get; }
        public string attributes { get; set; }
        public TaskResource.Status assignmentStatus { get; set; }
        public string reason { get; set; }
        public int? priority { get; set; }
        public string taskChannel { get; set; }
    
        /// <summary>
        /// Construct a new TaskUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="assignmentStatus"> The assignment_status </param>
        /// <param name="reason"> The reason </param>
        /// <param name="priority"> The priority </param>
        /// <param name="taskChannel"> The task_channel </param>
        public TaskUpdater(string workspaceSid, string sid, string attributes=null, TaskResource.Status assignmentStatus=null, string reason=null, int? priority=null, string taskChannel=null)
        {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
            this.assignmentStatus = assignmentStatus;
            this.reason = reason;
            this.taskChannel = taskChannel;
            this.priority = priority;
            this.attributes = attributes;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskResource </returns> 
        public override async Task<TaskResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
            
            return TaskResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated TaskResource </returns> 
        public override TaskResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource update failed: Unable to connect to server");
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
            
            return TaskResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (attributes != null)
            {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (assignmentStatus != null)
            {
                request.AddPostParam("AssignmentStatus", assignmentStatus.ToString());
            }
            
            if (reason != null)
            {
                request.AddPostParam("Reason", reason);
            }
            
            if (priority != null)
            {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (taskChannel != null)
            {
                request.AddPostParam("TaskChannel", taskChannel);
            }
        }
    }
}