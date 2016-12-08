using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow 
{

    public class WorkflowStatisticsResource : Resource 
    {
        private static Request BuildFetchRequest(FetchWorkflowStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workflows/" + options.WorkflowSid + "/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkflowStatisticsResource Fetch(FetchWorkflowStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowStatisticsResource> FetchAsync(FetchWorkflowStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkflowStatisticsResource Fetch(string workspaceSid, string workflowSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowStatisticsOptions(workspaceSid, workflowSid){Minutes = minutes, StartDate = startDate, EndDate = endDate};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkflowStatisticsResource> FetchAsync(string workspaceSid, string workflowSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkflowStatisticsOptions(workspaceSid, workflowSid){Minutes = minutes, StartDate = startDate, EndDate = endDate};
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkflowStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowStatisticsResource object represented by the provided JSON </returns> 
        public static WorkflowStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkflowStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("cumulative")]
        public object Cumulative { get; private set; }
        [JsonProperty("realtime")]
        public object Realtime { get; private set; }
        [JsonProperty("workflow_sid")]
        public string WorkflowSid { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
    
        private WorkflowStatisticsResource()
        {
        
        }
    }

}