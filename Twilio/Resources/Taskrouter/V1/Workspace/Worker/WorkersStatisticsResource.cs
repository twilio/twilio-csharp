using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Worker {

    public class WorkersStatisticsResource : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkersStatisticsFetcher capable of executing the fetch
         */
        public static WorkersStatisticsFetcher Fetch(string workspaceSid) {
            return new WorkersStatisticsFetcher(workspaceSid);
        }
    
        /**
         * Converts a JSON string into a WorkersStatisticsResource object
         * 
         * @param json Raw JSON string
         * @return WorkersStatisticsResource object represented by the provided JSON
         */
        public static WorkersStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkersStatisticsResource>(json);
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
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        public WorkersStatisticsResource() {
        
        }
    
        private WorkersStatisticsResource([JsonProperty("account_sid")]
                                          string accountSid, 
                                          [JsonProperty("cumulative")]
                                          Object cumulative, 
                                          [JsonProperty("realtime")]
                                          Object realtime, 
                                          [JsonProperty("workspace_sid")]
                                          string workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
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
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}