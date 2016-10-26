using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkerReader : Reader<WorkerResource> 
    {
        public string workspaceSid { get; }
        public string activityName { get; set; }
        public string activitySid { get; set; }
        public string available { get; set; }
        public string friendlyName { get; set; }
        public string targetWorkersExpression { get; set; }
        public string taskQueueName { get; set; }
        public string taskQueueSid { get; set; }
    
        /// <summary>
        /// Construct a new WorkerReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="activityName"> The activity_name </param>
        /// <param name="activitySid"> The activity_sid </param>
        /// <param name="available"> The available </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="targetWorkersExpression"> The target_workers_expression </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        public WorkerReader(string workspaceSid, string activityName=null, string activitySid=null, string available=null, string friendlyName=null, string targetWorkersExpression=null, string taskQueueName=null, string taskQueueSid=null)
        {
            this.workspaceSid = workspaceSid;
            this.taskQueueSid = taskQueueSid;
            this.activitySid = activitySid;
            this.activityName = activityName;
            this.available = available;
            this.targetWorkersExpression = targetWorkersExpression;
            this.friendlyName = friendlyName;
            this.taskQueueName = taskQueueName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> WorkerResource ResourceSet </returns> 
        public override Task<ResourceSet<WorkerResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<WorkerResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> WorkerResource ResourceSet </returns> 
        public override ResourceSet<WorkerResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<WorkerResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<WorkerResource> NextPage(Page<WorkerResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of WorkerResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<WorkerResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkerResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<WorkerResource>.FromJson("workers", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (activityName != null)
            {
                request.AddQueryParam("ActivityName", activityName);
            }
            
            if (activitySid != null)
            {
                request.AddQueryParam("ActivitySid", activitySid);
            }
            
            if (available != null)
            {
                request.AddQueryParam("Available", available);
            }
            
            if (friendlyName != null)
            {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkersExpression != null)
            {
                request.AddQueryParam("TargetWorkersExpression", targetWorkersExpression);
            }
            
            if (taskQueueName != null)
            {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (taskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}