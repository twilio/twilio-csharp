using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;
using Twilio.Resources;
using com.fasterxml.jackson.databind.JsonNode;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Worker {

    public class WorkerStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param workerSid The worker_sid
         * @return WorkerStatisticsFetcher capable of executing the fetch
         */
        public static WorkerStatisticsFetcher fetch(String workspaceSid, String workerSid) {
            return new WorkerStatisticsFetcher(workspaceSid, workerSid);
        }
    
        /**
         * Converts a JSON string into a WorkerStatistics object
         * 
         * @param json Raw JSON string
         * @return WorkerStatistics object represented by the provided JSON
         */
        public static WorkerStatistics fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerStatistics>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("cumulative")]
        private readonly JsonNode cumulative;
        [JsonProperty("worker_sid")]
        private readonly String workerSid;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private WorkerStatistics([JsonProperty("account_sid")]
                                 String accountSid, 
                                 [JsonProperty("cumulative")]
                                 JsonNode cumulative, 
                                 [JsonProperty("worker_sid")]
                                 String workerSid, 
                                 [JsonProperty("workspace_sid")]
                                 String workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.workerSid = workerSid;
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
         * @return The worker_sid
         */
        public String GetWorkerSid() {
            return this.workerSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}