using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class WorkersStatisticsResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkersStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkersStatisticsFetcher Fetcher(string workspaceSid) {
            return new WorkersStatisticsFetcher(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkersStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkersStatisticsResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The cumulative </returns> 
        public Object GetCumulative() {
            return this.cumulative;
        }
    
        /// <returns> The realtime </returns> 
        public Object GetRealtime() {
            return this.realtime;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    }
}