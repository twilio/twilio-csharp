using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace.Worker;
using Twilio.Http;
using Twilio.Resources;
using com.fasterxml.jackson.databind.JsonNode;

namespace Twilio.Resources.Taskrouter.V1.Workspace.Worker {

    public class WorkersStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkersStatisticsFetcher capable of executing the fetch
         */
        public static WorkersStatisticsFetcher fetch(String workspaceSid) {
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
        private readonly String accountSid;
        [JsonProperty("cumulative")]
        private readonly JsonNode cumulative;
        [JsonProperty("realtime")]
        private readonly JsonNode realtime;
        [JsonProperty("workspace_sid")]
        private readonly String workspaceSid;
    
        private WorkersStatistics([JsonProperty("account_sid")]
                                  String accountSid, 
                                  [JsonProperty("cumulative")]
                                  JsonNode cumulative, 
                                  [JsonProperty("realtime")]
                                  JsonNode realtime, 
                                  [JsonProperty("workspace_sid")]
                                  String workspaceSid) {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.realtime = realtime;
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
         * @return The workspace_sid
         */
        public String GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}