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
        /// <param name="minutes"> The minutes </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="endDate"> The end_date </param>
        /// <returns> WorkspaceStatisticsFetcher capable of executing the fetch </returns> 
        public static WorkspaceStatisticsFetcher Fetcher(string workspaceSid, int? minutes=null, string startDate=null, string endDate=null)
        {
            return new WorkspaceStatisticsFetcher(workspaceSid, minutes:minutes, startDate:startDate, endDate:endDate);
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
        public Object realtime { get; }
        [JsonProperty("cumulative")]
        public Object cumulative { get; }
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
    
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
            this.realtime = realtime;
            this.cumulative = cumulative;
            this.accountSid = accountSid;
            this.workspaceSid = workspaceSid;
        }
    }
}