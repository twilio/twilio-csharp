using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Worker {

    public class WorkerStatisticsResource : Resource {
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
         * Converts a JSON string into a WorkerStatisticsResource object
         * 
         * @param json Raw JSON string
         * @return WorkerStatisticsResource object represented by the provided JSON
         */
        public static WorkerStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerStatisticsResource>(json);
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
    
        public WorkerStatisticsResource() {
        
        }
    
        private WorkerStatisticsResource([JsonProperty("account_sid")]
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