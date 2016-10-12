using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class TaskCreator : Creator<TaskResource> {
        private string workspaceSid;
        private string attributes;
        private string workflowSid;
        private int? timeout;
        private int? priority;
        private string taskChannel;
    
        /// <summary>
        /// Construct a new TaskCreator
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        public TaskCreator(string workspaceSid, string attributes, string workflowSid) {
            this.workspaceSid = workspaceSid;
            this.attributes = attributes;
            this.workflowSid = workflowSid;
        }
    
        /// <summary>
        /// The timeout
        /// </summary>
        ///
        /// <param name="timeout"> The timeout </param>
        /// <returns> this </returns> 
        public TaskCreator setTimeout(int? timeout) {
            this.timeout = timeout;
            return this;
        }
    
        /// <summary>
        /// The priority
        /// </summary>
        ///
        /// <param name="priority"> The priority </param>
        /// <returns> this </returns> 
        public TaskCreator setPriority(int? priority) {
            this.priority = priority;
            return this;
        }
    
        /// <summary>
        /// The task_channel
        /// </summary>
        ///
        /// <param name="taskChannel"> The task_channel </param>
        /// <returns> this </returns> 
        public TaskCreator setTaskChannel(string taskChannel) {
            this.taskChannel = taskChannel;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskResource </returns> 
        public override async Task<TaskResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource creation failed: Unable to connect to server");
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
            
            return TaskResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created TaskResource </returns> 
        public override TaskResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskResource creation failed: Unable to connect to server");
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
            
            return TaskResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void addPostParams(Request request) {
            if (attributes != null) {
                request.AddPostParam("Attributes", attributes);
            }
            
            if (workflowSid != null) {
                request.AddPostParam("WorkflowSid", workflowSid);
            }
            
            if (timeout != null) {
                request.AddPostParam("Timeout", timeout.ToString());
            }
            
            if (priority != null) {
                request.AddPostParam("Priority", priority.ToString());
            }
            
            if (taskChannel != null) {
                request.AddPostParam("TaskChannel", taskChannel);
            }
        }
    }
}