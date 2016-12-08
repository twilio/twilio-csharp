using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class WorkerStatisticsResource : Resource 
    {
        private static Request BuildFetchRequest(FetchWorkerStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkerStatisticsResource Fetch(FetchWorkerStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerStatisticsResource> FetchAsync(FetchWorkerStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkerStatisticsResource Fetch(string workspaceSid, string workerSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkerStatisticsOptions(workspaceSid, workerSid){Minutes = minutes, StartDate = startDate, EndDate = endDate};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkerStatisticsResource> FetchAsync(string workspaceSid, string workerSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkerStatisticsOptions(workspaceSid, workerSid){Minutes = minutes, StartDate = startDate, EndDate = endDate};
            return await FetchAsync(options, client);
        }
        #endif
    
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
        public string AccountSid { get; private set; }
        [JsonProperty("cumulative")]
        public object Cumulative { get; private set; }
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
    
        private WorkerStatisticsResource()
        {
        
        }
    }

}