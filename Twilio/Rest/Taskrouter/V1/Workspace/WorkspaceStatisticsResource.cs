using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class WorkspaceStatisticsResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> WorkspaceStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkspaceStatisticsFetcher Fetcher(string workspaceSid)
        {
            return new WorkspaceStatisticsFetcher(workspaceSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkspaceStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkspaceStatisticsResource object represented by the provided JSON </returns> 
        public static WorkspaceStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkspaceStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("realtime")]
        public Object Realtime { get; set; }
        [JsonProperty("cumulative")]
        public Object Cumulative { get; set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
    
        public WorkspaceStatisticsResource()
        {
        
        }
    
        private WorkspaceStatisticsResource([JsonProperty("realtime")]
                                            Object realtime, 
                                            [JsonProperty("cumulative")]
                                            Object cumulative, 
                                            [JsonProperty("account_sid")]
                                            string accountSid, 
                                            [JsonProperty("workspace_sid")]
                                            string workspaceSid)
                                            {
            Realtime = realtime;
            Cumulative = cumulative;
            AccountSid = accountSid;
            WorkspaceSid = workspaceSid;
        }
    }
}