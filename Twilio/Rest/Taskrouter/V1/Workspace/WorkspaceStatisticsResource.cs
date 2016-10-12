using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkspaceStatisticsResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkspaceStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkspaceStatisticsFetcher Fetcher(string workspaceSid) {
            return new WorkspaceStatisticsFetcher(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkspaceStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkspaceStatisticsResource object represented by the provided JSON </returns> 
        public static WorkspaceStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkspaceStatisticsResource>(json);
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
    
        public WorkspaceStatisticsResource() {
        
        }
    
        private WorkspaceStatisticsResource([JsonProperty("realtime")]
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
    
        /// <returns> The realtime </returns> 
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /// <returns> The cumulative </returns> 
        public Object GetCumulative() {
            return this.cumulative;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}