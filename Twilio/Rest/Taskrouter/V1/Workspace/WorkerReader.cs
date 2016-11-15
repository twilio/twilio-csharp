using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkerReader : Reader<WorkerResource> 
    {
        public string WorkspaceSid { get; }
        public string ActivityName { get; set; }
        public string ActivitySid { get; set; }
        public string Available { get; set; }
        public string FriendlyName { get; set; }
        public string TargetWorkersExpression { get; set; }
        public string TaskQueueName { get; set; }
        public string TaskQueueSid { get; set; }
    
        /// <summary>
        /// Construct a new WorkerReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public WorkerReader(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> WorkerResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<WorkerResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + WorkspaceSid + "/Workers"
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
                "/v1/Workspaces/" + WorkspaceSid + "/Workers"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<WorkerResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
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
            if (ActivityName != null)
            {
                request.AddQueryParam("ActivityName", ActivityName);
            }
            
            if (ActivitySid != null)
            {
                request.AddQueryParam("ActivitySid", ActivitySid);
            }
            
            if (Available != null)
            {
                request.AddQueryParam("Available", Available);
            }
            
            if (FriendlyName != null)
            {
                request.AddQueryParam("FriendlyName", FriendlyName);
            }
            
            if (TargetWorkersExpression != null)
            {
                request.AddQueryParam("TargetWorkersExpression", TargetWorkersExpression);
            }
            
            if (TaskQueueName != null)
            {
                request.AddQueryParam("TaskQueueName", TaskQueueName);
            }
            
            if (TaskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", TaskQueueSid);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}