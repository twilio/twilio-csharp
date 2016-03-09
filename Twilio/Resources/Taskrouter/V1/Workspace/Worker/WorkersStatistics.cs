using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Worker {

    public class WorkersStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkersStatisticsFetcher capable of executing the fetch
         */
        public static WorkersStatisticsFetcher fetch(string workspaceSid) {
            return new WorkersStatisticsFetcher(workspaceSid);
        }
    
        /**
         * Converts a JSON string into a WorkersStatistics object
         * 
         * @param json Raw JSON string
         * @return WorkersStatistics object represented by the provided JSON
         */
        public static WorkersStatistics fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkersStatistics>(json);
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
    
        private WorkersStatistics([JsonProperty("account_sid")]
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