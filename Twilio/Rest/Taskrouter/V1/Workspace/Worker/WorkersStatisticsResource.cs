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
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkersStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkersStatisticsFetcher Fetcher(string workspaceSid, int? minutes=null, DateTime? startDate=null, DateTime? endDate=null, string taskQueueSid=null, string taskQueueName=null, string friendlyName=null) {
            return new WorkersStatisticsFetcher(workspaceSid, minutes:minutes, startDate:startDate, endDate:endDate, taskQueueSid:taskQueueSid, taskQueueName:taskQueueName, friendlyName:friendlyName);
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
        public string accountSid { get; }
        [JsonProperty("cumulative")]
        public Object cumulative { get; }
        [JsonProperty("realtime")]
        public Object realtime { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
    
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
    }
}