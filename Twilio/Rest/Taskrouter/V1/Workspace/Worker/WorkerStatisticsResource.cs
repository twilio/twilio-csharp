using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class WorkerStatisticsResource : Resource {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <returns> WorkerStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkerStatisticsFetcher Fetcher(string workspaceSid, string workerSid, int? minutes=null, DateTime? startDate=null, DateTime? endDate=null) {
            return new WorkerStatisticsFetcher(workspaceSid, workerSid, minutes:minutes, startDate:startDate, endDate:endDate);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerStatisticsResource object represented by the provided JSON </returns> 
        public static WorkerStatisticsResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerStatisticsResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("cumulative")]
        public Object cumulative { get; }
        [JsonProperty("worker_sid")]
        public string workerSid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
    
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
    }
}