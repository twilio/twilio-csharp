using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Workflow;
using Twilio.Http;
using Twilio.Resources;
using com.fasterxml.jackson.databind.JsonNode;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Workflow {

    public class WorkflowStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param workflowSid The workflow_sid
         * @return WorkflowStatisticsFetcher capable of executing the fetch
         */
        public static WorkflowStatisticsFetcher fetch(String workspaceSid, String workflowSid) {
            return new WorkflowStatisticsFetcher(workspaceSid, workflowSid);
        }
    
        /**
         * Converts a JSON string into a WorkflowStatistics object
         * 
         * @param json Raw JSON string
         * @return WorkflowStatistics object represented by the provided JSON
         */
        public static WorkflowStatistics fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkflowStatistics>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("cumulative")]
        private readonly JsonNode cumulative;
        [JsonProperty("realtime")]
        private readonly JsonNode realtime;
        [JsonProperty("workflow_sid")]
        private readonly String workflowSid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private WorkflowStatistics([JsonProperty("account_sid")]
                                   String accountSid, 
                                   [JsonProperty("cumulative")]
                                   JsonNode cumulative, 
                                   [JsonProperty("realtime")]
                                   JsonNode realtime, 
                                   [JsonProperty("workflow_sid")]
                                   String workflowSid, 
                                   [JsonProperty("workspace_sid")]
                                   String workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
            this.workflowSid = workflowSid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The cumulative
         */
        public JsonNode GetCumulative() {
            return this.cumulative;
        }
    
        /**
         * @return The realtime
         */
        public JsonNode GetRealtime() {
            return this.realtime;
        }
    
        /**
         * @return The workflow_sid
         */
        public String GetWorkflowSid() {
            return this.workflowSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}