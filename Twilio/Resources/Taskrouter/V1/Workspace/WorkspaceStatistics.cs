using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers.Taskrouter.V1.Workspace;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Taskrouter.V1.Workspace {

    public class WorkspaceStatistics : Resource {
        /**
         * fetch
         * 
         * @param workspaceSid The workspace_sid
         * @return WorkspaceStatisticsFetcher capable of executing the fetch
         */
        public static WorkspaceStatisticsFetcher fetch(string workspaceSid) {
            return new WorkspaceStatisticsFetcher(workspaceSid);
        }
    
        /**
         * Converts a JSON string into a WorkspaceStatistics object
         * 
         * @param json Raw JSON string
         * @return WorkspaceStatistics object represented by the provided JSON
         */
        public static WorkspaceStatistics fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkspaceStatistics>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("realtime")]
        private readonly Object realtime;
        [JsonProperty("cumulative")]
        private readonly Object cumulative;
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
    
        private WorkspaceStatistics([JsonProperty("realtime")]
                                    Object realtime, 
                                    [JsonProperty("cumulative")]
                                    Object cumulative, 
                                    [JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("workspace_sid")]
                                    string workspaceSid) {
            this.realtime = realtime;
            this.cumulative = cumulative;
            this.accountSid = accountSid;
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * @return The realtime
         */
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /**
         * @return The cumulative
         */
        public Object GetCumulative() {
            return this.cumulative;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The workspace_sid
         */
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}