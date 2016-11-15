using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkspaceStatisticsFetcher : Fetcher<WorkspaceStatisticsResource> 
    {
        public string WorkspaceSid { get; }
        public int? Minutes { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    
        /// <summary>
        /// Construct a new WorkspaceStatisticsFetcher
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public WorkspaceStatisticsFetcher(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkspaceStatisticsResource </returns> 
        public override async System.Threading.Tasks.Task<WorkspaceStatisticsResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceStatisticsResource fetch failed: Unable to connect to server");
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
            
            return WorkspaceStatisticsResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched WorkspaceStatisticsResource </returns> 
        public override WorkspaceStatisticsResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Statistics"
            );
            
                AddQueryParams(request);
            
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkspaceStatisticsResource fetch failed: Unable to connect to server");
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
            
            return WorkspaceStatisticsResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (Minutes != null)
            {
                request.AddQueryParam("Minutes", Minutes.ToString());
            }
            
            if (StartDate != null)
            {
                request.AddQueryParam("StartDate", StartDate);
            }
            
            if (EndDate != null)
            {
                request.AddQueryParam("EndDate", EndDate);
            }
        }
    }
}