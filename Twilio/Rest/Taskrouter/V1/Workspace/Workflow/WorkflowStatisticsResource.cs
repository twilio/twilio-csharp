using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Workflow {

    public class WorkflowStatisticsResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> WorkflowStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkflowStatisticsFetcher Fetcher(string workspaceSid, string workflowSid) {
            return new WorkflowStatisticsFetcher(workspaceSid, workflowSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkflowStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkflowStatisticsResource object represented by the provided JSON </returns> 
        public static WorkflowStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkflowStatisticsResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("cumulative")]
        private readonly Object cumulative;
        [JsonProperty("realtime")]
        private readonly Object realtime;
        [JsonProperty("workflow_sid")]
        private readonly string workflowSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public WorkflowStatisticsResource() {
        
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
                                           string workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
            this.workflowSid = workflowSid;
            this.workspaceSid = workspaceSid;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The cumulative </returns> 
        public Object GetCumulative() {
            return this.cumulative;
        }
    
        /// <returns> The realtime </returns> 
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /// <returns> The workflow_sid </returns> 
        public string GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}