using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    public class TaskQueueStatisticsFetcher : Fetcher<TaskQueueStatisticsResource> 
    {
        public string WorkspaceSid { get; }
        public string TaskQueueSid { get; }
        public DateTime? EndDate { get; set; }
        public string FriendlyName { get; set; }
        public int? Minutes { get; set; }
        public DateTime? StartDate { get; set; }
    
        /// <summary>
        /// Construct a new TaskQueueStatisticsFetcher
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        public TaskQueueStatisticsFetcher(string workspaceSid, string taskQueueSid)
        {
            WorkspaceSid = workspaceSid;
            TaskQueueSid = taskQueueSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched TaskQueueStatisticsResource </returns> 
        public override async System.Threading.Tasks.Task<TaskQueueStatisticsResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues/" + TaskQueueSid + "/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueStatisticsResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskQueueStatisticsResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched TaskQueueStatisticsResource </returns> 
        public override TaskQueueStatisticsResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/TaskQueues/" + TaskQueueSid + "/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TaskQueueStatisticsResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return TaskQueueStatisticsResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (EndDate != null)
            {
                request.AddQueryParam("EndDate", EndDate.ToString());
            }
            
            if (FriendlyName != null)
            {
                request.AddQueryParam("FriendlyName", FriendlyName);
            }
            
            if (Minutes != null)
            {
                request.AddQueryParam("Minutes", Minutes.ToString());
            }
            
            if (StartDate != null)
            {
                request.AddQueryParam("StartDate", StartDate.ToString());
            }
        }
    }
}