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

    public class WorkersStatisticsResource : Resource 
    {
        private static Request BuildFetchRequest(FetchWorkersStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkersStatisticsResource Fetch(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(FetchWorkersStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static WorkersStatisticsResource Fetch(string workspaceSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, string taskQueueSid = null, string taskQueueName = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(workspaceSid){Minutes = minutes, StartDate = startDate, EndDate = endDate, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, FriendlyName = friendlyName};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<WorkersStatisticsResource> FetchAsync(string workspaceSid, int? minutes = null, DateTime? startDate = null, DateTime? endDate = null, string taskQueueSid = null, string taskQueueName = null, string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new FetchWorkersStatisticsOptions(workspaceSid){Minutes = minutes, StartDate = startDate, EndDate = endDate, TaskQueueSid = taskQueueSid, TaskQueueName = taskQueueName, FriendlyName = friendlyName};
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WorkersStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkersStatisticsResource object represented by the provided JSON </returns> 
        public static WorkersStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkersStatisticsResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("cumulative")]
        public Object Cumulative { get; private set; }
        [JsonProperty("realtime")]
        public Object Realtime { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
    
        private WorkersStatisticsResource()
        {
        
        }
    }

}