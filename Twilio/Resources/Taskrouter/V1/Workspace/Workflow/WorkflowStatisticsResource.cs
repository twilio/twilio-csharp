using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Workflow;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Workflow {

    public class WorkflowStatisticsResource : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param workflowSid The workflow_sid
         * @return WorkflowStatisticsFetcher capable of executing the fetch
         */
        public static WorkflowStatisticsFetcher Fetch(string workspaceSid, string workflowSid) {
            return new WorkflowStatisticsFetcher(workspaceSid, workflowSid);
        }
    
        /**
         * Converts a JSON string into a WorkflowStatisticsResource object
         * 
         * @param json Raw JSON string
         * @return WorkflowStatisticsResource object represented by the provided JSON
         */
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The cumulative
         */
        public Object GetCumulative() {
            return this.cumulative;
        }
    
        /**
         * @return The realtime
         */
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /**
         * @return The workflow_sid
         */
        public string GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}