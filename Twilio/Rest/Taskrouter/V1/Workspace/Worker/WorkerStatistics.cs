using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class WorkerStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @param workerSid The worker_sid
         * @return WorkerStatisticsFetcher capable of executing the fetch
         */
        public static WorkerStatisticsFetcher Fetch(string workspaceSid, string workerSid) {
            return new WorkerStatisticsFetcher(workspaceSid, workerSid);
        }
    
        /**
         * Converts a JSON string into a WorkerStatistics object
         * 
         * @param json Raw JSON string
         * @return WorkerStatistics object represented by the provided JSON
         */
        public static WorkerStatistics FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerStatistics>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("cumulative")]
        private readonly Object cumulative;
        [JsonProperty("worker_sid")]
        private readonly string workerSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public WorkerStatistics() {
        
        }
    
        private WorkerStatistics([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("cumulative")]
                                 Object cumulative, 
                                 [JsonProperty("worker_sid")]
                                 string workerSid, 
                                 [JsonProperty("workspace_sid")]
                                 string workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.workerSid = workerSid;
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
         * @return The worker_sid
         */
        public string GetWorkerSid() {
            return this.workerSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}