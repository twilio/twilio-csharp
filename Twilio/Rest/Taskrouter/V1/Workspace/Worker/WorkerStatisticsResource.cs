using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkerStatisticsResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <returns> WorkerStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkerStatisticsFetcher Fetcher(string workspaceSid, string workerSid)
        {
            return new WorkerStatisticsFetcher(workspaceSid, workerSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerStatisticsResource object represented by the provided JSON </returns> 
        public static WorkerStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkerStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("cumulative")]
        public Object cumulative { get; set; }
        [JsonProperty("worker_sid")]
        public string workerSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; set; }
    
        public WorkerStatisticsResource()
        {
        
        }
    
        private WorkerStatisticsResource([JsonProperty("account_sid")]
                                         string accountSid, 
                                         [JsonProperty("cumulative")]
                                         Object cumulative, 
                                         [JsonProperty("worker_sid")]
                                         string workerSid, 
                                         [JsonProperty("workspace_sid")]
                                         string workspaceSid)
                                         {
            this.accountSid = accountSid;
            this.cumulative = cumulative;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
        }
    }
}