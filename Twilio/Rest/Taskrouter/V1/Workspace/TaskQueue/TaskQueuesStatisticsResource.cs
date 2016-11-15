using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Taskrouter.V1.Workspace.TaskQueue 
{

    public class TaskQueuesStatisticsResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <returns> TaskQueuesStatisticsReader capable of executing the read </returns> 
        public static TaskQueuesStatisticsReader Reader(string workspaceSid)
        {
            return new TaskQueuesStatisticsReader(workspaceSid);
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
        public string AccountSid { get; set; }
        [JsonProperty("cumulative")]
        public Dictionary<string, string> Cumulative { get; set; }
        [JsonProperty("realtime")]
        public Object Realtime { get; set; }
        [JsonProperty("task_queue_sid")]
        public string TaskQueueSid { get; set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; set; }
    
        public TaskQueuesStatisticsResource()
        {
        
        }
    
        private TaskQueuesStatisticsResource([JsonProperty("account_sid")]
                                             string accountSid, 
                                             [JsonProperty("cumulative")]
                                             Dictionary<string, string> cumulative, 
                                             [JsonProperty("realtime")]
                                             Object realtime, 
                                             [JsonProperty("task_queue_sid")]
                                             string taskQueueSid, 
                                             [JsonProperty("workspace_sid")]
                                             string workspaceSid)
                                             {
            AccountSid = accountSid;
            Cumulative = cumulative;
            Realtime = realtime;
            TaskQueueSid = taskQueueSid;
            WorkspaceSid = workspaceSid;
        }
    }
}