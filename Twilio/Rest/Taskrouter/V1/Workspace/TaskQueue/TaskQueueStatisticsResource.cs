using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    public class TaskQueueStatisticsResource : Resource 
    {
        private static Request BuildFetchRequest(FetchTaskQueueStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/" + options.TaskQueueSid + "/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskQueueStatisticsResource Fetch(FetchTaskQueueStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueStatisticsResource> FetchAsync(FetchTaskQueueStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static TaskQueueStatisticsResource Fetch(string workspaceSid, string taskQueueSid, DateTime? endDate = null, int? minutes = null, DateTime? startDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueStatisticsOptions(workspaceSid, taskQueueSid){EndDate = endDate, Minutes = minutes, StartDate = startDate};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<TaskQueueStatisticsResource> FetchAsync(string workspaceSid, string taskQueueSid, DateTime? endDate = null, int? minutes = null, DateTime? startDate = null, ITwilioRestClient client = null)
        {
            var options = new FetchTaskQueueStatisticsOptions(workspaceSid, taskQueueSid){EndDate = endDate, Minutes = minutes, StartDate = startDate};
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TaskQueueStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueueStatisticsResource object represented by the provided JSON </returns> 
        public static TaskQueueStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskQueueStatisticsResource>(json);
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
        [JsonProperty("realtime")]
        public object Realtime { get; private set; }
        [JsonProperty("task_queue_sid")]
        public string TaskQueueSid { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
    
        private TaskQueueStatisticsResource()
        {
        
        }
    }

}