using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkerReader : Reader<WorkerResource> {
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
        public WorkerReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// The activity_name
        /// </summary>
        ///
        /// <param name="activityName"> The activity_name </param>
        /// <returns> this </returns> 
        public WorkerReader ByActivityName(string activityName) {
            this.activityName = activityName;
            return this;
        }
    
        /// <summary>
        /// The activity_sid
        /// </summary>
        ///
        /// <param name="activitySid"> The activity_sid </param>
        /// <returns> this </returns> 
        public WorkerReader ByActivitySid(string activitySid) {
            this.activitySid = activitySid;
            return this;
        }
    
        /// <summary>
        /// The available
        /// </summary>
        ///
        /// <param name="available"> The available </param>
        /// <returns> this </returns> 
        public WorkerReader ByAvailable(string available) {
            this.available = available;
            return this;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public WorkerReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The target_workers_expression
        /// </summary>
        ///
        /// <param name="targetWorkersExpression"> The target_workers_expression </param>
        /// <returns> this </returns> 
        public WorkerReader ByTargetWorkersExpression(string targetWorkersExpression) {
            this.targetWorkersExpression = targetWorkersExpression;
            return this;
        }
    
        /// <summary>
        /// The task_queue_name
        /// </summary>
        ///
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <returns> this </returns> 
        public WorkerReader ByTaskQueueName(string taskQueueName) {
            this.taskQueueName = taskQueueName;
            return this;
        }
    
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        ///
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <returns> this </returns> 
        public WorkerReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> WorkerResource ResourceSet </returns> 
        public override Task<ResourceSet<WorkerResource>> ReadAsync(ITwilioRestClient client) {
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
        public override ResourceSet<WorkerResource> Read(ITwilioRestClient client) {
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
        public override Page<WorkerResource> NextPage(Page<WorkerResource> page, ITwilioRestClient client) {
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
        protected Page<WorkerResource> PageForRequest(ITwilioRestClient client, Request request) {
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
        private void AddQueryParams(Request request) {
            if (activityName != null) {
                request.AddQueryParam("ActivityName", activityName);
            }
            
            if (activitySid != null) {
                request.AddQueryParam("ActivitySid", activitySid);
            }
            
            if (available != null) {
                request.AddQueryParam("Available", available);
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (targetWorkersExpression != null) {
                request.AddQueryParam("TargetWorkersExpression", targetWorkersExpression);
            }
            
            if (taskQueueName != null) {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (taskQueueSid != null) {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}