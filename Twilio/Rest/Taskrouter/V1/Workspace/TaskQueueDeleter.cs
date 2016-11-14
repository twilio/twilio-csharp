using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Taskrouter.V1.Workspace;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class TaskQueueDeleter : Deleter<TaskQueueResource> 
    {
        public string WorkspaceSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new TaskQueueDeleter
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        public TaskQueueDeleter(string workspaceSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.WorkspaceSid + "/TaskQueues/" + this.Sid + ""
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override void Delete(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.WorkspaceSid + "/TaskQueues/" + this.Sid + ""
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}