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
        public string AccountSid { get; set; }
        [JsonProperty("cumulative")]
        public Object Cumulative { get; set; }
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
    
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
            AccountSid = accountSid;
            Cumulative = cumulative;
            WorkerSid = workerSid;
            WorkspaceSid = workspaceSid;
        }
    }
}