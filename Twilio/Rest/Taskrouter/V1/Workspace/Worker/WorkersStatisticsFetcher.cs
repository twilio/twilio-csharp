using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkersStatisticsFetcher : Fetcher<WorkersStatisticsResource> 
    {
        public string workspaceSid { get; }
        public int? minutes { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string taskQueueSid { get; set; }
        public string taskQueueName { get; set; }
        public string friendlyName { get; set; }
    
        /// <summary>
        /// Construct a new WorkersStatisticsFetcher
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="friendlyName"> The friendly_name </param>
        public WorkersStatisticsFetcher(string workspaceSid, int? minutes=null, DateTime? startDate=null, DateTime? endDate=null, string taskQueueSid=null, string taskQueueName=null, string friendlyName=null)
        {
            this.workspaceSid = workspaceSid;
            this.taskQueueSid = taskQueueSid;
            this.endDate = endDate;
            this.minutes = minutes;
            this.friendlyName = friendlyName;
            this.startDate = startDate;
            this.taskQueueName = taskQueueName;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkersStatisticsResource </returns> 
        public override async Task<WorkersStatisticsResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkersStatisticsResource fetch failed: Unable to connect to server");
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
            
            return WorkersStatisticsResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkersStatisticsResource </returns> 
        public override WorkersStatisticsResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkersStatisticsResource fetch failed: Unable to connect to server");
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
            
            return WorkersStatisticsResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (minutes != null)
            {
                request.AddQueryParam("Minutes", minutes.ToString());
            }
            
            if (startDate != null)
            {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null)
            {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            if (taskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (taskQueueName != null)
            {
                request.AddQueryParam("TaskQueueName", taskQueueName);
            }
            
            if (friendlyName != null)
            {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
        }
    }
}