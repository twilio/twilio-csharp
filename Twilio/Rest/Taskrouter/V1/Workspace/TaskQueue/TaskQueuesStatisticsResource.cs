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

    public class TaskQueuesStatisticsResource : Resource 
    {
        private static Request BuildReadRequest(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/TaskQueues/Statistics",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskQueuesStatisticsResource> Read(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
            return new ResourceSet<TaskQueuesStatisticsResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueuesStatisticsResource>> ReadAsync(ReadTaskQueuesStatisticsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
            return new ResourceSet<TaskQueuesStatisticsResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<TaskQueuesStatisticsResource> Read(string workspaceSid, DateTime? endDate = null, string friendlyName = null, int? minutes = null, DateTime? startDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueuesStatisticsOptions(workspaceSid){EndDate = endDate, FriendlyName = friendlyName, Minutes = minutes, StartDate = startDate, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<TaskQueuesStatisticsResource>> ReadAsync(string workspaceSid, DateTime? endDate = null, string friendlyName = null, int? minutes = null, DateTime? startDate = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadTaskQueuesStatisticsOptions(workspaceSid){EndDate = endDate, FriendlyName = friendlyName, Minutes = minutes, StartDate = startDate, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<TaskQueuesStatisticsResource> NextPage(Page<TaskQueuesStatisticsResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<TaskQueuesStatisticsResource>.FromJson("task_queues_statistics", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a TaskQueuesStatisticsResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskQueuesStatisticsResource object represented by the provided JSON </returns> 
        public static TaskQueuesStatisticsResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskQueuesStatisticsResource>(json);
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
    
        private TaskQueuesStatisticsResource()
        {
        
        }
    }

}