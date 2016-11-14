using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow 
{

    public class WorkflowStatisticsResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> WorkflowStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkflowStatisticsFetcher Fetcher(string workspaceSid, string workflowSid)
        {
            return new WorkflowStatisticsFetcher(workspaceSid, workflowSid);
        }
    
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
        public string AccountSid { get; set; }
        [JsonProperty("cumulative")]
        public Object Cumulative { get; set; }
        [JsonProperty("realtime")]
        public Object Realtime { get; set; }
        [JsonProperty("workflow_sid")]
        public string WorkflowSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
    
        public WorkflowStatisticsResource()
        {
        
        }
    
        private WorkflowStatisticsResource([JsonProperty("account_sid")]
                                           string accountSid, 
                                           [JsonProperty("cumulative")]
                                           Object cumulative, 
                                           [JsonProperty("realtime")]
                                           Object realtime, 
                                           [JsonProperty("workflow_sid")]
                                           string workflowSid, 
                                           [JsonProperty("workspace_sid")]
                                           string workspaceSid)
                                           {
            AccountSid = accountSid;
            Cumulative = cumulative;
            Realtime = realtime;
            WorkflowSid = workflowSid;
            WorkspaceSid = workspaceSid;
        }
    }
}